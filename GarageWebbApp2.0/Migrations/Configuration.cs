using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using GarageWebbApp2._0.Models;

namespace GarageWebbApp2._0.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GarageWebbApp2._0.Data_Access_Layer.ContextLayer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(GarageWebbApp2._0.Data_Access_Layer.ContextLayer context)
        {
            context.Vehicles.AddOrUpdate(
                o => o.ID,
                new Vehicle { Model = "Volvo S70", ModelYear = 1997, NumberOfWheels = 4, Owner = "Kristoffer Lindström", Color = VehicleColors.Silver, VehicleType = VehicleTypes.Car, RegNum = "BAO564" },
                new Vehicle { Model = "Saab 9-5", ModelYear = 2001, NumberOfWheels = 4, Owner = "Robin Viklund", Color = VehicleColors.Gray, VehicleType = VehicleTypes.Car, RegNum = "SOU510" }
            );
        }
    }
}
