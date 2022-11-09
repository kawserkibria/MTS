using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
     [RoutePrefix("api/CheckStatus")]
    public class CheckStatusController : ApiController
    {
         OTP.SWAPIClient objW = new OTP.SWAPIClient();
        [HttpPost]
        [Route("post")]
         public IHttpActionResult Post(LedgerName logParam)
        {
            string values = objW.mGetActive("0003", logParam.strLedgerName);
            return Json(values);
        }

        //[HttpPost]
        //[Route("post")]
        //public IHttpActionResult Post(Parameter param)
        //{
        //    OTP.MPO values = objW.gstrGetMpoAreaDevisionList("0002", "1", "305");
        //    return Json(values);
        //}

    }
     public class LedgerName
     {
         public string strLedgerName { get; set; }


     }
}
