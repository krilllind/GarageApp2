using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWebbApp2._0.Models
{
    public class VehicleViewModels
    {
        public string Owner { get; set; }

        public string RegNum { get; set; }

        public string Color { get; set; }

        public string VehicleType { get; set; }
    }
}