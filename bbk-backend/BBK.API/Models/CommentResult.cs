namespace BBK.API.Models;

public record CommentResult
{
    public int Id { get; init; }
    public int RecipeId { get; init; }
    public required string CreatedById { get; init; }
    public AuthUser? CreatedBy { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required string Text { get; init; }
}
