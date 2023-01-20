using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2UCAB.Migrations
{
    public partial class PeliculaFormato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Formato",
                table: "Peliculas",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Formato",
                table: "Peliculas");
        }
    }
}
