using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagement.Data
{
    // Inheriting from ApplicationUser so we can use Id and RoleId
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
