using Microsoft.ApplicationBlocks.Data;
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
    public partial class frmBLOReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindDistct();
            }

        }

        public void BindDistct()
        {
            DataSet DS = new DataSet();
            DS = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindDistrict");
            if (DS.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = DS.Tables[0];
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
            DataSet ds1 = new DataSet();
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@CreatedBy", ddlDistirct.SelectedValue);
            par[1] = new SqlParameter("@query", "3");
            ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindRepsData", par);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds1.Tables[0];
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
            BindBLOGridView(ddlLocalBody.SelectedValue);
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlLocalBodytype.SelectedIndex = 0;

            gvBLOLocalBody.EmptyDataText = "No Data Found";
            gvBLOLocalBody.DataBind();

            gvOfficerReports.EmptyDataText = "No Data Found";
            gvOfficerReports.DataBind();
            
            gvJrDetails.EmptyDataText = "No Data Found";
            gvJrDetails.DataBind();
        }

        public void BindBLOGridView(string localBodyId)
        {
            gvOfficerReports.EmptyDataText = "No Data Found";
            gvOfficerReports.DataBind();

            gvJrDetails.EmptyDataText = "No Data Found";
            gvJrDetails.DataBind();

            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@lbId", localBodyId);
            par[1] = new SqlParameter("@qry", 1);
            par[2] = new SqlParameter("@disId", 0);
            par[3] = new SqlParameter("@moNo", 0);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetBLOListLocalBodyWise", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["vOne"] = ds.Tables[0];
                gvBLOLocalBody.DataSource = ds.Tables[0];
                gvBLOLocalBody.DataBind();
            }
            else
            {
                gvBLOLocalBody.EmptyDataText = "No Data Found";
                gvBLOLocalBody.DataBind();
            }
        }

        protected void lbtnGetDetails_Click(object sender, EventArgs e)
        {
            gvJrDetails.EmptyDataText = "No Data Found";
            gvJrDetails.DataBind();

            LinkButton lbnObj = (LinkButton)sender;
            string DisgId = Convert.ToString(lbnObj.CommandArgument);
            string[] dataSp = DisgId.Split(',');
            string disId = dataSp[0];
            string lbId = dataSp[1];

            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@lbId", lbId);
            par[1] = new SqlParameter("@qry", 2);
            par[2] = new SqlParameter("@disId", disId);
            par[3] = new SqlParameter("@moNo", 0);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetBLOListLocalBodyWise", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["vTwo"] = ds.Tables[0];
                gvOfficerReports.DataSource = ds.Tables[0];
                gvOfficerReports.DataBind();
            }
            else
            {
                gvOfficerReports.EmptyDataText = "No Data Found";
                gvOfficerReports.DataBind();
            }
        }

        protected void lbtnGetJrDetails_Click(object sender, EventArgs e)
        {
            LinkButton lbnObj = (LinkButton)sender;
            string DisgId = Convert.ToString(lbnObj.CommandArgument);
            string[] dataSp = DisgId.Split(',');
            string disId = dataSp[0];
            string lbId = dataSp[1];
            string moNo = dataSp[2];
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@lbId", lbId);
            par[1] = new SqlParameter("@qry", 3);
            par[2] = new SqlParameter("@disId", disId);
            par[3] = new SqlParameter("@moNo", moNo);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetBLOListLocalBodyWise", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["vThree"] = ds.Tables[0];
                gvJrDetails.DataSource = ds.Tables[0];
                gvJrDetails.DataBind();
            }
            else
            {
                gvJrDetails.EmptyDataText = "No Data Found";
                gvJrDetails.DataBind();
            }
        }

        protected void gvBLOLocalBody_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfficerReports.EmptyDataText = "No Data Found";
            gvOfficerReports.DataBind();

            gvJrDetails.EmptyDataText = "No Data Found";
            gvJrDetails.DataBind();

            DataTable dt = (DataTable)ViewState["vOne"];
            gvBLOLocalBody.PageIndex = e.NewPageIndex;
            gvBLOLocalBody.DataSource = dt;
            gvBLOLocalBody.DataBind();
        }

        protected void gvOfficerReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJrDetails.EmptyDataText = "No Data Found";
            gvJrDetails.DataBind();


            DataTable dt = (DataTable)ViewState["vTwo"];
            gvOfficerReports.PageIndex = e.NewPageIndex;
            gvOfficerReports.DataSource = dt;
            gvOfficerReports.DataBind();
        }

        protected void gvJrDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["vThree"];
            gvJrDetails.PageIndex = e.NewPageIndex;
            gvJrDetails.DataSource = dt;
            gvJrDetails.DataBind();
        }

    }
}