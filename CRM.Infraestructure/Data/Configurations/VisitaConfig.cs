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
    public class VisitaConfig : IEntityTypeConfiguration<Visita>
    {
        public void Configure(EntityTypeBuilder<Visita> builder)
        {
            var hoy = DateTime.Today;
            builder.Property(a => a.FechaVisita).HasColumnType("date");
            builder.Property(a => a.Resultado).HasMaxLength(100);

            builder.HasData(
                 new Visita { Id = 1, IdEjecutivo = 1, IdCliente = 1, FechaVisita = hoy.AddDays(-10), Resultado = "Interesado en tarjeta de crédito" },
                 new Visita { Id = 2, IdEjecutivo = 1, IdCliente = 2, FechaVisita = hoy.AddDays(-8), Resultado = "Solicitó préstamo personal" },
                 new Visita { Id = 3, IdEjecutivo = 1, IdCliente = 3, FechaVisita = hoy.AddDays(-6), Resultado = "Interesado en tarjeta de débito" },

                 new Visita { Id = 4, IdEjecutivo = 2, IdCliente = 4, FechaVisita = hoy.AddDays(-12), Resultado = "Cotización de préstamo hipotecario" },
                 new Visita { Id = 5, IdEjecutivo = 2, IdCliente = 5, FechaVisita = hoy.AddDays(-7), Resultado = "Interesado en tarjeta de crédito" },

                 new Visita { Id = 6, IdEjecutivo = 3, IdCliente = 6, FechaVisita = hoy.AddDays(-14), Resultado = "Compra de vehículo" },
                 new Visita { Id = 7, IdEjecutivo = 3, IdCliente = 7, FechaVisita = hoy.AddDays(-11), Resultado = "Solicitó préstamo personal" },
                 new Visita { Id = 8, IdEjecutivo = 3, IdCliente = 8, FechaVisita = hoy.AddDays(-9), Resultado = "Interesado en cuenta de ahorro" },
                 new Visita { Id = 9, IdEjecutivo = 3, IdCliente = 9, FechaVisita = hoy.AddDays(-5), Resultado = "Aprobado para tarjeta de débito" },

                 new Visita { Id = 10, IdEjecutivo = 4, IdCliente = 10, FechaVisita = hoy.AddDays(-13), Resultado = "Interesado en préstamo comercial" },
                 new Visita { Id = 11, IdEjecutivo = 4, IdCliente = 11, FechaVisita = hoy.AddDays(-10), Resultado = "Solicitó tarjeta de crédito" },
                 new Visita { Id = 12, IdEjecutivo = 4, IdCliente = 12, FechaVisita = hoy.AddDays(-8), Resultado = "Cotización de seguro de vida" }
             );
        }
    }
}
