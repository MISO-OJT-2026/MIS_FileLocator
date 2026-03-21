using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS_FileLocator.Migrations
{
    /// <inheritdoc />
    public partial class newnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormTemplate",
                table: "FormTemplate");

            migrationBuilder.RenameTable(
                name: "FormTemplate",
                newName: "FormTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormTemplates",
                table: "FormTemplates",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormTemplates",
                table: "FormTemplates");

            migrationBuilder.RenameTable(
                name: "FormTemplates",
                newName: "FormTemplate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormTemplate",
                table: "FormTemplate",
                column: "Id");
        }
    }
}
