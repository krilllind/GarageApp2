using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWebbApp2._0.Models
{
    public class FilterViewModels
    {
        public Dictionary<string, bool> VehicleTypes { get; set; }
        public Dictionary<string, bool> VehicleColors { get; set; }
        public Dictionary<string, bool> FilterDates { get; set; }
        public string Date { get; set; }

        public FilterViewModels()
        {
            VehicleTypes = new Dictionary<string, bool>();
            VehicleColors = new Dictionary<string, bool>();
            FilterDates = new Dictionary<string, bool>();
            this.Date = "None";

            foreach (var item in Enum.GetNames(typeof(VehicleTypes)))
                VehicleTypes.Add(item, true);

            foreach (var item in Enum.GetNames(typeof(VehicleColors)))
                VehicleColors.Add(item, true);

            foreach (var item in Enum.GetNames(typeof(FilterDates)))
            {
                if (item == "None")
                    FilterDates.Add(item, true);
                else
                    FilterDates.Add(item, false);
            }
        }
    }
}