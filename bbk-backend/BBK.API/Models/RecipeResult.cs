using BBK.API.Data.Models;

namespace BBK.API.Models;

public class RecipeResult
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public required string CreatedById { get; set; }
    public AuthUser? CreatedBy { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public List<Step> Steps { get; set; } = [];
    public List<RecipeIngredientResult> RecipeIngredients { get; set; } = [];
    public List<Upvote> Upvotes { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
}

public class RecipeIngredientResult
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public Ingredient Ingredient { get; set; } = default!;
    public Unit Unit { get; set; } = default!;
}
