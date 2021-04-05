using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagement.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string UserName { get; set; }

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
