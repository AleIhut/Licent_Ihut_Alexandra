using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class judeteincercare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID1",
                table: "SalaEveniment");

            migrationBuilder.DropIndex(
                name: "IX_SalaEveniment_JudetID1",
                table: "SalaEveniment");

            migrationBuilder.DropColumn(
                name: "JudetID1",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "SalaEveniment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaEveniment_JudetID",
                table: "SalaEveniment",
                column: "JudetID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment");

            migrationBuilder.DropIndex(
                name: "IX_SalaEveniment_JudetID",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<string>(
                name: "JudetID",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JudetID1",
                table: "SalaEveniment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaEveniment_JudetID1",
                table: "SalaEveniment",
                column: "JudetID1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID1",
                table: "SalaEveniment",
                column: "JudetID1",
                principalTable: "Judet",
                principalColumn: "ID");
        }
    }
}
