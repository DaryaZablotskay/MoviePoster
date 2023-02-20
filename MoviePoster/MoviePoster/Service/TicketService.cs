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
    public class TicketService : ITicketService
    {
        private readonly MovieContext _movieContext;
        private readonly IUserRepository _userRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IShowDateRepository _showDateRepository;

        public TicketService(MovieContext movieContext, IUserRepository userRepository, IPlaceRepository placeRepository, ITicketRepository ticketRepository, IFilmRepository filmRepository, IShowDateRepository showDateRepository)
        {
            _movieContext = movieContext;
            _userRepository = userRepository;
            _placeRepository = placeRepository;
            _ticketRepository = ticketRepository;
            _filmRepository = filmRepository;
            _showDateRepository = showDateRepository;
        }

        public async Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto entity, string email)
        {
            var existUser = await _userRepository.GetByEmail(email);

            var userId = existUser.UserId;

            var existPlaces = _placeRepository.GetAll()
                .FirstOrDefault(p => p.Hall == entity.Hall && p.RowNumber == entity.RowNumber && p.SeatNumber == entity.SeatNumber);

            var placeId = existPlaces.PlaceId;

            var existTicket = _ticketRepository.GetAll()
                .FirstOrDefault(t => t.PlaceId == placeId && t.FilmId == filmId && t.ShowDateId == dateId);

            existTicket.UserId = userId;

            _ticketRepository.Update(existTicket);
            await _ticketRepository.Save();
        }

        public async Task<IEnumerable<InfoBasketDto>> GetBasket(User person)
        {
            var userId = person.UserId;
            var basket = await (from ticket in _movieContext.Tickets
                                join place in _movieContext.Places on ticket.PlaceId equals place.PlaceId
                                join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                                join film in _movieContext.Films on ticket.FilmId equals film.FilmId
                                join user in _movieContext.Users on ticket.UserId equals user.UserId
                                select new InfoBasketDto
                                {
                                    UserId = user.UserId,
                                    FilmName = film.Name,
                                    Hall = place.Hall,
                                    RowNumber = place.RowNumber,
                                    SeatNumber = place.SeatNumber,
                                    Date = showDate.Date
                                })
                          .Where(ibd => ibd.UserId == userId)
                          .ToListAsync();
            return basket;
        }

        public async Task AddTickets(AdminAddTicketDto entity)
        {
            var existFilm = await _filmRepository.GetAll().SingleOrDefaultAsync(f => f.Name == entity.FilmName);
            var existDate = await _showDateRepository.GetAll().SingleOrDefaultAsync(d => d.Date == entity.Date);
            var placeList = await _placeRepository.GetAll().Where(p => p.Hall == entity.Hall).ToListAsync();

            foreach (var place in placeList)
            {
                var newTicket = new Ticket
                {
                    FilmId = existFilm.FilmId,
                    ShowDateId = existDate.ShowDateId,
                    PlaceId = place.PlaceId
                };
                await _ticketRepository.Add(newTicket);
                await _ticketRepository.Save();
            }
        }


        public async Task DeleteTicket(AdminDeleteTicketDto entity)
        {
            var existFilm = await _filmRepository.GetAll().SingleOrDefaultAsync(f => f.Name == entity.FilmName);
            var existPlace = await _placeRepository.GetAll()
                .SingleOrDefaultAsync(p => p.Hall == entity.Hall && p.RowNumber == entity.RowNumber && p.SeatNumber == entity.SeatNumber);
            var existDate = await _showDateRepository.GetAll().SingleOrDefaultAsync(d => d.Date == entity.Date);

            var existTicket = await _ticketRepository.GetAll()
                .SingleOrDefaultAsync(t => t.FilmId == existFilm.FilmId && t.PlaceId == existPlace.PlaceId && t.ShowDateId == existDate.ShowDateId);
            if(existTicket != null)
            {
                _movieContext.Tickets.Remove(existTicket);
                await _ticketRepository.Save();
            }
        }
    }
}
