namespace PropertyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Content = c.String(nullable: false),
                        CommentCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        CommentEdited = c.DateTimeOffset(precision: 7),
                        ListingId = c.Int(nullable: false),
                        Property_PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Listing", t => t.ListingId, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.Property_PropertyId)
                .Index(t => t.ListingId)
                .Index(t => t.Property_PropertyId);
            
            CreateTable(
                "dbo.Listing",
                c => new
                    {
                        ListingId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListingId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PropTy = c.Int(nullable: false),
                        IsAHP = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(),
                        Bedroom = c.Int(nullable: false),
                        Bathroom = c.Int(nullable: false),
                        SqFt = c.Int(nullable: false),
                        Rent = c.Int(nullable: false),
                        AppFee = c.Int(nullable: false),
                        SD = c.Int(nullable: false),
                        NSFee = c.Int(nullable: false),
                        Cat = c.Boolean(nullable: false),
                        Dog = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Content = c.String(nullable: false),
                        ReplyCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        ReplyEdited = c.DateTimeOffset(precision: 7),
                        CommentId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Review", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.CommentId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        ReviewCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        ReviewEdited = c.DateTimeOffset(precision: 7),
                        VendorId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.Vendor", t => t.VendorId)
                .Index(t => t.VendorId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Review", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Reply", "ReviewId", "dbo.Review");
            DropForeignKey("dbo.Review", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Listing", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Comment", "Property_PropertyId", "dbo.Property");
            DropForeignKey("dbo.Comment", "ListingId", "dbo.Listing");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "VendorId" });
            DropIndex("dbo.Reply", new[] { "ReviewId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Listing", new[] { "PropertyId" });
            DropIndex("dbo.Comment", new[] { "Property_PropertyId" });
            DropIndex("dbo.Comment", new[] { "ListingId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Vendor");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Review");
            DropTable("dbo.Reply");
            DropTable("dbo.Property");
            DropTable("dbo.Listing");
            DropTable("dbo.Comment");
        }
    }
}
