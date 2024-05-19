namespace BBK.API.Contracts.Responses;

public record CommentResponse
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public required string CreatedById { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required string Text { get; set; }
}
