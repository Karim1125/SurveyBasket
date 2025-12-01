namespace SurveyBasket.Errors;

public static class VotesErrors
{
    public static readonly Error InvalidQuestions =
        new("Vote.InvalidQuestions", "Invalid questions", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicatedVote =
        new("Vote.DuplicatedVote", "This user has already voted in this poll before", StatusCodes.Status409Conflict);
}