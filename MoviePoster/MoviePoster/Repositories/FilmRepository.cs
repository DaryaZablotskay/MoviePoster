using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly MovieContext _movieContext;
        public FilmRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IQueryable<Film> GetAll()
        {
            return _movieContext.Films.AsQueryable();
        }

        public async Task<Film> GetById(Guid id)
        {
            return await _movieContext.Films.FindAsync(id);
        }
    }
}
