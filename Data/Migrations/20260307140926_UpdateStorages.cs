using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStorages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Folders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FillingCabinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "FillingCabinets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FileBoxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "FileBoxes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FillingCabinets");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "FillingCabinets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FileBoxes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "FileBoxes");
        }
    }
}
