using Application.Accounts.Commands;
using Application.Accounts.Commands.Deletes;
using Application.Accounts.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _mediator = mediator;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Roles.Admin))
                return View(await _mediator.Send(new GetAllAccount()));

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(CreateAccount command)
        {
            if (ModelState.IsValid)
                if (await _mediator.Send(command)) return RedirectToAction("Index");

            return View(command);
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginAccount command)
        {

            if (!ModelState.IsValid)
                return View(command);


            var result = await _signInManager.PasswordSignInAsync(command.UserEmail, command.Password, command.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
                return LocalRedirect("/Home/Index");

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(command);
            }

        }

        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {         
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = Roles.Admin)]

        public async Task<IActionResult> DeleteConfirmed(DeleteAccount command)
        {
            await _mediator.Send(command);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
