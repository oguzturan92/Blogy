using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Writer.ViewComponents.NotificationViewComponent
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly INotificationService _noticifationService;
        public NotificationViewComponent(INotificationService notificationService)
        {
            _noticifationService = notificationService;
        }
        public IViewComponentResult Invoke()
        {
            var notifications = _noticifationService.GetAll().OrderByDescending(i => i.NotificationDate).ToList();
            return View(notifications);
        }
    }
}