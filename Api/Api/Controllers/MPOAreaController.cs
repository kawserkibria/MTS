using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class MPOAreaController : ApiController
    {
        // GET api/mpoarea
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/mpoarea/5
        public IHttpActionResult Get(string id)
        {
            List<OTP.MpoArea> values = objW.mLoadMpoArea("0003", id).ToList();
            return Json(values);
        }

        // POST api/mpoarea
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mpoarea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mpoarea/5
        public void Delete(int id)
        {
        }
    }
}
