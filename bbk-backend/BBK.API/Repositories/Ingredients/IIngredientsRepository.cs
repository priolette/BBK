using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;
using BBK.API.Models;

namespace BBK.API.Repositories.Ingredients;

public interface IIngredientsRepository
{
    Task<ListResult<Ingredient>> GetAllAsync(IngredientQuery filter, PaginationFilter? pagination);
    Task CreateAsync(Ingredient ingredient);
}
