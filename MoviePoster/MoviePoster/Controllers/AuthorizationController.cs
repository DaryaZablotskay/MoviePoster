using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MoviePoster.Dtos;
using MoviePoster.Models;
using MoviePoster.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviePoster.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if(ModelState.IsValid)
            {
                var user = await _userRepository.GetByEmail(userRegisterDto.Email);

                if(user is null)
                {
                    await _userRepository.Add(new User
                    {
                        FirstName = userRegisterDto.FirstName,
                        LastName = userRegisterDto.LastName,
                        Email = userRegisterDto.Email,
                        Password = userRegisterDto.Password
                    });

                    await _userRepository.Save();
                    await Authenticate(userRegisterDto.Email);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Некорректные данные");
                }
            }
            return View(userRegisterDto);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.CheckIdentity(userLoginDto.Email, userLoginDto.Password);

                if (user != null)
                {
                    await Authenticate(userLoginDto.Email);
                    return RedirectToAction("Home", "Home");
                }

                ModelState.AddModelError(string.Empty, "Некоректный логин и(или) пароль"); 
            }

            return View(userLoginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Home");
        }

        private async Task Authenticate(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
