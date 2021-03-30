using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset ReviewCreated { get; set; }

        public DateTimeOffset? ReviewEdited { get; set; }

        public virtual List<Reply> Replies { get; set; }

        [Required]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorId))]
        public virtual Vendor Vendor { get; set; }
    }
}
