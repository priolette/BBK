using BBK.API.Data;
using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Upvotes;

public class UpvoteService(AppDbContext context) : IUpvoteService
{
    private readonly AppDbContext _context = context;

    public async Task<bool> CreateOrDeleteAsync(int recipeId, string userId)
    {
        var existingUpvote = await _context.Upvotes
            .FirstOrDefaultAsync(x => x.RecipeId == recipeId && x.CreatedById == userId);

        bool isUpvoted;
        if (existingUpvote is null)
        {
            var upvote = new Upvote
            {
                RecipeId = recipeId,
                CreatedById = userId
            };

            _context.Upvotes.Add(upvote);
            isUpvoted = true;
        }
        else
        {
            _context.Upvotes.Remove(existingUpvote);
            isUpvoted = false;
        }

        await _context.SaveChangesAsync();

        return isUpvoted;
    }
}
