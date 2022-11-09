using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
      [RoutePrefix("api/ChangeSalesOrder")]
    public class ChangeSalesOrderController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Param param)
        {
            OTP.summaryNew values = objW.DisplayApiChangeOrder("0003", param.strtc);
            return Json(values);
        }
        
        public class Param
        {
            public string strtc { get; set; }
            

        }
    }
}
