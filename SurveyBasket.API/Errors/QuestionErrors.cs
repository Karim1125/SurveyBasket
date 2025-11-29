namespace SurveyBasket.Errors;

public static class QuestionErrors
{
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No question was found with the given ID");

    public static readonly Error DuplicatedQuestionContent =
        new("Poll.DuplicatedContent", "Another question with the same content is already exists");
}