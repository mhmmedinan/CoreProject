using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialList(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAll();
            return View(values.Data);
        }
    }
}
