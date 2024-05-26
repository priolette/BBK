using BBK.API.Data;
using BBK.API.Data.Models;

namespace BBK.API.Repositories.RecipeIngredients;

public class RecipeIngredientsRepository(AppDbContext context) : IRecipeIngredientsRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddRange(List<RecipeIngredient> ingredients)
    {
        _context.RecipeIngredients.AddRange(ingredients);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRange(List<RecipeIngredient> ingredients)
    {
        _context.RecipeIngredients.RemoveRange(ingredients);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRange(List<RecipeIngredient> ingredients)
    {
        _context.RecipeIngredients.UpdateRange(ingredients);
        await _context.SaveChangesAsync();
    }
}
