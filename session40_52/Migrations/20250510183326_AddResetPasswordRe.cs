using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace session40_52.Migrations
{
    /// <inheritdoc />
    public partial class AddResetPasswordRe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tokenResetPass",
                table: "Users",
                newName: "ResetPasswordToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResetPasswordToken",
                table: "Users",
                newName: "tokenResetPass");
        }
    }
}
