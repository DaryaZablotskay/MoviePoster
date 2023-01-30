using MoviePoster.Dtos;
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
        public FilmService(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IEnumerable<FilmCatalogeDto> GetFilmCataloge()
        {
            var filmCataloge = (from film in _movieContext.Films
                                select new FilmCatalogeDto
                                {
                                    FilmCatalogeId = film.FilmId,
                                    NameCataoge = film.Name,
                                    GenreCataloge = film.Genre,
                                    AgeLimitCataloge = film.AgeLimit,
                                    PictureUrlCataloge = film.PictureUrl
                                }).ToList();
            return filmCataloge;
        }

        public OneFilmDto GetOneFilm(Guid oneFilmId)
        {
            var oneFilm = (from film in _movieContext.Films
                           select new OneFilmDto
                           {
                               OneFilmId = film.FilmId,
                               OneFilmName = film.Name,
                               OneFilmGenre = film.Genre,
                               OneFilmAgeLimit = film.AgeLimit,
                               OneFilmPictureUrl = film.PictureUrl,
                               OneFilmDuration = film.Duration,
                               OneFilmDescription = film.Description,
                               OneFilmRating = film.Rating
                           }).Where(ofd => ofd.OneFilmId == oneFilmId).First();
            return oneFilm;
        }

        public IEnumerable<ShowDatesDto> GetTimeForOneFilm(Guid oneFilmId)
        {
            var dates = (from film in _movieContext.Films
                         join showDate in _movieContext.ShowDates on film.FilmId equals showDate.FilmId
                         select new ShowDatesDto
                         {
                             ShowDatesDtoId = showDate.ShowDateId,
                             FilmId = film.FilmId,
                             Time = showDate.Date
                         }).Where(sdd => sdd.FilmId == oneFilmId).ToList();
            return dates;
        }
    }
}