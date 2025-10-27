using CRM.Application.DTOs;
using CRM.Application.Models;
using CRM.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CRM.Application.Interfaces
{
    public interface IVentaService
    {
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task<CreatedDTO> CreateAsync(VentaDTO dto);
        Task<Result<List<string>>> ProcesarArchivoAsync(IFormFile file);
    }
}
