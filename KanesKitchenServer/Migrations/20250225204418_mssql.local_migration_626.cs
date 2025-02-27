using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanesKitchenServer.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_626 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "rating",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rating",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Comments");
        }
    }
}
