using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToRecipesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser1", 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser1", 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser2", 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser2", 2 });

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "public",
                table: "Recipes",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 25, 12, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8886), new TimeSpan(0, 0, 0, 0, 0)), "google-oauth2|103919914105442701060" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 23, 12, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8888), new TimeSpan(0, 0, 0, 0, 0)), "auth0|662e3bad87766e08b83e46a0" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 24, 22, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8894), new TimeSpan(0, 0, 0, 0, 0)), "google-oauth2|103919914105442701060" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 25, 12, 29, 41, 929, DateTimeKind.Unspecified).AddTicks(8896), new TimeSpan(0, 0, 0, 0, 0)), "auth0|662e3bad87766e08b83e46a0" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById", "ImageUrl" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 25, 15, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8691), new TimeSpan(0, 3, 0, 0, 0)), "google-oauth2|103919914105442701060", "https://www.onceuponachef.com/images/2009/09/Pumpkin-Bread-100.jpg" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById", "ImageUrl" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 25, 15, 34, 41, 929, DateTimeKind.Unspecified).AddTicks(8731), new TimeSpan(0, 3, 0, 0, 0)), "auth0|662e3bad87766e08b83e46a0", "https://www.allrecipes.com/thmb/CQrgVw7qjs2QQfKqy0GMerfppsM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/229932-Simple-Pumpkin-Pie-vat-hero-4x3-LSH-ae211272471a4e7aa9f10716cdcf4bc3.jpg" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Upvotes",
                columns: new[] { "CreatedById", "RecipeId" },
                values: new object[,]
                {
                    { "auth0|662e3bad87766e08b83e46a0", 1 },
                    { "auth0|662e3bad87766e08b83e46a0", 2 },
                    { "google-oauth2|103919914105442701060", 1 },
                    { "google-oauth2|103919914105442701060", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "auth0|662e3bad87766e08b83e46a0", 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "auth0|662e3bad87766e08b83e46a0", 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "google-oauth2|103919914105442701060", 1 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "google-oauth2|103919914105442701060", 2 });

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "public",
                table: "Recipes");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 22, 18, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 0, 0, 0, 0)), "TestUser3" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 20, 18, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 0, 0, 0, 0)), "TestUser4" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 22, 4, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 0, 0, 0, 0)), "TestUser5" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 22, 18, 22, 5, 428, DateTimeKind.Unspecified).AddTicks(6180), new TimeSpan(0, 0, 0, 0, 0)), "TestUser6" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 22, 21, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 3, 0, 0, 0)), "TestUser1" });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 5, 22, 21, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 3, 0, 0, 0)), "TestUser2" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Upvotes",
                columns: new[] { "CreatedById", "RecipeId" },
                values: new object[,]
                {
                    { "TestUser1", 1 },
                    { "TestUser1", 2 },
                    { "TestUser2", 1 },
                    { "TestUser2", 2 }
                });
        }
    }
}
