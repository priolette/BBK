namespace BBK.API.Contracts.Responses;

public record UnitResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
}
