
using BBK.API.Contracts.Responses;
using BBK.API.Mappers;
using BBK.API.Services.Units;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BBK.API.Endpoints;

public static class UnitsEndpoints
{
    public static IEndpointRouteBuilder MapUnitsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/units");

        group.MapGet("/", GetAllUnitsAsync);

        group.RequireAuthorization();

        group.WithTags("Units");

        group.WithOpenApi();

        return app;
    }

    /// <summary>
    /// This endpoints returns all units
    /// </summary>
    /// <param name="unitService"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    private static async Task<Results<Ok<List<UnitResponse>>, IResult>> GetAllUnitsAsync(
        IUnitService unitService,
        HttpContext context)
    {
        var units = await unitService.GetAllUnitsAsync();
        var response = units.Select(u => u.ToUnitResponse());

        return TypedResults.Ok(response);
    }
}
