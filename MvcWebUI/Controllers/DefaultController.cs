using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMessageService _messageService;

        public DefaultController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            _messageService.TAdd(message);
            return PartialView();
        }
    }
}
