using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.EntityLayer.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(1000)]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; } = true;
        public bool IsDraft { get; set; } = false;
    }
}
