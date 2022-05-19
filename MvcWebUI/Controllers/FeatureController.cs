using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace MvcWebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkan Güncelleme";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Güncelleme";
            var values = _featureService.TGetById(1);
            return View(values.Data);
        }


        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            _featureService.TUpdate(feature);
            return RedirectToAction("Index","Default");

        }
    }
}
