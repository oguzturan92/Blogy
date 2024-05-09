using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebUI.Areas.Writer.Models;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly IChatService _chatService;
        public WriterController(UserManager<AppUser> userManager, IArticleService articleService, IChatService chatService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _chatService = chatService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.articlesCount = _articleService.GetAll().Where(i => i.AppUserId == user.Id).ToList().Count();
            ViewBag.sendChatsCount = _chatService.GetAll().Where(i => i.SenderUserId == user.Id).ToList().Count();
            ViewBag.receiverChatsCount = _chatService.GetAll().Where(i => i.ReceiverUserId == user.Id).ToList().Count();




            // HAVA DURUMU RAPİD APİ
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=Ankara&format=json&u=c"),
                Headers =
                {
                    { "X-RapidAPI-Key", "buraya kendi api bilginizi giriniz" },
                    { "X-RapidAPI-Host", "yahoo-weather5.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<DashboardModel>(body);
                return View(model);
            }
        }
    }
}
