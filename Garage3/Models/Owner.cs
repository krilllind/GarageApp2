using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Garage3.Models
{
    public class Owner
    {
        [Key]
        public string Owner_ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Vehicle")]
        public string Vehicle_ID { get; set; }
        //Navigational Prperty
        public virtual IEnumerable<Vehicle> Vehicle { get; set; }
    }
}