using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Areas.User.ViewComponents
{
    public class Notification:ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public Notification(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetAll().Data.Take(5).ToList();
            return View(values);
        }
    }
}
