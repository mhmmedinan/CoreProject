using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;


namespace MvcWebUI.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Listesi";
            var values = _portfolioService.TGetAll();
            return View(values.Data);
        }

        public IActionResult Delete(int id)
        {
            var values = _portfolioService.TGetById(id);
            _portfolioService.TDelete(values.Data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.v1 = "Proje Ekleme";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfolio portfolio)
        {
          
            if (!ModelState.IsValid)
            {
                return View("Add",portfolio);
                
            }

            _portfolioService.TAdd(portfolio);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.v1 = "Proje Güncelleme";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Güncelleme";
            var values = _portfolioService.TGetById(id);
            return View(values.Data);

        }

        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", portfolio);
            }
            _portfolioService.TUpdate(portfolio);
            return RedirectToAction("Index");

        }
    }
}
