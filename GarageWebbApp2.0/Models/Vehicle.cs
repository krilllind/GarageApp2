using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace GarageWebbApp2._0.Models
{
    public class Vehicle
    {
        [Key, DisplayName("Registration Number"), RegularExpression("^[A-Z]{3}[0-9]{3}$", ErrorMessage = "Needs to be in the format off AAA111 and be unique."), Index(IsUnique = true), StringLength(450)]
        public string Vehicle_ID { get; set; }

        [ForeignKey("Owner"), DisplayName("Owners PNR")]
        public string Owner_ID { get; set; }

        [ForeignKey("VehicleType"), DisplayName("Vehicle Type")]
        public int Type { get; set; }

        [Required]
        public VehicleColors Color { get; set; }

        //Navigational Parperty
        public virtual Owner Owner { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }

    public enum FilterDates
    {
        None,
        Today,
        Week,
        Month
    }

    public enum VehicleColors
    {
        Red,
        Green,
        Blue,
        Black,
        White,
        Orange,
        Silver,
        Gray
    }
}