using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        IQueryable<Film> GetAll();
        Task<Film> GetById(Guid id);
    }
}
