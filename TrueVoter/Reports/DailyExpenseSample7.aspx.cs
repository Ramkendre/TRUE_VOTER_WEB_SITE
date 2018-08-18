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
    public partial class DailyExpenseSample7 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    GetBasicData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void GetBasicData()
        {
            cmd.CommandText = "uspGetPartyExpenseOnCandiDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@mobile", SqlDbType.NVarChar, 50).Value = mob.Trim();
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
                gvPartyExpense.FooterRow.Cells[6].Text = "एकूण";
                gvPartyExpense.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                gvPartyExpense.FooterRow.Cells[7].Text = dsBdetls.Tables[0].Compute("Sum(Amount)", "").ToString();
            }
        }
        protected void gvPartyExpense_DataBound(object sender, EventArgs e)
        {
            for (int i = gvPartyExpense.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow CurrentRow = gvPartyExpense.Rows[i];
                GridViewRow PreviousRow = gvPartyExpense.Rows[i - 1];

                if (CurrentRow.Cells[1].Text == PreviousRow.Cells[1].Text)
                {
                    if (PreviousRow.Cells[1].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[1].RowSpan == 0)
                        {
                            PreviousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[1].RowSpan = CurrentRow.Cells[1].RowSpan + 1;
                        }
                        CurrentRow.Cells[1].Visible = false;
                    }
                }
                if (CurrentRow.Cells[2].Text == PreviousRow.Cells[2].Text)
                {
                    if (PreviousRow.Cells[2].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[2].RowSpan == 0)
                        {
                            PreviousRow.Cells[2].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[2].RowSpan = CurrentRow.Cells[2].RowSpan + 1;
                        }
                        CurrentRow.Cells[2].Visible = false;
                    }
                }
                if (CurrentRow.Cells[3].Text == PreviousRow.Cells[3].Text)
                {
                    if (PreviousRow.Cells[3].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[3].RowSpan == 0)
                        {
                            PreviousRow.Cells[3].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[3].RowSpan = CurrentRow.Cells[3].RowSpan + 1;
                        }
                        CurrentRow.Cells[3].Visible = false;
                    }
                }
                if (CurrentRow.Cells[4].Text == PreviousRow.Cells[4].Text)
                {
                    if (PreviousRow.Cells[4].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[4].RowSpan == 0)
                        {
                            PreviousRow.Cells[4].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[4].RowSpan = CurrentRow.Cells[4].RowSpan + 1;
                        }
                        CurrentRow.Cells[4].Visible = false;
                    }
                }

            }

        }

    }
}