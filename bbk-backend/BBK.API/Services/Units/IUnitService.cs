using BBK.API.Data.Models;

namespace BBK.API.Services.Units;

public interface IUnitService
{
    Task<List<Unit>> GetAllUnitsAsync();
}
