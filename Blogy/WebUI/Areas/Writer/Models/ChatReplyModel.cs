using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Areas.Writer.Models
{
    public class ChatReplyModel
    {
        public int ChatId { get; set; }
        public string ChatMessage { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public List<ChatLine> ChatLines { get; set; }
    }
}