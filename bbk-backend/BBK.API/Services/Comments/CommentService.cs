using BBK.API.Contracts;
using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;
using BBK.API.Models;
using BBK.API.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Comments;

public class CommentService(
    AppDbContext context,
    IUserService userService) : ICommentService
{
    private readonly AppDbContext _context = context;
    private readonly IUserService _userService = userService;

    public async Task<CommentResult> CreateAsync(CreateCommentRequest request, string userId)
    {
        var comment = new Comment
        {
            Text = request.Text,
            CreatedById = userId,
            RecipeId = request.RecipeId,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

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
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment is null || comment.CreatedById != userId)
        {
            return new UpdateCommentResult
            {
                Error = new ErrorResult(ErrorCodes.NotFound, "Comment not found")
            };
        }

        comment.Text = request.Text;
        await _context.SaveChangesAsync();

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
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment is null || comment.CreatedById != userId)
        {
            return new ErrorResult(ErrorCodes.NotFound, "Comment not found");
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();

        return null;
    }
}
