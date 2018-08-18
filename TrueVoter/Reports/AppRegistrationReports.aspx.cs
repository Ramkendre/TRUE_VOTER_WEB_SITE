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

namespace TrueVoter.Reports
{
    public partial class AppRegistrationReports : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string query = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgvAppRegistrationReports();
        }

        public void bindgvAppRegistrationReports()
        {
            cmd.CommandText = "SELECT L.[UserName],L.[RegId],(L.[Name]+' '+L.[Mname]+' '+L.[LName]) AS FULLNAME,L.[MobileNo],L.[address]" +
                              ",SM.[StateName],DM.[DistrictName],CM.[CityName] FROM [TrueVoterDB].[dbo].[Logins] AS L LEFT JOIN [TrueVoterDB].[dbo].[StateMaster] AS " +
                              "SM ON L.[State]=SM.[SID] LEFT JOIN [TrueVoterDB].[dbo].[DistrictMaster] AS DM ON L.District=DM.[DistrictId] LEFT JOIN [TrueVoterDB].[dbo].[CityMaster] AS CM ON L.[Taluka]=CM.[CityId] WHERE [UserType]='" + ddlRole.SelectedValue.ToString() + "' ORDER BY ID DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAppRegistrationReports.DataSource = ds;
                gvAppRegistrationReports.DataBind();
            }
            else
            {

            }
        }

        protected void gvAppRegistrationReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAppRegistrationReports.PageIndex = e.NewPageIndex;
            bindgvAppRegistrationReports();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            gvAppRegistrationReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            this.bindgvAppRegistrationReports();
            string trueVoter = "TrueVoterAppRegistered " + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvAppRegistrationReports.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvAppRegistrationReports.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}