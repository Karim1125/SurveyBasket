namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class VoteAnswerConfigurations : IEntityTypeConfiguration<VoteAnswer>
{
    public void Configure(EntityTypeBuilder<VoteAnswer> builder)
    {
        builder.HasIndex(p => new { p.VoteId, p.QuestionId }).IsUnique();
    }
}