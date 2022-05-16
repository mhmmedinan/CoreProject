using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";
            var values = _skillService.TGetAll();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Ekleme";
            return View();
        }


        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            _skillService.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var values = _skillService.TGetById(id);
            _skillService.TDelete(values.Data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.v1 = "Yetenek Güncelleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Güncelleme";
            var values = _skillService.TGetById(id);
            return View(values.Data);

        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            _skillService.TUpdate(skill);
            return RedirectToAction("Index");

        }
    }
}
