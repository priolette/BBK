using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToIngredientName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                schema: "public",
                table: "Ingredients",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Name",
                schema: "public",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 12, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 23, 12, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 24, 22, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 12, 29, 41, 929, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 15, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2024, 5, 25, 15, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
