using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class PachetulMeu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PachetulMeu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaEvenimentID = table.Column<int>(type: "int", nullable: true),
                    SonorizareID = table.Column<int>(type: "int", nullable: true),
                    DecoratiuneID = table.Column<int>(type: "int", nullable: true),
                    FotografID = table.Column<int>(type: "int", nullable: true),
                    ArtistID = table.Column<int>(type: "int", nullable: true),
                    HostesID = table.Column<int>(type: "int", nullable: true),
                    MaterialPirotehnicID = table.Column<int>(type: "int", nullable: true),
                    PrajituraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PachetulMeu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Artist_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artist",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Decoratiune_DecoratiuneID",
                        column: x => x.DecoratiuneID,
                        principalTable: "Decoratiune",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Fotograf_FotografID",
                        column: x => x.FotografID,
                        principalTable: "Fotograf",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Hostes_HostesID",
                        column: x => x.HostesID,
                        principalTable: "Hostes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_MaterialPirotehnic_MaterialPirotehnicID",
                        column: x => x.MaterialPirotehnicID,
                        principalTable: "MaterialPirotehnic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Prajitura_PrajituraID",
                        column: x => x.PrajituraID,
                        principalTable: "Prajitura",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_SalaEveniment_SalaEvenimentID",
                        column: x => x.SalaEvenimentID,
                        principalTable: "SalaEveniment",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PachetulMeu_Sonorizare_SonorizareID",
                        column: x => x.SonorizareID,
                        principalTable: "Sonorizare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_ArtistID",
                table: "PachetulMeu",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_DecoratiuneID",
                table: "PachetulMeu",
                column: "DecoratiuneID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_FotografID",
                table: "PachetulMeu",
                column: "FotografID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_HostesID",
                table: "PachetulMeu",
                column: "HostesID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_MaterialPirotehnicID",
                table: "PachetulMeu",
                column: "MaterialPirotehnicID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_PrajituraID",
                table: "PachetulMeu",
                column: "PrajituraID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_SalaEvenimentID",
                table: "PachetulMeu",
                column: "SalaEvenimentID");

            migrationBuilder.CreateIndex(
                name: "IX_PachetulMeu_SonorizareID",
                table: "PachetulMeu",
                column: "SonorizareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PachetulMeu");
        }
    }
}
