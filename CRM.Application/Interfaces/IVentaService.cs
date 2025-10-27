using CRM.Application.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IVentaService
    {
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task<CreatedDTO> CreateAsync(VentaDTO dto);
    }
}
