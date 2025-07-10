using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace med_consult_api.src.infrastructure.migrations
{
    /// <inheritdoc />
    public partial class Fixed_Models_Unique_Indexes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "AuthUserId",
                table: "UserProfiles");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthUserId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers",
                column: "UserProfileId",
                unique: true);
        }
    }
}
