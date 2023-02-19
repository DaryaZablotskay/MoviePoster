using Microsoft.EntityFrameworkCore;
using MoviePoster.Dtos;
using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service
{
    public class DateService : IDateService
    {
        private readonly MovieContext _movieContext;
        private readonly IShowDateRepository _showDateRepository;

        public DateService(MovieContext movieContext, IShowDateRepository showDateRepository)
        {
            _movieContext = movieContext;
            _showDateRepository = showDateRepository;
        }

        public async Task<IEnumerable<ShowDatesDto>> GetTimeForOneFilm(Guid oneFilmId)
        {
            var dates = await (from film in _movieContext.Films
                               join ticket in _movieContext.Tickets on film.FilmId equals ticket.FilmId
                               join showDate in _movieContext.ShowDates on ticket.ShowDateId equals showDate.ShowDateId
                               select new ShowDatesDto
                               {
                                   ShowDatesDtoId = showDate.ShowDateId,
                                   FilmId = film.FilmId,
                                   Time = showDate.Date
                               }).Where(sdd => sdd.FilmId == oneFilmId).Distinct().ToListAsync();
            return dates;
        }

        public async Task AddDates(AdminAddAndDeleteDataDto entity)
        {
            var newDate = new ShowDate
            {
                Date = entity.Date
            };
            await _showDateRepository.Add(newDate);
            await _showDateRepository.Save();
        }

        public async Task DeleteDate(AdminAddAndDeleteDataDto entity)
        {
            var existDate = await _showDateRepository.GetAll().SingleOrDefaultAsync(d => d.Date == entity.Date);
            _movieContext.ShowDates.Remove(existDate);
            await _showDateRepository.Save();
        }
    }
}
