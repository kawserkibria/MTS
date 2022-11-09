using Dutility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.UI;
namespace Api.Controllers
{

    [Route("api/GetPDF")]
    public class GetPDFController : ApiController
    {

        OTP.SWAPIClient objW = new OTP.SWAPIClient();

        [HttpGet]

        //public List<MydocumentList> ReadDouments(string objName, int intType)
        //{
        //    string strSQL = "";
        //    SqlCommand cmdInsert = new SqlCommand();
        //    SqlDataReader dr;
        //    string connstring = Utility.SQLConnstringProdctGalary("0001");
        //    List<MydocumentList> ooDocuments = new List<MydocumentList>();
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        try
        //        {
        //            gcnMain.Open();

        //            strSQL = "SELECT PRO_FILE FROM DPL_PRODUCT_GALARY ";
        //            strSQL = strSQL + "WHERE PRODUCT_G_NAME=@itemName ";
        //            strSQL = strSQL + "AND CARD_TYPE=@intType ";
        //            cmdInsert.Parameters.Add("@itemName", SqlDbType.VarChar).Value = objName;
        //            cmdInsert.Parameters.Add("@intType", SqlDbType.Int).Value = intType;
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.Connection = gcnMain;
        //            dr = cmdInsert.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                MydocumentList objDocumnets = new MydocumentList();
        //                //objDocumnets.strFileName = dr["STOCKITEM_NAME"].ToString();
        //                //objDocumnets.strType = dr["TYPE"].ToString();
        //                byte[] imagem = (byte[])(dr["PRO_FILE"]);
        //                objDocumnets.byData = imagem;
        //                ooDocuments.Add(objDocumnets);
        //            }
        //            dr.Close();
        //            gcnMain.Close();
        //            return ooDocuments;
        //        }
        //        catch (Exception ex)
        //        {
        //            return ooDocuments;
        //        }
        //    }
        //}

        //public HttpResponseMessage Get(string itemName, int intType)
        //{


        //    var doc = ReadDouments(itemName, intType);
        //    var response = new HttpResponseMessage(HttpStatusCode.OK);

        //    //////Assign byte array to response content.
        //    response.Content = new ByteArrayContent(doc[0].byData);

        //    //////Set "Content-Disposition: attachment" for downloading file through direct MIME transfer. 
        //    if (itemName != "")
        //    {
        //        response.Content.Headers.ContentDisposition =
        //                  new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //        ////response.Content.Headers.ContentDisposition.FileName = "OrderActivity.pdf";
        //        response.Content.Headers.ContentDisposition.FileName = itemName + ".pdf";
        //        //response.Content.Headers.Add("x-filename", "OrderActivity.pdf");

        //    }

        //    ////Set MIME type.
        //    ////response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        //    return response;
        //}

        public HttpResponseMessage Get(string itemName, int intType)
        {
            //var response = new HttpResponseMessage(HttpStatusCode.OK);
          
            string FilePath = objW.ReadDouments(itemName, intType);
          

            //HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
            //response.Content = new StreamContent(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
            ////WebClient User = new WebClient();
            ////Byte[] FileBuffer = User.DownloadData(FilePath);

            ////if (FileBuffer != null)
            //{

            ////    response.ContentType = "application/pdf";
            ////    response.AppendHeader("content-length", FileBuffer.Length.ToString());
            ////    response.BinaryWrite(FileBuffer);
            ////}  
          
            ////string pdfPath = FilePath;
            ////string jsFoo = "var pdf = window.open('" + pdfPath + "','_blank', 'width=1400, height = 850');pdf.moveTo(0,0);";
            ////ScriptManager.RegisterStartupScript(Page, Page.GetType(), "blah", jsFoo, true);
            //return response;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //if (File.Exists(FilePath))
            //{
            //    //File.Delete(dest);

            //    FileStream fileStream = new FileStream(FilePath, FileMode.Open,FileShare.Read);
            //    response.Content = new StreamContent(fileStream);
            //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            //    response.Content.Headers.ContentDisposition.FileName = "kk.pdf";
               
            //}
            return response;
        }



        #region "Comments"
        //public HttpResponseMessage Get(string itemName, int intType)
        //{
        //    var doc = ReadDouments(itemName, intType);
        //    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(doc[0].byData);
        //    result.Content.Headers.ContentType =
        //        new MediaTypeHeaderValue("application/octet-stream");

        //    return result;
        //}

        //public string loadPD(string objName)
        //{

        //    string filesName = "";
        //    string extenstype = ".pdf";

        //    filesName = Path.GetTempFileName();
        //    string ff = filesName.Substring(filesName.LastIndexOf('\\') + 1);
        //    filesName = filesName.Replace(ff, "");
        //    filesName = filesName + "Test" + extenstype;

        //    string strSQL = "";
        //    string connstring = Utility.SQLConnstringProdctGalary("0001");




        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader dr;

        //    //SqlCommand cmd = new SqlCommand("GetTestReportDocuments", sqlConn);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.AddWithValue("@ReportID", reportid);


        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        cmd.Connection = gcnMain;


        //        strSQL = "SELECT PRO_FILE FROM DPL_PRODUCT_GALARY ";
        //        if (objName != "")
        //        {
        //            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + objName + "' ";
        //        }
        //        cmd.CommandText = strSQL;
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            int size = 1024 * 1024;
        //            byte[] buffer = new byte[size];
        //            int readBytes = 0;
        //            int index = 0;
        //            using (FileStream fs = new FileStream(filesName, FileMode.Create, FileAccess.Write, FileShare.None))
        //            {
        //                while ((readBytes = (int)dr.GetBytes(0, index, buffer, 0, size)) > 0)
        //                {
        //                    fs.Write(buffer, 0, readBytes);
        //                    index += readBytes;

        //                }
        //            }

        //        }
        //    }
        //    try
        //    {
        //        Process prc = new Process();
        //        prc.StartInfo.FileName = filesName;
        //        prc.Start();
        //        //return Request.CreateResponse(HttpStatusCode.OK, "Ok" + filesName);
        //        //return Json(filesName);
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.ToString());
        //        throw ex;
        //    }


        //}
        //public class Param
        //{
        //    public string reportid { get; set; }


        //}
        #endregion
        public class MydocumentList
        {

            public string strFileName { get; set; }
            public int strType { get; set; }
            public byte[] byData { get; set; }
        }


    }
}
