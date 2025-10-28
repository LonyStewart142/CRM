using CRM.Domain.Entities;
using CRM.Domain.Interfaces;
using CRM.Domain.ViewModels;
using CRM.Infraestructure.Data;
using CRM.Infraestructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductividadEjecutivo>> GetProductividadPorEjecutivoAsync()
        {
            string query = SqlScripts.FileConsultaRadicacionesScript;

            var resultados = await _context
              .Database
              .SqlQueryRaw<ProductividadEjecutivo>(query)
              .ToListAsync();
            return resultados;
        }
    }
}
