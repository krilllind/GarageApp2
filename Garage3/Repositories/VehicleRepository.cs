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

        public Vehicle GetVehicle(string id)
        {
            return db.Vehicles.Find(id);
        }

        public void Add(Owner ow)
        {
            db.Owners.Add(ow);
            saveState();
        }

        public void Add(Vehicle ve)
        {
            db.Vehicles.Add(ve);
            saveState();
        }

        public void Edit(Owner ow)
        {
            db.Entry(ow).State = EntityState.Modified;

        }

        public void Edit(Vehicle ve)
        {
            db.Entry(ve).State = EntityState.Modified;
        }

        public void saveState()
        {
            db.SaveChanges();
        }

        public void Remove(Owner ow)
        {
            db.Owners.Remove(ow);
            saveState();
        }

        public void Remove(Vehicle ve)
        {
            db.Vehicles.Remove(ve);
            saveState();
        }
    }
}