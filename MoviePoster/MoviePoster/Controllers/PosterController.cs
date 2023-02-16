﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Controllers
{
    [Authorize]
    public class PosterController : Controller
    {
        private readonly IFilmService _filmService;

        public PosterController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Poster()
        {
            var films = await _filmService.GetFilmCataloge();
            return View(films);
        }

        public async Task<IActionResult> Film(Guid filmId)
        {
            var oneFilm = await _filmService.GetOneFilm(filmId);
            var dates = await _filmService.GetTimeForOneFilm(filmId);
            ViewBag.Dates = dates;

            return View(oneFilm);
        }
    }
}
