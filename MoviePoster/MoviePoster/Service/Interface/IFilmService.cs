using MoviePoster.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface IFilmService
    {
        IEnumerable<FilmCatalogeDto> GetFilmCataloge();
        OneFilmDto GetOneFilm(Guid oneFilmId);
        IEnumerable<ShowDatesDto> GetTimeForOneFilm(Guid oneFilmId);
        IEnumerable<PlacesDto> GetPlaces(Guid oneFilmId, Guid showDateId);
        Task AddUser(ReserveRequestUserDto user);
        Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto user);
    }
}
