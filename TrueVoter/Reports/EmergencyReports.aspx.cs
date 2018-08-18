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
    public partial class EmergencyReports : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindgvEmergency();
                BindDistrict();
            }
        }

        private void BindDistrict()
        {
            cmd.CommandText = " SELECT [Id],[Name_M],[Name_E],[StateId]  FROM [TrueVoterDB].[dbo].[Districts] WHERE StateId =12";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = ds.Tables[0];
                ddlDistrict.DataTextField = "Name_E";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();

                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType],[DistrictCode],[DistrictName],[ACNo] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE [DistrictCode]='" + ddlDistrict.SelectedValue.ToString() + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlLocalBodyName.DataSource = ds1.Tables[0];
                ddlLocalBodyName.DataTextField = "ElectionName";
                ddlLocalBodyName.DataValueField = "ElectionId";
                ddlLocalBodyName.DataBind();

                ddlLocalBodyName.Items.Add("--Select--");
                ddlLocalBodyName.SelectedIndex = ddlLocalBodyName.Items.Count - 1;
            }
        }
        public void BindgvEmergency()
        {
            cmd.CommandText = "SELECT [EmSID],[EmergServiceName],[Remark],[Status],[Date],[LoginNumber],[CreatedBy] FROM [TrueVoterDB].[dbo].[tblEmergencyServices] order by EmSID desc";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEmergencyReports.DataSource = ds;
                gvEmergencyReports.DataBind();
            }
            else 
            {

            }
        }

        protected void gvEmergencyReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmergencyReports.PageIndex = e.NewPageIndex;
            BindgvEmergency();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            gvEmergencyReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            this.BindgvEmergency();
            string trueVoter = "TrueVoterEmergencyRpt" + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvEmergencyReports.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvEmergencyReports.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void ddlEmergencyService_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}