using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Ejecutivo> Ejecutivos => Set<Ejecutivo>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<Visita> Visitas => Set<Visita>();
    }
}
