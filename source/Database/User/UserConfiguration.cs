namespace Architecture.Database;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), nameof(User));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Name).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Email).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Status).IsRequired();

        builder.HasIndex(entity => entity.Email).IsUnique();
    }
}
