using BBK.API.Contracts.Requests;
using BBK.API.Data;
using BBK.API.Data.Models;

namespace BBK.API.Services.Steps;

public class StepService(AppDbContext dbContext, ILogger<StepService> logger) : IStepService
{
    private readonly AppDbContext _context = dbContext;
    private readonly ILogger<StepService> _logger = logger;

    public async Task<List<Step>> UpdateStepsAsync(int recipeId, List<UpdateStepRequest> requestSteps, List<Step> dbSteps)
    {
        var stepsToAdd = requestSteps
            .Where(request => !dbSteps.Any(s => s.Id == request.Id))
            .Select(request => new Step
            {
                RecipeId = recipeId,
                Description = request.Description ?? throw new InvalidOperationException("Step description is required"),
                Order = request.Order ?? throw new InvalidOperationException("Step order is required")
            });

        var stepsToDelete = dbSteps
            .Where(s => !requestSteps.Any(request => request.Id == s.Id))
            .ToList();

        var stepsToUpdate = dbSteps
            .Where(s => requestSteps.Any(request => request.Id == s.Id))
            .ToList();

        foreach (var step in stepsToUpdate)
        {
            var request = requestSteps.First(request => request.Id == step.Id);

            step.Description = request.Description ?? step.Description;
            step.Order = request.Order ?? step.Order;
        }

        _context.Steps.AddRange(stepsToAdd);
        _context.Steps.RemoveRange(stepsToDelete);
        _context.Steps.UpdateRange(stepsToUpdate);

        await _context.SaveChangesAsync();

        return [.. stepsToUpdate, .. stepsToAdd];
    }
}
