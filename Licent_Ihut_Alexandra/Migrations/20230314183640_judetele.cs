using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class judetele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JudetID",
                table: "Localitate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localitate_JudetID",
                table: "Localitate",
                column: "JudetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Localitate_Judet_JudetID",
                table: "Localitate",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localitate_Judet_JudetID",
                table: "Localitate");

            migrationBuilder.DropIndex(
                name: "IX_Localitate_JudetID",
                table: "Localitate");

            migrationBuilder.DropColumn(
                name: "JudetID",
                table: "Localitate");
        }
    }
}
