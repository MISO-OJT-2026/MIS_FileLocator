using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class newCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the old single-int column if it exists, add the new string column
            migrationBuilder.AddColumn<string>(
                name: "AllowedConfidentialityLevels",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedConfidentialityLevels",
                table: "AspNetUsers");
        }
    }
}
