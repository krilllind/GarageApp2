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
            DateTime FromDate;
            DateTime ToDate;
            DateTime Today = DateTime.Now;

            switch(date)
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

            if (FilterTypes.Count() == 0)
                FilterTypes = filters.VehicleTypes.Keys.ToList();

            TempVehicles = context.Vehicles.ToList().Where(o => FilterTypes.Contains(Enum.GetName(typeof(VehicleTypes), o.VehicleType).ToString())
                && FilterColors.Contains(Enum.GetName(typeof(VehicleColors), o.Color).ToString())
                && o.Date >= FromDate && o.Date <= ToDate).ToList();

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

<<<<<<< HEAD
=======

>>>>>>> fa5d8cf590489f100a8b39968c50943a396a51f8
        public IEnumerable<Vehicle> Search(string SelectionField, string SearchField)
        {
            return context.Vehicles.AsEnumerable().OrderBy(o => o.VehicleType).Where(o => typeof(Vehicle).GetProperty(SelectionField).GetValue(o, null).ToString().ToLower().Contains(SearchField.Trim().ToLower()));
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