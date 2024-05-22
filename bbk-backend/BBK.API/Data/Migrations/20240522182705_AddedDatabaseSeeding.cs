using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BBK.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDatabaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "White, all-purpose", "Flour" },
                    { 2, "White, granulated", "Sugar" },
                    { 3, "Table salt", "Salt" },
                    { 4, "Unsalted", "Butter" },
                    { 5, "Large, whole", "Egg" },
                    { 6, "Whole", "Milk" },
                    { 7, "Double-acting", "Baking Powder" },
                    { 8, "Pure", "Vanilla Extract" },
                    { 9, "Ground", "Cinnamon" },
                    { 10, "Ground", "Nutmeg" },
                    { 11, "Ground", "Cloves" },
                    { 12, "Ground", "Ginger" },
                    { 13, "Canned, puree", "Pumpkin" },
                    { 14, "Chopped", "Pecans" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Recipes",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "Description", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 5, 22, 21, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(5990), new TimeSpan(0, 3, 0, 0, 0)), "TestUser1", "A delicious, moist pumpkin bread with a hint of spice.", null, "Pumpkin Bread" },
                    { 2, new DateTimeOffset(new DateTime(2024, 5, 22, 21, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6014), new TimeSpan(0, 3, 0, 0, 0)), "TestUser2", "A classic pumpkin pie with a flaky crust and creamy filling.", null, "Pumpkin Pie" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Units",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "C", "Cup" },
                    { 2, "Tbsp", "Tablespoon" },
                    { 3, "Tsp", "Teaspoon" },
                    { 4, "Oz", "Ounce" },
                    { 5, "Lb", "Pound" },
                    { 6, "g", "Gram" },
                    { 7, "kg", "Kilogram" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "CreatedById", "RecipeId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 5, 22, 18, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6173), new TimeSpan(0, 0, 0, 0, 0)), "TestUser3", 1, "This pumpkin bread is delicious! I added some chocolate chips for extra sweetness." },
                    { 2, new DateTimeOffset(new DateTime(2024, 5, 20, 18, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6175), new TimeSpan(0, 0, 0, 0, 0)), "TestUser4", 1, "I made this for Thanksgiving and it was a hit with my family. Will definitely make again!" },
                    { 3, new DateTimeOffset(new DateTime(2024, 5, 22, 4, 27, 5, 428, DateTimeKind.Unspecified).AddTicks(6179), new TimeSpan(0, 0, 0, 0, 0)), "TestUser5", 2, "The pumpkin pie turned out perfectly. I used a store-bought crust to save time." },
                    { 4, new DateTimeOffset(new DateTime(2024, 5, 22, 18, 22, 5, 428, DateTimeKind.Unspecified).AddTicks(6180), new TimeSpan(0, 0, 0, 0, 0)), "TestUser6", 2, "I love pumpkin pie and this recipe did not disappoint. The spices were just right!" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "RecipeIngredients",
                columns: new[] { "Id", "Amount", "IngredientId", "RecipeId", "UnitId" },
                values: new object[,]
                {
                    { 1, 2.0, 1, 1, 1 },
                    { 2, 1.5, 2, 1, 1 },
                    { 3, 1.0, 3, 1, 2 },
                    { 4, 0.5, 4, 1, 1 },
                    { 5, 2.0, 5, 1, 1 },
                    { 6, 0.5, 6, 1, 1 },
                    { 7, 1.0, 7, 1, 2 },
                    { 8, 1.0, 8, 1, 2 },
                    { 9, 1.0, 9, 1, 2 },
                    { 10, 0.5, 10, 1, 2 },
                    { 11, 0.25, 11, 1, 2 },
                    { 12, 0.25, 12, 1, 2 },
                    { 13, 1.0, 13, 1, 1 },
                    { 14, 0.5, 14, 1, 1 },
                    { 15, 1.0, 1, 2, 1 },
                    { 16, 0.75, 2, 2, 1 },
                    { 17, 0.25, 4, 2, 1 },
                    { 18, 2.0, 5, 2, 1 },
                    { 19, 1.0, 6, 2, 1 },
                    { 20, 1.0, 7, 2, 2 },
                    { 21, 1.0, 8, 2, 2 },
                    { 22, 1.0, 9, 2, 2 },
                    { 23, 0.5, 10, 2, 2 },
                    { 24, 0.25, 11, 2, 2 },
                    { 25, 0.25, 12, 2, 2 },
                    { 26, 1.0, 13, 2, 1 },
                    { 27, 0.5, 14, 2, 1 },
                    { 28, 0.5, 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Steps",
                columns: new[] { "Id", "Description", "Order", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Preheat oven to 350°F.", 1, 1 },
                    { 2, "Grease and flour a 9x5-inch loaf pan.", 2, 1 },
                    { 3, "In a medium bowl, whisk together flour, sugar, salt, and baking powder.", 3, 1 },
                    { 4, "In a large bowl, beat butter, eggs, milk, and vanilla until smooth.", 4, 1 },
                    { 5, "Gradually add dry ingredients to wet ingredients, mixing until just combined.", 5, 1 },
                    { 6, "Fold in pumpkin, pecans, and spices.", 6, 1 },
                    { 7, "Pour batter into prepared pan and smooth the top.", 7, 1 },
                    { 8, "Bake for 60-70 minutes, or until a toothpick inserted into the center comes out clean.", 8, 1 },
                    { 9, "Cool in pan for 10 minutes, then transfer to a wire rack to cool completely.", 9, 1 },
                    { 10, "Preheat oven to 425°F.", 1, 2 },
                    { 11, "Fit pie crust into a 9-inch pie plate and crimp edges as desired.", 2, 2 },
                    { 12, "In a large bowl, whisk together pumpkin, sugar, salt, and spices.", 3, 2 },
                    { 13, "In a separate bowl, whisk together eggs and milk.", 4, 2 },
                    { 14, "Gradually add egg mixture to pumpkin mixture, whisking until smooth.", 5, 2 },
                    { 15, "Pour filling into pie crust and smooth the top.", 6, 2 },
                    { 16, "Bake for 15 minutes, then reduce oven temperature to 350°F and bake for an additional 40-50 minutes, or until filling is set.", 7, 2 },
                    { 17, "Cool on a wire rack for 2 hours, then refrigerate until ready to serve.", 8, 2 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Upvotes",
                columns: new[] { "CreatedById", "RecipeId" },
                values: new object[,]
                {
                    { "TestUser1", 1 },
                    { "TestUser1", 2 },
                    { "TestUser2", 1 },
                    { "TestUser2", 2 },
                    { "TestUser3", 2 },
                    { "TestUser4", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Steps",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser3", 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Upvotes",
                keyColumns: new[] { "CreatedById", "RecipeId" },
                keyValues: new object[] { "TestUser4", 2 });

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
