using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2UCAB.Migrations
{
    public partial class TipoPersonaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoPersonaje",
                table: "PeliculasActor",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPersonaje",
                table: "PeliculasActor");
        }
    }
}
