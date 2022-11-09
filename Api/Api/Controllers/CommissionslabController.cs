
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CommissionslabController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        // GET api/commissionslab
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public IHttpActionResult Get()
        {
            List<Api.OTP.Commissionslab> values = objW.mLoadCommissionSlab("0003").ToList();
            return Json(values);
        }
        //// GET api/commissionslab/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/commissionslab
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/commissionslab/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/commissionslab/5
        //public void Delete(int id)
        //{
        //}
    }
}
