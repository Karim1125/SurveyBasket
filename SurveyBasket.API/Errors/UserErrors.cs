namespace SurveyBasket.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials = 
        new("User.InvalidCredentials", "Invalid email/password");
    public static readonly Error InvalidToken =
        new("User.InvalidToken", "Invalid token");
    public static readonly Error TokenNotFound =
        new("User.TokenNotFound", "Refresh token not found");
}
