using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{

     [RoutePrefix("api/NotificationUpdate")]
    public class UpdateNotificationController : ApiController
    {
         OTP.SWAPIClient objW = new OTP.SWAPIClient();


         [HttpPost]
         [Route("Post")]
         public IHttpActionResult Post(notification param)
         {
             string strSummary = "";
             //foreach (var item in param)
             //{
             //    strSummary = strSummary + item.orderid + "|" + item.teritorrycode + "|" + item.status + "~";
             //}
             int i = objW.mUpdateNotification("0003", param.orderid);
             return Json(i);
         }
         public class notification
         {
             public string orderid { get; set; }
             public string teritorrycode { get; set; }
             public int status { get; set; }

         }
    }
}
