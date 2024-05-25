using System.Security.Claims;

namespace BBK.API.Extensions;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        var principal = httpContext.User;

        if (principal == null)
        {
            return string.Empty;
        }

        string value = principal.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

        return value;
    }
}
