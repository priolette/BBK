namespace BBK.API.Data.Models;

public class Recipe
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string CreatedById { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }

    public virtual ICollection<Step> Steps { get; set; } = default!;
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = default!;
    public virtual ICollection<Upvote> Upvotes { get; set; } = default!;
    public virtual ICollection<Comment> Comments { get; set; } = default!;
}