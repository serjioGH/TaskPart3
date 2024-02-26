using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToBasketLineAndOrderLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Cloths");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "AssociatedId",
                table: "Baskets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cloths",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BasketLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BasketLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { new Guid("11111110-1111-1111-1111-111111111144"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("11111110-1111-1111-1111-111111111122"), "Address example", "s.r.a@example.com", "Serdzhan", "Ahmedov", "password", "1234567890" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "CreatedOn", "UserId" },
                values: new object[] { new Guid("11111110-1111-1111-1111-111111111133"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11111110-1111-1111-1111-111111111122") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("11111110-1111-1111-1111-111111111144"), new Guid("11111110-1111-1111-1111-111111111122") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines",
                column: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines");

            migrationBuilder.DropIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines");

            migrationBuilder.DeleteData(
                table: "Baskets",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111133"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111110-1111-1111-1111-111111111144"), new Guid("11111110-1111-1111-1111-111111111122") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111144"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111122"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketLines");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BasketLines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Sizes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "OrderStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cloths",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getDate()");

            migrationBuilder.AddColumn<long>(
                name: "AssociatedId",
                table: "Cloths",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                columns: new[] { "OrderId", "ClothId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketLines",
                table: "BasketLines",
                columns: new[] { "BasketId", "ClothId" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("11111110-1111-1111-1111-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("22222220-2222-2222-2222-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("88888880-8888-8888-8888-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("99999990-9999-9999-9999-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("66666660-6666-6666-6666-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("66666661-6666-6666-6666-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777770-7777-7777-7777-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: new Guid("77777771-7777-7777-7777-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("33333330-3333-3333-3333-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("44444440-4444-4444-4444-111111111111"),
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("55555550-5555-5555-5555-111111111111"),
                columns: new string[0],
                values: new object[0]);
        }
    }
}
