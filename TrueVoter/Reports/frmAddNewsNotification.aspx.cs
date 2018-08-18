using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmAddNewsNotification : System.Web.UI.Page
    {
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        clsAddNews objNBal = new clsAddNews();
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
                    BindGrid();
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
            objBAL.DistrictId = Convert.ToInt32(ddlDistirct.SelectedValue);
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

        protected void rbtnlocalBodywise_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = rbtnlocalBodywise.SelectedValue;
            if (i == "2")
            {
                pnlDislocal.Visible = true;
            }
            else
            {
                pnlDislocal.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (mob != "")
            {
                try
                {
                    objNBal.NewsScope = Convert.ToInt32(ddlNewsFor.SelectedValue);
                    objNBal.NewsScopeName = ddlNewsFor.SelectedItem.Text;
                    int dId = 0;
                    try
                    {
                        dId = Convert.ToInt32(ddlDistirct.SelectedValue);
                    }
                    catch
                    {
                        dId = 0;
                    }
                    objNBal.DistrictId = dId;
                    int lId = 0;
                    try
                    {
                        lId = Convert.ToInt32(ddlLocalBody.SelectedValue);
                    }
                    catch
                    {
                        lId = 0;
                    }
                    objNBal.localBodyId = lId;
                    objNBal.Header = txtHeading.Text;
                    objNBal.Description = txtDescription.Text;
                    objNBal.CreatedBy = mob;
                    objNBal.CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                    int i = Convert.ToInt32(objNBal.Insert(objNBal));
                    if (i == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Inserted Successfully')", true);
                        Clear();
                        BindGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Not Inserted Successfully')", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Not Inserted Successfully')", true);
                }   
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtId.Text = string.Empty;
            txtHeading.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlNewsFor.SelectedIndex = 0;
            BindDistrict();
            ddlLocalBody.Items.Clear();
        }

        public void BindGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                objNBal.CreatedBy = mob;
                ds = objNBal.BindGridBAL(objNBal);
                gvNews.DataSource = ds.Tables[0];
                gvNews.DataBind();
            }
            catch
            {
                gvNews.DataSource = ds.Tables[0];
                gvNews.DataBind();
            }
        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}