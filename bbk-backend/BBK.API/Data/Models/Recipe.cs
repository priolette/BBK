using BBK.API.Contracts.Responses;

namespace BBK.API.Data.Models;

// TODO: this is an example model only
public class Recipe
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public static class RecipeExtensions
{
    public static RecipeResponse ToResponse(this Recipe model)
    {
        return new RecipeResponse
        {
            Name = model.Name,
            Description = model.Description
        };
    }
}