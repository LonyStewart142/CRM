using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CRM.Infraestructure.Data.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Apellido)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Telefono)
                   .IsRequired()
                   .HasMaxLength(12);

            builder.Property(p => p.Direccion)
            .HasMaxLength(250);

            builder.HasMany(c => c.Visitas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Ventas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
