namespace BBK.API.Data.Models;

public class Upvote
{
    public int RecipeId { get; set; }
    public required string CreatedById { get; set; }

    public virtual Recipe Recipe { get; set; } = default!;
}
