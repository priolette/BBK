using BBK.API.Models;

namespace BBK.API.Services.Users;

public interface IUserService
{
    Task<AuthUser?> GetUserByIdAsync(string userId);
    Task<List<AuthUser>> GetUsersByIdsAsync(string[] userIds);
}
