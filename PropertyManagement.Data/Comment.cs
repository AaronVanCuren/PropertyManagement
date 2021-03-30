using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Data
{
    // Inheriting from ApplicationUser to bring in Id & UserName
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CommentCreated { get; set; }

        public DateTimeOffset? CommentEdited { get; set; }

        public virtual List<Reply> Replies { get; set; }


        // Comments are posted to property listing that are for sale or for rent
        [Required]
        public int ListingId { get; set; }

        [ForeignKey(nameof(ListingId))]
        public virtual Listing Listing { get; set; }
    }
}
