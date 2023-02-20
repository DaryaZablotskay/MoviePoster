using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> modelBuilder)
        {
            modelBuilder.HasKey(t => t.TicketId);

            modelBuilder.HasOne(t => t.ShowDate)
                        .WithMany(sd => sd.Tickets)
                        .HasForeignKey(t => t.ShowDateId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(t => t.Film)
                        .WithMany(f => f.Tickets)
                        .HasForeignKey(t => t.FilmId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(t => t.User)
                        .WithMany(u => u.Tickets)
                        .HasForeignKey(t => t.UserId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.HasOne(t => t.Place)
                        .WithMany(p => p.Tickets)
                        .HasForeignKey(t => t.PlaceId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasIndex(t => new { t.UserId, t.FilmId, t.ShowDateId, t.PlaceId }).IsUnique();
        }
    }
}
