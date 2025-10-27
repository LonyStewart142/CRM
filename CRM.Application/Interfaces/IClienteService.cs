using CRM.Application.DTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync();
        Task<ClienteDTO?> GetByIdAsync(int id);
        Task<CreatedDTO> CreateAsync(ClienteDTO dto);
        Task UpdateAsync(ClienteDTO dto);
    }
}
