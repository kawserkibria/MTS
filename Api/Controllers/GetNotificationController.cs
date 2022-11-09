using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/GetNotification")]
    public class GetNotificationController : ApiController
    {

        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Param code)
        {
            try
            {
                List<OTP.notification> values = objW.mGetAppsNotifucation("0004", code.strtc, code.utype).ToList();
                return Json(values);
            }
            catch (Exception ex)
            {
                return Json("Please Update");
            }
        }

        public class Param
        {
            public string strtc { get; set; }
            public string utype { get; set; }

        }
    }
}
