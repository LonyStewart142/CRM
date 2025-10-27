using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Ejecutivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public List<Visita> Visitas { get; set; } = [];

    }
}
