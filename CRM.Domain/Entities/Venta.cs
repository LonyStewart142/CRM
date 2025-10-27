using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Monto { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public string Producto { get; set; } = null!;

    }
}
