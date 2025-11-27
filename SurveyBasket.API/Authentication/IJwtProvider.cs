namespace SurveyBasket.Authentication;

public interface IJwtProvider
{
    (string token, int expiresIn) generateToken(ApplicationUser user);
}
