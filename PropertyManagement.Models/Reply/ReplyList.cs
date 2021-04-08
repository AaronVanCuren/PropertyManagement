using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models.Replies
{
    public class ReplyList
    {
        public int ReplyId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset ReplyCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? ReplyEdited { get; set; }
    }
}