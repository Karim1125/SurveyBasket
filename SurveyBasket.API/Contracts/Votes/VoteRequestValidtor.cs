namespace SurveyBasket.Contracts.Votes;

public class VoteRequestValidtor : AbstractValidator<VoteRequest>
{
    public VoteRequestValidtor()
    {
        RuleFor(vr => vr.Answers)
            .NotEmpty();

        RuleForEach(vr => vr.Answers)
            .SetInheritanceValidator(v => v.Add(new VoteAnswerRequestValidator()));
    }
}
