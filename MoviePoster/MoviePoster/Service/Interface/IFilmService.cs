using MoviePoster.Dtos;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmCatalogeDto>> GetFilmCataloge();
        Task<OneFilmDto> GetOneFilm(Guid oneFilmId);
        Task<IEnumerable<ShowDatesDto>> GetTimeForOneFilm(Guid oneFilmId);
        Task<IEnumerable<PlacesDto>> GetFreePlaces(Guid oneFilmId, Guid showDateId);
        Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto user, string email);
        Task<IEnumerable<InfoBasketDto>> GetBasket(User person);
    }
}
