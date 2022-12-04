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
    internal class MovieOfferConfiguration : IEntityTypeConfiguration<MovieOffer>
    {
        public void Configure(EntityTypeBuilder<MovieOffer> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.ToMail).IsRequired();
            builder.Property(k => k.UserId).IsRequired();
            builder.Property(k => k.MovieId).IsRequired();
        }
    }
}
