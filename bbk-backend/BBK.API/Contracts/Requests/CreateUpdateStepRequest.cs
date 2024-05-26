namespace BBK.API.Contracts.Requests;

public record CreateStepRequest
{
    public required string Description { get; init; }
    public required int Order { get; init; }
}

public record UpdateStepRequest
{
    public int? Id { get; init; }
    public string? Description { get; init; }
    public int? Order { get; init; }
}