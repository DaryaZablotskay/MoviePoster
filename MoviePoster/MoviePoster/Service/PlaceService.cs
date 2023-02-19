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
    public class PlaceService : IPlaceService
    {
        private readonly MovieContext _movieContext;
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(MovieContext movieContext, IPlaceRepository placeRepository)
        {
            _movieContext = movieContext;
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<PlacesDto>> GetFreePlaces(Guid oneFilmId, Guid showDateId)
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
                          .Where(pd => pd.UserDtoId == null)
                          .ToListAsync();
            return places;
        }

        public async Task AddPlaces(AdminAddAndDeletePlaceDto entity)
        {
            var newPlace = new Place
            {
                Hall = entity.Hall,
                RowNumber = entity.RowNumber,
                SeatNumber = entity.SeatNumber
            };
            await _placeRepository.Add(newPlace);
            await _placeRepository.Save();
        }


        public async Task DeletePlace(AdminAddAndDeletePlaceDto entity)
        {
            var existPlace = await _placeRepository.GetAll()
                .SingleOrDefaultAsync(p => p.Hall == entity.Hall && p.RowNumber == entity.RowNumber && p.SeatNumber == entity.SeatNumber);
            _movieContext.Places.Remove(existPlace);
            await _placeRepository.Save();
        }
    }
}
