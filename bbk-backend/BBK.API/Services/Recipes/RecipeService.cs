using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Recipes;

public class RecipeService(AppDbContext dbContext) : IRecipeService
{
    private readonly AppDbContext _context = dbContext;

    public async Task<ListResult<Recipe>> GetAllRecipesAsync(PaginationFilter? pagination)
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

        var data = await query.ToListAsync();

        return new ListResult<Recipe>
        {
            Data = data,
            Total = total
        };
    }
    
    public Task<RecipeResult?> GetRecipeByIdAsync(int id)
    {
        // TODO: fix this
        return _context.Recipes
            .Select(r => new RecipeResult
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
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
    }
}
