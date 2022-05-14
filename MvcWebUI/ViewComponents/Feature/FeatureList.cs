using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
