using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class StockgroupStudyController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        public IHttpActionResult Get()
        {
            //string values = objW.mLoadStockGroup("0002");
            List<OTP.Stockgroup> objGroup = objW.mLoadStockGroup("0003").ToList();

            Product1 model = new Product1();
            model.status = "no";
            if (objGroup.Count > 0)
            {
                model.status = "yes";
                model.items = objGroup.ToList();
            }

            return Json(model);

        }

    }
    public class Product1
    {
        public string status { get; set; }
        public List<OTP.Stockgroup> items { get; set; }


    }
}

