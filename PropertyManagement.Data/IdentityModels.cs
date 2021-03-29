using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PropertyManagement.Data
{
    public enum PropTy { Single_Family, Multi_Family, Student_Housing, Commercial, Mixed_Use, HOA, Vacation }
    public enum Utilities { Gas, Eletric, Water, Sewer, Trash, Internet, None}
    public enum Applicances { Refridgerator, Electric_Stove, Gas_Stove, Microwave, Dishwasher, Dryer, Washer, None }
    public enum Amenities { Attached_Garage, Detached_Garage, Large_Yard, Private_Yard, Fenced_Yard, /*If Washer/Dryer is not provided*/ Washer_Dryer_Hookup, Deck, Covered_Patio, Uncovered_Patio, Private_Pool, Public_Pool, Basement, Family_Room, Carpet_Bedrooms, Newer_Applicances, Formal_Dining_Room, Master_Bedroom, Fireplace, WalkIn_Closet, Double_Vanity, Soaking_Tub, Skylights, Ceiling_Fans, AC_Unit, Electric_Heating, Gas_Heating, Programmable_Thermostat, ADA_Ramps }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Customer user properties
        public PropTy PropTy { get; set; }

        public Utilities utilities { get; set; }

        public Applicances Applicances { get; set; }

        public Amenities Amenities { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Class databases
        // User database is built into framework
        public DbSet<Property> Properties { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}