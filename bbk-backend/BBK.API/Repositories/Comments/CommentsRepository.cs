using BBK.API.Data;
using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Repositories.Comments;

public class CommentsRepository(AppDbContext context) : ICommentsRepository
{
    private readonly AppDbContext _context = context;

    public Task<Comment?> GetByIdAsync(int id)
    {
        return _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
