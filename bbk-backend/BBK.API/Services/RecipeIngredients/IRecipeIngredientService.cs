using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;

namespace BBK.API.Services.RecipeIngredients;

public interface IRecipeIngredientService
{
    Task<List<RecipeIngredient>> UpdateRecipeIngredientsAsync(int recipeId, List<UpdateRecipeIngredientRequest> requests, List<RecipeIngredient> recipeIngredients);
}
