using Microsoft.ApplicationBlocks.Data;
//using BLL;
//using BOL;
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
    public partial class upDateDailyExpenses : System.Web.UI.Page
    {
        string mob = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    BindDailyExpense();
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
            else
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    //BindDailyExpense();
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
        }

        public void BindDailyExpense()
        {
            cmd = new SqlCommand();
            DataSet dsExpe = new DataSet();
            //cmd.Connection = con;
            //cmd.CommandText = "uspShowDailyExpenseNew";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
            //da = new SqlDataAdapter(cmd);
            //da.Fill(dsExpe);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@mobileNo", mob.Trim());
           
            dsExpe = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspShowDailyExpenseNew", par);


            int dsCnt = dsExpe.Tables[0].Rows.Count;
            if (dsCnt > 0)
            {
                lblTotal.Text=Convert.ToString(dsExpe.Tables[1].Rows[0][0]);
                lblTotalApp.Text = Convert.ToString(dsExpe.Tables[1].Rows[0][1]);
                gvMyDailyExpense.DataSource = dsExpe.Tables[0];
                gvMyDailyExpense.DataBind();
            }
            else
            {
                gvMyDailyExpense.DataSource = dsExpe;
                gvMyDailyExpense.DataBind();
            }
        }

        protected void ApproveRecord(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < gvMyDailyExpense.Rows.Count; i++)// 
            {
                CheckBox chkbox = ((CheckBox)gvMyDailyExpense.Rows[i].Cells[12].FindControl("CheckBox1"));
                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(gvMyDailyExpense.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
                updatecount = 1;
            }

            cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [IsActive]=1,[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[ModifyBy]='" + mob + "'  WHERE [PK_Id] IN (" + gvSNO + ") AND [OffAcceptStatus] IS NULL";//AND [Printed] IS NULL "; //
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDailyExpense();
        }

        protected void DisApproveRecord(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < gvMyDailyExpense.Rows.Count; i++)
            {
                CheckBox chkbox = ((CheckBox)gvMyDailyExpense.Rows[i].Cells[12].FindControl("CheckBox1"));
                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(gvMyDailyExpense.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
                updatecount = 1;
            }

            cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [IsActive]=0,[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[ModifyBy]='" + mob + "'  WHERE [PK_Id] IN (" + gvSNO + ") AND [OffAcceptStatus] IS NULL";// AND [Printed] IS NULL";//
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDailyExpense();
        }

        protected void gvMyDailyExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMyDailyExpense.PageIndex = e.NewPageIndex;
            this.BindDailyExpense();
        }

        protected void ApproveRecordNew(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < gvMyDailyExpense.Rows.Count; i++)// 
            {
                CheckBox chkbox = ((CheckBox)gvMyDailyExpense.Rows[i].Cells[12].FindControl("CheckBox1"));
                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(gvMyDailyExpense.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
                updatecount = 1;
            }

            cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [IsApproved]=1,[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[ModifyBy]='" + mob + "'  WHERE [PK_Id] IN (" + gvSNO + ") AND [OffAcceptStatus] IS NULL";// AND [Printed] IS NULL "; //
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDailyExpense();
        }

        protected void DisApproveRecordNew(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < gvMyDailyExpense.Rows.Count; i++)
            {
                CheckBox chkbox = ((CheckBox)gvMyDailyExpense.Rows[i].Cells[12].FindControl("CheckBox1"));
                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(gvMyDailyExpense.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
                updatecount = 1;
            }

            cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [IsApproved]=0,[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[ModifyBy]='" + mob + "'  WHERE [PK_Id] IN (" + gvSNO + ")  AND [OffAcceptStatus] IS NULL";// AND [Printed] IS NULL"; //
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindDailyExpense();
        }

        protected void gvMyDailyExpense_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TableCell EntryBy = e.Row.Cells[12];
            //    if (EntryBy.Text == "2")
            //    {
            //        EntryBy.Text = "Ward Member";
            //        EntryBy.BackColor = System.Drawing.Color.Green;
            //    }
            //    else if (EntryBy.Text == "3")
            //    {
            //        EntryBy.Text = "Representative";
            //        EntryBy.BackColor = System.Drawing.Color.Red;
            //    }
            //    else if (EntryBy.Text == "1")
            //    {
            //        EntryBy.Text = "Precident";
            //        EntryBy.BackColor = System.Drawing.Color.Green;
            //    }


            //    TableCell Verified = e.Row.Cells[14];
            //    if (Verified.Text == "1")
            //    {
            //        Verified.Text = "Verified";
            //        Verified.BackColor = System.Drawing.Color.Green;
            //    }
            //    else if (Verified.Text == "0")
            //    {
            //        Verified.Text = "Rejected";
            //        Verified.BackColor = System.Drawing.Color.Red;
            //    }
            //    else if (Verified.Text == " ")
            //    {
            //        Verified.Text = "Rejected";
            //        Verified.BackColor = System.Drawing.Color.Red;
            //    }


            //    TableCell Publish = e.Row.Cells[15];
            //    if (Publish.Text == "1")
            //    {
            //        Publish.Text = "Published";
            //        Publish.BackColor = System.Drawing.Color.Green;
            //    }
            //    else if (Publish.Text == "0")
            //    {
            //        Publish.Text = "Discarded";
            //        Publish.BackColor = System.Drawing.Color.Red;
            //    }
            //    else if (Publish.Text == " ")
            //    {
            //        Publish.Text = "Discarded";
            //        Publish.BackColor = System.Drawing.Color.Red;
            //    }
            //}
        }
    }
}