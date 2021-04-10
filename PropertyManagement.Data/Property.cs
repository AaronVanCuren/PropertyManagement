using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Data
{
    /*Research how to implement the following...
    public object Pictures { get; set; }
    public object Videos {get; set; }
    https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/working-with-azure-blob-storage-in-mvc/
    Implement google/apple maps
    Implement Audit Log to keep track of who makes changes and what changes were made
    Implement attachment uploads (pdfs, word docs, excel sheets...etc)*/

    public class Property
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

        public List<Utilities> Utilities { get; set; }

        public List<Applicances> Appliances { get; set; }

        // Are cats allowed at this property
        public bool Cat { get; set; }

        // Are dogs allowed at this property
        public bool Dog { get; set; }

        public List<Amenities> Amenities { get; set; }

        // Notes made by property management company about property
        // Not visable to other users
        public virtual List<Comment> Comments { get; set; }
    }

    public enum PropTy
    {
        [Display(Name = "Single Family")]
        Single_Family,

        [Display(Name = "Multi-Family")]
        Multi_Family,

        [Display(Name = "Student Housing")]
        Student_Housing,

        [Display(Name = "Commercial")]
        Commercial,

        [Display(Name = "Mixed-Use")]
        Mixed_Use,

        [Display(Name = "Home Owners Association")]
        HOA,

        [Display(Name = "Vacation/Airbnb")]
        Vacation
    }

    public enum Utilities { Gas, Eletric, Water, Sewer, Trash, Internet, None }

    public enum Applicances
    {
        [Display(Name = "Electric Stove")]
        Electric_Stove,

        [Display(Name = "Gas Stove")]
        Gas_Stove,

        Refridgerator, Microwave, Dishwasher, Dryer, Washer, None
    }

    public enum Amenities
    {
        [Display(Name = "Attached Garage")]
        Attached_Garage,

        [Display(Name = "Detached Garage")]
        Detached_Garage,

        [Display(Name = "Large Yard")]
        Large_Yard,

        [Display(Name = "Private Yard")]
        Private_Yard,

        [Display(Name = "Fenced Yard")]
        Fenced_Yard,

        Deck,

        [Display(Name = "Covered Patio")]
        Covered_Patio,

        [Display(Name = "Uncovered Patio")]
        Uncovered_Patio,

        [Display(Name = "Private Pool")]
        Private_Pool,

        [Display(Name = "Public Pool Access")]
        Public_Pool,

        Basement,

        [Display(Name = "Family Room")]
        Family_Room,

        [Display(Name = "Formal Dining Room")]
        Formal_Dining_Room,

        [Display(Name = "Master Bedroom")]
        Master_Bedroom,

        [Display(Name = "Carpeted Bedrooms")]
        Carpet_Bedrooms,

        [Display(Name = "Walk-In Closet(s)")]
        WalkIn_Closet,

        [Display(Name = "Double Vanity")]
        Double_Vanity,

        [Display(Name = "Updated Appliances")]
        Newer_Applicances,

        /*If Washer/Dryer is not provided*/
        [Display(Name = "Washer & Dryer Hookups")]
        Washer_Dryer_Hookup,

        Fireplace,

        [Display(Name = "Soaking Tub")]
        Soaking_Tub,

        Skylights,

        [Display(Name = "Ceiling Fans")]
        Ceiling_Fans,

        [Display(Name = "Central AC")]
        AC_Unit,

        [Display(Name = "Electric Heating")]
        Electric_Heating,

        [Display(Name = "Gas Heating")]
        Gas_Heating,

        [Display(Name = "Programmable Thermostat")]
        Programmable_Thermostat,

        [Display(Name = "Installed ADA Ramps")]
        ADA_Ramps
    }
}