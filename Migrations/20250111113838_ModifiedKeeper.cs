using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_ZOO.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedKeeper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Keeper",
                newName: "KeeperName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KeeperName",
                table: "Keeper",
                newName: "Name");
        }
    }
}
