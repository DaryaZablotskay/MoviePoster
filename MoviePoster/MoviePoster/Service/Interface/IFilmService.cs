﻿using MoviePoster.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface IFilmService
    {
        IEnumerable<FilmCatalogeDto> GetFilmCataloge();
        OneFilmDto GetOneFilm(Guid oneFilmId);
        IEnumerable<ShowDatesDto> GetTimeForOneFilm(Guid oneFilmId);
    }
}
