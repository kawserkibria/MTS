using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
     [RoutePrefix("api/ApprovedSalesOrder")]
    public class ApprovedSalesOrderController : ApiController
    {
         OTP.SWAPIClient objW = new OTP.SWAPIClient();
        // GET api/approvedsalesorder
      
         
         [HttpPost]
         [Route("Approved") ]
         public IHttpActionResult Approved(List<summary> param)
         {
             string strSummary = "";
             foreach (var item in param)
             {
                 strSummary = strSummary + item.orderId + "|" + item.approveBy + "|" + item.approveDate + "~";
             }
             string i = objW.UpdateAPISalesOrder("0003", strSummary);
             return Json(i);
         }

       



         public class summary
         {
             public string approveBy { get; set; }
             public string approveDate { get; set; }
             public string orderId { get; set; }
             
         }


    }
}
