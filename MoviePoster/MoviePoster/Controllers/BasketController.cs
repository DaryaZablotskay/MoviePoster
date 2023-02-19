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
        private readonly ITicketService _ticketService;

        public BasketController(IUserRepository userRepositor, IFilmService filmService, ITicketService ticketService)
        {
            _userRepository = userRepositor;
            _filmService = filmService;
            _ticketService = ticketService;
        }
        public async Task<IActionResult> Basket()
        {
            var user = await _userRepository.GetByEmail(User.Identity.Name);
            var basket = await _ticketService.GetBasket(user);
            ViewBag.FirstName = user.FirstName;
            ViewBag.Lastname = user.LastName;
            return View(basket);
        }
    }
}
