using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Data
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}
