using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class GetCustomerController : ApiController
    {
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        // GET api/getcustomer
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/getcustomer/5
        public IHttpActionResult Get(string id)
        {
            List<OTP.Customer> values = objW.mLoadCustomerName("0003", id).ToList();
            return Json(values);
        }

        // POST api/getcustomer
        public void Post([FromBody]string value)
        {
        }

        // PUT api/getcustomer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/getcustomer/5
        public void Delete(int id)
        {
        }
    }
}
