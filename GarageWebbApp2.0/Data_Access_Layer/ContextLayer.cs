using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GarageWebbApp2._0.Data_Access_Layer
{
    public class ContextLayer: DbContext
    {
        public DbSet<Models.Vehicle> Vehicles { get; set; }
        public ContextLayer() : base("DefaultConnection") {}
    }
}