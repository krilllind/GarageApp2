using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Garage3.Models
{
    public class Vehicle
    {
        [Key, DisplayName("Registration Number")]
        public string Vehicle_ID { get; set; }
        [ForeignKey("Owner") ]
        [Required, DisplayName("Owners PNR")]
        public string Owner_ID { get; set; }
        [ForeignKey("VehicleType"), DisplayName("Vehicle Type")]
        public int Type { get; set; }

        //Navigational Parperty
        public virtual Owner Owner { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}