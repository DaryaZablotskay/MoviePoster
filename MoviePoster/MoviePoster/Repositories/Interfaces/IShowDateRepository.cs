using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories.Interfaces
{
    public interface IShowDateRepository
    {
        IQueryable<ShowDate> GetAll();
        Task<ShowDate> GetById(Guid id);
        Task Save();
    }
}
