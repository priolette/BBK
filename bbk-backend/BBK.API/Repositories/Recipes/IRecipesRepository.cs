using BBK.API.Data.Models;
using BBK.API.Models;

namespace BBK.API.Repositories.Recipes;

public interface IRecipesRepository
{
    Task<ListResult<Recipe>> GetAllAsync(PaginationFilter? pagination);
    Task<Recipe?> GetByIdAsync(int id);
    Task<List<Recipe>> GetByUserIdAsync(string userId);
    Task CreateAsync(Recipe recipe);
    Task UpdateAsync(Recipe recipe);
    Task DeleteAsync(Recipe recipe);
}
