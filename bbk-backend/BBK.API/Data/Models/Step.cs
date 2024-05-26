namespace BBK.API.Data.Models;

public class Step
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public required string Description { get; set; }
    public required int Order { get; set; }
    public uint ConcurrecyToken { get; set; }

    public virtual Recipe Recipe { get; set; } = default!;
}
