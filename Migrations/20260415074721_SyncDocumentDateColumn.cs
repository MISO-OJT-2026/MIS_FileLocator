using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class SyncDocumentDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Documents");

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentDate",
                table: "Documents",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentDate",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Documents",
                type: "int",
                nullable: true);
        }
    }
}
