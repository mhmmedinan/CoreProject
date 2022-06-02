using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace MvcWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public DefaultController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetAllOrderByDesc();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var values = _announcementService.TGetById(id);
            return View(values.Data);
        }
    }
}
