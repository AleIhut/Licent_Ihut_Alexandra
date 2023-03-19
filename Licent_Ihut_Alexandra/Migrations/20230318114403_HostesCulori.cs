using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class HostesCulori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culori",
                table: "Hostes");

            migrationBuilder.CreateTable(
                name: "Culoare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuloareName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culoare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HostesCuloare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostesID = table.Column<int>(type: "int", nullable: false),
                    CuloareID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostesCuloare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HostesCuloare_Culoare_CuloareID",
                        column: x => x.CuloareID,
                        principalTable: "Culoare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostesCuloare_Hostes_HostesID",
                        column: x => x.HostesID,
                        principalTable: "Hostes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HostesCuloare_CuloareID",
                table: "HostesCuloare",
                column: "CuloareID");

            migrationBuilder.CreateIndex(
                name: "IX_HostesCuloare_HostesID",
                table: "HostesCuloare",
                column: "HostesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostesCuloare");

            migrationBuilder.DropTable(
                name: "Culoare");

            migrationBuilder.AddColumn<string>(
                name: "Culori",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
