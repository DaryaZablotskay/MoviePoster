using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePoster.Dtos;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IDateService _dateService;
        private readonly IPlaceService _placeService;
        private readonly ITicketService _ticketService;

        public AdminController(IFilmService filmService, IDateService dateService, IPlaceService placeService, ITicketService ticketService)
        {
            _filmService = filmService;
            _dateService = dateService;
            _placeService = placeService;
            _ticketService = ticketService;
        }

        public async Task<IActionResult> AddPage()
        {
            return View();
        }

        public async Task<IActionResult> DeletePage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddFilms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilms(AdminAddFillmDto entity)
        {
            await _filmService.AddFilms(entity);
            return RedirectToAction("AddFilms");
        }

        [HttpGet]
        public async Task<IActionResult> AddDatas()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDatas(AdminAddAndDeleteDataDto entity)
        {
            await _dateService.AddDates(entity);
            return RedirectToAction("AddDatas");
        }

        [HttpGet]
        public async Task<IActionResult> AddPlaces()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlaces(AdminAddAndDeletePlaceDto entity)
        {
            await _placeService.AddPlaces(entity);
            return RedirectToAction("AddPlaces");
        }

        [HttpGet]
        public async Task<IActionResult> AddTickets()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTickets(AdminAddTicketDto entity)
        {
            await _ticketService.AddTickets(entity);
            return RedirectToAction("AddTickets");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFilm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFilm(AdminDeleteFilmDto entity)
        {
            await _filmService.DeleteFilm(entity);
            return RedirectToAction("DeleteFilm");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePlace()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlace(AdminAddAndDeletePlaceDto entity)
        {
            await _placeService.DeletePlace(entity);
            return RedirectToAction("DeletePlace");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDate(AdminAddAndDeleteDataDto entity)
        {
            await _dateService.DeleteDate(entity);
            return RedirectToAction("DeleteDate");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTicket(AdminDeleteTicketDto entity)
        {
            await _ticketService.DeleteTicket(entity);
            return RedirectToAction("DeleteTicket");
        }
    }
}
