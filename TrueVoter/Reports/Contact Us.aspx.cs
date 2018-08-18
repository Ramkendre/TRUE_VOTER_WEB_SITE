using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Configuration;
using TrueVoter.App_Code.BAL;


namespace TrueVoter.Reports
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        string fileExtension = string.Empty;
        OleDbConnection conn = new OleDbConnection();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        LoginBAL objlogin = new LoginBAL();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                }
                else
                {
                    Response.Redirect("../Home/Logout");
                }
            }
            else
            {

            }
        }
    }
}