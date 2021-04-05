using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagement.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset ReplyCreated { get; set; }

        public DateTimeOffset? ReplyEdited { get; set; }

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

        /*[Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }*/
    }
}
