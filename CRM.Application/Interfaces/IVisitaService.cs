using CRM.Application.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IVisitaService
    {
        Task<IEnumerable<Visita>> GetAllAsync();
        Task<Visita?> GetByIdAsync(int id);
        Task<CreatedDTO> CreateAsync(VisitaDTO dto);
    }
}
