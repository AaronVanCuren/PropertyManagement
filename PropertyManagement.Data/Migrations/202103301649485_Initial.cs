namespace PropertyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "PropTy");
            DropColumn("dbo.ApplicationUser", "utilities");
            DropColumn("dbo.ApplicationUser", "Applicances");
            DropColumn("dbo.ApplicationUser", "Amenities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Amenities", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "Applicances", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "utilities", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationUser", "PropTy", c => c.Int(nullable: false));
        }
    }
}
