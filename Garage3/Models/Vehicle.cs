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
        public virtual Owner Owner_ID { get; set; }
        [ForeignKey("VehicleType")]
        public int Vehicletype { get; set; }
    }
}