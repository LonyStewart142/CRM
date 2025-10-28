using CRM.Domain.Entities;
using CRM.Domain.ViewModels;


namespace CRM.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<ProductividadEjecutivo>> GetProductividadPorEjecutivoAsync();
    }
}
