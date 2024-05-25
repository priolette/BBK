namespace BBK.API.Contracts.Requests;

public record IngredientQuery
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}
