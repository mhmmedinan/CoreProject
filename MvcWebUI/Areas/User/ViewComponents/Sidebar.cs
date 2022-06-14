using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.User.ViewComponents
{
    public class Sidebar:ViewComponent
    {
        private readonly UserManager<UserDto> _userManager;
        private readonly IUserMessageService _messageService;

        public Sidebar(UserManager<UserDto> userManager, IUserMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var unreadMessage = _messageService.GetCountMessageUnRead(values.Email).Data.Count();
            ViewBag.unreadMessage = unreadMessage;
            return View();
        }
    }
}
