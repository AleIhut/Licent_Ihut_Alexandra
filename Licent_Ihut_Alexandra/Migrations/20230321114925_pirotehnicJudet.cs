using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class pirotehnicJudet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic");

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

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

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
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic");

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

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
