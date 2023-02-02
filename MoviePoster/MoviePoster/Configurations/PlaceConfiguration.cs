using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> modelBuilder)
        {
            modelBuilder.HasKey(p => p.PlaceId);
            modelBuilder.Property(p => p.PlaceId).HasDefaultValueSql("NEWID()");
        }
    }
}
