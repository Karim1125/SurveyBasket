namespace SurveyBasket.Errors;

public static class PollErrors
{
    public static readonly Error PollNotFound =
        new("Poll.NotFound", "No poll found with the given ID");
}