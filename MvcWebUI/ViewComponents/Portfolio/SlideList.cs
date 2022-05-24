﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Portfolio
{
    public class SlideList:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public SlideList(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _portfolioService.TGetAll();

            return View(values.Data);
        }
    }
}
