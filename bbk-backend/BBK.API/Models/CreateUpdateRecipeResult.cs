namespace BBK.API.Models;

public record CreateUpdateRecipeResult
{
    public RecipeResult? Recipe { get; init; }
    public ErrorResult? Error { get; init; }
}
