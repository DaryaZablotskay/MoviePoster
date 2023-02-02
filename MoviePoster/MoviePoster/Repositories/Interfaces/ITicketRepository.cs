using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAll();
        void Update(Ticket ticket);
        Task Save();
    }
}
