using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

namespace TrueVoter.Reports
{
    public partial class frmNotices : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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

        public void bindGridView(string dist, string lbid)
        {
            hfDistId.Value = ddlDistirct.SelectedValue;
            hfLbId.Value = ddlLocalBody.SelectedValue;
            hfLbTyp.Value = ddlLocalBodytype.SelectedValue;
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@DistId", dist);
            par[1] = new SqlParameter("@lbId", lbid);
            par[2] = new SqlParameter("@qry", "1");
            par[3] = new SqlParameter("@CanMoNo", 0);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspNoticeLocalBodyWise", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["myData"] = ds.Tables[0];
                gvNotice.DataSource = ds.Tables[0];
                gvNotice.DataBind();
            }
            else
            {
                ViewState["myData"] = "No Data Found";
                gvNotice.EmptyDataText = "No Data Found";
                gvNotice.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bindGridView(ddlDistirct.SelectedValue, ddlLocalBody.SelectedValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                ddlDistirct.SelectedIndex = 0;
                ddlLocalBody.SelectedIndex = 0;
                ddlLocalBodytype.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lbtnGetDetails_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton l = (LinkButton)sender;
                string mNo = l.CommandArgument.ToString();
                string qs = mNo + "$" + hfDistId.Value + "$" + hfLbId.Value + "$" + hfLbTyp.Value;
                qs = cc.DESEncrypt(qs);
                Response.Redirect("frmNoticeDetails.aspx?data=" + qs + "");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}