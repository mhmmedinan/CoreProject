using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public ExperienceList(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _experienceService.TGetAll();
            return View(values.Data);
        }
    }
}
