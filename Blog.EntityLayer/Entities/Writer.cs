using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.EntityLayer.Entities
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string About { get; set; }   
        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Level { get; set; }

        public bool WriterStatus { get; set; } = true;

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
