
using BBK.API.Contracts.Requests;
using BBK.API.Contracts.Responses;
using BBK.API.Extensions;
using BBK.API.Models;
using BBK.API.Services.Comments;
using BBK.API.Services.Upvotes;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BBK.API.Endpoints;

public static class InteractionsEndpoints
{
    public static IEndpointRouteBuilder MapInteractionsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/interactions");

        group.MapPost("/comments", CreateCommentAsync);
        group.MapPut("/comments/{commentId}", UpdateCommentAsync);
        group.MapDelete("/comments/{commentId}", DeleteCommentAsync);
        group.MapPost("/recipes/{recipeId}/upvote", ToggleUpvoteAsync);

        group.RequireAuthorization();

        group.WithTags("Interactions");

        group.WithOpenApi();

        return app;
    }

    private static async Task<Results<Ok<CommentResult>, IResult>> CreateCommentAsync(
        CreateCommentRequest request,
        ICommentService commentService,
        HttpContext context)
    {
        var userId = context.GetUserId();
        var comment = await commentService.CreateAsync(request, userId!);

        return TypedResults.Ok(comment);
    }

    private static async Task<Results<Ok<CommentResult>, IResult>> UpdateCommentAsync(
        int commentId,
        UpdateCommentRequest request,
        ICommentService commentService,
        HttpContext context)
    {
        var userId = context.GetUserId();

        var result = await commentService.UpdateAsync(commentId, request, userId!);

        if (result.Error is not null)
        {
            return TypedResults.NotFound(new ErrorResponse(result.Error));
        }

        return TypedResults.Ok(result.Comment!);
    }

    private static async Task<Results<Ok, IResult>> DeleteCommentAsync(
        int commentId,
        ICommentService commentService,
        HttpContext context)
    {
        var userId = context.GetUserId();
        var error = await commentService.DeleteAsync(commentId, userId!);

        if (error is not null)
        {
            return TypedResults.NotFound(new ErrorResponse(error));
        }

        return TypedResults.Ok();
    }

    private static async Task<Results<Ok<bool>, IResult>> ToggleUpvoteAsync(
        int recipeId,
        IUpvoteService upvoteService,
        HttpContext context)
    {
        var userId = context.GetUserId();
        var isUpvoted = await upvoteService.CreateOrDeleteAsync(recipeId, userId!);

        return TypedResults.Ok(isUpvoted);
    }
}
