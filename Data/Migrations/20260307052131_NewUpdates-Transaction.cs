using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdatesTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AuditTrails",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AuditTrails",
                newName: "Username");
        }
    }
}
