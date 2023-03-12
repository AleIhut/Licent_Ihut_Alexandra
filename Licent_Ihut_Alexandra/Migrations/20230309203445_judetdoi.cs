using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class judetdoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Judet",
                table: "SalaEveniment",
                newName: "JudetID");

            migrationBuilder.AddColumn<int>(
                name: "JudetID1",
                table: "SalaEveniment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Judet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judet", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID1",
                table: "SalaEveniment");

            migrationBuilder.DropTable(
                name: "Judet");

            migrationBuilder.DropIndex(
                name: "IX_SalaEveniment_JudetID1",
                table: "SalaEveniment");

            migrationBuilder.DropColumn(
                name: "JudetID1",
                table: "SalaEveniment");

            migrationBuilder.RenameColumn(
                name: "JudetID",
                table: "SalaEveniment",
                newName: "Judet");
        }
    }
}
