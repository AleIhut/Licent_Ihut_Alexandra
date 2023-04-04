using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class Incercare1UserSauPrest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSauPrestatorID",
                table: "Membru",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSauPrestator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSauPrestator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membru_UserSauPrestatorID",
                table: "Membru",
                column: "UserSauPrestatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Membru_UserSauPrestator_UserSauPrestatorID",
                table: "Membru",
                column: "UserSauPrestatorID",
                principalTable: "UserSauPrestator",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membru_UserSauPrestator_UserSauPrestatorID",
                table: "Membru");

            migrationBuilder.DropTable(
                name: "UserSauPrestator");

            migrationBuilder.DropIndex(
                name: "IX_Membru_UserSauPrestatorID",
                table: "Membru");

            migrationBuilder.DropColumn(
                name: "UserSauPrestatorID",
                table: "Membru");
        }
    }
}
