namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class VoteConfigurations : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasIndex(p => new { p.PollId, p.UserId }).IsUnique();
    }
}