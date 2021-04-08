using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models.Vendors
{
    public class VendorDetail
    {
        public string VendorName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual IQueryable Reviews { get; set; }
    }
}