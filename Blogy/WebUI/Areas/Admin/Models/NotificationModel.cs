using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Admin.Models
{
    public class NotificationModel
    {
        public int NotificationId { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}