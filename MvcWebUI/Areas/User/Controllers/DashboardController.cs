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
        private readonly IUserMessageService _messageService;

        public DashboardController(UserManager<UserDto> userManager, IAnnouncementService announcementService, IUserMessageService messageService)
        {
            _userManager = userManager;
            _announcementService = announcementService;
            _messageService = messageService;
        }
   
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.FirstName + " " + values.LastName;

            var announcementCount = _announcementService.TGetAll().Data.Count();
            var messageReceiver = _messageService.GetListReceiverMessage(values.Email).Data.Count();
            var messageSender = _messageService.GetListSenderMessage(values.Email).Data.Count();
            var totalMessage = (messageReceiver)+(messageSender);
            ViewBag.v1 = messageReceiver;
            ViewBag.v2 = announcementCount;
            ViewBag.v3 = messageSender;
            ViewBag.v4 = totalMessage;
            return View();
        }
    }
}
