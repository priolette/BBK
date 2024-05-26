using BBK.API.Models;

namespace BBK.API.Services.Upvotes;

public interface IUpvoteService
{
    Task<bool> CreateOrDeleteAsync(int recipeId, string userId);
}
