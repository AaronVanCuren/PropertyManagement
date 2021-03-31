using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class VendorDetail
    {
        public string VendorName { get; set; }

        public string Description { get; set; }

        public virtual IQueryable Reviews { get; set; }
    }
}