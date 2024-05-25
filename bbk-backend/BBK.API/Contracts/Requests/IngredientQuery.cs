namespace BBK.API.Contracts.Requests;

public record IngredientQuery
{
    public string? Search { get; init; }
}
