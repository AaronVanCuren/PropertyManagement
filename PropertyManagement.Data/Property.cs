using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Data
{
    public class Property
    {
        public int PropertyId { get; set; }

        // Research how to implement
        // public object Pictures { get; set; }
        // public object Videos {get; set; }
        // https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/working-with-azure-blob-storage-in-mvc/

        // Implement google/apple maps
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

        // Notes made by property management company about property
        // Not visable to other users
        public List<Comment> Comments { get; set; }

        // Implement Audit Log to keep track of who makes changes and what changes were made

        // Implement attachment uploads (pdfs, word docs, excel sheets...etc)
    }
}
