using BBK.API.Data;
using BBK.API.Data.Models;

namespace BBK.API.Repositories.Steps;

public class StepsRepository(AppDbContext context) : IStepsRepository
{
    private readonly AppDbContext _context = context;

    public async Task UpdateRangeAsync(List<Step> steps)
    {
        _context.Steps.UpdateRange(steps);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<Step> steps)
    {
        _context.Steps.AddRange(steps);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(List<Step> steps)
    {
        _context.Steps.RemoveRange(steps);
        await _context.SaveChangesAsync();
    }
}
