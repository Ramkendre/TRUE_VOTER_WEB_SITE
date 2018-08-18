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
    public partial class frmPollingDayActivity1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (IsPostBack == false)
                {
                    BindDistct();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void BindDistct()
        {
            DataSet DS = new DataSet();
            DS = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindDistrict");
            if (DS.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = DS.Tables[0];
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictCode";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlDistrict.SelectedIndex = 0;
            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmale.Text.ToString() == "" || txtfemale.Text.ToString() == "" || txtother.Text.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter all Fields are Mandatory...')", true);
                }
                else
                {
                    string val = Convert.ToString(ViewState["PId"]);
                    if (val == "" || val == null)
                    {
                        SqlParameter[] par = new SqlParameter[11];
                        par[0] = new SqlParameter("@male", txtmale.Text);
                        par[1] = new SqlParameter("@female", txtfemale.Text);
                        par[2] = new SqlParameter("@other", txtother.Text);
                        par[3] = new SqlParameter("@wardno", txtwardNo.Text);
                        par[4] = new SqlParameter("@boothno", txtboothNo.Text);
                        par[5] = new SqlParameter("@district", ddlDistrict.SelectedValue);
                        par[6] = new SqlParameter("@lbtype", ddlLocalbodyType.SelectedValue);
                        par[7] = new SqlParameter("@lb", ddlLocalbodyName.SelectedValue);
                        par[8] = new SqlParameter("@CreatedBy", mob.ToString());
                        par[9] = new SqlParameter("@returnval", SqlDbType.Int);
                        par[9].Direction = ParameterDirection.Output;
                        int result = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertPollingDayActivity1", par);

                        Response.Redirect("~/Reports/frmPollingDayActivityTwo.aspx?pollingId=" + par[9].Value.ToString() + "");
                    }
                    else
                    {
                        Response.Redirect("~/Reports/frmPollingDayActivityTwo.aspx?pollingId=" + ViewState["PId"].ToString() + "");
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1 = new DataSet();
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@CreatedBy", ddlDistrict.SelectedValue);
                par[1] = new SqlParameter("@query", "3");
                ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindRepsData", par);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddlLocalbodyName.DataSource = ds1.Tables[0];
                    ddlLocalbodyName.DataTextField = "ElectionName";
                    ddlLocalbodyName.DataValueField = "ElectionId";
                    ddlLocalbodyName.DataBind();
                    ddlLocalbodyName.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlLocalbodyName.SelectedIndex = 0;
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }

        protected void txtboothNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDistrict.SelectedValue == "0" || ddlLocalbodyType.SelectedValue == "0" || ddlLocalbodyName.SelectedValue == "0"
                    || txtwardNo.Text == "" || txtboothNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select all Fields are Mandatory...')", true);
                }
                else
                {
                    DataSet ds1 = new DataSet();
                    SqlParameter[] par = new SqlParameter[11];
                    par[0] = new SqlParameter("@district", ddlDistrict.SelectedValue);
                    par[1] = new SqlParameter("@lbtype", ddlLocalbodyType.SelectedValue);
                    par[2] = new SqlParameter("@lb", ddlLocalbodyName.SelectedValue);
                    par[3] = new SqlParameter("@wardno", txtwardNo.Text);
                    par[4] = new SqlParameter("@boothno", txtboothNo.Text);
                    par[5] = new SqlParameter("@createdby",mob.ToString());
                    ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindWardBootNohWiseData", par);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        txtmale.Text = Convert.ToString(ds1.Tables[0].Rows[0][1]);
                        txtfemale.Text = Convert.ToString(ds1.Tables[0].Rows[0][2]);
                        txtother.Text = Convert.ToString(ds1.Tables[0].Rows[0][3]);
                        ViewState["PId"] = Convert.ToString(ds1.Tables[0].Rows[0][0]);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}