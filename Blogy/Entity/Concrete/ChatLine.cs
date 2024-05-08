using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ChatLine
    {
        public int ChatLineId { get; set; }
        public string ChatMessage { get; set; }
        public DateTime ChatDate { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}