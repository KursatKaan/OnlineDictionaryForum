using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.EntityLayer.Entities
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        [AllowHtml]
        public string AboutDetails1 { get; set; }
    }
}
