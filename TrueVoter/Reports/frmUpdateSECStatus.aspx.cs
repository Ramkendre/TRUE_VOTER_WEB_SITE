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
    public partial class frmUpdateSECStatus : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string MobileNo = Convert.ToString(Session["MobileNo"]);
            if (MobileNo != null)
            {
                mob = Convert.ToString(Session["MobileNo"]);
                if (IsPostBack != true)
                {
                }
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
        }


        public void CheckLogin()
        {
             string MobileNo = Convert.ToString(Session["MobileNo"]);
             if (MobileNo != null)
             {
             }
             else
             {
                 Response.Redirect("../Admin/Login.aspx");
             }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                CheckLogin();
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@mob", txtMobNo.Text.Trim());
                par[2] = new SqlParameter("@CreatedBy", mob);
                par[3] = new SqlParameter("@status", rbActive.SelectedValue);
                par[1] = new SqlParameter("@returnValue", SqlDbType.Int);
                par[1].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspChangeSECStatus", par);
                string result = par[1].Value.ToString();
                if (result == "101")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Recored Updated Successfully')", true);
                    txtMobNo.Text = string.Empty;
                }
                else if (result == "102")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Recored Not Found in Database')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Recored Update Failed')", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Recored Update Failed')", true);
            }

        }
    }
}