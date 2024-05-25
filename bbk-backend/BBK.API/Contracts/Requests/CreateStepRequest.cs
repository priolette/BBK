namespace BBK.API.Contracts.Requests;

public record CreateStepRequest
{
    public required string Description { get; set; }
    public required int Order { get; set; }
}
