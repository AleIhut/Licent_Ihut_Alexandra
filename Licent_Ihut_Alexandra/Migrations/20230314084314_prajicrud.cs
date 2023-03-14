using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class prajicrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prajitura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JudetID = table.Column<int>(type: "int", nullable: true),
                    LocalitateID = table.Column<int>(type: "int", nullable: true),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feluri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Figurine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prajitura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prajitura_Judet_JudetID",
                        column: x => x.JudetID,
                        principalTable: "Judet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prajitura_Localitate_LocalitateID",
                        column: x => x.LocalitateID,
                        principalTable: "Localitate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prajitura_JudetID",
                table: "Prajitura",
                column: "JudetID");

            migrationBuilder.CreateIndex(
                name: "IX_Prajitura_LocalitateID",
                table: "Prajitura",
                column: "LocalitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prajitura");
        }
    }
}
