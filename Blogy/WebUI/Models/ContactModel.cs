using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace WebUI.Models
{
    public class ContactModel
    {
        public int MessageId { get; set; }
        public string MessageFullname { get; set; }
        public string MessageMail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public Address Address { get; set; }
    }
}