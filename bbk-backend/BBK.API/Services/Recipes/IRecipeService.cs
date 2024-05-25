using BBK.API.Contracts.Requests;
using BBK.API.Models;

namespace BBK.API.Services.Recipes;

public interface IRecipeService
{
    Task<ListResult<ShortRecipeResult>> GetAllRecipesAsync(PaginationFilter? pagination);
    Task<RecipeResult?> GetRecipeByIdAsync(int id);
    Task<RecipeResult?> CreateRecipeAsync(CreateRecipeRequest request, string userId);
}
