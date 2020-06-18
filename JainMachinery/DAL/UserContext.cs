using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JainMachinery.Models;

namespace JainMachinery.DAL

{
    public class UserContext : DbContext
    {
        public UserContext()

            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<JainMachinery.Models.Contact> Contact { get; set; }

        public virtual DbSet<JainMachinery.Models.ProductMaster> ProductMaster { get; set; }
        public virtual DbSet<JainMachinery.Models.SubProductMain> SubProductMain { get; set; }
        public virtual DbSet<JainMachinery.Models.SubProductDetail> SubProductDetail { get; set; }

        public virtual DbSet<JainMachinery.Models.ProductVideos> ProductVideos { get; set; }
        public virtual DbSet<JainMachinery.Models.ProductBrochure> ProductBrochure { get; set; }

    }
}