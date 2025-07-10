using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace med_consult_api.src.infrastructure.migrations
{
    /// <inheritdoc />
    public partial class Fixed_AuthUser_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_AuthUsers_AuthUserId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_AuthUserId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthUserId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResetPasswordCode",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "AuthUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUsers_UserProfiles_UserProfileId",
                table: "AuthUsers",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUsers_UserProfiles_UserProfileId",
                table: "AuthUsers");

            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_UserProfileId",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "AuthUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthUserId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ResetPasswordCode",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AuthUserId",
                table: "UserProfiles",
                column: "AuthUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_AuthUsers_AuthUserId",
                table: "UserProfiles",
                column: "AuthUserId",
                principalTable: "AuthUsers",
                principalColumn: "Id");
        }
    }
}
