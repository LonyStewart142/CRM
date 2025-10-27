
using CRM.Domain.Entities;

namespace CRM.Application.DTOs
{
    public class VentaDTO
    {
        public decimal Monto { get; set; }
        public int IdCliente { get; set; }
        public string Producto { get; set; } = null!;
    }
}
