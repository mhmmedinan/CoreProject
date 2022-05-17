using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi";
            var values = _experienceService.TGetAll();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.v1 = "Deneyim Ekleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Experience experience)
        {
            _experienceService.TAdd(experience);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var values = _experienceService.TGetById(id);
            _experienceService.TDelete(values.Data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.v1 = "Deneyim Güncelleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Güncelleme";
            var values = _experienceService.TGetById(id);
            return View(values.Data);

        }

        [HttpPost]
        public IActionResult Update(Experience experience)
        {
            _experienceService.TUpdate(experience);
            return RedirectToAction("Index");

        }
    }
}
