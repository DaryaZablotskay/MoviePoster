using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        IQueryable<Place> GetAll();
        void Update(Place place);
        Task Save();
        Task Add(Place place);
    }
}
