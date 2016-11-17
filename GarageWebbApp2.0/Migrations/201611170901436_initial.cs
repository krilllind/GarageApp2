namespace GarageWebbApp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        RegNum = c.String(nullable: false, maxLength: 128),
                        Owner = c.String(nullable: false, maxLength: 50),
                        NumberOfWheels = c.Int(nullable: false),
                        ModelYear = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 50),
                        Color = c.Int(nullable: false),
                        VehicleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegNum);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
