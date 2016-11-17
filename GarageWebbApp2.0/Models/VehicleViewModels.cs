using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWebbApp2._0.Models
{
    public class VehicleViewModels
    {
        public int ID { get; set; }

        public string RegNum { get; set; }

        public string Owner { get; set; }

        public int NumberOfWheels { get; set; }

        public int ModelYear { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string VehicleType { get; set; }
    }
}