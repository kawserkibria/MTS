using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
     [RoutePrefix("api/smsapiverify")]
    public class SMSAPIVerifyController : ApiController
    {
        // GET api/smsapiverify
        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Get(Param objParam)
        {
            OTP.AppsVercifysumm values = objW.mobileSMSVerify("0003", objParam.mobile, objParam.otp, objParam.simICCno);
            return Json(values);
        }
        public class Param
        {
            public string mobile { get; set; }
            public string otp { get; set; }
            public string simICCno { get; set; }
        }
       
    }
}
