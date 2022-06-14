using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;

namespace MvcWebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IUserMessageService _messageService;
        private readonly UserManager<UserDto> _userManager;
        public AdminMessageController(IUserMessageService messageService, UserManager<UserDto> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public IActionResult SenderMessageList()
        {
            var admin = "admin@gmail.com";
            var values = _messageService.GetListSenderMessage(admin);
           
            return View(values.Data);
        }

        public IActionResult ReceiverMessageList()
        {
            var admin = "admin@gmail.com";
            var values = _messageService.GetListReceiverMessage(admin);

            return View(values.Data);
        }


        public IActionResult ReceiveMessageDetails(int id)
        {
            var details = _messageService.TrueReadMessage(id);
            return View(details.Data);
        }

        public IActionResult SenderMessageDetails(int id)
        {
            var details = _messageService.TGetById(id);
            return View(details.Data);
        }

        public IActionResult ReceiverDelete(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values.Data);
            return RedirectToAction("ReceiverMessageList");
        }


        public IActionResult SenderDelete(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values.Data);
            return RedirectToAction("SenderMessageList");
        }


        [HttpGet]
        public IActionResult AdminMessageSend()
        {
         
            return View();
        }


        [HttpPost]
        public IActionResult AdminMessageSend(UserMessage userMessage)
        {
            userMessage.Sender = "admin@gmail.com";
            userMessage.SenderName = "Admin";
            userMessage.Date = Convert.ToDateTime(DateTime.Now);
            var firstName = _userManager.Users.Where(x => x.Email == userMessage.Receiver)
                .Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            userMessage.ReceiverName = firstName;
            _messageService.TAdd(userMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
