using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class Membru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Fotograf",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotograf_MembruID",
                table: "Fotograf",
                column: "MembruID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Membru_MembruID",
                table: "Fotograf",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Membru_MembruID",
                table: "Fotograf");

            migrationBuilder.DropTable(
                name: "Membru");

            migrationBuilder.DropIndex(
                name: "IX_Fotograf_MembruID",
                table: "Fotograf");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Fotograf");
        }
    }
}
