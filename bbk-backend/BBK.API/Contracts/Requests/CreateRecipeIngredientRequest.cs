namespace BBK.API.Contracts.Requests;

public record CreateRecipeIngredientRequest
{
    public int IngredientId { get; set; }
    public int UnitId { get; set; }
    public double Amount { get; set; }
}
