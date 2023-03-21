using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class RezolvareJudeteSemne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Judet_JudetID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Judet_JudetID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Judet_JudetID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Judet_JudetID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "SalaEveniment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "SalaEveniment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Prajitura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Prajitura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Hostes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Hostes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Fotograf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Fotograf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Judet_JudetID",
                table: "Artist",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Judet_JudetID",
                table: "Fotograf",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Judet_JudetID",
                table: "Hostes",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Judet_JudetID",
                table: "Prajitura",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Judet_JudetID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Judet_JudetID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Judet_JudetID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Judet_JudetID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "SalaEveniment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "SalaEveniment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Prajitura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Prajitura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Hostes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Hostes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Fotograf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Fotograf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JudetID",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Judet_JudetID",
                table: "Artist",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Judet_JudetID",
                table: "Fotograf",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Judet_JudetID",
                table: "Hostes",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Judet_JudetID",
                table: "Prajitura",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Judet_JudetID",
                table: "SalaEveniment",
                column: "JudetID",
                principalTable: "Judet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
