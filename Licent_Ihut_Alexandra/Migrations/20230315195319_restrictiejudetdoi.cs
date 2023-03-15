using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class restrictiejudetdoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Fotograf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Fotograf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }
    }
}
