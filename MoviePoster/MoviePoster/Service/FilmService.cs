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
                                    PictureUrlCataloge = film.PictureUrl,
                                    PriceCataloge = film.Price
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
                               OneFilmRating = film.Rating,
                               OneFilmPrice = film.Price
                           }).First(ofd => ofd.OneFilmId == oneFilmId);
            return oneFilm;
        }

        public IEnumerable<ShowDatesDto> GetTimeForOneFilm(Guid oneFilmId)
        {
            var dates = (from film in _movieContext.Films
                         join ticket in _movieContext.Tickets on film.FilmId equals ticket.FilmId
                         join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                         select new ShowDatesDto
                         {
                             ShowDatesDtoId = showDate.ShowDateId,
                             FilmId = film.FilmId,
                             Time = showDate.Date
                         }).Where(sdd => sdd.FilmId == oneFilmId).Distinct().ToList();
            return dates;
        }

        public IEnumerable<PlacesDto> GetPlaces(Guid oneFilmId, Guid showDateId)
        {
            var places = (from place in _movieContext.Places
                          join ticket in _movieContext.Tickets on place.PlaceId equals ticket.PlaceId
                          join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                          join film in _movieContext.Films on ticket.FilmId equals film.FilmId
                          select new PlacesDto
                          {
                              FilmDtoId = film.FilmId,
                              ShowDateDtoId = showDate.ShowDateId,
                              PlaceDtoId = film.FilmId,
                              HallDto = place.Hall,
                              RowNumberDto = place.RowNumber,
                              SeatNumberDto = place.SeatNumber,
                              Status = place.Status
                          })
                          .Where(pd => pd.FilmDtoId == oneFilmId)
                          .Where(pd => pd.ShowDateDtoId == showDateId)
                          .ToList();
            return places;
        }
    }
}