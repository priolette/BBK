using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;
using BBK.API.Models;

namespace BBK.API.Services.Ingredients;

public interface IIngredientService
{
    Task<ListResult<Ingredient>> GetAllIngredientsAsync(IngredientQuery filter, PaginationFilter? pagination);
    Task<Ingredient?> CreateIngredientAsync(CreateIngredientRequest request);
}
