using GarageWebbApp2._0.Data_Access_Layer;
using GarageWebbApp2._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace GarageWebbApp2._0.Repositories
{
    public class VehicleRepository
    {
        private ContextLayer db;

        public VehicleRepository()
        {
            db = new ContextLayer();
        }

        public ICollection<Owner> GetAllOwners()
        {
            return db.Owners.ToList();
        }

        public ICollection<Vehicle> GetAllVehicles()
        {

            return db.Vehicles.Include(v => v.Owner).Include(v => v.VehicleType).ToList();
        }

        public ICollection<VehicleType> GetAllVehiclesTypes()
        {
            return db.VehicleTypes.ToList();
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
            db.SaveChanges();
        }

        public void Add(Vehicle ve)
        {
            db.Vehicles.Add(ve);
            db.SaveChanges();
        }

        public void Edit(Owner ow)
        {
            db.Entry(ow).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Edit(Vehicle ve)
        {
            db.Entry(ve).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(Owner ow)
        {
            db.Owners.Remove(ow);
            db.SaveChanges();
        }

        public void Remove(Vehicle ve)
        {
            db.Vehicles.Remove(ve);
            db.SaveChanges();
        }
        public IEnumerable<VehicleViewModels> GetVehicleView(FilterDates date, List<string> FilterTypes = null, List<string> FilterColors = null)
        {
            FilterViewModels filters = new FilterViewModels();
            List<Vehicle> TempVehicles = new List<Vehicle>();
            List<VehicleViewModels> SelectedVehicles = new List<VehicleViewModels>();
            DateTime FromDate;
            DateTime ToDate;
            DateTime Today = DateTime.Now;

            switch (date)
            {
                case FilterDates.Today:
                    FromDate = new DateTime(Today.Year, Today.Month, Today.Day, 0, 0, 0);
                    ToDate = new DateTime(Today.Year, Today.Month, Today.Day, 23, 59, 59);
                    break;

                case FilterDates.Week:
                    int x = Today.Day - (Today.Day % 7);
                    FromDate = new DateTime(Today.Year, Today.Month, x);
                    ToDate = new DateTime(Today.Year, Today.Month, x + 7);
                    break;

                case FilterDates.Month:
                    FromDate = new DateTime(Today.Year, Today.Month, 1);
                    ToDate = new DateTime(Today.Year, Today.Month, DateTime.DaysInMonth(Today.Year, Today.Month));
                    break;

                default:
                    FromDate = new DateTime(1970, 1, 1);
                    ToDate = new DateTime(Today.Year + 3, Today.Month, Today.Day);
                    break;
            }


            if (FilterColors.Count() == 0)
                FilterColors = filters.VehicleColors.Keys.ToList();

            TempVehicles = db.Vehicles.ToList().Where(o => FilterTypes.Contains(Enum.GetName(typeof(VehicleType), o.VehicleType).ToString())
                && FilterColors.Contains(Enum.GetName(typeof(VehicleColors), o.Color).ToString())).ToList();

            foreach (var item in TempVehicles)
            {
                SelectedVehicles.Add(new VehicleViewModels
                {
                    Owner = item.Owner_ID,
                    RegNum = item.Vehicle_ID,
                    Color = ((VehicleColors)item.Color).ToString(),
                    VehicleType = ((VehicleType)item.VehicleType).ToString()
                });
            }

            return SelectedVehicles;
        }

        //public IEnumerable<Vehicle> Search(string SelectionField, string SearchField)
        //{
        //    return context.Vehicles.AsEnumerable().OrderBy(o => o.VehicleType).Where(o => typeof(Vehicle).GetProperty(SelectionField).GetValue(o, null).ToString().ToLower().Contains(SearchField.Trim().ToLower()));
        //}
    }
}