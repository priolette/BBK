using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;

namespace BBK.API.Services.Steps;

public interface IStepService
{
    Task<List<Step>> UpdateStepsAsync(int recipeId, List<UpdateStepRequest> requestSteps, List<Step> dbSteps);
}
