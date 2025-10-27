using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CRM.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        public VentaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
