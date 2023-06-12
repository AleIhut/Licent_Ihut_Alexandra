using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class PachetulMeuClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "PachetulMeu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_MembruID",
                table: "PachetulMeu",
                column: "MembruID");

            migrationBuilder.AddForeignKey(
                name: "FK_PachetulMeu_Membru_MembruID",
                table: "PachetulMeu",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PachetulMeu_Membru_MembruID",
                table: "PachetulMeu");

            migrationBuilder.DropIndex(
                name: "IX_PachetulMeu_MembruID",
                table: "PachetulMeu");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "PachetulMeu");
        }
    }
}
