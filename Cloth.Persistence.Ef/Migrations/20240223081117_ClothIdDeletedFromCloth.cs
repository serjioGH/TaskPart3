using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cloth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ClothIdDeletedFromCloth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Cloths");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "Cloths",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
