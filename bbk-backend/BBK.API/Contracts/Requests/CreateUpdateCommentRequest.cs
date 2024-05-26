namespace BBK.API.Contracts.Requests;

public class CreateCommentRequest
{
    public required int RecipeId { get; init; }
    public required string Text { get; init; }
}

public class UpdateCommentRequest
{
    public required string Text { get; init; }
}