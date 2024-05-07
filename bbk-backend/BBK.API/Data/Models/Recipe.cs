using BBK.API.Contracts.Responses;

namespace BBK.API.Data.Models;

// TODO: this is an example model only
public class Recipe
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string CreatedById { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
}