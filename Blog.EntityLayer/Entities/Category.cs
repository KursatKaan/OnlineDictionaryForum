using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.EntityLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } = true;

        public ICollection<Heading> Headings { get; set; }
    }
}
