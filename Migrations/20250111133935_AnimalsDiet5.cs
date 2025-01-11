using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    /// <inheritdoc />
    public partial class AnimalsDiet5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalDiet_Animal_AnimalID1",
                table: "AnimalDiet");

            migrationBuilder.DropIndex(
                name: "IX_AnimalDiet_AnimalID1",
                table: "AnimalDiet");

            migrationBuilder.DropColumn(
                name: "AnimalID1",
                table: "AnimalDiet");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalID",
                table: "AnimalDiet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDiet_AnimalID",
                table: "AnimalDiet",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalDiet_Animal_AnimalID",
                table: "AnimalDiet",
                column: "AnimalID",
                principalTable: "Animal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalDiet_Animal_AnimalID",
                table: "AnimalDiet");

            migrationBuilder.DropIndex(
                name: "IX_AnimalDiet_AnimalID",
                table: "AnimalDiet");

            migrationBuilder.AlterColumn<string>(
                name: "AnimalID",
                table: "AnimalDiet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AnimalID1",
                table: "AnimalDiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDiet_AnimalID1",
                table: "AnimalDiet",
                column: "AnimalID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalDiet_Animal_AnimalID1",
                table: "AnimalDiet",
                column: "AnimalID1",
                principalTable: "Animal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
