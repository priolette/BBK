﻿using BBK.API.Contracts;
using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using BBK.API.Services.RecipeIngredients;
using BBK.API.Services.Steps;
using BBK.API.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Recipes;

public class RecipeService(
    AppDbContext dbContext,
    IUserService userService,
    IRecipeIngredientService recipeIngredientService,
    IStepService stepService,
    ILogger<RecipeService> logger) : IRecipeService
{
    private readonly AppDbContext _context = dbContext;
    private readonly IUserService _userService = userService;
    private readonly IRecipeIngredientService _recipeIngredientService = recipeIngredientService;
    private readonly IStepService _stepService = stepService;
    private readonly ILogger<RecipeService> _logger = logger;

    public async Task<ListResult<ShortRecipeResult>> GetAllRecipesAsync(PaginationFilter? pagination)
    {
        var query = _context.Recipes
            .Include(x => x.Upvotes)
            .AsQueryable();

        var total = await query.CountAsync();
        query = query.OrderBy(r => r.Title);

        if (pagination is not null)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);
        }

        var recipes = await query.ToListAsync();

        var userIds = recipes.Select(r => r.CreatedById).ToArray();
        var users = await _userService.GetUsersByIdsAsync(userIds);

        var results = recipes.Select(recipe => new ShortRecipeResult
        {
            Recipe = recipe,
            User = users.FirstOrDefault(u => u.UserId == recipe.CreatedById)
        }).ToList();

        return new ListResult<ShortRecipeResult>
        {
            Data = results,
            Total = total
        };
    }

    public async Task<RecipeResult?> GetRecipeByIdAsync(int id)
    {
        // TODO: fix this
        var recipe = await _context.Recipes
            .Select(r => new RecipeResult
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                ImageUrl = r.ImageUrl,
                CreatedById = r.CreatedById,
                CreatedAt = r.CreatedAt,
                ModifiedAt = r.ModifiedAt,
                Steps = r.Steps.ToList(),
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientResult
                {
                    Id = ri.Id,
                    Amount = ri.Amount,
                    Ingredient = ri.Ingredient,
                    Unit = ri.Unit
                }).ToList(),
                Upvotes = r.Upvotes.ToList(),
                Comments = r.Comments.ToList()
            })
            .FirstOrDefaultAsync(x => x.Id == id);

        if (recipe is null)
        {
            return null;
        }

        var user = await _userService.GetUserByIdAsync(recipe.CreatedById);
        recipe.CreatedBy = user;

        return recipe;
    }

    public async Task<CreateUpdateRecipeResult> CreateRecipeAsync(CreateRecipeRequest request, string userId)
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
            Recipe = await GetRecipeByIdAsync(recipe.Id)
        };
    }

    public async Task<CreateUpdateRecipeResult> UpdateRecipeAsync(int recipeId, UpdateRecipeRequest request, string userId)
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
            Recipe = await GetRecipeByIdAsync(recipe.Id)
        };
    }

    public async Task<ErrorResult?> DeleteRecipeAsync(int recipeId, string userId)
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
