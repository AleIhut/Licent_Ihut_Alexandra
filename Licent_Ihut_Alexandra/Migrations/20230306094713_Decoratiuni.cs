using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class Decoratiuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Decoratiune",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Companie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locație = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoratiune", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Decoratiune_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Decoratiune_MaterialID",
                table: "Decoratiune",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Decoratiune");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
