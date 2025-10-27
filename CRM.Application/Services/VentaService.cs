using AutoMapper;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;

namespace CRM.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;
        private readonly IMapper _mapper;
        public VentaService(IVentaRepository repository, IMapper mapper)
        {
            _repository = repository;
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
    }
}
