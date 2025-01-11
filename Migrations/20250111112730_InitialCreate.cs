using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosure",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosure", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Keeper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keeper", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Keeper_ID = table.Column<int>(type: "int", nullable: true),
                    KeeperID = table.Column<int>(type: "int", nullable: true),
                    Enclosure_ID = table.Column<int>(type: "int", nullable: true),
                    EnclosureID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Enclosure_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "Enclosure",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Animal_Keeper_KeeperID",
                        column: x => x.KeeperID,
                        principalTable: "Keeper",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureID",
                table: "Animal",
                column: "EnclosureID");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_KeeperID",
                table: "Animal",
                column: "KeeperID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Enclosure");

            migrationBuilder.DropTable(
                name: "Keeper");
        }
    }
}
