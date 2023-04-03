using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class MembruSala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "SalaEveniment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaEveniment_MembruID",
                table: "SalaEveniment",
                column: "MembruID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Membru_MembruID",
                table: "SalaEveniment",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Membru_MembruID",
                table: "SalaEveniment");

            migrationBuilder.DropIndex(
                name: "IX_SalaEveniment_MembruID",
                table: "SalaEveniment");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "SalaEveniment");
        }
    }
}
