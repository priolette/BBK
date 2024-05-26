using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Repositories.Recipes;

public class RecipesRepository(AppDbContext context) : IRecipesRepository
{
    private readonly AppDbContext _context = context;

    public async Task<ListResult<Recipe>> GetAllAsync(PaginationFilter? pagination)
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

        return new ListResult<Recipe>
        {
            Data = recipes,
            Total = total
        };
    }

    public Task<Recipe?> GetByIdAsync(int id)
    {
        return _context.Recipes
            .Include(x => x.Upvotes)
            .Include(x => x.Comments)
            .Include(x => x.RecipeIngredients).ThenInclude(x => x.Ingredient)
            .Include(x => x.RecipeIngredients).ThenInclude(x => x.Unit)
            .Include(x => x.Steps)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Recipe>> GetByUserIdAsync(string userId)
    {
        return _context.Recipes
            .Include(x => x.Upvotes)
            .Where(x => x.CreatedById == userId)
            .OrderBy(r => r.Title)
            .ToListAsync();
    }

    public async Task CreateAsync(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}
