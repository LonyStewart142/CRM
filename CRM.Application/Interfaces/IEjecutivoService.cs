using CRM.Application.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IEjecutivoService
    {
        Task<IEnumerable<Ejecutivo>> GetAllAsync();
        Task<Ejecutivo?> GetByIdAsync(int id);
        Task<CreatedDTO> CreateAsync(EjecutivoDTO dto);
        Task UpdateAsync(EjecutivoDTO dto);
    }
}
