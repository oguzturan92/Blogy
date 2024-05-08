using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CommentNewModel
    {
        public string CommentFullname { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int ArticleId { get; set; }
    }
}