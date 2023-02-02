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
                              UserDtoId = ticket.UserId,
                              HallDto = place.Hall,
                              RowNumberDto = place.RowNumber,
                              SeatNumberDto = place.SeatNumber
                          })
                          .Where(pd => pd.FilmDtoId == oneFilmId)
                          .Where(pd => pd.ShowDateDtoId == showDateId)
                          .ToList();
            return places;
        }

        public async Task AddUser(ReserveRequestUserDto user)
        {
            var newUser = new User
            {
                FirstName = user.FirstNameUser,
                LastName = user.LastNameUser,
                Email = user.Email
            };
            await _userRepository.Add(newUser);
            await _userRepository.Save();
        }

        public async Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto entity)
        {
            var existUser = _userRepository.GetAll()
                .Where(u => u.FirstName == entity.FirstNameUser)
                .Where(u => u.LastName == entity.LastNameUser)
                .FirstOrDefault(u => u.Email == entity.Email);

            var userId = existUser.UserId;

            var existPlaces = _placeRepository.GetAll()
                .Where(p => p.Hall == entity.Hall)
                .Where(p => p.RowNumber == entity.RowNumber)
                .FirstOrDefault(p => p.SeatNumber == entity.SeatNumber);
                //.FirstOrDefault(p => p.Hall == entity.Hall && p.RowNumber == entity.RowNumber && p.SeatNumber == entity.SeatNumber);

            var placeId = existPlaces.PlaceId;

            var existTicket = _ticketRepository.GetAll()
                .Where(t => t.FilmId == filmId)
                .Where(t => t.ShowDateId == dateId)
                .FirstOrDefault(t => t.PlaceId == placeId);
                //.FirstOrDefault(t => t.PlaceId == placeId && t.FilmId == filmId && t.ShowDateId == dateId);

            existTicket.UserId = userId;

            _ticketRepository.Update(existTicket);
            await _ticketRepository.Save();
        }
    }
}