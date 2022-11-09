using Dutility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [Route("api/PDFgroup")]
    public class PDFgroupController : ApiController
    {
        [HttpPost]
        public IHttpActionResult mGetgroup(Myitems obj)
        {
            string strSQL = "";

            SqlCommand cmdInsert = new SqlCommand();
            SqlDataReader dr;
            string connstring = Utility.SQLConnstringProdctGalary("0001");
            List<Myitems> ooDocuments = new List<Myitems>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    strSQL = "SELECT distinct STOCKGROUP_NAME FROM DPL_PRODUCT_GALARY ";
                    strSQL = strSQL + "where CARD_TYPE=@intType ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Parameters.Add("@intType", SqlDbType.Int).Value = obj.inttype;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        Myitems objDocumnets = new Myitems();
                        objDocumnets.GroupName = dr["STOCKGROUP_NAME"].ToString();
                        ooDocuments.Add(objDocumnets);
                    }
                    dr.Close();
                    gcnMain.Close();
                    return Json(ooDocuments);
                }
                catch (Exception ex)
                {
                    return Json(ooDocuments);
                }
            }
        }

        public class Myitems
        {

            public string GroupName { get; set; }
            public int inttype { get; set; }

        }
    }
}
