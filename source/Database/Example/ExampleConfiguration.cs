namespace Architecture.Database;

public sealed class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.ToTable(nameof(Example), nameof(Example));

        builder.Property(entity => entity.Name).HasMaxLength(250).IsRequired();
    }
}
