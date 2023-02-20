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
        Task<User> GetByEmail(string email);
        Task<User> CheckIdentity(string email, string password);
        Task Add(User user);
        Task Save();
    }
}
