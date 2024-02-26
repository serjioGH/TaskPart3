using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FinalChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111110-1111-1111-1111-111111111144"), new Guid("11111110-1111-1111-1111-111111111122") });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777770-7777-7777-7777-111111111111"),
                column: "Name",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777771-7777-7777-7777-111111111111"),
                column: "Name",
                value: "Cancelled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777770-7777-7777-7777-111111111111"),
                column: "Name",
                value: "Received");

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777771-7777-7777-7777-111111111111"),
                column: "Name",
                value: "Canceled");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("11111110-1111-1111-1111-111111111144"), new Guid("11111110-1111-1111-1111-111111111122") });
        }
    }
}
