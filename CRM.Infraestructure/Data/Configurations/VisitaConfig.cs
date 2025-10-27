using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Data.Configurations
{
    public class VisitaConfig : IEntityTypeConfiguration<Visita>
    {
        public void Configure(EntityTypeBuilder<Visita> builder)
        {
            builder.Property(a => a.FechaVisita).HasColumnType("date");
            builder.Property(a => a.Resultado).HasMaxLength(100);
        }
    }
}
