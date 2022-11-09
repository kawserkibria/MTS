using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CustomerUpdateStatusController : ApiController
    {
        // GET api/CustomerUpdateStatus/Update/GP-83569- Dr.md Al-Amin -M/s Jonone Pharmacy
        OTP.SWAPIClient objW = new OTP.SWAPIClient();
        [HttpPost]
        public IHttpActionResult Update(ReturnModel param)
        {
            string strSummary = "";
            foreach (var item in param.myList)
            {

                strSummary = strSummary + item.strCustomerName + "~";
                //methoe call
            }
            string strname = objW.mUpdateCustomerOnlineStatus("0003", strSummary);
            return Json(strname);
        }


        public class ReturnModel
        {
            public List<LedgerName> myList { get; set; }
        }
        public class LedgerName
        {
            public string strCustomerName { get; set; }


        }
    }
}
