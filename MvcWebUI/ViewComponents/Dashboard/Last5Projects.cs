using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public Last5Projects(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _portfolioService.GetAllTop5();
            return View(values.Data);
        }
    }
}
