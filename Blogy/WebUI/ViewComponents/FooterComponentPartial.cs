using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class FooterComponentPartial:ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			return View();
		}
    }
}