using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageWebbApp2._0.Models
{
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}[0-9]{3}$", ErrorMessage = "Needs to be in the format off AAA111 and be unique.")]
        public string RegNum { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-z|å|ä|öA-Z|Å|Ä|Ö ]*", ErrorMessage = "Can only contain 'a-ö', 'A-Ö' and spaces")]
        public string Owner { get; set; }

        [Required, Range(0, 8)]
        public int NumberOfWheels { get; set; }

        [Required, Range(0, 2017)]
        public int ModelYear { get; set; }

        [Required, MaxLength(50)]
        [RegularExpression("^[a-z|å|ä|öA-Z|Å|Ä|Ö0-9-/ ]*", ErrorMessage = "Can only contain 'a-ö', 'A-Ö' and spaces")]
        public string Model { get; set; }

        [Required]
        public VehicleColors Color { get; set; }

        [Required]
        public VehicleTypes VehicleType { get; set; }
    }

    public enum VehicleTypes
    {
        Car,
        Bus,
        Boat,
        Motorcycle
    }

    public enum VehicleColors
    {
        Red,
        Green,
        Blue,
        Black,
        White,
        Yellow,
        Silver,
        Gray
    }
}