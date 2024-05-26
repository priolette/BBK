using BBK.API.Data.Models;

namespace BBK.API.Repositories.Comments;

public interface ICommentsRepository
{
    Task<Comment?> GetByIdAsync(int id);
    Task CreateAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}
