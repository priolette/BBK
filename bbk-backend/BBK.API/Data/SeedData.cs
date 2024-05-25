using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Data;

public static class SeedData
{
    public static void SeedDatabase(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Unit>().HasData(
            new Unit { Id = 1, Name = "Cup", Code = "C" },
            new Unit { Id = 2, Name = "Tablespoon", Code = "Tbsp" },
            new Unit { Id = 3, Name = "Teaspoon", Code = "Tsp" },
            new Unit { Id = 4, Name = "Ounce", Code = "Oz" },
            new Unit { Id = 5, Name = "Pound", Code = "Lb" },
            new Unit { Id = 6, Name = "Gram", Code = "g" },
            new Unit { Id = 7, Name = "Kilogram", Code = "kg" }
        );

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Flour", Description = "White, all-purpose" },
            new Ingredient { Id = 2, Name = "Sugar", Description = "White, granulated" },
            new Ingredient { Id = 3, Name = "Salt", Description = "Table salt" },
            new Ingredient { Id = 4, Name = "Butter", Description = "Unsalted" },
            new Ingredient { Id = 5, Name = "Egg", Description = "Large, whole" },
            new Ingredient { Id = 6, Name = "Milk", Description = "Whole" },
            new Ingredient { Id = 7, Name = "Baking Powder", Description = "Double-acting" },
            new Ingredient { Id = 8, Name = "Vanilla Extract", Description = "Pure" },
            new Ingredient { Id = 9, Name = "Cinnamon", Description = "Ground" },
            new Ingredient { Id = 10, Name = "Nutmeg", Description = "Ground" },
            new Ingredient { Id = 11, Name = "Cloves", Description = "Ground" },
            new Ingredient { Id = 12, Name = "Ginger", Description = "Ground" },
            new Ingredient { Id = 13, Name = "Pumpkin", Description = "Canned, puree" },
            new Ingredient { Id = 14, Name = "Pecans", Description = "Chopped" }
        );

        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1,
                Title = "Pumpkin Bread",
                Description = "A delicious, moist pumpkin bread with a hint of spice.",
                ImageUrl = "https://www.onceuponachef.com/images/2009/09/Pumpkin-Bread-100.jpg",
                CreatedById = "google-oauth2|103919914105442701060",
                CreatedAt = DateTimeOffset.Now
            },
            new Recipe
            {
                Id = 2,
                Title = "Pumpkin Pie",
                Description = "A classic pumpkin pie with a flaky crust and creamy filling.",
                ImageUrl = "https://www.allrecipes.com/thmb/CQrgVw7qjs2QQfKqy0GMerfppsM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/229932-Simple-Pumpkin-Pie-vat-hero-4x3-LSH-ae211272471a4e7aa9f10716cdcf4bc3.jpg",
                CreatedById = "auth0|662e3bad87766e08b83e46a0",
                CreatedAt = DateTimeOffset.Now
            }
        );

        modelBuilder.Entity<RecipeIngredient>().HasData(
            new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, UnitId = 1, Amount = 2 },
            new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, UnitId = 1, Amount = 1.5 },
            new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 4, RecipeId = 1, IngredientId = 4, UnitId = 1, Amount = 0.5 },
            new RecipeIngredient { Id = 5, RecipeId = 1, IngredientId = 5, UnitId = 1, Amount = 2 },
            new RecipeIngredient { Id = 6, RecipeId = 1, IngredientId = 6, UnitId = 1, Amount = 0.5 },
            new RecipeIngredient { Id = 7, RecipeId = 1, IngredientId = 7, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 8, RecipeId = 1, IngredientId = 8, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 9, RecipeId = 1, IngredientId = 9, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 10, RecipeId = 1, IngredientId = 10, UnitId = 2, Amount = 0.5 },
            new RecipeIngredient { Id = 11, RecipeId = 1, IngredientId = 11, UnitId = 2, Amount = 0.25 },
            new RecipeIngredient { Id = 12, RecipeId = 1, IngredientId = 12, UnitId = 2, Amount = 0.25 },
            new RecipeIngredient { Id = 13, RecipeId = 1, IngredientId = 13, UnitId = 1, Amount = 1 },
            new RecipeIngredient { Id = 14, RecipeId = 1, IngredientId = 14, UnitId = 1, Amount = 0.5 },
            new RecipeIngredient { Id = 15, RecipeId = 2, IngredientId = 1, UnitId = 1, Amount = 1 },
            new RecipeIngredient { Id = 16, RecipeId = 2, IngredientId = 2, UnitId = 1, Amount = 0.75 },
            new RecipeIngredient { Id = 28, RecipeId = 2, IngredientId = 3, UnitId = 2, Amount = 0.5 },
            new RecipeIngredient { Id = 17, RecipeId = 2, IngredientId = 4, UnitId = 1, Amount = 0.25 },
            new RecipeIngredient { Id = 18, RecipeId = 2, IngredientId = 5, UnitId = 1, Amount = 2 },
            new RecipeIngredient { Id = 19, RecipeId = 2, IngredientId = 6, UnitId = 1, Amount = 1 },
            new RecipeIngredient { Id = 20, RecipeId = 2, IngredientId = 7, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 21, RecipeId = 2, IngredientId = 8, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 22, RecipeId = 2, IngredientId = 9, UnitId = 2, Amount = 1 },
            new RecipeIngredient { Id = 23, RecipeId = 2, IngredientId = 10, UnitId = 2, Amount = 0.5 },
            new RecipeIngredient { Id = 24, RecipeId = 2, IngredientId = 11, UnitId = 2, Amount = 0.25 },
            new RecipeIngredient { Id = 25, RecipeId = 2, IngredientId = 12, UnitId = 2, Amount = 0.25 },
            new RecipeIngredient { Id = 26, RecipeId = 2, IngredientId = 13, UnitId = 1, Amount = 1 },
            new RecipeIngredient { Id = 27, RecipeId = 2, IngredientId = 14, UnitId = 1, Amount = 0.5 }
        );

        modelBuilder.Entity<Step>().HasData(
            new Step { Id = 1, RecipeId = 1, Order = 1, Description = "Preheat oven to 350°F." },
            new Step { Id = 2, RecipeId = 1, Order = 2, Description = "Grease and flour a 9x5-inch loaf pan." },
            new Step { Id = 3, RecipeId = 1, Order = 3, Description = "In a medium bowl, whisk together flour, sugar, salt, and baking powder." },
            new Step { Id = 4, RecipeId = 1, Order = 4, Description = "In a large bowl, beat butter, eggs, milk, and vanilla until smooth." },
            new Step { Id = 5, RecipeId = 1, Order = 5, Description = "Gradually add dry ingredients to wet ingredients, mixing until just combined." },
            new Step { Id = 6, RecipeId = 1, Order = 6, Description = "Fold in pumpkin, pecans, and spices." },
            new Step { Id = 7, RecipeId = 1, Order = 7, Description = "Pour batter into prepared pan and smooth the top." },
            new Step { Id = 8, RecipeId = 1, Order = 8, Description = "Bake for 60-70 minutes, or until a toothpick inserted into the center comes out clean." },
            new Step { Id = 9, RecipeId = 1, Order = 9, Description = "Cool in pan for 10 minutes, then transfer to a wire rack to cool completely." },
            new Step { Id = 10, RecipeId = 2, Order = 1, Description = "Preheat oven to 425°F." },
            new Step { Id = 11, RecipeId = 2, Order = 2, Description = "Fit pie crust into a 9-inch pie plate and crimp edges as desired." },
            new Step { Id = 12, RecipeId = 2, Order = 3, Description = "In a large bowl, whisk together pumpkin, sugar, salt, and spices." },
            new Step { Id = 13, RecipeId = 2, Order = 4, Description = "In a separate bowl, whisk together eggs and milk." },
            new Step { Id = 14, RecipeId = 2, Order = 5, Description = "Gradually add egg mixture to pumpkin mixture, whisking until smooth." },
            new Step { Id = 15, RecipeId = 2, Order = 6, Description = "Pour filling into pie crust and smooth the top." },
            new Step { Id = 16, RecipeId = 2, Order = 7, Description = "Bake for 15 minutes, then reduce oven temperature to 350°F and bake for an additional 40-50 minutes, or until filling is set." },
            new Step { Id = 17, RecipeId = 2, Order = 8, Description = "Cool on a wire rack for 2 hours, then refrigerate until ready to serve." }
        );

        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                RecipeId = 1,
                Text = "This pumpkin bread is delicious! I added some chocolate chips for extra sweetness.",
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedById = "google-oauth2|103919914105442701060"
            },
            new Comment
            {
                Id = 2,
                RecipeId = 1,
                Text = "I made this for Thanksgiving and it was a hit with my family. Will definitely make again!",
                CreatedAt = DateTimeOffset.UtcNow.AddDays(-2),
                CreatedById = "auth0|662e3bad87766e08b83e46a0"
            },
            new Comment
            {
                Id = 3,
                RecipeId = 2,
                Text = "The pumpkin pie turned out perfectly. I used a store-bought crust to save time.",
                CreatedAt = DateTimeOffset.UtcNow.AddHours(-14),
                CreatedById = "google-oauth2|103919914105442701060"
            },
            new Comment
            {
                Id = 4,
                RecipeId = 2,
                Text = "I love pumpkin pie and this recipe did not disappoint. The spices were just right!",
                CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-5),
                CreatedById = "auth0|662e3bad87766e08b83e46a0"
            }
        );

        modelBuilder.Entity<Upvote>().HasData(
            new Upvote { RecipeId = 1, CreatedById = "google-oauth2|103919914105442701060" },
            new Upvote { RecipeId = 1, CreatedById = "auth0|662e3bad87766e08b83e46a0" },
            new Upvote { RecipeId = 2, CreatedById = "google-oauth2|103919914105442701060" },
            new Upvote { RecipeId = 2, CreatedById = "auth0|662e3bad87766e08b83e46a0" },
            new Upvote { RecipeId = 2, CreatedById = "TestUser3" },
            new Upvote { RecipeId = 2, CreatedById = "TestUser4" }
        );
    }
}
