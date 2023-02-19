using MoviePoster.Dtos;
using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface ITicketService
    {
        Task UpdateTicket(Guid filmId, Guid dateId, ReserveRequestUserDto entity, string email);
        Task<IEnumerable<InfoBasketDto>> GetBasket(User person);
        Task AddTickets(AdminAddTicketDto entity);
        Task DeleteTicket(AdminDeleteTicketDto entity);
    }
}
