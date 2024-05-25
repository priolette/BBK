namespace BBK.API.Contracts.Responses;

public class UserResponse
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public required string FullName { get; set; }
    public required string Picture { get; set; }
}
