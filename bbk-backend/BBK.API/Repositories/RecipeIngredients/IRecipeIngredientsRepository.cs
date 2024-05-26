using BBK.API.Data.Models;

namespace BBK.API.Repositories.RecipeIngredients;

public interface IRecipeIngredientsRepository
{
    Task AddRange(List<RecipeIngredient> ingredients);
    Task UpdateRange(List<RecipeIngredient> ingredients);
    Task RemoveRange(List<RecipeIngredient> ingredients);
}
