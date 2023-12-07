using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.EntityLayer.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdminUserName { get; set; }
        [Required]
        public string AdminPassword { get; set; }
        public string AdminPasswordKey { get; set; }
    }
}
