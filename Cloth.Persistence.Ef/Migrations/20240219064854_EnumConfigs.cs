using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cloth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnumConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("66666660-6666-6666-6666-111111111111"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("66666661-6666-6666-6666-111111111111"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("77777770-7777-7777-7777-111111111111"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { new Guid("66666660-6666-6666-6666-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa" },
                    { new Guid("66666661-6666-6666-6666-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PayPal" },
                    { new Guid("77777770-7777-7777-7777-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MasterCard" }
                });
        }
    }
}
