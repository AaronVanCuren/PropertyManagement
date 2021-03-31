using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public enum PropTy { Single_Family, Multi_Family, Student_Housing, Commercial, Mixed_Use, HOA, Vacation }
    public enum Utilities { Gas, Eletric, Water, Sewer, Trash, Internet, None }
    public enum Applicances { Refridgerator, Electric_Stove, Gas_Stove, Microwave, Dishwasher, Dryer, Washer, None }
    public enum Amenities { Attached_Garage, Detached_Garage, Large_Yard, Private_Yard, Fenced_Yard, /*If Washer/Dryer is not provided*/ Washer_Dryer_Hookup, Deck, Covered_Patio, Uncovered_Patio, Private_Pool, Public_Pool, Basement, Family_Room, Carpet_Bedrooms, Newer_Applicances, Formal_Dining_Room, Master_Bedroom, Fireplace, WalkIn_Closet, Double_Vanity, Soaking_Tub, Skylights, Ceiling_Fans, AC_Unit, Electric_Heating, Gas_Heating, Programmable_Thermostat, ADA_Ramps }

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

        public Applicances Appliances { get; set; }

        // Are cats allowed at this property
        public bool Cat { get; set; }

        // Are dogs allowed at this property
        public bool Dog { get; set; }

        public Amenities Amenities { get; set; }

        // Notes made by property management company about property
        // Not visable to other users
        public virtual List<Comment> Comments { get; set; }

        // Implement Audit Log to keep track of who makes changes and what changes were made

        // Implement attachment uploads (pdfs, word docs, excel sheets...etc)
    }
}