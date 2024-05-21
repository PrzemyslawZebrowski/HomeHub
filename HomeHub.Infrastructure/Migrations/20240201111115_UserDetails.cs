using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AdvertiserTypeId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AdvertiserTypeId",
                table: "User",
                column: "AdvertiserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AdvertiserType_AdvertiserTypeId",
                table: "User",
                column: "AdvertiserTypeId",
                principalTable: "AdvertiserType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AdvertiserType_AdvertiserTypeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdvertiserTypeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdvertiserTypeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User");
        }
    }
}
