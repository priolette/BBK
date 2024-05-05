namespace BBK.API.Data.Models;
public class Ingredient
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public required string Name { get; set; }
    public int Amount { get; set; }
    public int UnitId { get; set; }
    public int StepId { get; set; }

    public virtual Recipe Recipe { get; set; } = default!;
    public virtual Unit Unit { get; set; } = default!;
    public virtual Step Step { get; set; } = default!;
}