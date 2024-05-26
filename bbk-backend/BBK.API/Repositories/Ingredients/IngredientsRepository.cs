using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Repositories.Ingredients;

public class IngredientsRepository(AppDbContext context) : IIngredientsRepository
{
    private readonly AppDbContext _context = context;

    public async Task<ListResult<Ingredient>> GetAllAsync(IngredientQuery filter, PaginationFilter? pagination)
    {
        var query = _context.Ingredients
            .OrderBy(i => i.Name);

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            query = (IOrderedQueryable<Ingredient>)query.Where(q => EF.Functions.ILike(q.Name, '%' + filter.Search + '%') ||
                (q.Description != null ? EF.Functions.ILike(q.Description, '%' + filter.Search + '%') : false));
        }

        var total = await query.CountAsync();

        if (pagination is not null)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = (IOrderedQueryable<Ingredient>)query.Skip(skip).Take(pagination.PageSize);
        }

        var ingredients = await query.ToListAsync();

        return new ListResult<Ingredient>
        {
            Data = ingredients,
            Total = total
        };
    }

    public async Task CreateAsync(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
    }
}
