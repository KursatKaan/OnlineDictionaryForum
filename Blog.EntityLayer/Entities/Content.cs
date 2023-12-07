using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.EntityLayer.Entities
{
    public class Content
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string ContentText { get; set; }

        public bool ContentStatus { get; set; } = true;

        public DateTime ContentDate { get; set; }

        [ForeignKey("Heading")]
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        [ForeignKey("Writer")]
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
