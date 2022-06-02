using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;
using MvcWebUI.Areas.User.Models;

namespace MvcWebUI.Areas.User.Controllers
{
    [Area("User")]
    public class RegisterController : Controller
    {
        private readonly UserManager<UserDto> _userManager;

        public RegisterController(UserManager<UserDto> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                UserDto userDto = new UserDto()
                {
                    FirstName = userRegisterViewModel.FirstName,
                    LastName = userRegisterViewModel.LastName,
                    Email = userRegisterViewModel.Mail,
                    UserName = userRegisterViewModel.UserName,
                    ImageUrl = userRegisterViewModel.ImageUrl
                };
                var result = await _userManager.CreateAsync(userDto, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }

            }
            
            return View();
        }
    }
}
