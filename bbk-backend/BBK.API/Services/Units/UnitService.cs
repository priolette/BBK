using BBK.API.Data.Models;
using BBK.API.Repositories.Units;

namespace BBK.API.Services.Units;

public class UnitService(IUnitsRepository repository) : IUnitService
{
    private readonly IUnitsRepository _repository = repository;

    public Task<List<Unit>> GetAllUnitsAsync()
    {
        return _repository.GetAllAsync();
    }
}
