namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class QuestionConfigurations : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasIndex(p => new { p.PollId, p.Content }).IsUnique();

        builder.Property(x => x.Content).HasMaxLength(1000);    
    }
}
