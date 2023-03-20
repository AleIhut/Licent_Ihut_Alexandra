using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class LocalArtificii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }
    }
}
