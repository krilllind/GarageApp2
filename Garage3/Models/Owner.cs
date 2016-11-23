using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage3.Models
{
    public class Owner
    {
        [Key]
        public string Owner_ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Vehicle")]
        public virtual Vehicle Vehicle { get; set; }
    }
}