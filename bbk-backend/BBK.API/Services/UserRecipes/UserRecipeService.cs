using BBK.API.Contracts.Requests;
using BBK.API.Contracts;
using BBK.API.Data.Models;
using BBK.API.Models;
using Microsoft.EntityFrameworkCore;
using BBK.API.Services.Recipes;
using BBK.API.Services.RecipeIngredients;
using BBK.API.Services.Steps;
using BBK.API.Services.Users;
using BBK.API.Repositories.Recipes;
using BBK.API.Data;

namespace BBK.API.Services.UserRecipes;

public class UserRecipeService(
    AppDbContext context,
    IRecipesRepository repository,
    IRecipeService recipeService,
    IRecipeIngredientService recipeIngredientService,
    IStepService stepService,
    IUserService userService,
    ILogger<UserRecipeService> logger) : IUserRecipeService
{
    private readonly ILogger<UserRecipeService> _logger = logger;
    private readonly AppDbContext _context = context;
    private readonly IRecipesRepository _repository = repository;
    private readonly IRecipeService _recipeService = recipeService;
    private readonly IRecipeIngredientService _recipeIngredientService = recipeIngredientService;
    private readonly IStepService _stepService = stepService;
    private readonly IUserService _userService = userService;

    public async Task<List<ShortRecipeResult>> GetAllAsync(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        var recipes = await _repository.GetByUserIdAsync(userId);

        return recipes.Select(r => new ShortRecipeResult
        {
            Recipe = r,
            User = user
        }).ToList();
    }

    public async Task<CreateUpdateRecipeResult> CreateAsync(CreateRecipeRequest request, string userId)
    {
        var recipe = new Recipe
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            CreatedById = userId,
            CreatedAt = DateTimeOffset.UtcNow,
            RecipeIngredients = request.Ingredients.Select(i => new RecipeIngredient
            {
                IngredientId = i.IngredientId,
                UnitId = i.UnitId,
                Amount = i.Amount
            }).ToList(),
            Steps = request.Steps.Select(s => new Step
            {
                Description = s.Description,
                Order = s.Order
            }).ToList()
        };

        try
        {
            await _repository.CreateAsync(recipe);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create recipe");

            return new CreateUpdateRecipeResult
            {
                Error = new ErrorResult(ErrorCodes.FailedToCreate, "Failed to create recipe")
            };
        }

        return new CreateUpdateRecipeResult
        {
            Recipe = await _recipeService.GetRecipeByIdAsync(recipe.Id)
        };
    }

    public async Task<CreateUpdateRecipeResult> UpdateAsync(int recipeId, UpdateRecipeRequest request, string userId)
    {
        var recipe = await _repository.GetByIdAsync(recipeId);

        if (recipe is null || recipe.CreatedById != userId)
        {
            return new CreateUpdateRecipeResult
            {
                Error = new ErrorResult(ErrorCodes.NotFound, "Recipe not found")
            };
        }

        using var transaction = _context.Database.BeginTransaction();

        recipe.Title = request.Title ?? recipe.Title;
        recipe.Description = request.Description ?? recipe.Description;
        recipe.ImageUrl = request.ImageUrl ?? recipe.ImageUrl;
        recipe.ModifiedAt = DateTimeOffset.UtcNow;

        try
        {
            await _repository.UpdateAsync(recipe);
        }
        catch (DbUpdateConcurrencyException)
        {
            transaction.Rollback();
            throw;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError(ex, "Failed to update recipe");
            throw;
        }

        if (request.Ingredients is not null)
        {
            try
            {
                await _recipeIngredientService.UpdateRecipeIngredientsAsync(recipe.Id, [.. request.Ingredients], [.. recipe.RecipeIngredients]);
            }
            catch (InvalidOperationException ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Failed to update recipe ingredients");

                return new CreateUpdateRecipeResult
                {
                    Error = new ErrorResult(ErrorCodes.BadRequest, ex.Message)
                };
            }
            catch (DbUpdateConcurrencyException)
            {
                transaction.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Failed to update recipe ingredients");
                throw;
            }
        }

        if (request.Steps is not null)
        {
            try
            {
                await _stepService.UpdateStepsAsync(recipe.Id, [.. request.Steps], [.. recipe.Steps]);
            }
            catch (InvalidOperationException ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Failed to update recipe steps");

                return new CreateUpdateRecipeResult
                {
                    Error = new ErrorResult(ErrorCodes.BadRequest, ex.Message)
                };
            }
            catch (DbUpdateConcurrencyException)
            {
                transaction.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Failed to update recipe steps");
                throw;
            }
        }

        transaction.Commit();

        return new CreateUpdateRecipeResult
        {
            Recipe = await _recipeService.GetRecipeByIdAsync(recipe.Id)
        };
    }

    public async Task<ErrorResult?> DeleteAsync(int recipeId, string userId)
    {
        var recipe = await _repository.GetByIdAsync(recipeId);

        if (recipe is null || recipe.CreatedById != userId)
        {
            return new ErrorResult(ErrorCodes.NotFound, "Recipe not found");
        }

        await _repository.DeleteAsync(recipe);

        return null;
    }
}
