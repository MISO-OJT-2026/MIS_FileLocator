using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class upt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxConfidentialityLevelId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AllowedConfidentialityLevels",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedConfidentialityLevels",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "MaxConfidentialityLevelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
