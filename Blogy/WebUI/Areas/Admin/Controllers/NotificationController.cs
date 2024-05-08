using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult NotificationList()
        {
            var notification = _notificationService.GetAll();
            return View(notification);
        }

        [HttpGet]
        public IActionResult NotificationCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NotificationCreate(NotificationModel model)
        {
            var entity = new Notification()
            {
                NotificationTitle = model.NotificationTitle,
                NotificationDate = DateTime.Now
            };
            _notificationService.Create(entity);
            return RedirectToAction("NotificationList", "Notification");
        }

        public IActionResult NotificationDelete(int id)
        {
            var entity = _notificationService.GetById(id);
            _notificationService.Delete(entity);
            return RedirectToAction("NotificationList", "Notification");
        }
    }
}