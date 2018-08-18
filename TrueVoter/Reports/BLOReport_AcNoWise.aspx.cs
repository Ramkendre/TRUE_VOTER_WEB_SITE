using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

namespace TrueVoter.Reports
{
    public partial class BLOReport_AcNoWise : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string mob = string.Empty;
        string roleID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null)
            {
                if (IsPostBack == false)
                {

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DataTable dtvalue = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[dbo].[uspGetAbstractCCData]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ACNO", SqlDbType.NVarChar, 20).Value = txtAcNo.Text;
                cmd.Parameters.Add("@PARTNO", SqlDbType.NVarChar, 20).Value = "7";
                cmd.Parameters.Add("@MaxID", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@QUERY", SqlDbType.NVarChar, 20).Value = "7";
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtvalue = ds.Tables[0];
                    string excelFileName = "BloReport.xlsx";

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtvalue, "AcExcel");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + excelFileName + "");

                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No Data Found');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}