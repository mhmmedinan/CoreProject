using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        private readonly IUserMessageService _userMessageService;

        public MessageList(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userMessageService.GetUserMessageWithUser();
            return View(values.Data);
        }
    }
}
