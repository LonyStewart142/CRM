using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Visita
    {
        public int Id { get; set; }
        public int IdEjecutivo { get; set; }
        public Ejecutivo Ejecutivo { get; set; } = null!;
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public DateTime FechaVisita { get; set; }
        public string Resultado { get; set; } = null!;
    }
}
