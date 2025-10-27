using AutoMapper;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;

namespace CRM.Application.Services
{
    public class VisitaService : IVisitaService
    {
        private readonly IVisitaRepository _repository;
        private readonly IMapper _mapper;
        public VisitaService(IVisitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Visita>> GetAllAsync()
        {
            var visitas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Visita>>(visitas);
        }

        public async Task<Visita?> GetByIdAsync(int id)
        {
            var visita = await _repository.GetByIdAsync(id);
            return _mapper.Map<Visita>(visita);
        }
        public async Task<CreatedDTO> CreateAsync(VisitaDTO dto)
        {
            var visita = _mapper.Map<Visita>(dto);
            //venta.FechaVenta = DateTime.Now;
            await _repository.AddAsync(visita);
            return _mapper.Map<CreatedDTO>(visita);
        }
        public async Task UpdateAsync(VisitaDTO dto)
        {
             var visita = _mapper.Map<Visita>(dto);
            await _repository.UpdateAsync(visita);
        }
    }
}
