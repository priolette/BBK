namespace BBK.API.Data.Models;

public class Step
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public required string Description { get; set; }

    public virtual Recipe Recipe { get; set; } = default!;
    public virtual ICollection<Ingredient> Ingredients { get; set; } = default!;

}
