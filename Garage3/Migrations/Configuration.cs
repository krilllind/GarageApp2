namespace Garage3.Migrations
{
    using Garage3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage3.DataAccesLayer.OwnerWehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage3.DataAccesLayer.OwnerWehicleContext context)
        {

            Owner testOwner = new Owner() { Name = "Robin", Owner_ID = "870427-8558"};
            
            

            context.VehicleTypes.AddOrUpdate(
                vt => vt.VehicleType_Id,

                new VehicleType { Name = "Car"},
                new VehicleType { Name = "Buss"},
                new VehicleType { Name = "Bout"},
                new VehicleType { Name = "Motorbike"}
            );

            context.Owners.AddOrUpdate(testOwner);
            VehicleType vts = context.VehicleTypes.Find(1);
            context.Vehicles.AddOrUpdate(

                new Vehicle { Vehicle_ID = "SOU510", Owner_ID = testOwner.Owner_ID, Owner = testOwner, VehicleType = vts }
                );

        }
    }
}
