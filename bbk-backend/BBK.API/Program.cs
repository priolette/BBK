using BBK.API;
using BBK.API.Contracts.Responses;
using BBK.API.Endpoints;
using Microsoft.AspNetCore.Diagnostics;

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
// Custom handling for request deserialization exceptions.
app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (exception is BadHttpRequestException)
        {
            var badRequestResult = TypedResults.BadRequest(new ErrorResponse
            {
                Code = "BadRequest",
                Message = "Invalid request body.",
            });

            await badRequestResult.ExecuteAsync(context);
            return;
        }

        await Results.Problem().ExecuteAsync(context);
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Endpoint mapping
app.MapGroup("/api/v1")
    .MapUnitsEndpoints()
    .MapIngredientsEndpoints()
    .MapRecipesEndpoints();

app.Run();
