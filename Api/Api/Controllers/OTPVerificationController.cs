using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/OTPVerification")]
    public class OTPVerificationController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Get(Param objParam)
        {
            string values = objW.mGetOTPNo("0003", objParam.Mobile, objParam.Token);
            return Json(values);
        }
        public class Param
        {
            public string Mobile { get; set; }
            public string Token { get; set; }

        }


    }
}
