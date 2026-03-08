using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class AddedStorageModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "Folders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchivedBy",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "FillingCabinets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchivedBy",
                table: "FillingCabinets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedAt",
                table: "FileBoxes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchivedBy",
                table: "FileBoxes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "FillingCabinets");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "FillingCabinets");

            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "FileBoxes");

            migrationBuilder.DropColumn(
                name: "ArchivedBy",
                table: "FileBoxes");
        }
    }
}
