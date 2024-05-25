namespace BBK.API.Contracts.Requests;

public record CreateRecipeRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public string? ImageUrl { get; init; }
    public required CreateRecipeIngredientRequest[] Ingredients { get; init; }
    public required CreateStepRequest[] Steps { get; init; }
}

public record UpdateRecipeRequest
{
    public required int Id { get; set; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public required UpdateRecipeIngredientRequest[]? Ingredients { get; init; }
    public required UpdateStepRequest[]? Steps { get; init; }
}