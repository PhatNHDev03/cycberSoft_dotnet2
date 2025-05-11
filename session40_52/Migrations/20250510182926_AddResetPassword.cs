using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace session40_52.Migrations
{
    /// <inheritdoc />
    public partial class AddResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresTokenResetPassword",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tokenResetPass",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresTokenResetPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "tokenResetPass",
                table: "Users");
        }
    }
}
