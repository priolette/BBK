using BBK.API.Contracts.Requests;
using BBK.API.Models;

namespace BBK.API.Services.Recipes;

public interface IRecipeService
{
    Task<ListResult<ShortRecipeResult>> GetAllRecipesAsync(PaginationFilter? pagination);
    Task<RecipeResult?> GetRecipeByIdAsync(int id);
    Task<CreateUpdateRecipeResult> CreateRecipeAsync(CreateRecipeRequest request, string userId);
    Task<CreateUpdateRecipeResult> UpdateRecipeAsync(int recipeId, UpdateRecipeRequest request, string userId);
    Task<ErrorResult?> DeleteRecipeAsync(int recipeId, string userId);
}
