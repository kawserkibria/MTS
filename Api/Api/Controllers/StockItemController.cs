using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class StockItemController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
      
        // GET api/stockitem/5
        public IHttpActionResult Get(string id)
        {
            List<OTP.StockItem> values = objW.mGetStockItemFromGroup("0003", id, "0001").ToList();
            return Json(values);
        }
       
      
    }
}
