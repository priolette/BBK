using BBK.API.Contracts.Responses;
using BBK.API.Data.Models;

namespace BBK.API.Mappers;

public static class ModelToContract
{
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