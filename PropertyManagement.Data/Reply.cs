using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }


        // Replies applicable only to comments
        // Can be created by anyone
        [Required]
        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }

        // Replies applicable only to reviews
        // Can only be created by original author or company user
        [Required]
        public int ReviewId { get; set; }

        [ForeignKey(nameof(ReviewId))]
        public virtual Review Review { get; set; }
    }
}
