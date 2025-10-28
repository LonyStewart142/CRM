using AutoMapper;
using ClosedXML.Excel;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Application.Models;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Formats.Asn1;
using System.Globalization;

namespace CRM.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public VentaService(IVentaRepository repository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            var ventas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Venta>>(ventas);
        }

        public async Task<Venta?> GetByIdAsync(int id)
        {
            var venta = await _repository.GetByIdAsync(id);
            return _mapper.Map<Venta>(venta);
        }
        public async Task<CreatedDTO> CreateAsync(VentaDTO dto)
        {
            var venta = _mapper.Map<Venta>(dto);
            venta.FechaVenta = DateTime.Now;
            await _repository.AddAsync(venta);
            return _mapper.Map<CreatedDTO>(venta);
        }
        public async Task UpdateAsync(VentaDTO dto)
        {
             var venta = _mapper.Map<Venta>(dto);
            await _repository.UpdateAsync(venta);
        }

        public async Task<Result<List<string>>> ProcesarArchivoAsync(IFormFile file)
        {
            var result = new Result<List<string>> { Ok = false, Data = new List<string>() };

            if (!ValidarArchivo(file, out string error))
            {
                result.Message = error;
                return result;
            }

            List<VentaDTO> ventas;
            try
            {
                ventas = LeerArchivo(file);
            }
            catch (Exception ex)
            {
                result.Message = $"Error al leer el archivo: {ex.Message}";
                return result;
            }

            if (!ventas.Any())
            {
                result.Message = "No se encontraron registros válidos en el archivo.";
                return result;
            }

            // Validar duplicados dentro del archivo
            DetectarDuplicadosInternos(ventas, result);

            if (result.Data.Any())
            {
                result.Message = "Se encontraron registros duplicados dentro del archivo.";
                return result;
            }

            // Validar referencias (ej. clientes que no existen)
            await ValidarReferenciasAsync(ventas, result);

            if (result.Data.Any())
            {
                result.Message = "Se encontraron registros con referencias inexistentes en la base de datos.";
                return result;
            }

            await ProcesarVentasAsync(ventas, result);

            return result;
        }

        // ---------------- Métodos Auxiliares ----------------

        private bool ValidarArchivo(IFormFile file, out string error)
        {
            error = string.Empty;

            if (file == null || file.Length == 0)
            {
                error = "Archivo inválido o vacío.";
                return false;
            }

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != ".csv" && extension != ".xlsx")
            {
                error = "Formato no soportado. Use CSV o Excel (.xlsx).";
                return false;
            }

            return true;
        }

        private List<VentaDTO> LeerArchivo(IFormFile file)
        {
            var ventas = new List<VentaDTO>();
            var extension = Path.GetExtension(file.FileName).ToLower();

            using var stream = file.OpenReadStream();

            if (extension == ".csv")
            {
                using var reader = new StreamReader(stream);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                ventas = csv.GetRecords<VentaDTO>().ToList();
            }
            else if (extension == ".xlsx")
            {
                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheet(1);
                var rows = worksheet.RowsUsed().Skip(1);

                foreach (var row in rows)
                {
                    if (int.TryParse(row.Cell(1).GetString(), out int idCliente) &&
                        DateTime.TryParse(row.Cell(2).GetString(), out DateTime fechaVenta) &&
                        decimal.TryParse(row.Cell(3).GetString(), out decimal monto))
                    {
                        ventas.Add(new VentaDTO
                        {
                            IdCliente = idCliente,
                            FechaVenta = fechaVenta,
                            Monto = monto,
                            Producto = row.Cell(4).GetString()
                        });
                    }
                }
            }

            return ventas;
        }

        private async Task ProcesarVentasAsync(List<VentaDTO> ventas, Result<List<string>> result)
        {
            foreach (var venta in ventas)
            {
                bool existe = await _repository.ExistsAsync(e =>
                    e.IdCliente == venta.IdCliente &&
                    e.FechaVenta == venta.FechaVenta &&
                    e.Producto == venta.Producto);

                if (existe)
                {
                    result.Data.Add($"Registro duplicado: ClienteId={venta.IdCliente}, FechaVenta={venta.FechaVenta:yyyy-MM-dd}, Producto={venta.Producto}");
                }
            }

            if (result.Data.Any())
            {
                result.Message = "Se encontraron ventas que ya están registradas.";
            }
            else
            {
                await _repository.AddRangeAsync(_mapper.Map<IEnumerable<Venta>>(ventas));
                result.Ok = true;
                result.Message = "Todos los registros fueron procesados correctamente.";
            }
        }
        private void DetectarDuplicadosInternos(List<VentaDTO> ventas, Result<List<string>> result)
        {
            // Agrupar por combinación única de IdCliente + FechaVenta + Producto
            var duplicados = ventas
                .GroupBy(v => new { v.IdCliente, v.FechaVenta, v.Producto })
                .Where(g => g.Count() > 1);

            foreach (var grupo in duplicados)
            {
                result.Data.Add($"Duplicado interno en archivo: ClienteId={grupo.Key.IdCliente}, FechaVenta={grupo.Key.FechaVenta:yyyy-MM-dd}, Producto={grupo.Key.Producto}");
            }
        }

        private async Task ValidarReferenciasAsync(List<VentaDTO> ventas, Result<List<string>> result)
        {
            // Obtener todos los IDs de cliente únicos del archivo
            var idsClientes = ventas.Select(v => v.IdCliente).Distinct().ToList();

            // Consultar los existentes en DB (suponiendo repositorio genérico o DbContext)
            var clientesExistentes =( await _clienteRepository.GetAllAsync()).ToList()
                .Where(c => idsClientes.Contains(c.Id))
                .Select(c => c.Id);

            // Detectar IDs que no existen
            var idsInvalidos = idsClientes.Except(clientesExistentes).ToList();

            if (idsInvalidos.Count != 0)
            {
                foreach (var id in idsInvalidos)
                    result.Data.Add($"El ClienteId={id} es invalido, no esta registrado en nuestra base de datos.");
            }
        }


    }
}
