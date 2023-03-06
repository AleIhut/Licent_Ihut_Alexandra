using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class GenMuzical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieMuzica");

            migrationBuilder.RenameColumn(
                name: "NumeGen",
                table: "GenMuzical",
                newName: "GenMuzicalNume");

            migrationBuilder.CreateTable(
                name: "SonorizareGenMuzical",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SonorizareID = table.Column<int>(type: "int", nullable: false),
                    GenMuzicalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonorizareGenMuzical", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SonorizareGenMuzical_GenMuzical_GenMuzicalID",
                        column: x => x.GenMuzicalID,
                        principalTable: "GenMuzical",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SonorizareGenMuzical_Sonorizare_SonorizareID",
                        column: x => x.SonorizareID,
                        principalTable: "Sonorizare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SonorizareGenMuzical_GenMuzicalID",
                table: "SonorizareGenMuzical",
                column: "GenMuzicalID");

            migrationBuilder.CreateIndex(
                name: "IX_SonorizareGenMuzical_SonorizareID",
                table: "SonorizareGenMuzical",
                column: "SonorizareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SonorizareGenMuzical");

            migrationBuilder.RenameColumn(
                name: "GenMuzicalNume",
                table: "GenMuzical",
                newName: "NumeGen");

            migrationBuilder.CreateTable(
                name: "CategorieMuzica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenMuzicalID = table.Column<int>(type: "int", nullable: false),
                    SonorizareID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieMuzica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieMuzica_GenMuzical_GenMuzicalID",
                        column: x => x.GenMuzicalID,
                        principalTable: "GenMuzical",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieMuzica_Sonorizare_SonorizareID",
                        column: x => x.SonorizareID,
                        principalTable: "Sonorizare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMuzica_GenMuzicalID",
                table: "CategorieMuzica",
                column: "GenMuzicalID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMuzica_SonorizareID",
                table: "CategorieMuzica",
                column: "SonorizareID");
        }
    }
}
