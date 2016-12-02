namespace GarageWebbApp2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GarageWebbApp2._0.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageWebbApp2._0.Data_Access_Layer.ContextLayer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GarageWebbApp2._0.Data_Access_Layer.ContextLayer context)
        {
           Owner TestOwner = new Owner { Owner_ID = "00000101-1597", Name = "Kalle Kanin" };
           Owner TestOwner2 = new Owner { Owner_ID = "2000101-1597", Name = "Clas Claywood" };
           Owner TestOwner3 = new Owner { Owner_ID = "961119-1289", Name = "Henry Öhman" };
            
            //context.VehicleTypes.AddOrUpdate(
            //    v => v.VehicleType_Id,
            //    new VehicleType { Name = "Car" },
            //    new VehicleType { Name = "Buss" },
            //    new VehicleType { Name = "Motorcycle" },
            //    new VehicleType { Name = "Boat" }
            //);

            context.Owners.AddOrUpdate(
                o => o.Owner_ID,
                TestOwner,
                TestOwner2,
                TestOwner3
            );

            //context.Vehicles.AddOrUpdate(
            //    v => v.Vehicle_ID,
            //    new Vehicle {  Vehicle_ID = "ABC123", Owner = TestOwner, Type = 1, Color = VehicleColors.Orange }
            //);
        }
    }
}
