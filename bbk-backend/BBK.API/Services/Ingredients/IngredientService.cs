using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using BBK.API.Repositories.Ingredients;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Ingredients;

public class IngredientService(
    IIngredientsRepository repository,
    ILogger<IngredientService> logger) : IIngredientService
{
    private readonly ILogger<IngredientService> _logger = logger;
    private readonly IIngredientsRepository _repository = repository;

    public Task<ListResult<Ingredient>> GetAllIngredientsAsync(IngredientQuery filter, PaginationFilter? pagination)
    {
        return _repository.GetAllAsync(filter, pagination);
    }

    public async Task<Ingredient?> CreateIngredientAsync(CreateIngredientRequest request)
    {
        var ingredient = new Ingredient
        {
            Name = request.Name,
            Description = request.Description
        };

        try
        {
            await _repository.CreateAsync(ingredient);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating ingredient");
            return null;
        }

        return ingredient;
    }
}
