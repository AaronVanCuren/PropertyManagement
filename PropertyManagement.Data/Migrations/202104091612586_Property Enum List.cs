namespace PropertyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyEnumList : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Property", "Utilities");
            DropColumn("dbo.Property", "Appliances");
            DropColumn("dbo.Property", "Amenities");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "Amenities", c => c.Int(nullable: false));
            AddColumn("dbo.Property", "Appliances", c => c.Int(nullable: false));
            AddColumn("dbo.Property", "Utilities", c => c.Int(nullable: false));
        }
    }
}