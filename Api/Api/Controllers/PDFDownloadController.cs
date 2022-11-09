using Dutility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Api.Controllers
{
    [Route("api/PDFDownload")]
    public class PDFDownloadController : ApiController
    {
        // GET api/pdfdownload
      
        public HttpResponseMessage Get(string itemName, int intType)
        {


            var doc = ReadDouments(itemName, intType);
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            //Assign byte array to response content.
            response.Content = new ByteArrayContent(doc[0].byData);

            //Set "Content-Disposition: attachment" for downloading file through direct MIME transfer. 
            if (itemName != "")
            {
                response.Content.Headers.ContentDisposition =
                          new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                //response.Content.Headers.ContentDisposition.FileName = "OrderActivity.pdf";
                response.Content.Headers.ContentDisposition.FileName = itemName + ".pdf";
                //response.Content.Headers.Add("x-filename", "OrderActivity.pdf");
            }

            //Set MIME type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
           
            return response;
        }
        public List<MydocumentList> ReadDouments(string objName, int intType)
        {
            string strSQL = "";
            SqlCommand cmdInsert = new SqlCommand();
            SqlDataReader dr;
            string connstring = Utility.SQLConnstringProdctGalary("0001");
            List<MydocumentList> ooDocuments = new List<MydocumentList>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    strSQL = "SELECT PRO_FILE FROM DPL_PRODUCT_GALARY ";
                    strSQL = strSQL + "WHERE PRODUCT_G_NAME=@itemName ";
                    strSQL = strSQL + "AND CARD_TYPE=@intType ";
                    cmdInsert.Parameters.Add("@itemName", SqlDbType.VarChar).Value = objName;
                    cmdInsert.Parameters.Add("@intType", SqlDbType.Int).Value = intType;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.Connection = gcnMain;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        MydocumentList objDocumnets = new MydocumentList();
                        //objDocumnets.strFileName = dr["STOCKITEM_NAME"].ToString();
                        //objDocumnets.strType = dr["TYPE"].ToString();
                        byte[] imagem = (byte[])(dr["PRO_FILE"]);
                        objDocumnets.byData = imagem;
                        ooDocuments.Add(objDocumnets);
                    }
                    dr.Close();
                    gcnMain.Close();
                    return ooDocuments;
                }
                catch (Exception ex)
                {
                    return ooDocuments;
                }
            }
        }

        public class MydocumentList
        {

            public string strFileName { get; set; }
            public int strType { get; set; }
            public byte[] byData { get; set; }
        }
    }
}
