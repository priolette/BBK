using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConcurrencyTokensToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Upvotes",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Units",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Steps",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Recipes",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "RecipeIngredients",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Ingredients",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                schema: "public",
                table: "Comments",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 26, 15, 52, 10, 615, DateTimeKind.Unspecified).AddTicks(2453), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 24, 15, 52, 10, 615, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 26, 1, 52, 10, 615, DateTimeKind.Unspecified).AddTicks(2460), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 26, 15, 47, 10, 615, DateTimeKind.Unspecified).AddTicks(2462), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 26, 18, 52, 10, 615, DateTimeKind.Unspecified).AddTicks(2308), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 26, 18, 52, 10, 615, DateTimeKind.Unspecified).AddTicks(2343), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Upvotes");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "public",
                table: "Comments");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 14, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 23, 14, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 0, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 14, 7, 59, 52, DateTimeKind.Unspecified).AddTicks(8586), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 17, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8424), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 17, 12, 59, 52, DateTimeKind.Unspecified).AddTicks(8469), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
