using Auth0.Core.Exceptions;
using Auth0.ManagementApi;
using BBK.API.Models;

namespace BBK.API.Services.Users;

public class UserService(
    IManagementApiClient apiClient,
    ILogger<UserService> logger) : IUserService
{
    private readonly IManagementApiClient _apiClient = apiClient;
    private readonly ILogger<UserService> _logger = logger;

    public async Task<AuthUser?> GetUserByIdAsync(string userId)
    {
        try
        {
            var user = await _apiClient.Users.GetAsync(userId);

            if (user is null)
            {
                return null;
            }

            return new AuthUser
            {
                UserId = user.UserId,
                Email = user.Email,
                EmailVerified = user.EmailVerified,
                FirstName = user.FirstName,
                FullName = user.FullName,
                LastName = user.LastName,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber,
                Picture = user.Picture,
                UserName = user.UserName
            };
        }
        catch (ErrorApiException ex)
        {
            _logger.LogWarning(ex, "Failed getting user by id: {UserId}", userId);
            return null;
        }
    }

    public async Task<List<AuthUser>> GetUsersByIdsAsync(string[] userIds)
    {
        var userTasks = userIds.Select(GetUserByIdAsync);
        var users = await Task.WhenAll(userTasks);

        var foundUsers = users
            .Where(user => user is not null)
            .Select(u => u!);

        if (!foundUsers.Any())
        {
            return [];
        }

        return foundUsers.ToList();
    }
}
