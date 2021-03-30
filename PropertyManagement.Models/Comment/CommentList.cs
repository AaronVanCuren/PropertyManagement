﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class CommentList
    {
        public int ListingId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CommentCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? CommentEdited { get; set; }
    }
}