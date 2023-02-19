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
        Task AddFilms(AdminAddFillmDto entity);
        Task DeleteFilm(AdminDeleteFilmDto entity);
    }
}
