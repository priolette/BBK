using BBK.API.Models;
using BBK.API.Repositories.Recipes;
using BBK.API.Services.Users;

namespace BBK.API.Services.Recipes;

public class RecipeService(
    IRecipesRepository repository,
    IUserService userService) : IRecipeService
{
    private readonly IUserService _userService = userService;
    private readonly IRecipesRepository _repository = repository;

    public async Task<ListResult<ShortRecipeResult>> GetAllRecipesAsync(PaginationFilter? pagination)
    {
        var listResult = await _repository.GetAllAsync(pagination);

        var userIds = listResult.Data.Select(r => r.CreatedById).ToArray();
        var users = await _userService.GetUsersByIdsAsync(userIds);

        var results = listResult.Data.Select(recipe => new ShortRecipeResult
        {
            Recipe = recipe,
            User = users.FirstOrDefault(u => u.UserId == recipe.CreatedById)
        }).ToList();

        return new ListResult<ShortRecipeResult>
        {
            Data = results,
            Total = listResult.Total
        };
    }

    public async Task<RecipeResult?> GetRecipeByIdAsync(int id)
    {
        var recipe = await _repository.GetByIdAsync(id);

        if (recipe is null)
        {
            return null;
        }

        var user = await _userService.GetUserByIdAsync(recipe.CreatedById);

        return new RecipeResult
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            ImageUrl = recipe.ImageUrl,
            CreatedById = recipe.CreatedById,
            CreatedBy = user,
            CreatedAt = recipe.CreatedAt,
            ModifiedAt = recipe.ModifiedAt,
            Steps = [.. recipe.Steps],
            RecipeIngredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientResult
            {
                Id = ri.Id,
                Amount = ri.Amount,
                Ingredient = ri.Ingredient,
                Unit = ri.Unit
            }).ToList(),
            Upvotes = [.. recipe.Upvotes],
            Comments = [.. recipe.Comments]
        };
    }
}
