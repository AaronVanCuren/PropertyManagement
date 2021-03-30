using PropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class PropertyList
    {
        public int PropertyId { get; set; }

        public string Address { get; set; }

        // Property Type
        public PropTy PropTy { get; set; }

        // Is Afforable Housing Property
        public bool IsAHP { get; set; }

        // Vacant or Occupied
        public bool Status { get; set; }

        // Information about the property
        public string Description { get; set; }

        public int Bedroom { get; set; }

        public int Bathroom { get; set; }

        public int SqFt { get; set; }

        public int Rent { get; set; }

        // Application Fee
        public int AppFee { get; set; }

        // Security Deposit
        public int SD { get; set; }

        // Non-Sufficient Funds Fee
        public int NSFee { get; set; }

        public Utilities Utilities { get; set; }

        public Applicances Applicances { get; set; }

        // Are cats allowed at this property
        public bool Cat { get; set; }

        // Are dogs allowed at this property
        public bool Dog { get; set; }

        public Amenities Amenities { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
