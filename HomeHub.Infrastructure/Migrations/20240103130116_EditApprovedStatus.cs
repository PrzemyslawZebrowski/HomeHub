using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditApprovedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnnouncementStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Approved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnnouncementStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Accepted");
        }
    }
}
