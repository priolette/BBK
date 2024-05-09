using BBK.API.Contracts.Responses;
using BBK.API.Data.Models;

namespace BBK.API.Mappers;

public static class RecipesMapper
{
    public static RecipeResponse ToRecipeResponse(this Recipe model)
    {
        return new RecipeResponse
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            CreatedById = model.CreatedById,
            CreatedAt = model.CreatedAt,
            ModifiedAt = model.ModifiedAt,
            Comments = model.Comments.ToList(),
            Ingredients = model.Ingredients.ToList()
        };
    }
    
    public static ShortRecipeResponse ToShortRecipeResponse(this Recipe model)
    {
        return new ShortRecipeResponse
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            CreatedById = model.CreatedById,
            CreatedAt = model.CreatedAt,
            ModifiedAt = model.ModifiedAt
        };
    }
}