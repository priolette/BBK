namespace BBK.API.Data.Models;

public class RecipeIngredient
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public int UnitId { get; set; }
    public double Amount { get; set; }
    
    public virtual Recipe Recipe { get; set; } = default!;
    public virtual Ingredient Ingredient { get; set; } = default!;
    public virtual Unit Unit { get; set; } = default!;
}
