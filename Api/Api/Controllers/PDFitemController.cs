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
    [Route("api/PDFitem")]
    public class PDFitemController : ApiController
    {

        [HttpPost]
        public IHttpActionResult mGetItem(Myitems obj)
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

                    strSQL = "SELECT distinct PRODUCT_G_NAME,PRODUCT_G_NAME FROM DPL_PRODUCT_GALARY ";
                    strSQL = strSQL + "WHERE STOCKGROUP_NAME=@groupname ";
                    strSQL = strSQL + "AND CARD_TYPE=@intType ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Parameters.Add("@groupname", SqlDbType.VarChar).Value = obj.strFileName;
                    cmdInsert.Parameters.Add("@intType", SqlDbType.Int).Value = obj.inttype;
                    dr = cmdInsert.ExecuteReader();
                    while  (dr.Read())
                    {
                        Myitems objDocumnets = new Myitems();
                        //objDocumnets.strgroupname = obj.strgroupname;
                        objDocumnets.strItemName = dr["PRODUCT_G_NAME"].ToString();
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

            public string strFileName { get; set; }
            public string strItemName { get; set; }
            public int inttype { get; set; }

        }
    }
}
