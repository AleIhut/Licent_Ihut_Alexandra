using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class FacAlegerea1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaEvenimentAles",
                columns: table => new
                {
                    MembruID = table.Column<int>(type: "int", nullable: false),
                    SalaEvenimentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaEvenimentAles", x => new { x.MembruID, x.SalaEvenimentID });
                    table.ForeignKey(
                        name: "FK_SalaEvenimentAles_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaEvenimentAles_SalaEveniment_SalaEvenimentID",
                        column: x => x.SalaEvenimentID,
                        principalTable: "SalaEveniment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaEvenimentAles_SalaEvenimentID",
                table: "SalaEvenimentAles",
                column: "SalaEvenimentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaEvenimentAles");
        }
    }
}
