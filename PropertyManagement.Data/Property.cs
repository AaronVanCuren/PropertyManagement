using System;
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
        Single_Family = 1 << 0,

        [Display(Name = "Multi-Family")]
        Multi_Family = 1 << 1,

        [Display(Name = "Student Housing")]
        Student_Housing = 1 << 2,

        [Display(Name = "Commercial")]
        Commercial = 1 << 3,

        [Display(Name = "Mixed-Use")]
        Mixed_Use = 1 << 4,

        [Display(Name = "Home Owners Association")]
        HOA = 1 << 5,

        [Display(Name = "Vacation/Airbnb")]
        Vacation = 1 << 6
    }

    [Flags]
    public enum Utilities { Gas = 1 << 0, Eletric = 1 << 1, Water = 1 << 2, Sewer = 1 << 3, Trash = 1 << 4, Internet = 1 << 5, None = 0 }

    [Flags]
    public enum Applicances
    {
        [Display(Name = "Electric Stove")]
        Electric_Stove = 1 << 0,

        [Display(Name = "Gas Stove")]
        Gas_Stove = 1 << 1,

        Refridgerator = 1 << 2, Microwave = 1 << 3, Dishwasher = 1 << 4, Dryer = 1 << 5, Washer = 1 << 6, None = 0
    }

    [Flags]
    public enum Amenities
    {
        None = 0,

        [Display(Name = "Attached Garage")]
        Attached_Garage = 1 << 0,

        [Display(Name = "Detached Garage")]
        Detached_Garage = 1 << 1,

        [Display(Name = "Large Yard")]
        Large_Yard = 1 << 2,

        [Display(Name = "Private Yard")]
        Private_Yard = 1 << 3,

        [Display(Name = "Fenced Yard")]
        Fenced_Yard = 1 << 4,

        Deck = 1 << 5,

        [Display(Name = "Covered Patio")]
        Covered_Patio = 1 << 6,

        [Display(Name = "Uncovered Patio")]
        Uncovered_Patio = 1 << 7,

        [Display(Name = "Private Pool")]
        Private_Pool = 1 << 8,

        [Display(Name = "Public Pool Access")]
        Public_Pool = 1 << 9,

        Basement = 1 << 10,

        [Display(Name = "Family Room")]
        Family_Room = 1 << 11,

        [Display(Name = "Formal Dining Room")]
        Formal_Dining_Room = 1 << 12,

        [Display(Name = "Master Bedroom")]
        Master_Bedroom = 1 << 13,

        [Display(Name = "Carpeted Bedrooms")]
        Carpet_Bedrooms = 1 << 14,

        [Display(Name = "Walk-In Closet(s)")]
        WalkIn_Closet = 1 << 15,

        [Display(Name = "Double Vanity")]
        Double_Vanity = 1 << 16,

        [Display(Name = "Updated Appliances")]
        Newer_Applicances = 1 << 17,

        /*If Washer/Dryer is not provided*/
        [Display(Name = "Washer & Dryer Hookups")]
        Washer_Dryer_Hookup = 1 << 18,

        Fireplace = 1 << 19,

        [Display(Name = "Soaking Tub")]
        Soaking_Tub = 1 << 20,

        Skylights = 1 << 21,

        [Display(Name = "Ceiling Fans")]
        Ceiling_Fans = 1 << 22,

        [Display(Name = "Central AC")]
        AC_Unit = 1 << 23,

        [Display(Name = "Electric Heating")]
        Electric_Heating = 1 << 24,

        [Display(Name = "Gas Heating")]
        Gas_Heating = 1 << 25,

        [Display(Name = "Programmable Thermostat")]
        Programmable_Thermostat = 1 << 26,

        [Display(Name = "Installed ADA Ramps")]
        ADA_Ramps = 1 << 27
    }
}