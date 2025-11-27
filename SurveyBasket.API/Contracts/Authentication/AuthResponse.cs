namespace SurveyBasket.Contracts.Authentication;

public record AuthResponse(
    string Id,
    string? Email,
    string Firstname,
    string Lastname,
    string Token,
    int ExpiresIn
);
