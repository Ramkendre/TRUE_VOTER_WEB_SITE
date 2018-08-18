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
    public partial class DailyExpenseSample9 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);
        }

        protected void btnFinalPrint_Click(object sender, EventArgs e)
        {
            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                MultiView1.ActiveViewIndex += 1;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "uspDownloadPartyFundDetails";
                cmd.Parameters.Add("@mobileno", SqlDbType.NVarChar).Value = mob;
                cmd.Parameters.Add("@fromDate", SqlDbType.NVarChar).Value = txtFromDate.Text;
                cmd.Parameters.Add("@toDate", SqlDbType.NVarChar).Value = txtToDate.Text;
                cmd.Parameters.Add("@qury", SqlDbType.NVarChar).Value = "1";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    //lblcandidateName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CandidateName"]);
                    lblParty.Text = Convert.ToString(ds.Tables[1].Rows[0]["PN"]);
                    lblLocalBodyId.Text = Convert.ToString(ds.Tables[1].Rows[0]["LocalBodyName"]);
                    //lblWardNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["WardNo"]);
                    //lblSeat.Text = Convert.ToString(ds.Tables[1].Rows[0]["SeatNo"]);
                    //lblDistrictNm.Text = Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]);
                    lblVotingDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionDate"]);
                    //lblElection.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionType"]);
                    lblExpenseDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                    lblFromDate.Text = txtFromDate.Text.ToString() + " ते " + txtToDate.Text.ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDonation.DataSource = ds.Tables[0];
                        gvDonation.DataBind();
                        gvDonation.FooterRow.Cells[6].Text = "एकूण";
                        gvDonation.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                        gvDonation.FooterRow.Cells[7].Text = ds.Tables[0].Compute("Sum(Amount)", "").ToString();
                    }
                    else
                    {
                        gvDonation.DataSource = ds.Tables[0];
                        gvDonation.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Candidate Data Not Found...'); window.location='frmHomeUser.aspx'", true);
                }
            }
        }
    }
}