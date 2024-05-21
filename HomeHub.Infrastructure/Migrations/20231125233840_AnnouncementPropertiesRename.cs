using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnnouncementPropertiesRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AnnouncementStatus_AnnouncementStatusId",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AnnouncementType_AnnouncementTypeId",
                table: "Announcement");

            migrationBuilder.RenameColumn(
                name: "AnnouncementTypeId",
                table: "Announcement",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "AnnouncementStatusId",
                table: "Announcement",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_AnnouncementTypeId",
                table: "Announcement",
                newName: "IX_Announcement_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_AnnouncementStatusId",
                table: "Announcement",
                newName: "IX_Announcement_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AnnouncementStatus_StatusId",
                table: "Announcement",
                column: "StatusId",
                principalTable: "AnnouncementStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AnnouncementType_TypeId",
                table: "Announcement",
                column: "TypeId",
                principalTable: "AnnouncementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AnnouncementStatus_StatusId",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_AnnouncementType_TypeId",
                table: "Announcement");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Announcement",
                newName: "AnnouncementTypeId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Announcement",
                newName: "AnnouncementStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_TypeId",
                table: "Announcement",
                newName: "IX_Announcement_AnnouncementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_StatusId",
                table: "Announcement",
                newName: "IX_Announcement_AnnouncementStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AnnouncementStatus_AnnouncementStatusId",
                table: "Announcement",
                column: "AnnouncementStatusId",
                principalTable: "AnnouncementStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_AnnouncementType_AnnouncementTypeId",
                table: "Announcement",
                column: "AnnouncementTypeId",
                principalTable: "AnnouncementType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
