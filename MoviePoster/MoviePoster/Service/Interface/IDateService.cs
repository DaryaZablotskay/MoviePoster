using MoviePoster.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface IDateService
    {
        Task<IEnumerable<ShowDatesDto>> GetTimeForOneFilm(Guid oneFilmId);
        Task AddDates(AdminAddAndDeleteDataDto entity);
        Task DeleteDate(AdminAddAndDeleteDataDto entity);
    }
}
