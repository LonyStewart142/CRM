using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Data.Configurations
{
    public class EjecutivoConfig : IEntityTypeConfiguration<Ejecutivo>
    {
        public void Configure(EntityTypeBuilder<Ejecutivo> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Apellido)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasMany(e => e.Visitas)
                  .WithOne(v => v.Ejecutivo)
                  .HasForeignKey(v => v.IdEjecutivo)
                  .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
              new Ejecutivo { Id = 1, Nombre = "Carlos", Apellido = "Rodríguez" },
              new Ejecutivo { Id = 2, Nombre = "Marta", Apellido = "García" },
              new Ejecutivo { Id = 3, Nombre = "José", Apellido = "Hernández" },
              new Ejecutivo { Id = 4, Nombre = "Laura", Apellido = "Vega" }
          );

        }
    }
}
