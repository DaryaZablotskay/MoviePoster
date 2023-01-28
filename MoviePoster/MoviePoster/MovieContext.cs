using Microsoft.EntityFrameworkCore;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster
{
    public class MovieContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<FilmUser> FilmUsers { get; set; }

        public MovieContext(DbContextOptions<MovieContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(255);

            modelBuilder.Entity<Place>().HasKey(p => p.PlaceId);
            modelBuilder.Entity<Place>().Property(p => p.PlaceId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Place>()
                .HasOne(p => p.User)
                .WithMany(u => u.Places)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Film>().HasKey(f => f.FilmId);
            modelBuilder.Entity<Film>().Property(f => f.FilmId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Film>().Property(f => f.Name).HasMaxLength(255);
            modelBuilder.Entity<Film>().Property(f => f.AgeLimit).HasMaxLength(255);
            modelBuilder.Entity<Film>().Property(f => f.Duration).HasMaxLength(255);
            modelBuilder.Entity<Film>().Property(f => f.Description).HasMaxLength(1000);
            modelBuilder.Entity<Film>().Property(f => f.Genre).HasMaxLength(255);
            modelBuilder.Entity<Film>().Property(f => f.PictureUrl).HasMaxLength(2000);

            modelBuilder.Entity<FilmUser>().HasKey(fu => fu.FilmUserId);
            modelBuilder.Entity<FilmUser>().Property(fu => fu.FilmUserId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<FilmUser>()
                .HasOne(fu => fu.Film)
                .WithMany(f => f.FilmUsers)
                .HasForeignKey(fu => fu.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmUser>()
               .HasOne(fu => fu.User)
               .WithMany(u => u.FilmUsers)
               .HasForeignKey(fu => fu.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FilmUser>().HasIndex(fu => new { fu.UserId, fu.FilmId }).IsUnique();

            modelBuilder.Entity<ShowDate>().HasKey(sd => sd.ShowDateId);
            modelBuilder.Entity<ShowDate>().Property(sd => sd.ShowDateId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ShowdateFilm>().HasKey(sdf => sdf.ShowdateFilmId);
            modelBuilder.Entity<ShowdateFilm>().Property(sdf => sdf.ShowdateFilmId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ShowdateFilm>()
                .HasOne(sdf => sdf.Film)
                .WithMany(f => f.ShowdateFilms)
                .HasForeignKey(sdf => sdf.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShowdateFilm>()
               .HasOne(sdf => sdf.ShowDate)
               .WithMany(sd => sd.ShowdateFilms)
               .HasForeignKey(sdf => sdf.ShowDateId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShowdateFilm>().HasIndex(sdf => new { sdf.ShowDateId, sdf.FilmId }).IsUnique();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-C122T4K;Database=MoviePoster;Trusted_Connection=True;");
        }
    }
}