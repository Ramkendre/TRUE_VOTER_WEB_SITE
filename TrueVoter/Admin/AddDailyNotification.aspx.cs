using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Admin
{
    public partial class AddDailyNotification : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode commoncode = new CommonCode();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string MobileNo = Session["MobileNo"].ToString();
            if (MobileNo != null)
            {
                mob = Session["MobileNo"].ToString();
                if (IsPostBack != true)
                {
                    BindDailyNotification();
                }
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void BindDailyNotification()
        {
            string query2 = "SELECT [Id],[Date],[RoleId],[Message],[CreatedBy],[CreatedDate] FROM [TrueVoterDB].[dbo].[tbl_DailyNotification](NOLOCK) ORDER BY [Id] DESC";
            ds.Clear();
            ds = commoncode.ExecuteDataset(query2);
            gvTodaysNotification.DataSource = ds.Tables[0];
            gvTodaysNotification.DataBind();

        }
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [TrueVoterDB].[dbo].[tbl_DailyNotification] ([Date],[RoleId],[Message],[CreatedBy],[CreatedDate]) VALUES ('" + txtDate.Text + "','" + ddlRole.SelectedValue + "','" + txtNotification.Text + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
            int i = commoncode.ExecuteNonQuery(query);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Notification Inserted..!!!')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Notification Insertion Failed..!!!')", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDate.Text = "";
            txtNotification.Text = "";
            ddlRole.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }

        protected void gvTodaysNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTodaysNotification.PageIndex = e.NewPageIndex;
            BindDailyNotification();
        }
    }
}