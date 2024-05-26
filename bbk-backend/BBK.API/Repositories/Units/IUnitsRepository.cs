using BBK.API.Data.Models;

namespace BBK.API.Repositories.Units;

public interface IUnitsRepository
{
    Task<List<Unit>> GetAllAsync();
}
