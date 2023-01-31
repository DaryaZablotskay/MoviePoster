using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Configurations
{
    public class ShowDateConfiguration : IEntityTypeConfiguration<ShowDate>
    {
        public void Configure(EntityTypeBuilder<ShowDate> modelBuilder)
        {
            modelBuilder.HasKey(sd => sd.ShowDateId);
            modelBuilder.Property(sd => sd.ShowDateId).HasDefaultValueSql("NEWID()");
        }
    }
}
