using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Garage3.Models
{
    public class Owner
    {
        [Key, DisplayName("PNR")]
        public string Owner_ID { get; set; }
        public string Name { get; set; }
        
    }
}