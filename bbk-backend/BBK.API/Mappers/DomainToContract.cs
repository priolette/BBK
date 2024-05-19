using BBK.API.Contracts.Responses;
using BBK.API.Models;

namespace BBK.API.Mappers;

public static class DomainToContract
{
    public static RecipeResponse ToRecipeResponse(this RecipeResult recipe)
    {
        var ingredients = recipe.RecipeIngredients.Select(ToRecipeIngredientResponse).ToList();

        return new RecipeResponse
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            CreatedById = recipe.CreatedById,
            CreatedAt = recipe.CreatedAt,
            ModifiedAt = recipe.ModifiedAt,
            Ingredients = recipe.RecipeIngredients.Select(ToRecipeIngredientResponse).ToList(),
            Steps = recipe.Steps.Select(ModelToContract.ToStepResponse).ToList(),
            Upvotes = recipe.Upvotes.Count,
            Comments = recipe.Comments.Select(ModelToContract.ToCommentResponse).ToList()
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
}
