using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JainMachinery.DAL
{
    public class Global
    {
        public static string result = String.Empty;
        public static string WebsiteUrl()
        {

            switch (ConfigurationManager.AppSettings["Environment"].ToString().ToLower())
            {

                case "local":
                    result = "http://localhost:1882/";
                    break;
                case "development":
                    result = "http://jainmachinery.com/";
                    break;
                case "production":
                    result = "http://jainmachinery.jihuzzur.com/";
                    break;
                default:
                    result = "http://www.hihuzurweb.com/";
                    break;
            }

            return result;
        }
        public class Page
        {
            public int PageSize { get; set; }
        }
        public List<Page> GetPaging()
        {
            List<Page> PageList = new List<Page>();
            PageList.Add(new Page { PageSize = 1 });
            PageList.Add(new Page { PageSize = 5 });
            PageList.Add(new Page { PageSize = 10 });
            PageList.Add(new Page { PageSize = 20 });
            PageList.Add(new Page { PageSize = 50 });
            PageList.Add(new Page { PageSize = 100 });

            return PageList;
        }
    }
}