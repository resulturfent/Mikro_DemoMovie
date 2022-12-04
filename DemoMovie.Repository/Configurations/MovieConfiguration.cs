using DemoMovie.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMovie.Repository.Configurations
{
    internal class MovieConfiguration:IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.MovieName).IsRequired().HasMaxLength(6000);
            builder.Property(k => k.AverageScore).HasColumnType("decimal(5,2)");


            //builder.HasOne(k => k.MovieCategory).WithMany(k => k.Movies).HasForeignKey(k => k.MovieCategory);//1-çok ilişki tanımlaması yapıldı. EF kurallarına göre yazıldığından ayrıca bu işlemlere ihtiyaç duyulmadı.

            builder.ToTable("Movie");
        }
    }
}
