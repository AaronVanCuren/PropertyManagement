using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PropertyManagement.Models
{
    public class ReviewCreate
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(280, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}