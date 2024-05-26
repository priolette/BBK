namespace BBK.API.Data.Models;

public class Unit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public uint ConcurrecyToken { get; set; }

    public virtual ICollection<RecipeIngredient> IngredientAmounts { get; set; } = default!;
}
