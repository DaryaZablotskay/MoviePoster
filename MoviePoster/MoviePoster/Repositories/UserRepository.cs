﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetByEmail(string email)
        {
            return await _movieContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> CheckIdentity(string email, string password)
        {
            return await _movieContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
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
