using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class UsernameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111122"),
                column: "Username",
                value: "Serj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                schema: "public",
                table: "Users");
        }
    }
}
