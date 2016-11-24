using Garage3.DataAccesLayer;
using Garage3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Garage3.Repositories
{
    public class VehicleRepository
    {
        private OwnerWehicleContext db = new OwnerWehicleContext();

        public ICollection<Owner> GetOwners()
        {
            return db.Owners.ToList();
        }

        public ICollection<Vehicle> GetVehicles()
        {
            
            return db.Vehicles.Include(v => v.Owner).Include(v => v.VehicleType).ToList();
        }

        public Owner GetOwner(string id)
        {
            return db.Owners.Find(id);
        }

    }
}