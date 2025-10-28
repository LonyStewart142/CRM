using CRM.Domain.ViewModels;
namespace CRM.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ProductividadEjecutivo>> GetProductividadPorEjecutivoAsync();
    }
}
