using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmet Listesi";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Listesi";
            var values = _serviceService.TGetAll();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.v1 = "Hizmet Ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekleme";
            return View();
        }


        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceService.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var values = _serviceService.TGetById(id);
            _serviceService.TDelete(values.Data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.v1 = "Hizmet Güncelleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Güncelleme";
            var values = _serviceService.TGetById(id);
            return View(values.Data);

        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            _serviceService.TUpdate(service);
            return RedirectToAction("Index");

        }
    }
}
