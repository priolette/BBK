using BBK.API.Data;
using BBK.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BBK.API.Services.Units;

public class UnitService(AppDbContext context) : IUnitService
{
    private readonly AppDbContext _context = context;

    public Task<List<Unit>> GetAllUnitsAsync()
    {
        return _context.Units
            .OrderBy(u => u.Name)
            .ToListAsync();
    }
}
