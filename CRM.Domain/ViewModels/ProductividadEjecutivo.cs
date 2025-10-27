using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.ViewModels
{
    public class ProductividadEjecutivo
    {
        public int IdEjecutivo { get; set; }
        public string Ejecutivo { get; set; } = null!;
        public int TotalVisitas { get; set; }
        public int ClientesAtendidos { get; set; }
        public int TotalVentas { get; set; }
        public decimal MontoTotalVentas { get; set; }
    }
}
