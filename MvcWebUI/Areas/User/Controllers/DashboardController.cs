using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MvcWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<UserDto> _userManager;
        private readonly IAnnouncementService _announcementService;

        public DashboardController(UserManager<UserDto> userManager, IAnnouncementService announcementService)
        {
            _userManager = userManager;
            _announcementService = announcementService;
        }
   
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.FirstName + " " + values.LastName;

            var count = _announcementService.TGetAll();
            ViewBag.v1 = 0;
            ViewBag.v2 = count.Data.Count;
            return View();
        }
    }
}
