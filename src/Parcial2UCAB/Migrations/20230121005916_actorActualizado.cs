using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2UCAB.Migrations
{
    public partial class actorActualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Actores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Actores");
        }
    }
}
