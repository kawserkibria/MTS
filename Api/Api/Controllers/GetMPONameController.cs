using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/MPO")]
    public class GetMPONameController : ApiController
    {

        OTP.SWAPIClient objW = new OTP.SWAPIClient();


        //public IHttpActionResult Get(string id)
        //{
        //    List<OTP.MPO> values = objW.gstrGetMpoAreaDevisionList("0002", id,).ToList();
        //    return Json(values);
        //}
        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post(LogIn logParam)
        {
            OTP.MPO values = objW.gstrGetMpoAreaDevisionList("0003", logParam.UserID, logParam.Password);
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
    public class LogIn
    {
        public string UserID { get; set; }
        public string Password { get; set; }



    }
    //public class Parameter
    //{
    //    public string id1 { get; set; }
    //    public string id2 { get; set; }
    //    public string id3 { get; set; }

    //    public List<MyList> MyList { get; set; }
    //}

    //public class MyList
    //{
    //    public string Name { get; set; }
    //    public string MobileNo { get; set; }
    //}


}
