using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Chat
    {
        public int ChatId { get; set; }
        public DateTime ChatDate { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public List<ChatLine> ChatLines { get; set; }
    }
}