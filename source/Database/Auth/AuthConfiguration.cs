namespace Architecture.Database;

public sealed class AuthConfiguration : IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.ToTable(nameof(Auth), nameof(Auth));

        builder.Property(entity => entity.Login).HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Password).HasMaxLength(1000).IsRequired();

        builder.Property(entity => entity.Salt).HasMaxLength(1000);

        builder.Property(entity => entity.Roles);

        builder.HasOne(entity => entity.User).WithOne().HasForeignKey<Auth>("UserId").IsRequired();

        builder.HasIndex(entity => entity.Login).IsUnique();

        builder.HasIndex(entity => entity.Salt).IsUnique();

        builder.HasIndex("UserId").IsUnique();
    }
}
