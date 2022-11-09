using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class mLoadItemRateController : ApiController
    {
        // GET api/mloaditemrate
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        public IHttpActionResult Get()
        {
            List<OTP.StockitemRate> values = objW.mLoadItemRate("0003", "").ToList();
            return Json(values);
        }


        // GET api/mloaditemrate/5
        public IHttpActionResult Get(string id)
        {
            List<OTP.StockitemRate> values = objW.mLoadItemRate("0003", id).ToList();
            return Json(values);
        }


        // POST api/mloaditemrate
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mloaditemrate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mloaditemrate/5
        public void Delete(int id)
        {
        }
    }
}
