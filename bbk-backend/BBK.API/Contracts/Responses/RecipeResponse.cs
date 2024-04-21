namespace BBK.API.Contracts.Responses;

public record RecipeResponse
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}
