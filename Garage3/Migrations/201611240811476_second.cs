namespace Garage3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Owners", "Vehicle_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "Vehicle_ID", c => c.String());
        }
    }
}
