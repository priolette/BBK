﻿using BBK.API.Contracts.Requests;
using BBK.API.Data.Models;
using BBK.API.Repositories.Steps;

namespace BBK.API.Services.Steps;

public class StepService(
    IStepsRepository repository) : IStepService
{
    private readonly IStepsRepository _repository = repository;

    public async Task<List<Step>> UpdateStepsAsync(int recipeId, List<UpdateStepRequest> requestSteps, List<Step> dbSteps)
    {
        var stepsToAdd = requestSteps
            .Where(request => !dbSteps.Any(s => s.Id == request.Id))
            .Select(request => new Step
            {
                RecipeId = recipeId,
                Description = request.Description ?? throw new InvalidOperationException("Step description is required"),
                Order = request.Order ?? throw new InvalidOperationException("Step order is required")
            })
            .ToList();

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

        await _repository.AddRangeAsync(stepsToAdd);
        await _repository.UpdateRangeAsync(stepsToUpdate);
        await _repository.RemoveRangeAsync(stepsToDelete);

        return [.. stepsToUpdate, .. stepsToAdd];
    }
}
