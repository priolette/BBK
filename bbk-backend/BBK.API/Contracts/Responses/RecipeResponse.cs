﻿using BBK.API.Data.Models;

namespace BBK.API.Contracts.Responses;

public record RecipeResponse
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string CreatedById { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? ModifiedAt { get; init; }
    public List<Comment>? Comments { get; init; }
    public required List<Ingredient> Ingredients { get; init; }
}
