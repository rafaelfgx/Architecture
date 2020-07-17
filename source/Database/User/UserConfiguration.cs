using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.OwnsOne(x => x.FullName, y =>
            {
                y.Property(x => x.Name).HasColumnName(nameof(FullName.Name)).HasMaxLength(100).IsRequired();
                y.Property(x => x.Surname).HasColumnName(nameof(FullName.Surname)).HasMaxLength(200).IsRequired();
            });

            builder.OwnsOne(x => x.Email, y =>
            {
                y.Property(x => x.Value).HasColumnName(nameof(User.Email)).HasMaxLength(300).IsRequired();
                y.HasIndex(x => x.Value).IsUnique();
            });

            builder.HasOne(x => x.Auth);
        }
    }
}
