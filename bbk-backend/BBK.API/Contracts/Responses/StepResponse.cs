namespace BBK.API.Contracts.Responses;

public record StepResponse
{
    public int Id { get; init; }
    public required string Description { get; init; }
    public required int Order { get; init; }
}
