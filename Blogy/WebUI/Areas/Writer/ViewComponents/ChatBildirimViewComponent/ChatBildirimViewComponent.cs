using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Writer.ViewComponents.ChatBildirimViewComponent
{
    public class ChatBildirimViewComponent : ViewComponent
    {
        private readonly IChatService _chatService;
        private readonly UserManager<AppUser> _userManager;
        public ChatBildirimViewComponent(IChatService chatService, UserManager<AppUser> userManager)
        {
            _chatService = chatService;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var chats = _chatService.GetAll().Where(i => i.ReceiverUserId == user.Id).OrderByDescending(i => i.ChatDate).Take(3).ToList();
            return View(chats);
        }
    }
}