using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MvcWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    [Route("User/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly IUserMessageService _userMessageService;
        private readonly UserManager<UserDto> _userManager;

        public MessageController(IUserMessageService userMessageService, UserManager<UserDto> userManager)
        {
            _userMessageService = userMessageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string receiver)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            receiver = values.Email;
            var messageList = _userMessageService.GetListReceiverMessage(receiver);
            return View(messageList.Data);
        }


        public async Task<IActionResult> SenderMessage(string sender)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            sender = values.Email;
            var messageList = _userMessageService.GetListSenderMessage(sender);
            return View(messageList.Data);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var details = _userMessageService.TrueReadMessage(id);
            return View(details.Data);
        }
        
        public IActionResult SenderMessageDetails(int id)
        {
            var details = _userMessageService.TGetById(id);
            return View(details.Data);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> SendMessage(UserMessage userMessage)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var mail = values.Email;
            var name = values.FirstName + " " + values.LastName;
            userMessage.Date = Convert.ToDateTime(DateTime.Now);
            userMessage.Sender = mail;
            userMessage.SenderName = name;
            var firstName = _userManager.Users.Where(x => x.Email == userMessage.Receiver)
                .Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            userMessage.ReceiverName = firstName;
            _userMessageService.TAdd(userMessage);
            return RedirectToAction("SenderMessage");

        }


    }
}
