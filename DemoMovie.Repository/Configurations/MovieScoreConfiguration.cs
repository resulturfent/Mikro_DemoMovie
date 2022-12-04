using DemoMovie.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.Repository.Configurations
{
    internal class MovieScoreConfiguration : IEntityTypeConfiguration<MovieScore>
    {
        public void Configure(EntityTypeBuilder<MovieScore> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Score).IsRequired().HasColumnType("decimal(5,2)");
            builder.Property(k => k.MoviesId).IsRequired();
            builder.Property(k => k.UserId).IsRequired();

        }
    }
}
