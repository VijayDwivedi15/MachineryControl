using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JainMachinery.DAL;

namespace JainMachinery.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/

        UserContext db = new UserContext();
        AdminManager admin = new AdminManager();
        public ActionResult Index()
        {
            ViewBag.Totalcategory = db.ProductMaster.Count();
            ViewBag.TotalMachines = db.SubProductDetail.Count();
            ViewBag.totalcontact = db.Contact.Count();
            return View();
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //return RedirectToAction("UserCP", "Dashboard", new { area = "Admin" });
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }



        public ActionResult ProductMaster(Int64 ProductID = 0)
        {
            Models.ProductMaster pm = new Models.ProductMaster();

            if (ProductID > 0)
            {
                var exist = db.ProductMaster.Where(s => s.ProductID == ProductID).FirstOrDefault();
                pm.ProductName = exist.ProductName;
                pm.ProductID = ProductID;
                pm.ProductImage = exist.ProductImage;
                ViewBag.ProductID = ProductID;
            }

            ViewData["Product"] = db.ProductMaster.ToList();
            return View(pm);
        }

        [HttpPost]

        public ActionResult ProductMaster(HttpPostedFileBase ProductImage, Int64 ProductID = 0, string ProductName = null, string ProductDetail=null)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            string productimg = null;
            productimg = "ProductMaster/" + ProductImage.FileName;

            Models.ProductMaster pm = new Models.ProductMaster();

            var Exist = db.ProductMaster.Where(s => s.ProductID == ProductID).FirstOrDefault();

            if (Exist == null)
            {
                pm.CreatedBy = userid;
                pm.CreatedDate = DateTime.Now;
                pm.ProductImage = productimg;
                pm.ProductName = ProductName;
                pm.ProductDetail = ProductDetail;

                db.ProductMaster.Add(pm);
                int i = db.SaveChanges();

                Status = "Succeeded";
                string path = Server.MapPath("~/ProductMaster/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ProductImage.SaveAs(path + ProductImage.FileName);

            }
            else
            {
                Exist.CreatedBy = userid;
                Exist.CreatedDate = DateTime.Now;
                Exist.ProductImage = productimg;
                Exist.ProductName = ProductName;
                Exist.ProductDetail = ProductDetail;

                db.SaveChanges();

                Status = "Succeeded";
                string path = Server.MapPath("~/ProductMaster/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ProductImage.SaveAs(path + ProductImage.FileName);
            }

            TempData["Example"] = Status;
            return RedirectToAction("ProductMaster", "Admin", new { area = "Admin" });

        }

        public ActionResult DeleteProduct(Int64 ProductID = 0)
        {
            string Status = "NA";

            var StatusExist = db.ProductMaster.Find(ProductID);
            if (StatusExist != null)
            {

                db.ProductMaster.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }
            TempData["Deleteexample"] = Status;
            return RedirectToAction("ProductMaster", "Admin", new { area = "Admin" });
        }



        private void PopulateProductMastre(object selectedvalue = null)
        {
            var productlist = db.ProductMaster.ToList();
            var product = new SelectList(productlist, "ProductID", "ProductName", selectedvalue);
            ViewBag.ProductID = product;
        }



        public ActionResult SubProducts()
        {
            PopulateProductMastre();
            return View();
        }


        [HttpPost]

        public ActionResult SubProducts(HttpPostedFileBase[] SubProductImage, Int64[] SubProductDetailID, string[] SubProductName, string[] Description, Int64 ProductID = 0)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            Models.SubProductMain main = new Models.SubProductMain();
            Models.SubProductDetail detail = new Models.SubProductDetail();

            main.CreatedBy = userid;
            main.CreatedDate = DateTime.Now;
            main.ProductID = ProductID;

            db.SubProductMain.Add(main);
            int i = db.SaveChanges();
            int k = 0;

            Int64 Lastid = 0;

            if (i > 0)
            {
                Lastid = db.SubProductMain.Where(p => p.CreatedBy == userid).Max(p => p.SubProductMainID);

                for (int j = 0; j < SubProductName.Length; j++)
                {


                    detail.SubProductMainID = Lastid;
                    detail.SubProductName = SubProductName[j];
                    detail.SubProductImage = SubProductImage[j].FileName;
                    detail.Description = Description[j];

                    db.SubProductDetail.Add(detail);
                    k = db.SaveChanges();
                    Status = "Succeeded";

                    string path = Server.MapPath("~/SubProducts/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    SubProductImage[j].SaveAs(path + Path.GetFileName(SubProductImage[j].FileName));

                }

            }

            TempData["Example"] = Status;
            return RedirectToAction("AllSubProducts", "Admin", new { area = "Admin" });
        }


        public ActionResult AllSubProducts()
        {
            var allsubproduct = admin.GetAllSubProducts();

            ViewData["SubProduvts"] = allsubproduct;
            return View();
        }

        public ActionResult ProductVideos()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ProductVideos(HttpPostedFileBase Video, Int64 VideoID = 0, string Title = null, string Description=null)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            string eventviedo = null;
            eventviedo = "Videos/" + Video.FileName;

            Models.ProductVideos pm = new Models.ProductVideos();


            pm.Description = Description;
            pm.UploadedDate = DateTime.Now;
            pm.Video = eventviedo;
            pm.Title = Title;

            db.ProductVideos.Add(pm);
            int i = db.SaveChanges();

            Status = "Succeeded";
            string path = Server.MapPath("~/Videos/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Video.SaveAs(path + Video.FileName);


            TempData["Example"] = Status;
            return RedirectToAction("AllProductVideos", "Admin", new { area = "Admin" });
        }

        public ActionResult AllProductVideos()
        {
            ViewData["Videos"] = db.ProductVideos.OrderByDescending(s => s.VideoID).ToList();
            return View();
        }

        public ActionResult DeleteEventVideos(Int64 VideoID = 0)
        {
            string Status = "NA";

            var StatusExist = db.ProductVideos.Find(VideoID);
            if (StatusExist != null)
            {

                db.ProductVideos.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            TempData["Example"] = Status;
            return RedirectToAction("AllProductVideos", "Admin", new { area = "Admin" });
        }


        public ActionResult AddProductBrochure()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductBrochure(HttpPostedFileBase Brochure, Int64 BrochureID = 0, string Title = null)
        {
            string userid = User.Identity.GetUserId();
            string Status = "";

            string eventviedo = null;
            eventviedo = "Videos/" + Brochure.FileName;

            Models.ProductBrochure pm = new Models.ProductBrochure();


         
            pm.UploadedDate = DateTime.Now;
            pm.Brochure = eventviedo;
            pm.Title = Title;

            db.ProductBrochure.Add(pm);
            int i = db.SaveChanges();

            Status = "Succeeded";
            string path = Server.MapPath("~/Videos/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Brochure.SaveAs(path + Brochure.FileName);


            TempData["Example"] = Status;
            return RedirectToAction("AddProductBrochure", "Admin", new { area = "Admin" });
        }

        public ActionResult AllBrochures()
        {
            ViewData["AllBrochures"] = db.ProductBrochure.OrderByDescending(s => s.BrochureID).ToList();
            return View();
        }


        public ActionResult DeleteProductBrochures(Int64 BrochureID=0)
        {
            string Status = "NA";

            var StatusExist = db.ProductBrochure.Find(BrochureID);
            if (StatusExist != null)
            {

                db.ProductBrochure.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            TempData["Example"] = Status;
            return RedirectToAction("AllBrochures", "Admin", new { area = "Admin" });
        }

        public ActionResult AllContactForm()
        {
            ViewData["AllContacts"] = db.Contact.OrderByDescending(s => s.ContactID).ToList();
            return View();
        }

        public ActionResult DeleteWebsiteContacts(Int64 ContactID = 0)
        {
            string Status = "NA";

            var StatusExist = db.Contact.Find(ContactID);
            if (StatusExist != null)
            {

                db.Contact.Remove(StatusExist);
                int result = db.SaveChanges();
                if (result == 1)
                    Status = "Deleted";
                else

                    Status = "Unsucceeded";
            }
            else
            {

                Status = "Unsucceeded";
            }

            TempData["Example"] = Status;
            return RedirectToAction("AllContactForm", "Admin", new { area = "Admin" });
        }


	}
}