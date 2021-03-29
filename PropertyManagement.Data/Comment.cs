using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Content { get; set; }

        public virtual List<Reply> Replies { get; set; }


        // Comments are posted to property listing that are for sale or for rent
        [Required]
        public int ListingId { get; set; }

        [ForeignKey(nameof(ListingId))]
        public virtual Listing Listing { get; set; }

        // Notes are posted to a property for property management company viewing
        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; }
    }
}
