using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class MPODivisionController : ApiController
    {
        // GET api/mpodivision
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/mpodivision/5
        public IHttpActionResult Get(string id)
        {
            List<OTP.Division> values = objW.mLoadMpoDivisoin("0003", id).ToList();
            return Json(values);
        }

        // POST api/mpodivision
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mpodivision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mpodivision/5
        public void Delete(int id)
        {
        }
    }
}
