using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories
{
    public class ShowDateRepository : IShowDateRepository
    {
        private readonly MovieContext _movieContext;
        public ShowDateRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IQueryable<ShowDate> GetAll()
        {
            return _movieContext.ShowDates.AsQueryable();
        }

        public async Task<ShowDate> GetById(Guid id)
        {
            return await _movieContext.ShowDates.FindAsync(id);
        }

        public Task Save()
        {
            return _movieContext.SaveChangesAsync();
        }
    }
}
