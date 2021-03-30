using PropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class VendorList
    {
        public string VendorName { get; set; }

        public string Description { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}
