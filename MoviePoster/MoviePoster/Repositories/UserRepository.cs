using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieContext _movieContext;
        public UserRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IQueryable<User> GetAll()
        {
            return _movieContext.Users.AsQueryable();
        }

        public Task Add(User user)
        {
            return _movieContext.Users.AddAsync(user).AsTask();
        }

        public Task Save()
        {
           return _movieContext.SaveChangesAsync();
        }
    }
}
