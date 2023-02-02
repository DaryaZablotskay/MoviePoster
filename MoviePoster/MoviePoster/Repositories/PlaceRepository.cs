using Microsoft.EntityFrameworkCore;
using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly MovieContext _movieContext;
        public PlaceRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IQueryable<Place> GetAll()
        {
            return _movieContext.Places.AsQueryable();
        }
        public void Update(Place place)
        {
            _movieContext.Entry(place).State = EntityState.Modified;
        }

        public Task Save()
        {
            return _movieContext.SaveChangesAsync();
        }
    }
}



