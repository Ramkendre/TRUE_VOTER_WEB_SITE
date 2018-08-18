using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrueVoter.Reports
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = null;
            string imgID = context.Request.QueryString["imgID"];
            string MobileNo = context.Request.QueryString["MobileNo"];
            string query = "SELECT [TrueVoterDB].[dbo].[tblComplaint].[MobileNo],[ComID],[HomePhoto],[DocumentPhoto] FROM [TrueVoterDB].[dbo].[tblComplaint] INNER JOIN [TrueVoterDB].[dbo].[tblComplaintPhotos]ON [TrueVoterDB].[dbo].[tblComplaint].[ID]=[TrueVoterDB].[dbo].[tblComplaintPhotos].[ComID]WHERE [TrueVoterDB].[dbo].[tblComplaint].[MobileNo]='" + MobileNo + "' ORDER BY [TrueVoterDB].[dbo].[tblComplaint].[ID] DESC";
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            for (int i = 0; i > ds.Tables[0].Rows.Count; i++)
            {
                context.Response.ContentType = "image/jpg";
                context.Response.BinaryWrite((byte[])ds.Tables[0].Rows[i]["HomePhoto"]);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}