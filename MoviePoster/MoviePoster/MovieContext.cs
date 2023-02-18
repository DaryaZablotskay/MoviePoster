using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviePoster.Configurations;
using MoviePoster.Helpers;
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
        public DbSet<ShowDate> ShowDates { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Role> Roles { get; set; }

        public MovieContext(DbContextOptions<MovieContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new ShowDateConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            var film = SeedData.GenerateFilms();
            var place = SeedData.GeneratePlaces();
            var showDate = SeedData.GenerateShowDates();
            var ticket = SeedData.GenerateTickets();
            var role = SeedData.GenerateRoles();
            var admin = SeedData.GenerateAdmin();

            modelBuilder.Entity<Film>().HasData(film);
            modelBuilder.Entity<Place>().HasData(place);
            modelBuilder.Entity<ShowDate>().HasData(showDate);
            modelBuilder.Entity<Ticket>().HasData(ticket);
            modelBuilder.Entity<Role>().HasData(role);
            modelBuilder.Entity<User>().HasData(admin);
        }
    }
}