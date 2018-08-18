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
    public partial class DailyExpenseSample6 : System.Web.UI.Page
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
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
                gvPartyExpense.FooterRow.Cells[5].Text = "एकूण";
                gvPartyExpense.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                gvPartyExpense.FooterRow.Cells[6].Text = dsBdetls.Tables[0].Compute("Sum(Amount)", "").ToString();
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

               
                //for (int j = 0; j < CurrentRow.Cells.Count; j++)
                //{
                //    if (CurrentRow.Cells[j].Text == PreviousRow.Cells[j].Text)
                //    {
                //        if (PreviousRow.Cells[j].RowSpan == 0)
                //        {
                //            if (CurrentRow.Cells[j].RowSpan == 0)
                //            {
                //                PreviousRow.Cells[j].RowSpan += 2;
                //            }
                //            else
                //            {
                //                PreviousRow.Cells[j].RowSpan = CurrentRow.Cells[j].RowSpan + 1;
                //            }
                //            CurrentRow.Cells[j].Visible = false;
                //        }
                //    }
                //}
            }

        }

        public void GetBasicData1()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        public void GetBasicData2()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        public void GetBasicData3()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        public void GetBasicData4()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        public void GetBasicData5()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        public void GetBasicData6()
        {
            cmd.CommandText = "uspGetPartyExpenseDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = dsBdetls.Tables[0];
                gvPartyExpense.DataBind();
            }
        }
        }
}