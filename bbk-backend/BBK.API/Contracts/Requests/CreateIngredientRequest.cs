namespace BBK.API.Contracts.Requests;

public class CreateIngredientRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
