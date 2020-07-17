using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.ToTable("Auths", "Auth");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Login).IsUnique();

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Salt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Roles).IsRequired();
        }
    }
}
