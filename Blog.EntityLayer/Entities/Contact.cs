using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.EntityLayer.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
