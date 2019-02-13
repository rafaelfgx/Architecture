using DotNetCoreArchitecture.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserLogEntityConfiguration : IEntityTypeConfiguration<UserLogEntity>
    {
        public void Configure(EntityTypeBuilder<UserLogEntity> builder)
        {
            builder.ToTable("UsersLogs", "User");

            builder.HasKey(x => x.UserLogId);

            builder.Property(x => x.UserLogId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LogType).IsRequired();
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(8000);
            builder.Property(x => x.DateTime).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UsersLogs).HasForeignKey(x => x.UserId);
        }
    }
}
