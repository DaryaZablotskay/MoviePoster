using Microsoft.AspNetCore.Mvc;
using MoviePoster.Dtos;
using MoviePoster.EmailHelper.Interfaces;
using MoviePoster.Repositories.Interfaces;
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
        private readonly IFilmRepository _filmRepository;
        private readonly IShowDateRepository _showDateRepository;
        private readonly IEmailSender _emailSender;

        public PosterController(IFilmService filmService, IFilmRepository filmRepository, IShowDateRepository showDateRepository, IEmailSender emailSender)
        {
            _filmService = filmService;
            _filmRepository = filmRepository;
            _showDateRepository = showDateRepository;
            _emailSender = emailSender;
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

        [HttpGet]
        public IActionResult Buy(Guid filmId, Guid dateId)
        {
            ViewBag.FilmId = filmId;
            ViewBag.DateId = dateId;
            var places = _filmService.GetPlaces(filmId, dateId);
            ViewBag.Places = places;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(Guid filmId, Guid dateId,ReserveRequestUserDto user)
        {
            await _filmService.AddUser(user);
            await _filmService.UpdateTicket(filmId, dateId, user);
            string place = user.Hall + " зал, " + user.RowNumber + " ряд, " + user.SeatNumber + " место";
            var filmName = _filmRepository.GetById(filmId).Result.Name;
            var date = _showDateRepository.GetById(dateId).Result.Date;
            await _emailSender.Send(place, date, user.Email, filmName);
            return RedirectToAction("BuyCompleted");
        }

        public IActionResult BuyCompleted()
        {
            return View();
        }
    }
}
