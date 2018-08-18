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
    public partial class frmMarketPersonReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                //mob = "9881563737";
                if (IsPostBack == false)
                {
                    BindGridView("1");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }



        public void BindGridView(string query)
        {
            cmd.CommandText = "uspDownloadMarketPersonReports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = query;
            cmd.Parameters.Add("@mob", SqlDbType.NVarChar, 10).Value = mob;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMarketPersonDetails.DataSource = ds.Tables[0];
                gvMarketPersonDetails.DataBind();
            }
            else
            {
                gvMarketPersonDetails.DataSource = ds.Tables[0];
                gvMarketPersonDetails.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            if (rbtnReportType.SelectedValue == "1")
            {
                query = "1";
                BindGridView(query);
            }
            else if (rbtnReportType.SelectedValue == "2")
            {
                query = "2";
                BindGridView(query);
            }
            else
            {
                query = "3";
                BindGridView(query);
            }
        }
    }
}