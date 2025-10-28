using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CRM.Infraestructure.Data.Configurations
{
    public class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            var hoy = DateTime.Today;

            builder.Property(a => a.FechaVenta).HasColumnType("date");
            builder.Property(a => a.Monto).HasPrecision(18, 2);

            builder.HasData(
                new Venta { Id = 1, FechaVenta = hoy.AddDays(-10), Monto = 25000m, IdCliente = 1, Producto = "Tarjeta de Crédito" },
                new Venta { Id = 2, FechaVenta = hoy.AddDays(-8), Monto = 120000m, IdCliente = 2, Producto = "Préstamo Personal" },
                new Venta { Id = 3, FechaVenta = hoy.AddDays(-6), Monto = 1500m, IdCliente = 3, Producto = "Tarjeta de Débito" },

                new Venta { Id = 4, FechaVenta = hoy.AddDays(-12), Monto = 3500000m, IdCliente = 4, Producto = "Préstamo Hipotecario" },
                new Venta { Id = 5, FechaVenta = hoy.AddDays(-7), Monto = 20000m, IdCliente = 5, Producto = "Tarjeta de Crédito" },

                new Venta { Id = 6, FechaVenta = hoy.AddDays(-14), Monto = 750000m, IdCliente = 6, Producto = "Préstamo Vehicular" },
                new Venta { Id = 7, FechaVenta = hoy.AddDays(-11), Monto = 95000m, IdCliente = 7, Producto = "Préstamo Personal" },
                new Venta { Id = 8, FechaVenta = hoy.AddDays(-9), Monto = 500m, IdCliente = 8, Producto = "Cuenta de Ahorro" },
                new Venta { Id = 9, FechaVenta = hoy.AddDays(-5), Monto = 1200m, IdCliente = 9, Producto = "Tarjeta de Débito" },

                new Venta { Id = 10, FechaVenta = hoy.AddDays(-13), Monto = 1800000m, IdCliente = 10, Producto = "Préstamo Comercial" },
                new Venta { Id = 11, FechaVenta = hoy.AddDays(-10), Monto = 30000m, IdCliente = 11, Producto = "Tarjeta de Crédito" },
                new Venta { Id = 12, FechaVenta = hoy.AddDays(-8), Monto = 15000m, IdCliente = 12, Producto = "Seguro de Vida" }
            );
        }
    }
}
