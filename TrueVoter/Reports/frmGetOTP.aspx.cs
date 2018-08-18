using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using TrueVoter.App_Code.BAL;
namespace TrueVoter.Reports
{
    public partial class frmGetOTP : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        LoginBAL objloginBAL = new LoginBAL();
        CommonCode commoncode = new CommonCode();
        string mob = string.Empty;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            if (txtGetOPT.Text == "" || txtGetOPT.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter valid 10 Digits Mobile No. in the UserName field!!!')", true);
            }
            else
            {
                cmd.CommandText = "uspGetOTPNew";
                cmd.Connection = contrue;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@mobileNo",SqlDbType.NVarChar).Value=txtGetOPT.Text;
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {                   
                    string msg = "OTP FOR VERIFICATION IS:" + ds.Tables[0].Rows[0]["OTP"] + " ";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('" + msg + "')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First Mobile NO...')", true);
                }
            }
        }
    }
}