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
        var query = _context.Recipes.AsQueryable();

        // TODO: add other filtering options

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
    
    public Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        return _context.Recipes
            .Include(x => x.Ingredients)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
