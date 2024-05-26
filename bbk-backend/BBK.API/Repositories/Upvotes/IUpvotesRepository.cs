using BBK.API.Data.Models;

namespace BBK.API.Repositories.Upvotes;

public interface IUpvotesRepository
{
    Task<Upvote?> GetByUserAndRecipeIdAsync(string userId, int recipeId);
    Task CreateAsync(Upvote upvote);
    Task DeleteAsync(Upvote upvote);
}
