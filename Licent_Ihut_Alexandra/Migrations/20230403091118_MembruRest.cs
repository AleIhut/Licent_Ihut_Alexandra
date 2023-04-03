using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licent_Ihut_Alexandra.Migrations
{
    public partial class MembruRest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Sonorizare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Prajitura",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "MaterialPirotehnic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Hostes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Decoratiune",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembruID",
                table: "Artist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sonorizare_MembruID",
                table: "Sonorizare",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_Prajitura_MembruID",
                table: "Prajitura",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPirotehnic_MembruID",
                table: "MaterialPirotehnic",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_Hostes_MembruID",
                table: "Hostes",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_Decoratiune_MembruID",
                table: "Decoratiune",
                column: "MembruID");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_MembruID",
                table: "Artist",
                column: "MembruID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Membru_MembruID",
                table: "Artist",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Decoratiune_Membru_MembruID",
                table: "Decoratiune",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostes_Membru_MembruID",
                table: "Hostes",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPirotehnic_Membru_MembruID",
                table: "MaterialPirotehnic",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Membru_MembruID",
                table: "Prajitura",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sonorizare_Membru_MembruID",
                table: "Sonorizare",
                column: "MembruID",
                principalTable: "Membru",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Membru_MembruID",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Decoratiune_Membru_MembruID",
                table: "Decoratiune");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostes_Membru_MembruID",
                table: "Hostes");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPirotehnic_Membru_MembruID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Membru_MembruID",
                table: "Prajitura");

            migrationBuilder.DropForeignKey(
                name: "FK_Sonorizare_Membru_MembruID",
                table: "Sonorizare");

            migrationBuilder.DropIndex(
                name: "IX_Sonorizare_MembruID",
                table: "Sonorizare");

            migrationBuilder.DropIndex(
                name: "IX_Prajitura_MembruID",
                table: "Prajitura");

            migrationBuilder.DropIndex(
                name: "IX_MaterialPirotehnic_MembruID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropIndex(
                name: "IX_Hostes_MembruID",
                table: "Hostes");

            migrationBuilder.DropIndex(
                name: "IX_Decoratiune_MembruID",
                table: "Decoratiune");

            migrationBuilder.DropIndex(
                name: "IX_Artist_MembruID",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Sonorizare");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Prajitura");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "MaterialPirotehnic");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Hostes");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Decoratiune");

            migrationBuilder.DropColumn(
                name: "MembruID",
                table: "Artist");
        }
    }
}
