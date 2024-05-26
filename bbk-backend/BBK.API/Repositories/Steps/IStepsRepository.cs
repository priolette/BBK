using BBK.API.Data.Models;

namespace BBK.API.Repositories.Steps;

public interface IStepsRepository
{
    Task AddRangeAsync(List<Step> steps);
    Task UpdateRangeAsync(List<Step> steps);
    Task RemoveRangeAsync(List<Step> steps);
}
