using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmGetPassword : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        LoginBAL objloginBAL = new LoginBAL();
        CommonCode commoncode = new CommonCode();
        string mob = string.Empty;
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
            try
            {
                if (txtForgetUsername.Text == "" || txtForgetUsername.Text.Length < 10)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter valid 10 Digits Mobile No. in the UserName field!!!')", true);
                }
                else
                {
                    objloginBAL.UserName = txtForgetUsername.Text;
                    DataSet dsPwdDetails = objloginBAL.GetLoginPassword(objloginBAL);
                    CommonCode commoncode = new CommonCode();
                    if (dsPwdDetails.Tables[0].Rows.Count > 0)
                    {
                        //string pd = "Dphw8uRj8m223uy8jL6IROJWchsfAa78LC1+bdPl4TLU0HliZ4mfRlSm0xZ7PTAm";
                        //string pd1 = "xbwwEW+aKy+VhMAwDHJjAktab558b8O1VTqKA9SdCKwwwlbkamdciJJ4i3FjzvMV";
                        //string pwd2 = commoncode.DESDecrypt(pd);
                        //string pwd3 = commoncode.DESDecrypt(pd1);
                        string pwd2 = commoncode.DESDecrypt(dsPwdDetails.Tables[0].Rows[0]["Password"].ToString());
                        string msg = "Dear " + dsPwdDetails.Tables[0].Rows[0]["NAME"] + " you installed TRUE VOTER. Your password for login is " + pwd2 + "";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('"+msg+"')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First...')", true);
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }
    }
}