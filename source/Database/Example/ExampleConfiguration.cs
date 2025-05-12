namespace Architecture.Database;

public sealed class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.ToTable(nameof(Example), nameof(Example));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Name).HasMaxLength(250).IsRequired();
    }
}
