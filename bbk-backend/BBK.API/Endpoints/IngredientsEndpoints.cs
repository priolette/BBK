
using BBK.API.Contracts;
using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Mappers;
using BBK.API.Models;
using BBK.API.Services.Ingredients;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BBK.API.Endpoints;

public static class IngredientsEndpoints
{
    public static IEndpointRouteBuilder MapIngredientsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/ingredients");

        group.MapGet("/", GetAllIngredientsAsync);
        group.MapPost("/", CreateIngredientAsync);

        group.RequireAuthorization();

        group.WithTags("Ingredients");

        group.WithOpenApi();

        return app;
    }

    /// <summary>
    /// This endpoint returns a list of ingredients by query.
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <param name="query"></param>
    /// <param name="ingredientService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<PagedResponse<IngredientResponse>>, IResult>> GetAllIngredientsAsync(
        [AsParameters] PaginationQuery paginationQuery,
        [AsParameters] IngredientQuery query,
        IIngredientService ingredientService,
        HttpContext context)
    {
        var pagination = new PaginationFilter
        {
            PageNumber = paginationQuery.PageNumber ?? 1,
            PageSize = paginationQuery.PageSize ?? 100
        };

        var result = await ingredientService.GetAllIngredientsAsync(query, pagination);
        var ingredients = result.Data.Select(i => i.ToIngredientResponse());

        var response = new PagedResponse<IngredientResponse>(ingredients, pagination.PageNumber, pagination.PageSize, result.Total);

        return TypedResults.Ok(response);
    }

    /// <summary>
    /// This endpont creates a new ingredient.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ingredientService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<IngredientResponse>, IResult>> CreateIngredientAsync(
        CreateIngredientRequest request,
        IIngredientService ingredientService,
        HttpContext context)
    {
        var ingredient = await ingredientService.CreateIngredientAsync(request);

        if (ingredient is null)
        {
            return TypedResults.BadRequest(
                new ErrorResponse(ErrorCodes.FailedToCreate, "Failed to create ingredient."));
        }

        return TypedResults.Ok(ingredient.ToIngredientResponse());
    }
}
