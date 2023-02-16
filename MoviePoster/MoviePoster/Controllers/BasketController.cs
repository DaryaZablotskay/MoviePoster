using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePoster.Repositories.Interfaces;
using MoviePoster.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IFilmService _filmService;

        public BasketController(IUserRepository userRepositor, IFilmService filmService)
        {
            _userRepository = userRepositor;
            _filmService = filmService;
        }
        public async Task<IActionResult> Basket()
        {
            var user = await _userRepository.GetByEmail(User.Identity.Name);
            var basket = await _filmService.GetBasket(user);
            ViewBag.FirstName = user.FirstName;
            ViewBag.Lastname = user.LastName;
            return View(basket);
        }
    }
}
