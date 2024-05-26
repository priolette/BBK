using BBK.API;
using BBK.API.Contracts;
using BBK.API.Contracts.Responses;
using BBK.API.Endpoints;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// See: HostingExtensions.cs
builder.AddConfiguration();
builder.AddSerilog();
builder.AddDatabase();
builder.AddAuth();
builder.AddAuth0ManagementApi();
builder.AddApplicationServices();
builder.AddOpenApi();

var app = builder.Build();

// Handler for any uncaught exceptions.
app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (exception is BadHttpRequestException)
        {
            var badRequestResult = TypedResults.BadRequest(
                new ErrorResponse(ErrorCodes.BadRequest, "Invalid request body."));

            await badRequestResult.ExecuteAsync(context);
            return;
        }
        else if (exception is DbUpdateConcurrencyException)
        {
            var concurrencyResult = TypedResults.Conflict(
                new ErrorResponse(ErrorCodes.ConcurrencyError, "The resource has been modified by another user."));

            await concurrencyResult.ExecuteAsync(context);
            return;
        }

        await Results.Problem().ExecuteAsync(context);
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Endpoint mapping
app.MapGroup("/api/v1")
    .MapRecipesEndpoints()
    .MapUserRecipesEndpoints()
    .MapIngredientsEndpoints()
    .MapUnitsEndpoints()
    .MapInteractionsEndpoints();

app.Run();
