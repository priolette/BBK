using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Data.Models;
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

        group.WithTags("Recipes");

        // TODO
        //group.RequireAuthorization();

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
    private static async Task<Results<Ok<PagedResponse<RecipeResponse>>, IResult>> GetAllRecipesAsync(
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
        var recipes = result.Data.Select(r => r.ToResponse());

        var response = new PagedResponse<RecipeResponse>(recipes, pagination.PageNumber, pagination.PageSize, result.Total);

        return TypedResults.Ok(response);
    }
}