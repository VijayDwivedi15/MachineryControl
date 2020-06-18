using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JainMachinery.DAL
{
    public class AdminManager
    {
        UserContext db = new UserContext();


        public List<Models.AllSubProdust> GetAllSubProducts()
        {

            var status = new List<Models.AllSubProdust>();

            using (var db = new UserContext())
            {

                status = db.Database
                          .SqlQuery<Models.AllSubProdust>("exec All_SubProducts").ToList();
            }

            return status;
        }


    }
}