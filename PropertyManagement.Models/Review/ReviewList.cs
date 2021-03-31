﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class ReviewList
    {
        public string FirstName { get; set; }

        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset ReviewCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? ReviewEdited { get; set; }
    }
}