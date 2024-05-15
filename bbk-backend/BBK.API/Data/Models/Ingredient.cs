namespace BBK.API.Data.Models;
public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<RecipeIngredient> IngredientAmounts { get; set; } = default!;
}