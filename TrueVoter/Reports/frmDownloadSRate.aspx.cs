using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmDownloadSRate : System.Web.UI.Page
    {
        frmDownloadSRateBAL objBAL = new frmDownloadSRateBAL();
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
                    BindDistrict();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void BindDistrict()
        {
            DataSet ds = new DataSet();
            ds = objBAL.BindDistrictBAL();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = ds.Tables[0];
                ddlDistirct.DataTextField = "DistrictName";
                ddlDistirct.DataValueField = "DistrictCode";
                ddlDistirct.DataBind();
                ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlDistirct.SelectedIndex = 0;
            }
            else
            {
            }
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objBAL.DistID = Convert.ToInt32(ddlDistirct.SelectedValue);
            ds = objBAL.BindLocalBodyBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds.Tables[0];
                ddlLocalBody.DataTextField = "ElectionName";
                ddlLocalBody.DataValueField = "ElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                objBAL.LocalBodyId = Convert.ToInt32(ddlLocalBody.SelectedValue);
                ds = objBAL.BindSRates(objBAL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvStandardRates.DataSource = ds.Tables[0];
                    gvStandardRates.DataBind();
                }
                else
                {
                    ViewState["data"] = ds.Tables[0];
                    gvStandardRates.EmptyDataText = "No Data Found...";
                    gvStandardRates.DataBind();
                }
            }
            catch
            {
                ViewState["data"] = ds.Tables[0];
                gvStandardRates.EmptyDataText = "Error!!!";
                gvStandardRates.DataBind();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExcelDown_Click(object sender, EventArgs e)
        {
            try
            {
                gvStandardRates.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                gvStandardRates.DataSource = ViewState["data"];
                gvStandardRates.DataBind();
                string trueVoter = ddlLocalBody.SelectedItem.Text + "StandardRates" + System.DateTime.Today.ToString("dd-MM-yyyy");
                if (gvStandardRates.Visible)
                {
                    //Response.Clear();
                    Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                    // Response.Charset = "";
                    Response.ContentType = "application/excel";
                    StringWriter sWriter = new StringWriter();
                    HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                    gvStandardRates.RenderControl(hTextWriter);
                    Response.Write(sWriter.ToString());
                    Response.End();
                }
            }
            catch
            {
            }
        }

        protected void gvStandardRates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStandardRates.PageIndex = e.NewPageIndex;
            gvStandardRates.DataSource = ViewState["data"];
            gvStandardRates.DataBind();
        }
    }
}