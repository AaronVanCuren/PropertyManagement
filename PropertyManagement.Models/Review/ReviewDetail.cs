using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class ReviewDetail
    {
        public int ReviewId { get; set; }

        public IQueryable VendorName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset ReviewCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? ReviewEdited { get; set; }
    }
}
