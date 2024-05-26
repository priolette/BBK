namespace BBK.API.Models;

public record UpdateCommentResult
{
    public CommentResult? Comment { get; init; }
    public ErrorResult? Error { get; init; }
}
