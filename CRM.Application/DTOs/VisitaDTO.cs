
using CRM.Domain.Entities;

namespace CRM.Application.DTOs
{
    public class VisitaDTO
    {
        public int IdEjecutivo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Resultado { get; set; } = null!;
    }
}
