using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace med_consult_api.src.infrastructure.migrations
{
    /// <inheritdoc />
    public partial class Fixed_UserProfile_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_Email",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AuthUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AuthUsers");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AuthUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_Email",
                table: "AuthUsers",
                column: "Email",
                unique: true);
        }
    }
}
