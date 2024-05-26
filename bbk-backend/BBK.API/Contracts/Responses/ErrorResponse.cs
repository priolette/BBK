using BBK.API.Models;

namespace BBK.API.Contracts.Responses;

public record ErrorResponse
{
    public string Message { get; init; }
    public string Code { get; init; }

    public ErrorResponse(string code, string message)
    {
        Message = message;
        Code = code;
    }

    public ErrorResponse(ErrorResult error)
    {
        Message = error.Message ?? string.Empty;
        Code = error.Code;
    }
}
