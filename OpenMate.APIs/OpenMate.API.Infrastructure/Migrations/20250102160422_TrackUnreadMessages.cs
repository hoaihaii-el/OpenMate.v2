using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMate.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrackUnreadMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnReadCount",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnReadCount",
                table: "Participants");
        }
    }
}
