using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmDownloadCCData : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = null;
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (!Page.IsPostBack)
                {
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "uspGetCCDataOfficerWise";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add("@MoNo", SqlDbType.NVarChar, 10).Value = txtOfficerMoNo.Text.Trim();
            da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["CCData"] = ds.Tables[0];
                gvCCDetails.DataSource = ds.Tables[0];
                gvCCDetails.DataBind();

                ViewState["DisCCData"] = ds.Tables[1];
                GridView1.DataSource = ds.Tables[1];
                GridView1.DataBind();
            }
            else
            {
                gvCCDetails.EmptyDataText = "No Data Found";
                gvCCDetails.DataBind();

                GridView1.EmptyDataText = "No Data Found";
                GridView1.DataBind();
            }
        }
        protected void gvCCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            gvCCDetails.PageIndex = e.NewPageIndex;
            dt = (DataTable)ViewState["CCData"];
            gvCCDetails.DataSource = dt;
            gvCCDetails.DataBind();
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtOfficerMoNo.Text = string.Empty;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            GridView1.PageIndex = e.NewPageIndex;
            dt = (DataTable)ViewState["DisCCData"];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}