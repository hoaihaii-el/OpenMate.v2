using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMate.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEffortProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Effort",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effort",
                table: "Members");
        }
    }
}
