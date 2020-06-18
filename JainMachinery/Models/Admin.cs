using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JainMachinery.Models
{
    public class Contact
    {
        [Key]

        public Int64 ContactID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string Message { get; set; }

        public DateTime ContactDate { get; set; }


    }

    public class ProductMaster
    {
        [Key]
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public string ProductDetail { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class SubProductMain
    {
        [Key]
        public Int64 SubProductMainID { get; set; }
        public Int64 ProductID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public class SubProductDetail
    {
        [Key]
        public Int64 SubProductDetailID { get; set; }
        public Int64 SubProductMainID { get; set; }
        public string SubProductName { get; set; }
        public string SubProductImage { get; set; }
        public string Description { get; set; }
    }

    public class ProductVideos
    {
        [Key]
        public Int64 VideoID { get; set; }
        public string Title { get; set; }
        public string Video { get; set; }
        public DateTime UploadedDate { get; set; }
        public string Description { get; set; }

    }

    public class ProductBrochure
    {
        [Key]

        public Int64 BrochureID { get; set; }
        public string Title { get; set; }
        public string Brochure { get; set; }
        public DateTime UploadedDate { get; set; }
    }


}