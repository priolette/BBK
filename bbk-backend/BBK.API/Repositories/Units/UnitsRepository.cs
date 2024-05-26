using BBK.API.Data;
using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Repositories.Units;

public class UnitsRepository(AppDbContext context) : IUnitsRepository
{
    private readonly AppDbContext _context = context;

    public Task<List<Unit>> GetAllAsync()
    {
        return _context.Units
            .OrderBy(u => u.Name)
            .ToListAsync();
    }
}
