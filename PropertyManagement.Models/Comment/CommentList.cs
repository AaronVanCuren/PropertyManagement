using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models.Comments
{
    public class CommentList
    {
        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CommentCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? CommentEdited { get; set; }
    }
}
