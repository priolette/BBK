using BBK.API.Data.Models;

namespace BBK.API.Models;

public record ShortRecipeResult
{
    public required Recipe Recipe { get; init; }
    public AuthUser? User { get; init; }
}
