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
    public partial class DailyExpenseSample8 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);
            // mob="9422311611";
            if (mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@mobileNo", mob.ToString()); // Convert.ToString(Session["MobileNO"]));
                    //par[1] = new SqlParameter("@mobileNo", SqlDbType.NVarChar, 10, mob.Trim());
                    //par[3] = new SqlParameter("@mobileNo", SqlDbType.NVarChar, 10, mob.Trim());
                    ds = new DataSet();
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetPartyOfficerData", par);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblname.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrFullName"]);
                        lblfathername.Text = Convert.ToString(ds.Tables[0].Rows[0]["FatherName"]);
                        lblAge.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]);
                        lblAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                        lblPartyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]);
                        lblPartyOfficeAdd.Text = Convert.ToString(ds.Tables[0].Rows[0]["HeadAddress"]);
                        lbltodate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                        lblplace.Text = Convert.ToString(ds.Tables[0].Rows[0]["Place"]);
                        lblofficerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrFullName"]);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Party Officer Data Not Found...')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
    }
}