using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;

namespace BBK.API.Services.RecipeIngredients;

public class RecipeIngredientService(AppDbContext context, ILogger<RecipeIngredientService> logger) : IRecipeIngredientService
{
    private readonly AppDbContext _context = context;
    private readonly ILogger<RecipeIngredientService> _logger = logger;


    /// <summary>
    /// Adds, updates, and deletes recipe ingredients based on request and provided existing recipe ingredients
    /// </summary>
    /// <param name="recipeId"></param>
    /// <param name="requests">The ingredients to add/update/delete</param>
    /// <param name="recipeIngredients">Current recipe ingredients for a specific recipe</param>
    /// <returns>The list of added and updated ingredients</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<List<RecipeIngredient>> UpdateRecipeIngredientsAsync(
        int recipeId,
        List<UpdateRecipeIngredientRequest> requests, 
        List<RecipeIngredient> recipeIngredients)
    {
        var ingredientsToAdd = requests
            .Where(irq => !recipeIngredients.Any(ri => ri.Id == irq.Id))
            .Select(irq => new RecipeIngredient
            {
                RecipeId = recipeId,
                IngredientId = irq.IngredientId ?? throw new InvalidOperationException("IngredientId is required"),
                UnitId = irq.UnitId ?? throw new InvalidOperationException("UnitId is required"),
                Amount = irq.Amount ?? throw new InvalidOperationException("Amount is required")
            });

        var ingredientsToDelete = recipeIngredients
            .Where(ri => !requests.Any(irq => irq.Id == ri.Id))
            .ToList();

        var ingredientsToUpdate = recipeIngredients
                .Where(ri => requests.Any(irq => irq.Id == ri.Id))
                .ToList();

        foreach (var ingredient in ingredientsToUpdate)
        {
            var request = requests.First(irq => irq.Id == ingredient.Id);

            ingredient.IngredientId = request.IngredientId ?? ingredient.IngredientId;
            ingredient.UnitId = request.UnitId ?? ingredient.UnitId;
            ingredient.Amount = request.Amount ?? ingredient.Amount;
        }

        _context.RecipeIngredients.AddRange(ingredientsToAdd);
        _context.RecipeIngredients.RemoveRange(ingredientsToDelete);
        _context.RecipeIngredients.UpdateRange(ingredientsToUpdate);

        await _context.SaveChangesAsync();

        return [.. ingredientsToUpdate, .. ingredientsToAdd];
    }
}
