using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cloth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("22222220-2222-2222-2222-111111111111"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("33333330-3333-3333-3333-111111111111"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("44444440-4444-4444-4444-111111111111"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("55555550-5555-5555-5555-111111111111"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Sizes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "OrderStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cloths",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Cloths",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cloths",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Brands",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("88888880-8888-8888-8888-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Men" },
                    { new Guid("99999990-9999-9999-9999-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Women" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("66666660-6666-6666-6666-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing" },
                    { new Guid("66666661-6666-6666-6666-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { new Guid("77777770-7777-7777-7777-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { new Guid("77777771-7777-7777-7777-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("88888880-8888-8888-8888-111111111111"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("99999990-9999-9999-9999-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("66666660-6666-6666-6666-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("66666661-6666-6666-6666-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777770-7777-7777-7777-111111111111"));

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777771-7777-7777-7777-111111111111"));

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Cloths");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cloths");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Baskets");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cloths",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("11111110-1111-1111-1111-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chanel" },
                    { new Guid("22222220-2222-2222-2222-111111111111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33333330-3333-3333-3333-111111111111"), "Small" },
                    { new Guid("44444440-4444-4444-4444-111111111111"), "Medium" },
                    { new Guid("55555550-5555-5555-5555-111111111111"), "Large" }
                });
        }
    }
}
