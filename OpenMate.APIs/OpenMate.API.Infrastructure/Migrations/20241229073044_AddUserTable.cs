using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMate.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "Username");
        }
    }
}
