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

        }
    }
}
