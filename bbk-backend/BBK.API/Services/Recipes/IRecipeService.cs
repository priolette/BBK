using BBK.API.Data.Models;
using BBK.API.Models;

namespace BBK.API.Services.Recipes;

public interface IRecipeService
{
    Task<ListResult<Recipe>> GetAllRecipesAsync(PaginationFilter? pagination);
}
