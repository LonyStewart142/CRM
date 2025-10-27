using AutoMapper;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;

namespace CRM.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO?> GetByIdAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }
        public async Task<CreatedDTO> CreateAsync(ClienteDTO dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            await _repository.AddAsync(cliente);
            return _mapper.Map<CreatedDTO>(cliente);
        }
        public async Task UpdateAsync(ClienteDTO dto)
        {
             var cliente = _mapper.Map<Cliente>(dto);
            await _repository.UpdateAsync(cliente);
        }
    }
}
