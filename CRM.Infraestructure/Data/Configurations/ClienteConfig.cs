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


            builder.HasData(
                new Cliente { Id = 1, Nombre = "Juan", Apellido = "Pérez", Direccion = "Calle 1", Telefono = "8095550001" },
                new Cliente { Id = 2, Nombre = "María", Apellido = "López", Direccion = "Calle 2", Telefono = "8095550002" },
                new Cliente { Id = 3, Nombre = "Carlos", Apellido = "Gómez", Direccion = "Calle 3", Telefono = "8095550003" },
                new Cliente { Id = 4, Nombre = "Ana", Apellido = "Torres", Direccion = "Calle 4", Telefono = "8095550004" },
                new Cliente { Id = 5, Nombre = "Luis", Apellido = "Ramírez", Direccion = "Calle 5", Telefono = "8095550005" },
                new Cliente { Id = 6, Nombre = "Laura", Apellido = "Martínez", Direccion = "Calle 6", Telefono = "8095550006" },
                new Cliente { Id = 7, Nombre = "Pedro", Apellido = "Fernández", Direccion = "Calle 7", Telefono = "8095550007" },
                new Cliente { Id = 8, Nombre = "Sofía", Apellido = "Jiménez", Direccion = "Calle 8", Telefono = "8095550008" },
                new Cliente { Id = 9, Nombre = "Javier", Apellido = "Mendoza", Direccion = "Calle 9", Telefono = "8095550009" },
                new Cliente { Id = 10, Nombre = "Camila", Apellido = "Reyes", Direccion = "Calle 10", Telefono = "8095550010" },
                new Cliente { Id = 11, Nombre = "Andrés", Apellido = "Morales", Direccion = "Calle 11", Telefono = "8095550011" },
                new Cliente { Id = 12, Nombre = "Paola", Apellido = "Castro", Direccion = "Calle 12", Telefono = "8095550012" },
                new Cliente { Id = 13, Nombre = "Fernando", Apellido = "Silva", Direccion = "Calle 13", Telefono = "8095550013" },
                new Cliente { Id = 14, Nombre = "Gabriela", Apellido = "Rojas", Direccion = "Calle 14", Telefono = "8095550014" },
                new Cliente { Id = 15, Nombre = "Ricardo", Apellido = "Herrera", Direccion = "Calle 15", Telefono = "8095550015" },
                new Cliente { Id = 16, Nombre = "Daniela", Apellido = "Cruz", Direccion = "Calle 16", Telefono = "8095550016" },
                new Cliente { Id = 17, Nombre = "Oscar", Apellido = "Vargas", Direccion = "Calle 17", Telefono = "8095550017" },
                new Cliente { Id = 18, Nombre = "Elena", Apellido = "Navarro", Direccion = "Calle 18", Telefono = "8095550018" },
                new Cliente { Id = 19, Nombre = "Martín", Apellido = "Santos", Direccion = "Calle 19", Telefono = "8095550019" },
                new Cliente { Id = 20, Nombre = "Lucía", Apellido = "Peña", Direccion = "Calle 20", Telefono = "8095550020" }
            );
        }
    }
}
