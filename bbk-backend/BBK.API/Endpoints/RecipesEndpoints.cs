using BBK.API.Contracts;
using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Extensions;
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
        group.MapPost("/", CreateRecipeAsync).RequireAuthorization();
        group.MapPut("/{recipeId}", UpdateRecipeAsync).RequireAuthorization();
        group.MapDelete("/{recipeId}", DeleteRecipeAsync).RequireAuthorization();

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
    /// This endpoint returns a recipe by id
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

    /// <summary>
    /// This endpoint creates a new recipe, as well as its ingredients and steps.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="recipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<RecipeResponse>, IResult>> CreateRecipeAsync(
        CreateRecipeRequest request,
        IRecipeService recipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var result = await recipeService.CreateRecipeAsync(request, userId);

        if (result.Error is not null)
        {
            return TypedResults.BadRequest(new ErrorResponse(result.Error));
        }

        return TypedResults.Ok(result.Recipe!.ToRecipeResponse());
    }

    /// <summary>
    /// This endpoint updates a recipe, as well as its ingredients and steps (if provided).
    /// </summary>
    /// <param name="recipeId"></param>
    /// <param name="request"></param>
    /// <param name="recipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<RecipeResponse>, IResult>> UpdateRecipeAsync(
        int recipeId,
        UpdateRecipeRequest request,
        IRecipeService recipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var result = await recipeService.UpdateRecipeAsync(recipeId, request, userId);

        if (result.Error is not null)
        {
            return result.Error.Code switch
            {
                ErrorCodes.NotFound => TypedResults.NotFound(new ErrorResponse(result.Error)),
                ErrorCodes.BadRequest => TypedResults.BadRequest(new ErrorResponse(result.Error)),
                _ => TypedResults.Problem()
            };
        }

        return TypedResults.Ok(result.Recipe!.ToRecipeResponse());
    }

    /// <summary>
    /// This endpoints deletes a user's recipe by id.
    /// </summary>
    /// <param name="recipeId"></param>
    /// <param name="recipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok, IResult>> DeleteRecipeAsync(
        int recipeId,
        IRecipeService recipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var error = await recipeService.DeleteRecipeAsync(recipeId, userId);

        if (error is not null)
        {
            return TypedResults.NotFound(new ErrorResponse(error));
        }

        return TypedResults.Ok();
    }
}