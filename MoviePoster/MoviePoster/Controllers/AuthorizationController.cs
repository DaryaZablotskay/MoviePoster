using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly MovieContext _movieContext;
        private readonly IUserRepository _userRepository;

        public AuthorizationController(MovieContext movieContext, IUserRepository userRepository)
        {
            _movieContext = movieContext;
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
                    var newUser = new User
                    {
                        FirstName = userRegisterDto.FirstName,
                        LastName = userRegisterDto.LastName,
                        Email = userRegisterDto.Email,
                        Password = userRegisterDto.Password
                    };

                    var userRole = await _movieContext.Roles.SingleOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                    {
                        newUser.Role = userRole;
                    }
                       
                    await _userRepository.Add(newUser);
                    await _userRepository.Save();
                    await Authenticate(newUser);
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
                    await Authenticate(user);
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

        private async Task Authenticate(User user)
        {
            var role = await _movieContext.Roles.FindAsync(user.RoleId);
            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
