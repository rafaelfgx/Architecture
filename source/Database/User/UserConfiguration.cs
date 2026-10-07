namespace Architecture.Database;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), nameof(User));

        builder.Property(entity => entity.Name).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Email).HasMaxLength(250).IsRequired();

        builder.HasIndex(entity => entity.Email).IsUnique();
    }
}
