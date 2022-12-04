using DemoMovie.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.Repository.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Name).HasMaxLength(100);
            builder.Property(k => k.Lastname).HasMaxLength(100);
            builder.Property(k => k.UserName).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Password).IsRequired().HasMaxLength(100);

        }
    }
}
