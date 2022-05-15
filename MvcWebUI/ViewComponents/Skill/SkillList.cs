using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        private readonly ISkillService _skillService;

        public SkillList(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _skillService.TGetAll();
            return View(values.Data);
        }
    }
}
