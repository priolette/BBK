using BBK.API.Contracts.Requests;
using BBK.API.Models;

namespace BBK.API.Services.Comments;

public interface ICommentService
{
    Task<CommentResult> CreateAsync(CreateCommentRequest request, string userId);
    Task<UpdateCommentResult> UpdateAsync(int commentId, UpdateCommentRequest request, string userId);
    Task<ErrorResult?> DeleteAsync(int commentId, string userId);
}
