using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3.Models
{
    public class Vehicle
    {
        [Key]
        public string Vehicle_ID { get; set; }
        [ForeignKey("Owner")]
        public int Owner_ID { get; set; }
        [ForeignKey("VehicleType")]
<<<<<<< HEAD
        public int VehicleType { get; set; }
=======
        public int Type { get; set; }

        //Navigational Prperty
        public virtual Owner Owner { get; set; }
        public virtual VehicleType Vehicletype { get; set; }

>>>>>>> 3c93670c39e1e16f534ea141f666ba4929e5503a
    }
}