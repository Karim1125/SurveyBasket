namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class AnswerConfigurations : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasIndex(p => new { p.QuestionId, p.Content }).IsUnique();

        builder.Property(x => x.Content).HasMaxLength(1000);
    }
}