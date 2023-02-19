using Microsoft.EntityFrameworkCore;
using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MovieContext _movieContext;
        public TicketRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _movieContext.Tickets.AsQueryable();
        }

        public void Update(Ticket ticket)
        {
            _movieContext.Entry(ticket).State = EntityState.Modified;
        }

        public Task Save()
        {
            return _movieContext.SaveChangesAsync();
        }

        public Task Add(Ticket ticket)
        {
            return _movieContext.Tickets.AddAsync(ticket).AsTask();
        }
    }
}
