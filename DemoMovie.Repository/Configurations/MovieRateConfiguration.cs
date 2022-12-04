using DemoMovie.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMovie.Repository.Configurations
{
    public class MovieRateConfiguration : IEntityTypeConfiguration<MovieRate>
    {
        public void Configure(EntityTypeBuilder<MovieRate> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Comment).IsRequired().HasMaxLength(6000);
            builder.Property(k => k.Score).IsRequired();

        }
    }
}
