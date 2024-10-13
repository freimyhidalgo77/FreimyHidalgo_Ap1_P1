using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FreimyHidalgo_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {  
        /// <inheritdoc />  
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CobroDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    valorCobrado = table.Column<double>(type: "REAL", nullable: false),
                    CobrosCobroId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalles", x => x.DetalleId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    PrestamosPrestamoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "PrestamosPrestamoId", "nombre" },
                values: new object[,]
                {
                    { 1, null, "Juan Perez" },
                    { 2, null, "Cristal Hernandez" },
                    { 3, null, "Maria Sanchez" },
                    { 4, null, "Hancock Smith" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalles_CobrosCobroId",
                table: "CobroDetalles",
                column: "CobrosCobroId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalles_PrestamoId",
                table: "CobroDetalles",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_DeudorId",
                table: "Cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudores_PrestamosPrestamoId",
                table: "Deudores",
                column: "PrestamosPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CobroDetalles_Cobros_CobrosCobroId",
                table: "CobroDetalles",
                column: "CobrosCobroId",
                principalTable: "Cobros",
                principalColumn: "CobroId");

            migrationBuilder.AddForeignKey(
                name: "FK_CobroDetalles_Prestamos_PrestamoId",
                table: "CobroDetalles",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Deudores_DeudorId",
                table: "Cobros",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deudores_Prestamos_PrestamosPrestamoId",
                table: "Deudores",
                column: "PrestamosPrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deudores_Prestamos_PrestamosPrestamoId",
                table: "Deudores");

            migrationBuilder.DropTable(
                name: "CobroDetalles");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
