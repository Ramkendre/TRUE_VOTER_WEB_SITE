using Microsoft.ApplicationBlocks.Data;
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
    public partial class frmACWardWiseCount : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        string roleID = string.Empty;
        GridView gvfor = new GridView();
        GridView gvUnfor = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           BindGridViewData();
        }

        public void BindGridViewData()
        {
            DataSet ds = new DataSet();
            if (txtACNO.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Please Enter AC No')", true);
            }
            else if (txtWardNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Please Enter Ward No')", true);
            }
            else
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@acNo", txtACNO.Text.Trim());
                par[1] = new SqlParameter("@wardNo", txtWardNo.Text.Trim());
                par[2] = new SqlParameter("@queryNo", "0");
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspDownloadCCDataACWardWise", par);
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                {
                    lblCountNo.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCountNo1.Text = Convert.ToString(ds.Tables[1].Rows.Count);
                    gvBoothAdd.DataSource = ds.Tables[0];
                    gvBoothAdd.DataBind();

                    gvfor.DataSource = ds.Tables[0];
                    gvfor.DataBind();
                    gvUnfor.DataSource = ds.Tables[1];
                    gvUnfor.DataBind();
                }
                else
                {
                    gvBoothAdd.EmptyDataText = "No Active Data Found";
                    gvBoothAdd.DataBind();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExportActive_Click(object sender, EventArgs e)
        {
            gvfor.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            BindGridViewData();
            string trueVoter = "ACWardControlChartApprovedData" + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvfor.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvfor.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }

        protected void btnExportDeActive_Click(object sender, EventArgs e)
        {
            gvUnfor.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            BindGridViewData();
            string trueVoter = "ACWardControlChartUnformatedData" + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvUnfor.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvUnfor.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }

        protected void gvBoothAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBoothAdd.PageIndex = e.NewPageIndex;
            BindGridViewData();
        }
    }
}