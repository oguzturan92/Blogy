using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime NotificationDate { get; set; }
    }
}