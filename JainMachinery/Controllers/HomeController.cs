using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JainMachinery.DAL;

namespace JainMachinery.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();
        AdminManager admin = new AdminManager();
        public ActionResult Index()
        {
            ViewData["masterproducts"] = db.ProductMaster.Take(4).ToList();
            ViewData["Videos"] = db.ProductVideos.OrderByDescending(s=>s.VideoID).Take(3).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]

        public ActionResult ContactSubmit()
        {
            return View();
        }


        public ActionResult Products()
        {
            ViewData["masterproducts"] = db.ProductMaster.ToList();
            return View();
        }


        public ActionResult ProductDetail(Int64 SubProductDetailID = 0)
        {
            ViewData["ProductDetail"] = db.SubProductDetail.Where(s => s.SubProductDetailID == SubProductDetailID).FirstOrDefault();
            ViewData["ReletedProduct"] = db.SubProductDetail.Take(4).ToList();
            
            return View();
        }

        public ActionResult FoodProcessingMachine()
        {
            return View();
        }

        public ActionResult AgriculerMachine()
        {
            return View();
        }

        public ActionResult SprayPumsandGuns()
        {
            return View();
        }

        public ActionResult PumpsandMotors()
        {
            return View();
        }

        public ActionResult AllProducts(Int64 ProductID = 0)
        {
            var allproducts = admin.GetAllSubProducts().Where(s => s.ProductID == ProductID).ToList();
            ViewData["AllProduct"] = allproducts;
            ViewBag.ProductID = ProductID;

            return View();
           
        }

        public ActionResult ProductDemo()
        {
            ViewData["Videos"] = db.ProductVideos.OrderByDescending(s => s.VideoID).ToList();
            return View();
        }

        public ActionResult ProductBrochures()
        {
            ViewData["Brochures"] = db.ProductBrochure.ToList();
            return View();
        }



        public ActionResult SubmitContactData(string Name = null, string MobileNo = null, string Email = null, string CompanyName = null, string ProductName = null, string Message=null)
        {
            string Status = "";

            Models.Contact contact = new Models.Contact();

            contact.CompanyName = CompanyName;
            contact.ContactDate = DateTime.Now;
            contact.Email = Email;
            contact.Message = Message;
            contact.MobileNo = MobileNo;
            contact.Name = Name;
            contact.ProductName = ProductName;
            db.Contact.Add(contact);
            db.SaveChanges();

            ViewBag.Status = Status;
            return Json(Status, JsonRequestBehavior.AllowGet);
        }

    }
}