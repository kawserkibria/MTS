using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
     [RoutePrefix("api/smsapi")]
    public class SMSAPIController : ApiController
    {
        // GET api/smsapi
       

        OTP.SWAPIClient objW = new OTP.SWAPIClient();

       
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Get(Param objmobile)
        {
            string values = objW.mobileSMSAPI("0003", objmobile.Mobile);
            return Json(values);
        }


        public class Param
        {
            public string Mobile { get; set; }
            

        }
    }
}
