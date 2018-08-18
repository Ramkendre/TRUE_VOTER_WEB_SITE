using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmControlChartStatusCount : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtACNo.Text != "")
            {
                StringBuilder MyStringBuilder = new StringBuilder("SELECT [ToUser],(SELECT (Name+' '+LName) AS Name FROM [TrueVoterDB].[dbo].[Logins] Where [UserName]=[ToUser]) AS WardofficerName,");
                MyStringBuilder.Append("[FromUser],(SELECT (Name+' '+LName) AS Name FROM [TrueVoterDB].[dbo].[Logins] Where [UserName]=[FromUser]) AS BLOName,[vstatus],");
                MyStringBuilder.Append("[ACNO],[PartNo],[WardNo],COUNT([SrNo]) AS TOTAL FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WHERE ");

                if (txtACNo.Text != "")
                {
                    MyStringBuilder.Append("[ACNO]='" + txtACNo.Text + "' AND");
                }
                if (txtPart.Text != "")
                {
                    MyStringBuilder.Append("[PartNo]='" + txtPart.Text + "' AND");
                }
                if (txtwardOffMoNo.Text != "")
                {
                    MyStringBuilder.Append("[ToUser]='" + txtwardOffMoNo.Text + "' AND");
                }
                if (txtMoNo.Text != "")
                {
                    MyStringBuilder.Append("[FromUser]='" + txtMoNo.Text + "' AND");
                }
                if (txtDate.Text != "")
                {
                    MyStringBuilder.Append("[CreateDate] like '" + txtDate.Text + "%' AND");
                }
                MyStringBuilder.Remove(MyStringBuilder.Length - 4, 4);

                MyStringBuilder.Append(" group by [vstatus],[ACNO],[PartNo],[WardNo],[FromUser],[ToUser] ORDER BY [WardNo]");


                cmd.Connection = con;
                cmd.CommandText = MyStringBuilder.ToString();
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvControlChartData.DataSource = ds.Tables[0];
                    gvControlChartData.DataBind();
                }
                else
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvControlChartData.DataSource = ds.Tables[0];
                    gvControlChartData.DataBind();
                }

                try
                {
                    lblRecordcnt.Text = "Total Records :" + ds.Tables[0].Rows.Count;
                }
                catch
                {
                    lblRecordcnt.Text = "No Data Found";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this,typeof(Page),"Message","alert('Please Enter Ac No')",true);
            }

            //if (txtACNo.Text != "" && txtMoNo.Text != "")
            //{
            //    cmd.CommandText = "uspGetStatusCntRptDataNew";
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@ACNO", SqlDbType.NVarChar, 20).Value = txtACNo.Text;
            //    cmd.Parameters.Add("@MoNo", SqlDbType.NVarChar, 20).Value = txtMoNo.Text;
            //    cmd.Parameters.Add("@dt", SqlDbType.NVarChar, 20).Value = txtDate.Text;
            //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "3";
            //    da = new SqlDataAdapter(cmd);
            //    ds.Clear();
            //    da.Fill(ds);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //    else
            //    {
            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //}
            //else if (txtACNo.Text != "" && txtMoNo.Text == "")
            //{
            //    cmd.CommandText = "uspGetStatusCntRptDataNew";
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@ACNO", SqlDbType.NVarChar, 20).Value = txtACNo.Text;
            //    cmd.Parameters.Add("@MoNo", SqlDbType.NVarChar, 20).Value = txtMoNo.Text;
            //    cmd.Parameters.Add("@dt", SqlDbType.NVarChar, 20).Value = txtDate.Text;
            //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "2";
            //    da = new SqlDataAdapter(cmd);
            //    ds.Clear();
            //    da.Fill(ds);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //    else
            //    {
            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //}
            //else if (txtACNo.Text == "" && txtMoNo.Text != "")
            //{
            //    cmd.CommandText = "uspGetStatusCntRptDataNew";
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@ACNO", SqlDbType.NVarChar, 20).Value = txtACNo.Text;
            //    cmd.Parameters.Add("@MoNo", SqlDbType.NVarChar, 20).Value = txtMoNo.Text;
            //    cmd.Parameters.Add("@dt", SqlDbType.NVarChar, 20).Value = txtDate.Text;
            //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "1";
            //    da = new SqlDataAdapter(cmd);
            //    ds.Clear();
            //    da.Fill(ds);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {

            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //    else
            //    {
            //        ViewState["data"] = null;
            //        ViewState["data"] = ds.Tables[0];
            //        gvControlChartData.DataSource = ds.Tables[0];
            //        gvControlChartData.DataBind();
            //    }
            //}
            //try
            //{
            //    lblRecordcnt.Text = "Total Records :" + ds.Tables[0].Rows.Count;
            //}
            //catch
            //{
            //    lblRecordcnt.Text = "No Data Found";
            //}
        }

        protected void gvControlChartData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["data"];
            gvControlChartData.PageIndex = e.NewPageIndex;
            gvControlChartData.DataSource = dt;
            gvControlChartData.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtACNo.Text = string.Empty;
            txtMoNo.Text = string.Empty;
            ViewState["data"] = null;
        }
    }
}