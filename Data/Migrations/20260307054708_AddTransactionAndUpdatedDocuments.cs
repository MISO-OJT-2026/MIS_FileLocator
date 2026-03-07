using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionAndUpdatedDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "BorrowRemarks",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowedAt",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentBorrower",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReturnDate",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TransactionLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLogs");

            migrationBuilder.DropColumn(
                name: "BorrowRemarks",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BorrowedAt",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CurrentBorrower",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedBy",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedBy",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
