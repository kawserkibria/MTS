using Dutility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/SalesOrderInsert")]
    public class SalesOrderInsertController : ApiController
    {
        // GET api/salesorderinsert
        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        [HttpPost]
        [Route("Save")]
        public IHttpActionResult Save(ReturnModel param)
        {
            //for summary save
            string strSummary = "", strDetails = "";

            foreach (var item in param.summary)
            {
                if (item.reciveAddress=="")
                {
                    item.reciveAddress = "";
                }
                strSummary = strSummary + item.orderId + "|" + item.approveBy + "|" + item.approveDate + "|" + 12 + "|" + item.date + "|" + item.doctor + "|" + item.id +
                                               "|" + item.mpo + "|" + item.status + "|" + item.totalAmount + "|" + item.totlaQty + "|" + item.newCustomer + "|" + item.reciveAddress + "~";
                //methoe call

            }

            // for description save
            foreach (var item in param.details)
            {
                //string doctorName = item.doctorName;
                double dblbonus = Math.Round(Utility.mdblGetBonus("0004", item.itemName, "0001", item.itemQuentity, item.date), 2);
                string strUOM = Utility.gGetBaseUOM("0004", item.itemName);
                strDetails = strDetails + item.orderid + "|" + item.groupName + "|" + item.itemName + "|" + item.itemPrice + "|"
                                        + item.itemQuentity + "|" + item.itemTotalPrice + "|" + item.slabgroupName + "|" + strUOM + "|" + dblbonus + "~";
                //methoe call
            }
            string i = objW.SaveAPISalesOrder("0004", strSummary, strDetails);

            return Json(i);
        }
        //public IHttpActionResult Save(ReturnModel param)
        //{
        //    //for summary save
        //    string strSummary = "",strDetails="";

        //    foreach (var item in param.samary)
        //    {
        //        strSummary = strSummary + item.orderId + "|" + item.approveBy + "|" + item.approveDate + "|" + 12 + "|" + item.date + "|" + item.doctor + "|" + item.id +
        //                                       "|" + item.mpo + "|" +  item.status + "|" + item.totalAmount + "|" + item.totlaQty + "~";
        //        //methoe call
        //    }

        //   // for description save
        //    foreach (var item in param.describ)
        //    {
        //        //string doctorName = item.doctorName;
        //        double dblbonus = Math.Round(Utility.mdblGetBonus("0002", item.itemName, "0001", item.itemQuentity, item.date), 2);
        //        string strUOM = Utility.gGetBaseUOM("0002", item.itemName);
        //        strDetails = strDetails + item.orderid + "|" +  item.groupName + "|" + item.itemName + "|" + item.itemPrice + "|"
        //                                + item.itemQuentity + "|" + item.itemTotalPrice + "|" + item.slabgroupName + "|" + strUOM + "|" + dblbonus + "~";
        //        //methoe call
        //    }
        //    string i = objW.SaveAPISalesOrder("0002", strSummary, strDetails);

        //    return Json(param);
        //}

        public class ReturnModel
        {
            public List<summary> summary { get; set; }
            public List<details> details { get; set; }
        }
        public class summary
        {
            public string approveBy { get; set; }
            public string approveDate { get; set; }
            public string date { get; set; }
            public string doctor { get; set; }
            public string id { get; set; }
            public bool isSelected { get; set; }
            public string mpo { get; set; }
            public string orderId { get; set; }
            public string newCustomer { get; set; }
            public string reciveAddress { get; set; }

            public int status { get; set; }
            public double totalAmount { get; set; }
            public double totlaQty { get; set; }
            


        }
        public class details
        {
            public string mpo { get; set; }
            public string doctorName { get; set; }
            public string groupName { get; set; }
            public string itemName { get; set; }
            public double itemPrice { get; set; }
            public double itemQuentity { get; set; }
            public double itemTotalPrice { get; set; }
            public string orderid { get; set; }
            public string slabgroupName { get; set; }
            public string date { get; set; }


        }
    }
}
