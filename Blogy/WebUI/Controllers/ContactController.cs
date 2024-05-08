using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IAddressService _addressService;
        public ContactController(IMessageService messageService, IAddressService addressService)
        {
            _messageService = messageService;
            _addressService = addressService;
        }
        
        public IActionResult ContactClient()
        {
            var model = new ContactModel()
            {
                Address = _addressService.GetAll().FirstOrDefault()
            };
            return View(model);
        }

        public IActionResult NewMessage(ContactModel model)
        {
            var message = new Message()
            {
                MessageFullname = model.MessageFullname,
                MessageMail = model.MessageMail,
                MessageSubject = model.MessageSubject,
                MessageContent = model.MessageContent,
                MessageDate = DateTime.Now
            };
            _messageService.Create(message);
            return RedirectToAction("ContactClient", "Contact");
        }
    }
}