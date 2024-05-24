using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Mappers;
using BBK.API.Models;
using BBK.API.Services.Recipes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BBK.API.Endpoints;

public static class RecipesEndpoints
{
    public static IEndpointRouteBuilder MapRecipesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/recipes");

        group.MapGet("/", GetAllRecipesAsync);
        group.MapGet("/{recipeId}", GetRecipeByIdAsync);

        group.WithTags("Recipes");

        group.WithOpenApi();

        return app;
    }

    /// <summary>
    /// This endpoint returns all recipes.
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <param name="recipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<PagedResponse<ShortRecipeResponse>>, IResult>> GetAllRecipesAsync(
        [AsParameters] PaginationQuery paginationQuery,
        IRecipeService recipeService,
        HttpContext context)
    {
        var pagination = new PaginationFilter
        {
            PageNumber = paginationQuery.PageNumber ?? 1,
            PageSize = paginationQuery.PageSize ?? 10
        };

        var result = await recipeService.GetAllRecipesAsync(pagination);
        var recipes = result.Data.Select(r => r.ToShortRecipeResponse());

        var response = new PagedResponse<ShortRecipeResponse>(recipes, pagination.PageNumber, pagination.PageSize, result.Total);

        return TypedResults.Ok(response);
    }

    /// <summary>
    /// This endpoint return recipe by id
    /// </summary>
    /// <param name="recipeId"></param>
    /// <param name="recipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<RecipeResponse>, IResult>> GetRecipeByIdAsync(
        int recipeId,
        IRecipeService recipeService,
        HttpContext context)
    {
        var recipe = await recipeService.GetRecipeByIdAsync(recipeId);

        if (recipe is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(recipe.ToRecipeResponse());
    }
}