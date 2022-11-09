using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
   // [RoutePrefix("api/MPO")]
    public class OldMPOAreaController : ApiController
    {
        // GET api/mpoarea
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpGet]
        //[Route("Gettest/{uid:string}/{upass:string}")]
        //[Route("api/Task/{id:int}/{id2:int}/{id3}")]
        public IHttpActionResult Get(string id)
        {
            List<OTP.MpoArea> values = objW.mLoadMpoArea("0003", id).ToList();
            return Json(values);
        }
        //// vai ki ashen?



        //[HttpPost]
        //[Route("post")]
        //public IHttpActionResult Post(string UserID)
        //{
        //    List<OTP.MpoArea> values = objW.mLoadMpoArea("0002", UserID).ToList();
        //    return Json(values);
        //}

        //    [HttpPost]
        //    [Route("post")]
        //    public IHttpActionResult Post(Parameter param)
        //    {
        //        List<OTP.MpoArea> values = objW.mLoadMpoArea("0002","","").ToList();
        //        return Json(values);
        //    }

        //}
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
}
