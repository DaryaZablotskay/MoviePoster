using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviePoster.Dtos;
using MoviePoster.EmailHelper.Interfaces;
using MoviePoster.Repositories.Interfaces;
using MoviePoster.Service.Interface;

namespace MoviePoster.Controllers
{
    public class BuyController : Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IShowDateRepository _showDateRepository;
        private readonly IEmailSender _emailSender;
        private readonly ITicketRepository _ticketRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly IFilmService _filmService;
        private readonly IPlaceService _placeService;
        private readonly ITicketService _ticketService;

        public BuyController(IFilmService filmService, IFilmRepository filmRepository, IShowDateRepository showDateRepository, IEmailSender emailSender, ITicketRepository ticketRepository, IPlaceRepository placeRepository, IPlaceService placeService, ITicketService ticketService)
        {
            _filmService = filmService;
            _filmRepository = filmRepository;
            _showDateRepository = showDateRepository;
            _emailSender = emailSender;
            _ticketRepository = ticketRepository;
            _placeRepository = placeRepository;
            _placeService = placeService;
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Buy(Guid filmId, Guid dateId)
        {
            var places = await _placeService.GetFreePlaces(filmId, dateId);
            ViewBag.Places = places;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(Guid filmId, Guid dateId, ReserveRequestUserDto user)
        {
            var existPlaces = _placeRepository.GetAll()
          .FirstOrDefault(p => p.Hall == user.Hall && p.RowNumber == user.RowNumber && p.SeatNumber == user.SeatNumber);

            if (existPlaces is null)
            {
                return RedirectToAction("NotFoundPlace");
            }
            else
            {
                var placeId = existPlaces.PlaceId;
                var ticket = _ticketRepository.GetAll()
                        .FirstOrDefault(t => t.FilmId == filmId && t.ShowDateId == dateId && t.PlaceId == placeId);

                var email = User.Identity.Name;

                if (ticket.UserId is null)
                {
                    await _ticketService.UpdateTicket(filmId, dateId, user, email);
                    string place = user.Hall + " зал, " + user.RowNumber + " ряд, " + user.SeatNumber + " место";
                    var filmName = _filmRepository.GetById(filmId).Result.Name;
                    var date = _showDateRepository.GetById(dateId).Result.Date;
                    await _emailSender.Send(place, date, email, filmName);
                    return RedirectToAction("BuyCompleted", new { @filmName = filmName, @date = date, @hall = user.Hall, @row = user.RowNumber, @seat = user.SeatNumber });
                }
                else
                {
                    return RedirectToAction("OccupiedPlace");
                }
            }  
        }

        public IActionResult BuyCompleted(string filmName, DateTime? date, int? hall, int? row, int? seat)
        {
            ViewBag.Film = filmName;
            ViewBag.Date = date;
            ViewBag.Hall = hall;
            ViewBag.Row = row;
            ViewBag.Seat = seat;
            return View();
        }

        public IActionResult OccupiedPlace()
        {
            return View();
        }

        public IActionResult NotFoundPlace()
        {
            return View();
        }
    }
}

