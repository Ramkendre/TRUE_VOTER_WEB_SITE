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
    public partial class frmNoticeDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string d = Request.QueryString[0];
                if (d != "")
                {
                    try
                    {
                        d = cc.DESDecrypt(d);
                        string[] d1 = d.Split('$');
                        hfCanMob.Value = d1[0].ToString();
                        hfDistId.Value = d1[1].ToString();
                        hfLbId.Value = d1[2].ToString();
                        hfLbTyp.Value = d1[3].ToString();

                        SqlParameter[] par = new SqlParameter[5];
                        par[0] = new SqlParameter("@DistId", 0);
                        par[1] = new SqlParameter("@lbId", 0);
                        par[2] = new SqlParameter("@CanMoNo", d1[0].ToString());
                        par[3] = new SqlParameter("@qry", "2");
                        DataSet ds = new DataSet();
                        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspNoticeLocalBodyWise", par);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Status"].ToString() == "CLOSED")
                            {
                                remarkInsert.Visible = false;
                                btnstatus.Visible = false;
                            }
                            else
                            {
                                remarkInsert.Visible = true;
                            }

                            FvNoticeAndDis.DataSource = ds.Tables[0];
                            FvNoticeAndDis.DataBind();
                        }
                        BindGridRemark();
                    }
                    catch (Exception) { }
                }
            }
        }

        public void BindGridRemark()
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@MobileNo", hfCanMob.Value);
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DownloadRemarks", par);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvRemark.DataSource = ds.Tables[0];
                    gvRemark.DataBind();
                }

            }
            catch (Exception)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "InsertRemarks";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@remark", txtRemark.Text);
                cmd.Parameters.Add("@mobileno", hfCanMob.Value);
                cmd.Parameters.Add("@createdBy", Session["MobileNo"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Remark Submitted Successfully...')", true);
                txtRemark.Text = "";
                BindGridRemark();
            }
            catch (Exception)
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        protected void gvRemark_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvRemark.PageIndex = e.NewPageIndex;
                BindGridRemark();
            }
            catch (Exception)
            {

            }
        }

        protected void btnstatus_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "uspNoticeChangeStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mobileno", hfCanMob.Value);
                cmd.Parameters.Add("@modify", Session["MobileNo"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}