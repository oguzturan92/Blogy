using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Writer.Models;

namespace WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Admin")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IChatLineService _chatLineService;
        private readonly UserManager<AppUser> _userManager;
        public ChatController(IChatService chatService, IChatLineService chatLineService, UserManager<AppUser> userManager)
        {
            _chatService = chatService;
            _chatLineService = chatLineService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ChatList()
        {
            var senderUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var chats = _chatService.GetAll().OrderByDescending(i => i.ChatDate).Where(i => i.SenderUserId == senderUser.Id || i.ReceiverUserId == senderUser.Id).ToList();
            return View(chats);
        }

        [HttpGet]
        public async Task<IActionResult> ChatCreate()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new ChatModel()
            {
                Users = _userManager.Users.Where(i => i.Id != user.Id).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChatCreate(ChatModel model)
        {
            var senderUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var chat = new Chat()
            {
                ChatDate = DateTime.Now,
                SenderUserId = senderUser.Id,
                ReceiverUserId = model.ReceiverUserId,
                ChatLines = new List<ChatLine>()
                {
                    new ChatLine(){
                        ChatDate = DateTime.Now,
                        ChatMessage = model.ChatMessage,
                        SenderUserId = senderUser.Id,
                        ReceiverUserId = model.ReceiverUserId
                    }
                }
            };
            _chatService.Create(chat);
            return RedirectToAction("ChatList", "Chat");
        }

        [HttpGet]
        public async Task<IActionResult> ChatReply(int id)
        {
            var chat = _chatService.GetById(id);
            var senderUser = await _userManager.FindByIdAsync(chat.SenderUserId.ToString());
            var receiverUser = await _userManager.FindByIdAsync(chat.ReceiverUserId.ToString());
            var model = new ChatReplyModel()
            {
                ChatId = id,
                SenderId = senderUser.Id,
                SenderName = senderUser.Name + " " + senderUser.Surname,
                ReceiverId = receiverUser.Id,
                ReceiverName = receiverUser.Name + " " + receiverUser.Surname,
                ChatLines = _chatLineService.GetAll().Where(i => i.ChatId == id).OrderByDescending(i => i.ChatDate).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChatReply(ChatReplyModel model)
        {
            var chat = _chatService.GetById(model.ChatId);
            var chatLine = new ChatLine()
            {
                ChatMessage = model.ChatMessage,
                ChatDate = DateTime.Now,
                SenderUserId = chat.SenderUserId,
                ReceiverUserId = chat.ReceiverUserId,
                ChatId = model.ChatId
            };
            _chatLineService.Create(chatLine);
            return RedirectToAction("ChatReply", "Chat", new { id = chat.ChatId});
        }

        public IActionResult ChatDelete(int id)
        {
            var chat = _chatService.GetById(id);
            _chatService.Delete(chat);
            return RedirectToAction("ChatList", "Chat");
        }

    }
}