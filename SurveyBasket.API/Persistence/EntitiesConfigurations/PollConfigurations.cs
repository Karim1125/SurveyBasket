namespace SurveyBasket.Persistence.EntitiesConfigurations;

public class PollConfigurations : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.HasIndex(p => p.Title).IsUnique();

        builder.Property(x => x.Title).HasMaxLength(200);
        builder.Property(x => x.Summary).HasMaxLength(1500);
    }
}