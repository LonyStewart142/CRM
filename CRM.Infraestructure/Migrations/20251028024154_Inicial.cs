using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejecutivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejecutivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVenta = table.Column<DateTime>(type: "date", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEjecutivo = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaVisita = table.Column<DateTime>(type: "date", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitas_Ejecutivos_IdEjecutivo",
                        column: x => x.IdEjecutivo,
                        principalTable: "Ejecutivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Calle 1", "Juan", "8095550001" },
                    { 2, "López", "Calle 2", "María", "8095550002" },
                    { 3, "Gómez", "Calle 3", "Carlos", "8095550003" },
                    { 4, "Torres", "Calle 4", "Ana", "8095550004" },
                    { 5, "Ramírez", "Calle 5", "Luis", "8095550005" },
                    { 6, "Martínez", "Calle 6", "Laura", "8095550006" },
                    { 7, "Fernández", "Calle 7", "Pedro", "8095550007" },
                    { 8, "Jiménez", "Calle 8", "Sofía", "8095550008" },
                    { 9, "Mendoza", "Calle 9", "Javier", "8095550009" },
                    { 10, "Reyes", "Calle 10", "Camila", "8095550010" },
                    { 11, "Morales", "Calle 11", "Andrés", "8095550011" },
                    { 12, "Castro", "Calle 12", "Paola", "8095550012" },
                    { 13, "Silva", "Calle 13", "Fernando", "8095550013" },
                    { 14, "Rojas", "Calle 14", "Gabriela", "8095550014" },
                    { 15, "Herrera", "Calle 15", "Ricardo", "8095550015" },
                    { 16, "Cruz", "Calle 16", "Daniela", "8095550016" },
                    { 17, "Vargas", "Calle 17", "Oscar", "8095550017" },
                    { 18, "Navarro", "Calle 18", "Elena", "8095550018" },
                    { 19, "Santos", "Calle 19", "Martín", "8095550019" },
                    { 20, "Peña", "Calle 20", "Lucía", "8095550020" }
                });

            migrationBuilder.InsertData(
                table: "Ejecutivos",
                columns: new[] { "Id", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Rodríguez", "Carlos" },
                    { 2, "García", "Marta" },
                    { 3, "Hernández", "José" },
                    { 4, "Vega", "Laura" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "FechaVenta", "IdCliente", "Monto", "Producto" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), 1, 25000m, "Tarjeta de Crédito" },
                    { 2, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 2, 120000m, "Préstamo Personal" },
                    { 3, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 3, 1500m, "Tarjeta de Débito" },
                    { 4, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 4, 3500000m, "Préstamo Hipotecario" },
                    { 5, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), 5, 20000m, "Tarjeta de Crédito" },
                    { 6, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), 6, 750000m, "Préstamo Vehicular" },
                    { 7, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), 7, 95000m, "Préstamo Personal" },
                    { 8, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), 8, 500m, "Cuenta de Ahorro" },
                    { 9, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, 1200m, "Tarjeta de Débito" },
                    { 10, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 10, 1800000m, "Préstamo Comercial" },
                    { 11, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), 11, 30000m, "Tarjeta de Crédito" },
                    { 12, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 12, 15000m, "Seguro de Vida" }
                });

            migrationBuilder.InsertData(
                table: "Visitas",
                columns: new[] { "Id", "FechaVisita", "IdCliente", "IdEjecutivo", "Resultado" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), 1, 1, "Interesado en tarjeta de crédito" },
                    { 2, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 2, 1, "Solicitó préstamo personal" },
                    { 3, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), 3, 1, "Interesado en tarjeta de débito" },
                    { 4, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), 4, 2, "Cotización de préstamo hipotecario" },
                    { 5, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), 5, 2, "Interesado en tarjeta de crédito" },
                    { 6, new DateTime(2025, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), 6, 3, "Compra de vehículo" },
                    { 7, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), 7, 3, "Solicitó préstamo personal" },
                    { 8, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), 8, 3, "Interesado en cuenta de ahorro" },
                    { 9, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 9, 3, "Aprobado para tarjeta de débito" },
                    { 10, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 10, 4, "Interesado en préstamo comercial" },
                    { 11, new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Local), 11, 4, "Solicitó tarjeta de crédito" },
                    { 12, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 12, 4, "Cotización de seguro de vida" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_IdCliente",
                table: "Visitas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_IdEjecutivo",
                table: "Visitas",
                column: "IdEjecutivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Ejecutivos");
        }
    }
}
