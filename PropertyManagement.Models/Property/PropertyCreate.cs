using PropertyManagement.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Models.Properties
{
    public class PropertyCreate
    {
        [Required]
        public string Address { get; set; }

        // Property Type
        [Required]
        [Display(Name = "Property Type")]
        public PropTy PropTy { get; set; }

        // Is Afforable Housing Property
        [Required]
        [Display(Name = "Afforable Housing Property")]
        public bool IsAHP { get; set; }

        // Vacant or Occupied
        [Required]
        [Display(Name = "Vacant")]
        public bool Status { get; set; }

        // Information about the property
        [Required]
        public string Description { get; set; }

        [Required]
        public int Bedroom { get; set; }

        [Required]
        public int Bathroom { get; set; }

        [Required]
        [Display(Name = "Total Square Feet")]
        public int SqFt { get; set; }

        [Required]
        public int Rent { get; set; }

        // Application Fee
        [Required]
        [Display(Name = "Application Fee")]
        public int AppFee { get; set; }

        // Security Deposit
        [Required]
        [Display(Name = "Security Deposit")]
        public int SD { get; set; }

        // Non-Sufficient Funds Fee
        [Required]
        [Display(Name = "Non-Sufficient Funds Fee")]
        public int NSFee { get; set; }

        [Required]
        public List<Utilities> Utilities { get; set; }

        [Required]
        public List<Applicances> Appliances { get; set; }

        // Are cats allowed at this property
        [Required]
        public bool Cat { get; set; }

        // Are dogs allowed at this property
        [Required]
        public bool Dog { get; set; }

        [Required]
        public List<Amenities> Amenities { get; set; }
    }
}