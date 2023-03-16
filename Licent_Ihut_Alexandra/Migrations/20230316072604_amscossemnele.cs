using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class amscossemnele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "SalaEveniment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imagine",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "SalaEveniment",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "Feluri",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "Imagine",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Fotograf",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Fotograf",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "Decoratiune",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist",
                column: "LocalitateID",
                principalTable: "Localitate",
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
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes",
                column: "LocalitateID",
                principalTable: "Localitate",
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
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "SalaEveniment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Imagine",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SalaEveniment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "SalaEveniment",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Prajitura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Feluri",
                table: "Prajitura",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Hostes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Imagine",
                table: "Hostes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Fotograf",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Fotograf",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Fotograf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descriere",
                table: "Decoratiune",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocalitateID",
                table: "Artist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Localitate_LocalitateID",
                table: "Artist",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Localitate_LocalitateID",
                table: "Fotograf",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Localitate_LocalitateID",
                table: "Hostes",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Localitate_LocalitateID",
                table: "Prajitura",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaEveniment_Localitate_LocalitateID",
                table: "SalaEveniment",
                column: "LocalitateID",
                principalTable: "Localitate",
                principalColumn: "ID");
        }
    }
}
