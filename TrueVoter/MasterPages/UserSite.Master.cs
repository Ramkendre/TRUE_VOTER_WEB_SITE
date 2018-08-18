using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.MasterPages
{
    public partial class UserSite : System.Web.UI.MasterPage
    {
        CommonCode cc = new CommonCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RegID"] != null)
            {
                Label lblFirstName = (Label)LoginView1.FindControl("lblFirstName");
                lblFirstName.Text = Convert.ToString(Session["NAME"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "Session_Expired();", true);
            }
            if (!Page.IsPostBack)
            {
                if (Session["RegID"] != null)
                {
                    //Label lblFirstName = (Label)LoginView1.FindControl("lblFirstName");
                    Label lblLastName = (Label)LoginView1.FindControl("lblLastName");
                    // lblFirstName.Text = Session["NAME"].ToString();
                    string UserRole = Session["UserType"].ToString();
                    string MobileNo = Session["MobileNo"].ToString();
                    string MainRole = Session["MainRole"].ToString();

                    if (MobileNo == "9422325020" || MobileNo == "8087371027" || MobileNo == "9403397649") //SUPER ADMIN
                    {
                        liSuperAdmin.Visible = true;
                        liAdmin.Visible = true;
                        liAllReports.Visible = true;
                        liControlchrt.Visible = true;
                        liApproveExpen.Visible = true;
                        liExpenseRpt.Visible = true;
                    }
                    else if (MobileNo == "9619460202") //ADMIN
                    {
                        liAdmin.Visible = true;
                        liAllReports.Visible = true;
                        liControlchrt.Visible = true;
                        liGramPanchayat.Visible = true;
                    }
                    else
                    {
                        if (UserRole == "2")
                        {
                            switch (MainRole)
                            {
                                case "1":
                                    liAllReports.Visible = true;
                                    liAcceptExp.Visible = true;
                                    break;
                                case "5":
                                    liAllReports.Visible = true;
                                    liAcceptExp.Visible = true;
                                    liGramPanchayat.Visible = true;
                                    break;
                                case "6":
                                    liAllReports.Visible = true;
                                    liAcceptExp.Visible = true;
                                    liGramPanchayat.Visible = true;
                                    break;
                                case "11":
                                    liAllReports.Visible = true;
                                    liAcceptExp.Visible = true;
                                    break;
                                case "12":
                                    liAllReports.Visible = true;
                                    liAcceptExp.Visible = true;
                                    break;
                                default:
                                    liAllReports.Visible = true;
                                    liControlchrt.Visible = true;
                                    break;
                            }
                        }
                        else if (UserRole == "3")
                        {
                            string qry = "SELECT [MobileNo] FROM [TrueVoterDB].[dbo].[tblAISPLRepresentativeDetails] WHERE MobileNo='" + MobileNo + "'";
                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(qry);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                liMarketMenu.Visible = true;
                            }
                            else
                            {
                                switch (MainRole)
                                {
                                    case "1":
                                        liApproveExpen.Visible = true;
                                        liExpenseRpt.Visible = true;
                                        break;
                                    case "2":
                                        liApproveExpen.Visible = true;
                                        liExpenseRpt.Visible = true;
                                        break;
                                    case "3":

                                        break;
                                    case "4":
                                        liPartyOfficer.Visible = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "Session_Expired();", true);
                    //Response.Redirect("~/Reports/frmHomeUser.aspx");
                }
            }
        }
    }
}