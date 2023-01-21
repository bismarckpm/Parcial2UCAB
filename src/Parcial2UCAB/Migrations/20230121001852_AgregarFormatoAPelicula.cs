using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2UCAB.Migrations
{
    public partial class AgregarFormatoAPelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "formato",
                table: "Peliculas",
                type: "integer",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "formato",
                table: "Peliculas");
        }
    }
}
