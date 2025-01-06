using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMate.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSprintDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Doing",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Finish",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Review",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Todo",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doing",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "Todo",
                table: "Sprints");
        }
    }
}
