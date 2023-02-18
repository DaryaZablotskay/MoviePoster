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
        public AdminController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> AddPage()
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
    }
}
