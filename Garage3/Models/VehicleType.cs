﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage3.Models
{
    public class VehicleType
    {
        [Key]
        public int VehicleType_Id { get; set; }
        [DisplayName("Vehicle Type")]
        public string Name { get; set; }
    }
}