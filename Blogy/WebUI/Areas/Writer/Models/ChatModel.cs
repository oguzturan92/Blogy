using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Writer.Models
{
    public class ChatModel
    {
        public int ReceiverUserId { get; set; }
        public string ChatMessage { get; set; }
        public List<AppUser> Users { get; set; }
    }
}