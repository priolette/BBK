using BBK.API.Data.Models;
using BBK.API.Repositories.Upvotes;

namespace BBK.API.Services.Upvotes;

public class UpvoteService(IUpvotesRepository repository) : IUpvoteService
{
    private readonly IUpvotesRepository _repository = repository;

    public async Task<bool> CreateOrDeleteAsync(int recipeId, string userId)
    {
        var existingUpvote = await _repository.GetByUserAndRecipeIdAsync(userId, recipeId);

        if (existingUpvote is null)
        {
            var upvote = new Upvote
            {
                RecipeId = recipeId,
                CreatedById = userId
            };

            await _repository.CreateAsync(upvote);
            return true;
        }

        await _repository.DeleteAsync(existingUpvote);
        return false;
    }
}
