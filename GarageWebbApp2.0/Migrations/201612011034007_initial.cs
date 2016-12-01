namespace GarageWebbApp2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Owner_ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Vehicle_ID = c.String(nullable: false, maxLength: 450),
                        Owner_ID = c.String(maxLength: 128),
                        Type = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vehicle_ID)
                .ForeignKey("dbo.Owners", t => t.Owner_ID)
                .ForeignKey("dbo.VehicleTypes", t => t.Type, cascadeDelete: true)
                .Index(t => t.Vehicle_ID, unique: true)
                .Index(t => t.Owner_ID)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleType_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VehicleType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Type", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "Owner_ID", "dbo.Owners");
            DropIndex("dbo.Vehicles", new[] { "Type" });
            DropIndex("dbo.Vehicles", new[] { "Owner_ID" });
            DropIndex("dbo.Vehicles", new[] { "Vehicle_ID" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Owners");
        }
    }
}
