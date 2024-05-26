using BBK.API.Contracts.Responses;
using BBK.API.Models;

namespace BBK.API.Mappers;

public static class DomainToContract
{
    public static RecipeResponse ToRecipeResponse(this RecipeResult recipe, string? userId = null)
    {
        bool? isUpvoted = null;
        List<int>? userComments = null;

        if (userId is not null)
        {
            isUpvoted = recipe.Upvotes.Any(up => up.CreatedById == userId);
            userComments = recipe.Comments.Where(c => c.CreatedById == userId).Select(c => c.Id).ToList();
        }

        var ingredients = recipe.RecipeIngredients.Select(ToRecipeIngredientResponse).ToList();

        return new RecipeResponse
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            ImageUrl = recipe.ImageUrl,
            CreatedById = recipe.CreatedById,
            CreatedBy = recipe.CreatedBy?.ToUserResponse(),
            CreatedAt = recipe.CreatedAt,
            ModifiedAt = recipe.ModifiedAt,
            Ingredients = recipe.RecipeIngredients.Select(ToRecipeIngredientResponse).ToList(),
            Steps = recipe.Steps.Select(ModelToContract.ToStepResponse).ToList(),
            Upvotes = recipe.Upvotes.Count,
            IsUpvoted = isUpvoted,
            Comments = recipe.Comments.Select(ToCommentResponse).ToList(),
            UserComments = userComments
        };
    }

    public static ShortRecipeResponse ToShortRecipeResponse(this ShortRecipeResult result, string? userId = null)
    {
        bool? isUpvoted = userId is not null ? result.Recipe.Upvotes.Any(up => up.CreatedById == userId) : null;

        return new ShortRecipeResponse
        {
            Id = result.Recipe.Id,
            Title = result.Recipe.Title,
            Description = result.Recipe.Description,
            ImageUrl = result.Recipe.ImageUrl,
            CreatedById = result.Recipe.CreatedById,
            CreatedBy = result.User?.ToUserResponse(),
            CreatedAt = result.Recipe.CreatedAt,
            ModifiedAt = result.Recipe.ModifiedAt,
            Upvotes = result.Recipe.Upvotes.Count,
            IsUpvoted = isUpvoted
        };
    }

    public static RecipeIngredientResponse ToRecipeIngredientResponse(this RecipeIngredientResult ingredient)
    {
        return new RecipeIngredientResponse
        {
            Id = ingredient.Id,
            Amount = ingredient.Amount,
            Ingredient = ModelToContract.ToIngredientResponse(ingredient.Ingredient),
            Unit = ModelToContract.ToUnitResponse(ingredient.Unit)
        };
    }

    public static CommentResponse ToCommentResponse(this CommentResult comment)
    {
        return new CommentResponse
        {
            Id = comment.Id,
            RecipeId = comment.RecipeId,
            CreatedById = comment.CreatedById,
            CreatedBy = comment.CreatedBy?.ToUserResponse(),
            CreatedAt = comment.CreatedAt,
            Text = comment.Text
        };
    }

    public static UserResponse ToUserResponse(this AuthUser user)
    {
        return new UserResponse
        {
            Id = user.UserId,
            Email = user.Email,
            FullName = user.FullName,
            UserName = user.UserName,
            NickName = user.NickName,
            Picture = user.Picture
        };
    }
}
