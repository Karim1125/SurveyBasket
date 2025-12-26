using System.Security.Claims;

namespace SurveyBasket.Extensions;

public static class UserExtensions
{
    public static string? GetUserId(this System.Security.Claims.ClaimsPrincipal user) =>
        user.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
}