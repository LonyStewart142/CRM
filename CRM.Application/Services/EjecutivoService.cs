using AutoMapper;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;

namespace CRM.Application.Services
{
    public class EjecutivoService : IEjecutivoService
    {
        private readonly IEjecutivoRepository _repository;
        private readonly IMapper _mapper;
        public EjecutivoService(IEjecutivoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Ejecutivo>> GetAllAsync()
        {
            var ejecutivos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Ejecutivo>>(ejecutivos);
        }

        public async Task<Ejecutivo?> GetByIdAsync(int id)
        {
            var ejecutivo = await _repository.GetByIdAsync(id);
            return _mapper.Map<Ejecutivo>(ejecutivo);
        }
        public async Task<CreatedDTO> CreateAsync(EjecutivoDTO dto)
        {
            var ejecutvo = _mapper.Map<Ejecutivo>(dto);
            await _repository.AddAsync(ejecutvo);
            return _mapper.Map<CreatedDTO>(ejecutvo);
        }
        public async Task UpdateAsync(EjecutivoDTO dto)
        {
             var ejecutivo = _mapper.Map<Ejecutivo>(dto);
            await _repository.UpdateAsync(ejecutivo);
        }
    }
}
