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
        private readonly IUserRepository _userRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IShowDateRepository _showDateRepository;
        private readonly ITicketRepository _ticketRepository;

        public FilmService(MovieContext movieContext, IUserRepository userRepository, IPlaceRepository placeRepository, IShowDateRepository showDateRepository, ITicketRepository ticketRepository)
        {
            _movieContext = movieContext;
            _userRepository = userRepository;
            _placeRepository = placeRepository;
            _showDateRepository = showDateRepository;
            _ticketRepository = ticketRepository;
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

        public async Task<IEnumerable<ShowDatesDto>> GetTimeForOneFilm(Guid oneFilmId)
        {
            var dates = await (from film in _movieContext.Films
                         join ticket in _movieContext.Tickets on film.FilmId equals ticket.FilmId
                         join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                         select new ShowDatesDto
                         {
                             ShowDatesDtoId = showDate.ShowDateId,
                             FilmId = film.FilmId,
                             Time = showDate.Date
                         }).Where(sdd => sdd.FilmId == oneFilmId).Distinct().ToListAsync();
            return dates;
        }

        public async Task<IEnumerable<PlacesDto>> GetPlaces(Guid oneFilmId, Guid showDateId)
        {
            var places = await (from place in _movieContext.Places
                          join ticket in _movieContext.Tickets on place.PlaceId equals ticket.PlaceId
                          join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                          join film in _movieContext.Films on ticket.FilmId equals film.FilmId
                          select new PlacesDto
                          {
                              FilmDtoId = film.FilmId,
                              ShowDateDtoId = showDate.ShowDateId,
                              PlaceDtoId = film.FilmId,
                              UserDtoId = ticket.UserId,
                              HallDto = place.Hall,
                              RowNumberDto = place.RowNumber,
                              SeatNumberDto = place.SeatNumber
                          })
                          .Where(pd => pd.FilmDtoId == oneFilmId)
                          .Where(pd => pd.ShowDateDtoId == showDateId)
                          .ToListAsync();
            return places;
        }

        public async Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto entity)
        {
            var newUser = new User
            {
                FirstName = entity.FirstNameUser,
                LastName = entity.LastNameUser,
                Email = entity.Email
            };
            await _userRepository.Add(newUser);
            await _userRepository.Save();

            var userId = newUser.UserId;

            var existPlaces = _placeRepository.GetAll()
                .FirstOrDefault(p => p.Hall == entity.Hall && p.RowNumber == entity.RowNumber && p.SeatNumber == entity.SeatNumber);

            var placeId = existPlaces.PlaceId;

            var existTicket = _ticketRepository.GetAll()
                .FirstOrDefault(t => t.PlaceId == placeId && t.FilmId == filmId && t.ShowDateId == dateId);

            existTicket.UserId = userId;

            _ticketRepository.Update(existTicket);
            await _ticketRepository.Save();
        }
    }
}