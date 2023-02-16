using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> modelBuilder)
        {
            modelBuilder.HasKey(f => f.FilmId);
            modelBuilder.Property(f => f.Name).HasMaxLength(255);
            modelBuilder.Property(f => f.Description).HasMaxLength(1000);
            modelBuilder.Property(f => f.Genre).HasMaxLength(255);
            modelBuilder.Property(f => f.PictureUrl).HasMaxLength(2000);
        }
    }
}
