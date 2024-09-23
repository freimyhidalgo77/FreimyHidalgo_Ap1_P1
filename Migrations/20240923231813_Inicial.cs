using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreimyHidalgo_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regitro",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regitro", x => x.name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regitro");
        }
    }
}
