using Microsoft.EntityFrameworkCore;
using MoviePoster.Dtos;
using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service
{
    public class FilmService : IFilmService
    {
        private readonly MovieContext _movieContext;
        private readonly IFilmRepository _filmRepository;

        public FilmService(MovieContext movieContext, IFilmRepository filmRepository)
        {
            _movieContext = movieContext;
            _filmRepository = filmRepository;
        }

        public async Task<IEnumerable<FilmCatalogeDto>> GetFilmCataloge()
        {
            var filmCataloge = await (from film in _movieContext.Films
                                select new FilmCatalogeDto
                                {
                                    FilmCatalogeId = film.FilmId,
                                    NameCataoge = film.Name,
                                    GenreCataloge = film.Genre,
                                    AgeLimitCataloge = film.AgeLimit,
                                    PictureUrlCataloge = film.PictureUrl,
                                    PriceCataloge = film.Price
                                }).ToListAsync();
            return filmCataloge;
        }

        public async Task<OneFilmDto> GetOneFilm(Guid oneFilmId)
        {
            var oneFilm = await (from film in _movieContext.Films
                           select new OneFilmDto
                           {
                               OneFilmId = film.FilmId,
                               OneFilmName = film.Name,
                               OneFilmGenre = film.Genre,
                               OneFilmAgeLimit = film.AgeLimit,
                               OneFilmPictureUrl = film.PictureUrl,
                               OneFilmDuration = film.Duration,
                               OneFilmDescription = film.Description,
                               OneFilmRating = film.Rating,
                               OneFilmPrice = film.Price
                           }).FirstAsync(ofd => ofd.OneFilmId == oneFilmId);
            return oneFilm;
        }

        public async Task AddFilms(AdminAddFillmDto entity)
        {
            var newFilm = new Film
            {
                Name = entity.FilmName,
                Genre = entity.Genre,
                AgeLimit = entity.AgeLimit,
                Duration = entity.Duration,
                Description = entity.Description,
                PictureUrl = entity.PictureUrl,
                Rating = entity.Rating,
                Price = entity.Price
            };
            await _filmRepository.Add(newFilm);
            await _filmRepository.Save();
        }

        public async Task DeleteFilm(AdminDeleteFilmDto entity)
        {
            var existFilm = await _filmRepository.GetAll().SingleOrDefaultAsync(f => f.Name == entity.FilmName);
            _movieContext.Films.Remove(existFilm);
            await _filmRepository.Save();
        }
    }
}