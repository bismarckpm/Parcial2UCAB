using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2UCAB.Migrations
{
    public partial class LineasPersonaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LineasPersonaje",
                table: "PeliculasActor",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineasPersonaje",
                table: "PeliculasActor");
        }
    }
}
