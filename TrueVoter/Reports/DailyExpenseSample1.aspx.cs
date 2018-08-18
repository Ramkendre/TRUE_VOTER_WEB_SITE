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
    public partial class DailyExpenseSample1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null)
            {
                if (IsPostBack == false)
                {

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnShowGrid_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "uspDailyExpenseWithSECLock";//"uspDailyExpenseNew";
            cmd.Parameters.Add("@mobileno", SqlDbType.NVarChar).Value = mob;
            cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = txtDate.Text.Trim();
            cmd.Parameters.Add("@showId", SqlDbType.NVarChar).Value = "1";
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Close();
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            gridViewPrivew.DataSource = ds.Tables[0];
            gridViewPrivew.DataBind();

            btnFinalPrint.Visible = true;
            btnCancle.Visible = true;
        }

        protected void btnFinalPrint_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex += 1;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "uspDailyExpenseWithSECLock";
            cmd.Parameters.Add("@mobileno", SqlDbType.NVarChar).Value = mob;
            cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = txtDate.Text.Trim();
            cmd.Parameters.Add("@showId", SqlDbType.NVarChar).Value = "2";
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Close();
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            if (ds.Tables[1].Rows.Count > 0)
            {
                lblcandidateName.Text = Convert.ToString(ds.Tables[1].Rows[0]["CandidateName"]);
                lblParty.Text = Convert.ToString(ds.Tables[1].Rows[0]["PN"]);
                lblLocalBodyId.Text = Convert.ToString(ds.Tables[1].Rows[0]["LocalBodyName"]);
                lblWardNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["WardNo"]);
                lblSeat.Text = Convert.ToString(ds.Tables[1].Rows[0]["SeatNo"]);
                lblDistrictNm.Text = Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]);
                lblVotingDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionDate"]);
                lblElection.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionType"]);
                try
                {
                    DateTime nowdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
                    lblExpenseDate.Text = nowdate.ToString("yyyy-MM-dd");
                }
                catch
                {
                    lblExpenseDate.Text = txtDate.Text.Trim();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDaillyExpenses.DataSource = ds.Tables[0];
                    gvDaillyExpenses.DataBind();
                    gvDaillyExpenses.FooterRow.Cells[9].Text = "एकूण";
                    gvDaillyExpenses.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                    gvDaillyExpenses.FooterRow.Cells[10].Text = ds.Tables[0].Compute("Sum(TotalExpense)", "").ToString();
                }
                else
                {
                    gvDaillyExpenses.DataSource = ds.Tables[0];
                    gvDaillyExpenses.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Candidate Data Not Found...'); window.location='frmHomeUser.aspx'", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

    }
}