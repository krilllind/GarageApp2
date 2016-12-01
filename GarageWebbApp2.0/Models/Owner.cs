using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace GarageWebbApp2._0.Models
{
    public class Owner
    {
        [Key, DisplayName("PNR")]
        public string Owner_ID { get; set; }

        [Required, RegularExpression("^[a-z|å|ä|öA-Z|Å|Ä|Ö ]*", ErrorMessage = "Can only contain 'a-ö', 'A-Ö' and spaces"), MaxLength(50)]
        public string Name { get; set; }
    }
}