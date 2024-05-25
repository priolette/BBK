using BBK.API.Data;
using BBK.API.Models;
using BBK.API.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Recipes;

public class RecipeService(
    AppDbContext dbContext,
    IUserService userService) : IRecipeService
{
    private readonly AppDbContext _context = dbContext;
    private readonly IUserService _userService = userService;

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
            .FirstOrDefaultAsync();

        if (recipe is null)
        {
            return null;
        }

        var user = await _userService.GetUserByIdAsync(recipe.CreatedById);
        recipe.CreatedBy = user;

        return recipe;
    }
}
