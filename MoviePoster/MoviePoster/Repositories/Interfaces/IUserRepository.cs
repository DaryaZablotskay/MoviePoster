using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task Add(User user);
        Task Save();
    }
}
