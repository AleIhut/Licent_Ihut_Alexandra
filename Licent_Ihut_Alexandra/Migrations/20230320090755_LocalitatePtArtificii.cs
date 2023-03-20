using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class LocalitatePtArtificii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalitateID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPirotehnic_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPirotehnic_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "MaterialPirotehnic");
        }
    }
}
