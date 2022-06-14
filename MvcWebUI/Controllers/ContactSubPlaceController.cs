using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        private readonly IContactService _contactService;

        public ContactSubPlaceController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.TGetById(1);
            return View(values.Data);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
