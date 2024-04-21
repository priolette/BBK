namespace BBK.API.Contracts.Responses;

public record ErrorResponse
{
    public required string Message { get; init; }
    public required string Code { get; init; }
}
