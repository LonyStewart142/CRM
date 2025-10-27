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
            //string script = SqlScripts.FileConsultaRadicacionesScript;

            var query = @"SELECT 
                            e.Id IdEjecutivo,
                            e.Nombre + ' ' + e.Apellido AS Ejecutivo,
                            COUNT(DISTINCT v.Id) AS TotalVisitas,
                            COUNT(DISTINCT c.Id) AS ClientesAtendidos,
                            COUNT(DISTINCT ve.Id) AS TotalVentas,
                            ISNULL(SUM(ve.Monto), 0) AS MontoTotalVentas
                        FROM Ejecutivos e
                        LEFT JOIN Visitas v ON e.Id = v.IdEjecutivo
                        LEFT JOIN Clientes c ON v.IdCliente = c.Id
                        LEFT JOIN Ventas ve ON c.Id = ve.IdCliente
                        GROUP BY e.Id, e.Nombre, e.Apellido
                        ORDER BY MontoTotalVentas DESC";

            var resultados = await _context
              .Database
              .SqlQueryRaw<ProductividadEjecutivo>(query)
              .ToListAsync();
            return resultados;
        }
    }
}
