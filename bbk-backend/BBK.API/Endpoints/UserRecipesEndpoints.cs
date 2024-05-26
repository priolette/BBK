using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Contracts;
using BBK.API.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using BBK.API.Mappers;
using BBK.API.Services.UserRecipes;

namespace BBK.API.Endpoints;

public static class UserRecipesEndpoints
{
    public static IEndpointRouteBuilder MapUserRecipesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/user/recipes");

        group.MapGet("/", GetAllUserRecipesAsync);
        group.MapPost("/", CreateRecipeAsync);
        group.MapPut("/{recipeId}", UpdateRecipeAsync);
        group.MapDelete("/{recipeId}", DeleteRecipeAsync);

        group.RequireAuthorization();

        group.WithTags("User Recipes");

        group.WithOpenApi();

        return app;
    }

    /// <summary>
    /// This endpoints returns all recipes created by the user.
    /// </summary>
    /// <param name="userRecipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<List<RecipeResponse>>, IResult>> GetAllUserRecipesAsync(
        IUserRecipeService userRecipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var recipes = await userRecipeService.GetAllAsync(userId!);
        var response = recipes.Select(r => r.ToShortRecipeResponse(userId)).ToList();

        return TypedResults.Ok(response);
    }

    /// <summary>
    /// This endpoint creates a new recipe, as well as its ingredients and steps.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userRecipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<RecipeResponse>, IResult>> CreateRecipeAsync(
        CreateRecipeRequest request,
        IUserRecipeService userRecipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var result = await userRecipeService.CreateAsync(request, userId!);

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
    /// <param name="userRecipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<RecipeResponse>, IResult>> UpdateRecipeAsync(
        int recipeId,
        UpdateRecipeRequest request,
        IUserRecipeService userRecipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var result = await userRecipeService.UpdateAsync(recipeId, request, userId!);

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
    /// <param name="userRecipeService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok, IResult>> DeleteRecipeAsync(
        int recipeId,
        IUserRecipeService userRecipeService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var error = await userRecipeService.DeleteAsync(recipeId, userId!);

        if (error is not null)
        {
            return TypedResults.NotFound(new ErrorResponse(error));
        }

        return TypedResults.Ok();
    }
}
