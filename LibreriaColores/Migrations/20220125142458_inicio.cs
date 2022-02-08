using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibreriaColores.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    Teléfono = table.Column<string>(nullable: false),
                    Dirección = table.Column<string>(nullable: false),
                    LocalidadId = table.Column<int>(nullable: false),
                    Localidad = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDeVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Producto = table.Column<string>(nullable: false),
                    PrecioVenta = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: true),
                    DNICliente = table.Column<int>(nullable: false),
                    MontoPago = table.Column<decimal>(nullable: false),
                    MontoCambio = table.Column<decimal>(nullable: false),
                    MontoTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: false),
                    DNICliente = table.Column<int>(nullable: false),
                    TipoDocumento = table.Column<string>(nullable: true),
                    MontoPago = table.Column<decimal>(nullable: false),
                    MontoCambio = table.Column<decimal>(nullable: false),
                    MontoTotal = table.Column<decimal>(nullable: false),
                    FechaRegistro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "DetalleDeVentas");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
