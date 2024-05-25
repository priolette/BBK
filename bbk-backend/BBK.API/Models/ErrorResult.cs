namespace BBK.API.Models;

public record ErrorResult
{
    public string Code { get; init; }
    public string? Message { get; init; }

    public ErrorResult(string code, string? message = null)
    {
        Code = code;
        Message = message;
    }
}
