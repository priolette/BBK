namespace BBK.API.Models;

public class AuthUser
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public bool? EmailVerified { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? FirstName { get; set; }
    public required string FullName { get; set; }
    public string? LastName { get; set; }
    public required string Picture { get; set; }
}