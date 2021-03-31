namespace PropertyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "Appliances", c => c.Int(nullable: false));
            DropColumn("dbo.Property", "Applicances");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "Applicances", c => c.Int(nullable: false));
            DropColumn("dbo.Property", "Appliances");
        }
    }
}
