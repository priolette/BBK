namespace BBK.API.Data.Models;

public class Comment
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public required string CreatedById { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required string Text { get; set; }

    public virtual Recipe Recipe { get; set; } = default!;
}
