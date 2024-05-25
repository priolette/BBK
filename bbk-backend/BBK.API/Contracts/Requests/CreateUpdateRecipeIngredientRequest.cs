namespace BBK.API.Contracts.Requests;

public record CreateRecipeIngredientRequest
{
    public int IngredientId { get; set; }
    public int UnitId { get; set; }
    public double Amount { get; set; }
}

public record UpdateRecipeIngredientRequest
{
    public int? Id { get; set; }
    public int? IngredientId { get; set; }
    public int? UnitId { get; set; }
    public double? Amount { get; set; }
}
