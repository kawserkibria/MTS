using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/DisplaySalesOrder")]
    public class DisplaySalesOrderController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        // GET api/displaysalesorder
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Param param)
        {
            OTP.summaryNew values = objW.DisplayApiOrder("0003", param.strtc, param.intSyn);
            return Json(values);
        }
        // GET api/displaysalesorder/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        public class Param
        {
            public string strtc { get; set; }
            public int intSyn { get; set; }

        }

    }
}
