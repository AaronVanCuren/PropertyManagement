namespace PropertyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicMVP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "VendorId", "dbo.Vendor");
            DropIndex("dbo.Review", new[] { "VendorId" });
            AddColumn("dbo.Comment", "UserName", c => c.String());
            AddColumn("dbo.Reply", "UserName", c => c.String());
            AddColumn("dbo.Review", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Review", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Review", "VendorId", c => c.Int());
            CreateIndex("dbo.Review", "VendorId");
            CreateIndex("dbo.Review", "UserId");
            AddForeignKey("dbo.Review", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Review", "VendorId", "dbo.Vendor", "VendorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.Review", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "VendorId" });
            AlterColumn("dbo.Review", "VendorId", c => c.Int(nullable: false));
            DropColumn("dbo.Review", "UserId");
            DropColumn("dbo.Review", "FirstName");
            DropColumn("dbo.Reply", "UserName");
            DropColumn("dbo.Comment", "UserName");
            CreateIndex("dbo.Review", "VendorId");
            AddForeignKey("dbo.Review", "VendorId", "dbo.Vendor", "VendorId", cascadeDelete: true);
        }
    }
}
