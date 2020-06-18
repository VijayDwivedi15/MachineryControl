using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JainMachinery.Models
{
    public class AllSubProdust
    {
        public Int64 SubProductMainID { get; set; }
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string SubProductName { get; set; }
        public string SubProductImage { get; set; }
        public string Description { get; set; }
        public Int64 SubProductDetailID { get; set; }
    }

}