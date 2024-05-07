namespace BBK.API.Contracts.Responses;

public record ShortRecipeResponse
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string CreatedById { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? ModifiedAt { get; init; }
}