using BBK.API.Contracts.Requests;
using BBK.API.Models;

namespace BBK.API.Services.UserRecipes;

public interface IUserRecipeService
{
    Task<List<ShortRecipeResult>> GetAllAsync(string userId);
    Task<CreateUpdateRecipeResult> CreateAsync(CreateRecipeRequest request, string userId);
    Task<CreateUpdateRecipeResult> UpdateAsync(int recipeId, UpdateRecipeRequest request, string userId);
    Task<ErrorResult?> DeleteAsync(int recipeId, string userId);
}
