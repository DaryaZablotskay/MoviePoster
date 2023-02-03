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
        private readonly ITicketRepository _ticketRepository;
        private readonly IPlaceRepository _placeRepository;

        public PosterController(IFilmService filmService, IFilmRepository filmRepository, IShowDateRepository showDateRepository, IEmailSender emailSender, ITicketRepository ticketRepository, IPlaceRepository placeRepository)
        {
            _filmService = filmService;
            _filmRepository = filmRepository;
            _showDateRepository = showDateRepository;
            _emailSender = emailSender;
            _ticketRepository = ticketRepository;
            _placeRepository = placeRepository;
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

        [HttpGet]
        public async Task<IActionResult> Buy(Guid filmId, Guid dateId)
        {
            ViewBag.FilmId = filmId;
            ViewBag.DateId = dateId;
            var places = await _filmService.GetPlaces(filmId, dateId);
            ViewBag.Places = places;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(Guid filmId, Guid dateId, ReserveRequestUserDto user)
        {
            try
            {
                var existPlaces = _placeRepository.GetAll()
               .FirstOrDefault(p => p.Hall == user.Hall && p.RowNumber == user.RowNumber && p.SeatNumber == user.SeatNumber);

                var placeId = existPlaces.PlaceId;

                var ticket = _ticketRepository.GetAll()
                    .FirstOrDefault(t => t.FilmId == filmId && t.ShowDateId == dateId && t.PlaceId == placeId);

                if (ticket.UserId != null)
                {
                    return RedirectToAction("ErrorBuy");
                }
                else
                {
                    await _filmService.UpdateTicket(filmId, dateId, user);
                    string place = user.Hall + " зал, " + user.RowNumber + " ряд, " + user.SeatNumber + " место";
                    var filmName = _filmRepository.GetById(filmId).Result.Name;
                    var date = _showDateRepository.GetById(dateId).Result.Date;
                    await _emailSender.Send(place, date, user.Email, filmName);
                    return RedirectToAction("BuyCompleted", new { @filmName = filmName, @date = date, @hall = user.Hall, @row = user.RowNumber, @seat = user.SeatNumber });
                }
            }
            catch(NullReferenceException)
            {
                return RedirectToAction("SeatNotFound");
            }
        }

        public IActionResult BuyCompleted(string? filmName, DateTime? date, int? hall, int? row, int? seat)
        {
            ViewBag.Film = filmName;
            ViewBag.Date = date;
            ViewBag.Hall = hall;
            ViewBag.Row = row;
            ViewBag.Seat = seat;
            return View();
        }

        public IActionResult ErrorBuy()
        {
            return View();
        }
    }
}
