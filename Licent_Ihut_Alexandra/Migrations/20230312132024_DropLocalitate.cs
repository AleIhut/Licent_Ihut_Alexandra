using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class DropLocalitate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localitate",
                table: "SalaEveniment");

            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "SalaEveniment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Localitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeLocalitate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localitate", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaEveniment_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.DropTable(
                name: "Localitate");

            migrationBuilder.DropIndex(
                name: "IX_SalaEveniment_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.AddColumn<string>(
                name: "Localitate",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
