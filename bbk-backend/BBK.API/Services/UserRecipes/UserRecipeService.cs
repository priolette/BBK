using BBK.API.Contracts.Requests;
using BBK.API.Contracts;
using BBK.API.Data.Models;
using BBK.API.Models;
using Microsoft.EntityFrameworkCore;
using BBK.API.Data;
using BBK.API.Services.Recipes;
using BBK.API.Services.RecipeIngredients;
using BBK.API.Services.Steps;
using BBK.API.Services.Users;

namespace BBK.API.Services.UserRecipes;

public class UserRecipeService(
    AppDbContext context,
    IRecipeService recipeService,
    IRecipeIngredientService recipeIngredientService,
    IStepService stepService,
    IUserService userService,
    ILogger<UserRecipeService> logger) : IUserRecipeService
{
    private readonly AppDbContext _context = context;
    private readonly ILogger<UserRecipeService> _logger = logger;
    private readonly IRecipeService _recipeService = recipeService;
    private readonly IRecipeIngredientService _recipeIngredientService = recipeIngredientService;
    private readonly IStepService _stepService = stepService;
    private readonly IUserService _userService = userService;

    public async Task<List<ShortRecipeResult>> GetAllAsync(string userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        return await _context.Recipes
            .Include(x => x.Upvotes)
            .Where(x => x.CreatedById == userId)
            .OrderBy(r => r.Title)
            .Select(r => new ShortRecipeResult
            {
                Recipe = r,
                User = user
            })
            .ToListAsync();
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
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
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
        var recipe = await _context.Recipes
            .Include(r => r.RecipeIngredients)
            .Include(r => r.Steps)
            .FirstOrDefaultAsync(r => r.Id == recipeId && r.CreatedById == userId);

        if (recipe is null)
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
            await _context.SaveChangesAsync();
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
        var recipe = await _context.Recipes
            .FirstOrDefaultAsync(r => r.Id == recipeId && r.CreatedById == userId);

        if (recipe is null)
        {
            return new ErrorResult(ErrorCodes.NotFound, "Recipe not found");
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();

        return null;
    }
}
