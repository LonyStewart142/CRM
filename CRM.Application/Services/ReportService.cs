using AutoMapper;
using CRM.Application.DTOs;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CRM.Domain.ViewModels;

namespace CRM.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<ProductividadEjecutivo>> GetProductividadPorEjecutivoAsync()
        {
            return _repository.GetProductividadPorEjecutivoAsync();
        }
    }
}
