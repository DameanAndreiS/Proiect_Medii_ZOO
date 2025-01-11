using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    /// <inheritdoc />
    public partial class AnimalsDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enclosure_ID",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Keeper_ID",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animal",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AnimalDiet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalID1 = table.Column<int>(type: "int", nullable: false),
                    DietID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalDiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnimalDiet_Animal_AnimalID1",
                        column: x => x.AnimalID1,
                        principalTable: "Animal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalDiet_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDiet_AnimalID1",
                table: "AnimalDiet",
                column: "AnimalID1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDiet_DietID",
                table: "AnimalDiet",
                column: "DietID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalDiet");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Animal",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Enclosure_ID",
                table: "Animal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Keeper_ID",
                table: "Animal",
                type: "int",
                nullable: true);
        }
    }
}
