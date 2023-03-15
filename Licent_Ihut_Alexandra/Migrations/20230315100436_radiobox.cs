using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class radiobox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Figurine",
                table: "Prajitura");

            migrationBuilder.AddColumn<string>(
                name: "Figurina",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Figurina",
                table: "Prajitura");

            migrationBuilder.AddColumn<string>(
                name: "Figurine",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
