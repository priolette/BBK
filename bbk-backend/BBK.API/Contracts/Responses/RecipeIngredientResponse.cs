namespace BBK.API.Contracts.Responses;

public record RecipeIngredientResponse
{
    public int Id { get; init; }
    public double Amount { get; init; }
    public required IngredientResponse Ingredient { get; init; }
    public required UnitResponse Unit { get; init; }
}
