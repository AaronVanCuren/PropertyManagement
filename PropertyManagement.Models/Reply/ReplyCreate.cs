using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PropertyManagement.Models.Replies
{
    // Might have to add some sort of validation to ensure a user does not need to enter both a comment
    public class ReplyCreate
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public int CommentId { get; set; }

        [Required]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(280, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }

        public List<SelectListItem> Comments { get; set; }

        public List<SelectListItem> Reviews { get; set; }
    }
}
