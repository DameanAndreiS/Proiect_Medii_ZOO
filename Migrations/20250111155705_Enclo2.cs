using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    /// <inheritdoc />
    public partial class Enclo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Enclosure",
                newName: "EnclosureName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnclosureName",
                table: "Enclosure",
                newName: "Name");
        }
    }
}
