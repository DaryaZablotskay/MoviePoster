using MoviePoster.Dtos;
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
        Task<IEnumerable<PlacesDto>> GetPlaces(Guid oneFilmId, Guid showDateId);
        Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto user);
    }
}
