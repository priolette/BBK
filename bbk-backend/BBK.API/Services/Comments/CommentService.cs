using BBK.API.Contracts;
using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;
using BBK.API.Models;
using BBK.API.Repositories.Comments;
using BBK.API.Services.Users;

namespace BBK.API.Services.Comments;

public class CommentService(
    ICommentsRepository commentsRepository,
    IUserService userService) : ICommentService
{
    private readonly IUserService _userService = userService;
    private readonly ICommentsRepository _commentsRepository = commentsRepository;

    public async Task<CommentResult> CreateAsync(CreateCommentRequest request, string userId)
    {
        var comment = new Comment
        {
            Text = request.Text,
            CreatedById = userId,
            RecipeId = request.RecipeId,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await _commentsRepository.CreateAsync(comment);

        var user = await _userService.GetUserByIdAsync(userId);

        return new CommentResult
        {
            Id = comment.Id,
            Text = comment.Text,
            RecipeId = comment.RecipeId,
            CreatedAt = comment.CreatedAt,
            CreatedById = comment.CreatedById,
            CreatedBy = user,
        };
    }

    public async Task<UpdateCommentResult> UpdateAsync(int commentId, UpdateCommentRequest request, string userId)
    {
        var comment = await _commentsRepository.GetByIdAsync(commentId);

        if (comment is null || comment.CreatedById != userId)
        {
            return new UpdateCommentResult
            {
                Error = new ErrorResult(ErrorCodes.NotFound, "Comment not found")
            };
        }

        comment.Text = request.Text;

        await _commentsRepository.UpdateAsync(comment);

        var user = await _userService.GetUserByIdAsync(userId);

        return new UpdateCommentResult
        {
            Comment = new CommentResult
            {
                Id = comment.Id,
                Text = comment.Text,
                RecipeId = comment.RecipeId,
                CreatedAt = comment.CreatedAt,
                CreatedById = comment.CreatedById,
                CreatedBy = user
            }
        };
    }

    public async Task<ErrorResult?> DeleteAsync(int commentId, string userId)
    {
        var comment = await _commentsRepository.GetByIdAsync(commentId);

        if (comment is null || comment.CreatedById != userId)
        {
            return new ErrorResult(ErrorCodes.NotFound, "Comment not found");
        }

        await _commentsRepository.DeleteAsync(comment);

        return null;
    }
}
