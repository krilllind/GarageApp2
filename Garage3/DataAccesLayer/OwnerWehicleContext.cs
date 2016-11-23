using Garage3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage3.DataAccesLayer
{
    public class OwnerWehicleContext : DbContext
    {
        public OwnerWehicleContext() : base("DefaultConnection") { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}