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
                        ID = c.Int(nullable: false, identity: true),
                        RegNum = c.String(nullable: false, maxLength: 450),
                        Owner = c.String(nullable: false, maxLength: 50),
                        NumberOfWheels = c.Int(nullable: false),
                        ModelYear = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 50),
                        Color = c.Int(nullable: false),
                        VehicleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.RegNum, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "RegNum" });
            DropTable("dbo.Vehicles");
        }
    }
}