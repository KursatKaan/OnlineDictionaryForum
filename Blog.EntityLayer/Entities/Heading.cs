using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.EntityLayer.Entities
{
    public class Heading
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string HeadingTitle { get; set; }

        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; } = true;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Writer")]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
