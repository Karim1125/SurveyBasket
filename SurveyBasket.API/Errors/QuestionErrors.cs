namespace SurveyBasket.Errors;

public record QuestionErrors
{
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No question was found with the given ID", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedQuestionContent =
        new("Poll.DuplicatedContent", "Another question with the same content is already exists", StatusCodes.Status404NotFound);
}