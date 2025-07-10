using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace med_consult_api.src.infrastructure.migrations
{
    /// <inheritdoc />
    public partial class Fixed_Models_Unique_Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_Telephone",
                table: "UserProfiles",
                newName: "IX_UserProfile_Telephone");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_Email",
                table: "UserProfiles",
                newName: "IX_UserProfile_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                newName: "IX_Role_Name");

            migrationBuilder.RenameIndex(
                name: "IX_AuthUsers_UserName",
                table: "AuthUsers",
                newName: "IX_AuthUser_UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_Telephone",
                table: "UserProfiles",
                newName: "IX_UserProfiles_Telephone");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_Email",
                table: "UserProfiles",
                newName: "IX_UserProfiles_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Role_Name",
                table: "Roles",
                newName: "IX_Roles_Name");

            migrationBuilder.RenameIndex(
                name: "IX_AuthUser_UserName",
                table: "AuthUsers",
                newName: "IX_AuthUsers_UserName");
        }
    }
}
