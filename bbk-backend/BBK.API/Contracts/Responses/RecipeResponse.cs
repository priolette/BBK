namespace BBK.API.Contracts.Responses;

public record RecipeResponse
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public string? ImageUrl { get; init; }
    public required string CreatedById { get; init; }
    public UserResponse? CreatedBy { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? ModifiedAt { get; init; }
    public required List<RecipeIngredientResponse> Ingredients { get; init; } = [];
    public required List<StepResponse> Steps { get; init; } = [];
    public required int Upvotes { get; init; }
    public bool? IsUpvoted { get; init; }
    public required List<CommentResponse> Comments { get; init; } = [];
    public List<int>? UserComments { get; init; }
}
