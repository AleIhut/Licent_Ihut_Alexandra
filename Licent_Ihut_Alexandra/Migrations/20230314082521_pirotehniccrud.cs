using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class pirotehniccrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialPirotehnic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    LocalitateID = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPirotehnic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaterialPirotehnic_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPirotehnic_JudetID",
                table: "MaterialPirotehnic",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPirotehnic_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialPirotehnic");
        }
    }
}
