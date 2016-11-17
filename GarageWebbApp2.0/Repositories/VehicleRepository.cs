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
        private ContextLayer context;

        public VehicleRepository()
        {
            context = new ContextLayer();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return context.Vehicles;
        }

        public IEnumerable<VehicleViewModels> GetVehicleView(FilterDates date, List<string> FilterTypes = null, List<string> FilterColors = null)
        {
            FilterViewModels filters = new FilterViewModels();
            List<Vehicle> TempVehicles = new List<Vehicle>();
            List<VehicleViewModels> SelectedVehicles = new List<VehicleViewModels>();

            if (FilterColors.Count() == 0)
                FilterColors = filters.VehicleColors.Keys.ToList();

            if (FilterTypes.Count() == 0)
                FilterTypes = filters.VehicleTypes.Keys.ToList();

            TempVehicles = context.Vehicles.ToList().Where(o => FilterTypes.Contains(Enum.GetName(typeof(VehicleTypes), o.VehicleType).ToString())
                && FilterColors.Contains(Enum.GetName(typeof(VehicleColors), o.Color).ToString())).ToList();

            foreach (var item in TempVehicles)
            {
                SelectedVehicles.Add(new VehicleViewModels
                {
                    ID = item.ID,
                    Owner = item.Owner,
                    RegNum = item.RegNum,
                    Model = item.Model,
                    ModelYear = item.ModelYear,
                    NumberOfWheels = item.NumberOfWheels,
                    Color = ((VehicleColors)item.Color).ToString(),
                    VehicleType = ((VehicleTypes)item.VehicleType).ToString(),
                    Date = item.Date
                });
            }

            return SelectedVehicles.OrderBy(o => o.VehicleType).ThenByDescending(o => o.Date);
        }

        public Vehicle GetVehicleById(int id)
        {
            return context.Vehicles.FirstOrDefault(o => o.ID == id);
        }

        public void AddVehicle(Vehicle item)
        {
            item.Date = DateTime.Now;
            context.Vehicles.Add(item);
            context.SaveChanges();
        }

        public void DeleteVehicle(int id)
        {
            Vehicle item = context.Vehicles.FirstOrDefault(o => o.ID == id);
            if (item != null)
            {
                context.Vehicles.Remove(item);
                context.SaveChanges();
            }
        }

        //public bool HasColumnWithValue(string col, string val)
        //{
        //    var tmp = context.Vehicles.Where(o => typeof(Vehicle).GetProperty(col).GetValue(o, null).ToString().ToLower() == val.ToLower()).ToList();

        //    if (tmp.Count() > 0)
        //        return true;

        //    return true;
        //}

        //public void EditVehicle(Vehicle item)
        //{
        //    context.Entry(item).State = EntityState.Modified;
        //    context.SaveChanges();
        //}

        public IEnumerable<Vehicle> Search(string SelectionField, string SearchField)
        {
            return context.Vehicles.AsEnumerable().Where(o => typeof(Vehicle).GetProperty(SelectionField).GetValue(o, null).ToString().ToLower().Contains(SearchField.Trim().ToLower()));
        }

        public bool IsDataBaseEmpty()
        {
            List<Vehicle> vehicles = context.Vehicles.ToList();
            int size = vehicles.Count();
            
            if (size == 0)
                return true;
            

            return false;
        }
    }
}