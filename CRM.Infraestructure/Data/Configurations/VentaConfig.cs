using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infraestructure.Data.Configurations
{
    public class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.Property(a => a.FechaVenta).HasColumnType("date");
            builder.Property(a => a.Monto).HasPrecision(18, 2);
        }
    }
}
