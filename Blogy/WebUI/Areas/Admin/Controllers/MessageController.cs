using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult MessageList()
        {
            var messages = _messageService.GetAll().OrderByDescending(i => i.MessageDate).ToList();
            return View(messages);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = _messageService.GetById(id);
            return View(message);
        }
    }
}