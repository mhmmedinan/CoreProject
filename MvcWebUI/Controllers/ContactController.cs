using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace MvcWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
          
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.TGetAll();
            return View(values.Data);
        }

        public IActionResult Delete(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values.Data);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetails(int id)
        {
            var values = _messageService.TGetById(id);
            return View(values.Data);
        }
    }
}
