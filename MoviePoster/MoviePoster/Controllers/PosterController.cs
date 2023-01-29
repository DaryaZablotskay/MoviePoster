using Microsoft.AspNetCore.Mvc;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Controllers
{
    public class PosterController : Controller
    {
        private readonly IFilmService _filmService;
        public PosterController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        public IActionResult Poster()
        {
            var films = _filmService.GetFilmCataloge();
            return View(films);
        }

        public IActionResult Film(Guid filmId)
        {
            var oneFilm = _filmService.GetOneFilm(filmId);
            var dates = _filmService.GetTimeForOneFilm(filmId);
            ViewBag.Dates = dates;

            return View(oneFilm);
        }

        public IActionResult Buy(Guid filmId, Guid dateId)
        {
            return View();
        }
    }
}
