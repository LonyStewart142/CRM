using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.DTOs
{
    public class ClienteDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
