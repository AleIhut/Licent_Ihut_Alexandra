using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class artificii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Localitate_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPirotehnic_LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropColumn(
                name: "LocalitateID",
                table: "MaterialPirotehnic");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Judet_JudetID",
                table: "MaterialPirotehnic");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MaterialPirotehnic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
