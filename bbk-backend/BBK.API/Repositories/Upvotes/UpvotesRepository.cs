using BBK.API.Data;
using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Repositories.Upvotes;

public class UpvotesRepository(AppDbContext context) : IUpvotesRepository
{
    private readonly AppDbContext _context = context;

    public Task<Upvote?> GetByUserAndRecipeIdAsync(string userId, int recipeId)
    {
        return _context.Upvotes
            .FirstOrDefaultAsync(x => x.RecipeId == recipeId && x.CreatedById == userId);
    }

    public async Task CreateAsync(Upvote upvote)
    {
        _context.Upvotes.Add(upvote);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Upvote upvote)
    {
        _context.Upvotes.Remove(upvote);
        await _context.SaveChangesAsync();
    }
}
