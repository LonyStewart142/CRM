using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public List<Venta> Ventas { get; set; } = [];
        public List<Visita> Visitas { get; set; } = [];
    }
}
