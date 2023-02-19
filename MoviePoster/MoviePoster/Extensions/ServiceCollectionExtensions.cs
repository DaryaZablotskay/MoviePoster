using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviePoster.EmailHelper;
using MoviePoster.EmailHelper.Interfaces;
using MoviePoster.Repositories;
using MoviePoster.Repositories.Interfaces;
using MoviePoster.Service;
using MoviePoster.Service.Interface;

namespace MoviePoster.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IShowDateRepository, ShowDateRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();

            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}
