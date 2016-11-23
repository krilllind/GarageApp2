using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3.Models
{
    public class Vehicle
    {
        public string Vehicle_ID { get; set; }
        [ForeignKey("Owner")]
        public int Owner_ID { get; set; }
        [ForeignKey("VehicleType")]
        public int Type { get; set; }

        //Navigational Prperty
        public virtual Owner Owner { get; set; }
        public virtual VehicleType Vehicletype { get; set; }

    }
}