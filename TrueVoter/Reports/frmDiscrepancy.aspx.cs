using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmDiscrepancy : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindDistct();
            }

            string qd = string.Empty;
            try
            {
                qd = Request.QueryString[0];
            }
            catch
            {
                qd = "";
            }

            if (qd != "")
            {
                qd = cc.DESDecrypt(qd);
                string[] d=qd.Split('$');
                DataSet DS = new DataSet();
                DS = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindDistrict");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    ddlDistirct.DataSource = DS.Tables[0];
                    ddlDistirct.DataTextField = "DistrictName";
                    ddlDistirct.DataValueField = "DistrictCode";
                    ddlDistirct.DataBind();
                    ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistirct.SelectedValue = d[0].ToString();
                }
                else
                {

                }

                DataSet ds1 = new DataSet();
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@CreatedBy", d[0].ToString());
                par[1] = new SqlParameter("@query", "3");
                ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindRepsData", par);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddlLocalBody.DataSource = ds1.Tables[0];
                    ddlLocalBody.DataTextField = "ElectionName";
                    ddlLocalBody.DataValueField = "ElectionId";
                    ddlLocalBody.DataBind();
                    ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlLocalBody.SelectedValue = d[1].ToString();
                }
                else
                {

                }
               // txtWardNo.Text = d[2].ToString();
                ddlLocalBodytype.SelectedValue = d[3].ToString();
                bindGridView(d[0].ToString(), d[1].ToString());//, d[2].ToString());
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

        protected void lbtnGetDetails_Click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            string mNo = l.CommandArgument.ToString();
            string qs = mNo + "$" + hfDistId.Value + "$" + hfLbId.Value + "$" + hfWard.Value + "$" + hfLbTyp.Value;
            qs = cc.DESEncrypt(qs);
            Response.Redirect("frmDiscrepancyDetails.aspx?data=" + qs + "");
        }

        public void bindGridView(string dist,string lbid)//,string wNo)
        {
            hfDistId.Value = ddlDistirct.SelectedValue;
            hfLbId.Value = ddlLocalBody.SelectedValue;
            hfLbTyp.Value = ddlLocalBodytype.SelectedValue;
           // hfWard.Value = txtWardNo.Text;
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@DistId", dist);
            par[1] = new SqlParameter("@lbId", lbid);
            par[2] = new SqlParameter("@wardNo","0");// wNo);
            par[3] = new SqlParameter("@qry", "3");
            //par[3] = new SqlParameter("@qry", "1"); old grid view Bind
            par[4] = new SqlParameter("@CanMoNo", 0);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandiListWardWiseDescri", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["myData"] = ds.Tables[0];
                gvCandidateList.DataSource = ds.Tables[0];
                gvCandidateList.DataBind();
            }
            else
            {
                ViewState["myData"] = "No Data Found";
                gvCandidateList.EmptyDataText = "No Data Found";
                gvCandidateList.DataBind();
            }
        
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bindGridView(ddlDistirct.SelectedValue, ddlLocalBody.SelectedValue);//, txtWardNo.Text);
        }

        protected void gvCandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["myData"];
            gvCandidateList.PageIndex = e.NewPageIndex;
            gvCandidateList.DataSource = dt;
            gvCandidateList.DataBind();

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlLocalBodytype.SelectedIndex = 0;
            //txtWardNo.Text = string.Empty;

            gvCandidateList.EmptyDataText = "No Data Found";
            gvCandidateList.DataBind();
        }
    }
}