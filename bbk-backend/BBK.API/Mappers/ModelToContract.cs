using BBK.API.Contracts.Responses;
using BBK.API.Data.Models;

namespace BBK.API.Mappers;

public static class ModelToContract
{
    public static CommentResponse ToCommentResponse(this Comment model)
    {
        return new CommentResponse
        {
            Id = model.Id,
            RecipeId = model.RecipeId,
            CreatedById = model.CreatedById,
            CreatedAt = model.CreatedAt,
            Text = model.Text
        };
    }

    public static StepResponse ToStepResponse(this Step model)
    {
        return new StepResponse
        {
            Id = model.Id,
            Description = model.Description,
            Order = model.Order
        };
    }

    public static IngredientResponse ToIngredientResponse(this Ingredient model)
    {
        return new IngredientResponse
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description
        };
    }

    public static UnitResponse ToUnitResponse(this Unit model)
    {
        return new UnitResponse
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code
        };
    }
}