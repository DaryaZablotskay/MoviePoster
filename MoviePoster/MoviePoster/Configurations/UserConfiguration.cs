using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(u => u.UserId);
            modelBuilder.Property(u => u.UserId).HasDefaultValueSql("NEWID()");
            modelBuilder.Property(u => u.FirstName).HasMaxLength(255);
            modelBuilder.Property(u => u.LastName).HasMaxLength(255);
            modelBuilder.Property(u => u.Email).HasMaxLength(255);
        }
    }
}
