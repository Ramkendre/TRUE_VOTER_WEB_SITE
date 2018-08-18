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
    public partial class frmAddLocalBody : System.Web.UI.Page
    {
        string mob = string.Empty;
        string roleID = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    BindDistrict();
                    gvBindLocalBody();
                    btnSubmit.Text = "Submit";
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
            ds = SqlHelper.ExecuteDataset(con,CommandType.StoredProcedure,"uspBindDistrict");
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

        public void gvBindLocalBody()
        {
            try
            {
                DataSet ds = null;
                //SqlParameter[] par = new SqlParameter[1];
                //par[0] = new SqlParameter("@mob", mob.Trim());
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetLocalBodys");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvLocalBodys.DataSource = ds.Tables[0];
                    gvLocalBodys.DataBind();
                }
                else
                {
                    gvLocalBodys.EmptyDataText = "No Data Found";
                    gvLocalBodys.DataBind();
                }
            }
            catch
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (mob != null)
            {
                if (btnSubmit.Text == "Submit")
                {
                    SqlParameter[] par = new SqlParameter[7];
                    par[0] = new SqlParameter("@ElectionId", txtLocalBodyId.Text.Trim());
                    par[1] = new SqlParameter("@distId", ddlDistirct.SelectedValue.Trim());
                    par[2] = new SqlParameter("@distName", ddlDistirct.SelectedItem.Text.Trim());
                    par[3] = new SqlParameter("@localBodyNm", txtlocalbodynm.Text.Trim());
                    par[4] = new SqlParameter("@acNm", txtACNo.Text.Trim());
                    par[5] = new SqlParameter("@localBodyType", ddlLocalBodytype.SelectedValue.Trim());
                    par[6] = new SqlParameter("@qry", "1");
                   int i= SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateLocalBody", par);

                    if (i==-1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Local Body Added Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Insert Failed')", true);
                    }
                    ClearFields();
                    gvBindLocalBody();
                }
                else
                {
                    SqlParameter[] par = new SqlParameter[7];
                    par[0] = new SqlParameter("@ElectionId", txtLocalBodyId.Text.Trim());
                    par[1] = new SqlParameter("@distId", ddlDistirct.SelectedValue.Trim());
                    par[2] = new SqlParameter("@distName", ddlDistirct.SelectedItem.Text.Trim());
                    par[3] = new SqlParameter("@localBodyNm", txtlocalbodynm.Text.Trim());
                    par[4] = new SqlParameter("@acNm", txtACNo.Text.Trim());
                    par[5] = new SqlParameter("@localBodyType", ddlLocalBodytype.SelectedValue.Trim());
                    par[6] = new SqlParameter("@qry", "2");
                    int i =  SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateLocalBody", par);

                    if (i ==-1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Local Body Added Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Insert Failed')", true);
                    }
                    ClearFields();
                    gvBindLocalBody();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired...')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void gvLocalBodys_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLocalBodys.PageIndex = e.NewPageIndex;
            gvBindLocalBody();
        }
        public void UpdateData(string pid)
        {
            DataSet ds = null;

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@Lid",pid);
            ds = SqlHelper.ExecuteDataset(con,CommandType.StoredProcedure,"uspGetLocalBodyDetails",par);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                //[ElectionId],[ElectionName],[LocalBodyType],[DistrictCode],[DistrictName],[ACNo] 
                txtLocalBodyId.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectionId"]);
                txtlocalbodynm.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectionName"]);
                txtACNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACNo"]);
                ddlLocalBodytype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]);
                ddlDistirct.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DistrictCode"]);
                btnSubmit.Text = "Update";
            }
        }
        public void ClearFields()
        {
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBodytype.SelectedIndex = 0;
            txtACNo.Text = string.Empty;
            txtlocalbodynm.Text = string.Empty;
            txtLocalBodyId.Text = string.Empty;
            //txtNoofMem.Text = string.Empty;
            btnSubmit.Text = "Submit";
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            string pid = btnEdit.CommandArgument;
            UpdateData(pid);
        }

    }
}