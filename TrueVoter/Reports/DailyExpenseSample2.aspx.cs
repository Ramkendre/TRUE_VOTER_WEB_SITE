using System;
using System.Collections;
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
    public partial class DailyExpenseSample2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        DataSet ds = null;
        string MoNo=string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            Panel1.Visible = false;
        }

        protected void lnkbtnOrder1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expences_Procedure.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expences Procedure.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expense_Order_1.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expense Order 1.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Expenses_Format_Order 2.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Expenses Format Order 2.pdf"));
            Response.End();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sqlExist = "SELECT * FROM [TrueVoterDB].[dbo].[Logins] WHERE [UserName] = '" + txtLoginMobile.Text.Trim() + "' AND [UserType] = 3";

            SqlCommand cmd = new SqlCommand(sqlExist, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dsExist = new DataSet();
            da.Fill(dsExist);

            if (dsExist.Tables[0].Rows.Count > 0)
            {
                GetData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid MobileNumber..!!!')", true);
            }

            MultiView1.ActiveViewIndex += 1;
        }


        public void GetData()
        {
            try
            {

                if (Session["MobileNo"] != null)
                {
                    MoNo = Session["MobileNo"].ToString();
                    #region //query
                    //string query = " SELECT DE.[PK_Id],(L.[NAME]+' '+L.[LName]) AS CandidateName, DE.[Date], DE.[InsertBy] ,DE.[PartyName], DE.[PartyNo], DE.[CandidateRole], DE.[CandidateRoleName], DM.[DistrictName], DE.[LocalBodyType], DE.[LocalBodyNameID], DE.[WardNo], DE.[ReffrenceMobile],CEI.[LocalBodyName],ET.[ExpenseType], ETS.[SubExpenseType], DE.[Qty_Size_Area], DE.[Rate], DE.[TotalExpense], DE.[PaymentMode], DE.[PaidAmount], DE.[InvoiceNo], DE.[SourceOfExpense], DE.[PartyName], DE.[PartyNo] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] AS DE INNER JOIN [TrueVoterDB].[dbo].[tblExpenseType] AS ET ON DE.[ExpenseType]=ET.[EID] INNER JOIN [TrueVoterDB].[dbo].[tblSubExpenseType] AS ETS ON DE.[SubExpenseType]=ETS.[SEID] INNER JOIN [TrueVoterDB].[dbo].[Logins] AS L ON DE.[InsertBy]=L.[MobileNo] INNER JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] AS CEI ON DE.[InsertBy]=CEI.[usrMobileNumber] LEFT JOIN [TrueVoterDB].[dbo].[DistrictMaster] DM ON DM.[DistrictId]=DE.[CandidateDistrict] WHERE DE.[InsertBy]='" + txtLoginMobile.Text + "' AND DE.[InsertDate]='" + txtDate.Text + "'"+
                    //                "SELECT SUM([TotalExpense]) AS TOTAL FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [InsertBy]='" + txtLoginMobile.Text + "' AND [InsertDate]='" + txtDate.Text + "'";

                    //string squery = "SELECT DE.[PK_Id],(SELECT ([NAME]+' '+[LName]) FROM [TrueVoterDB].[dbo].[Logins] WHERE [UserName] = '" + txtLoginMobile.Text.Trim() + "') AS CandidateName " +
                    //                ",DE.[Date], DE.[InsertBy] ,DE.[PartyName], " +
                    //                "DE.[PartyNo], DE.[CandidateRole], DE.[CandidateRoleName], DM.[Name_M] AS DistrictName, DE.[LocalBodyType], " +
                    //                "DE.[LocalBodyNameID], DE.[WardNo], DE.[ReffrenceMobile],CEI.[LocalBodyName],ET.[ExpenseType], " +
                    //                "ETS.[SubExpenseType], DE.[Qty_Size_Area], DE.[Rate], DE.[TotalExpense], DE.[PaymentMode], " +
                    //                "DE.[PaidAmount], DE.[InvoiceNo], DE.[SourceOfExpense], DE.[PartyName], DE.[PartyNo] " +
                    //                "FROM [TrueVoterDB].[dbo].[tblDailyExpenses] AS DE " +
                    //                "INNER JOIN [TrueVoterDB].[dbo].[tblExpenseType] AS ET ON DE.[ExpenseType]=ET.[EID] " +
                    //                "INNER JOIN [TrueVoterDB].[dbo].[tblSubExpenseType] AS ETS ON DE.[SubExpenseType]=ETS.[SEID] " +
                    //                "INNER JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] AS CEI ON DE.[InsertBy]=CEI.[usrMobileNumber] " +
                    //                "LEFT JOIN [TrueVoterDB].[dbo].[Districts] DM ON DM.[Id]=DE.[CandidateDistrict] " +
                    //                "WHERE (DE.[InsertBy] = '" + txtLoginMobile.Text.Trim() + "' OR DE.[ReffrenceMobile] = '" + txtLoginMobile.Text.Trim() + "') AND DE.[IsApproved] = 1 AND DE.[Date] = '" + txtDate.Text.Trim() + "'" +
                    //                "SELECT SUM([TotalExpense]) AS TOTAL FROM [TrueVoterDB].[dbo].[tblDailyExpenses] " +
                    //                "WHERE ([InsertBy] = '" + txtLoginMobile.Text.Trim() + "' OR [ReffrenceMobile] = '" + txtLoginMobile.Text.Trim() + "') AND [IsApproved] = 1 AND [Date] = '" + txtDate.Text.Trim() + "'";

                    //SqlCommand cmd = new SqlCommand(squery, con);
                    #endregion
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "uspDownloadcandiDailyExpsam2SECLock";// "uspDownloadcandiDailyExpsam2New";
                    cmd.Parameters.Add("@mobileno", SqlDbType.NVarChar).Value = MoNo;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Close();
                    ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblcandidateName.Text = ds.Tables[1].Rows[0]["CandidateName"].ToString();
                        lblParty.Text = ds.Tables[1].Rows[0]["PN"].ToString();
                        lblLocalBodyId.Text = ds.Tables[1].Rows[0]["LocalBodyName"].ToString();
                        lblWardNo.Text = ds.Tables[1].Rows[0]["WardNo"].ToString();
                        lblSeat.Text = Convert.ToString(ds.Tables[1].Rows[0]["SeatNo"]);
                        lblDistrictNm.Text = ds.Tables[1].Rows[0]["DistrictName"].ToString();
                        lblVotingDate.Text = ds.Tables[1].Rows[0]["ElectionDate"].ToString();
                        //DateTime nowdate = Convert.ToDateTime(ds.Tables[1].Rows[0]["Date"]);
                        lblExpenseDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                        lblElection.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionType"]);
                        gvDaillyExpenses.DataSource = ds.Tables[0];
                        gvDaillyExpenses.DataBind();

                        ShowingGroupingDataInGridView(gvDaillyExpenses.Rows, 1, 2);

                        gvDaillyExpenses.FooterRow.Cells[6].Text = "एकूण";
                        gvDaillyExpenses.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                        gvDaillyExpenses.FooterRow.Cells[7].Text = ds.Tables[0].Compute("Sum(TotalExpense)", "").ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        void ShowingGroupingDataInGridView(GridViewRowCollection gridViewRows, int startIndex, int totalColumns)
        {
            if (totalColumns == 0) return;
            int i, count = 1;
            ArrayList lst = new ArrayList();
            lst.Add(gridViewRows[0]);
            var ctrl = gridViewRows[0].Cells[startIndex];
            for (i = 1; i < gridViewRows.Count; i++)
            {
                TableCell nextTbCell = gridViewRows[i].Cells[startIndex];
                if (ctrl.Text == nextTbCell.Text)
                {
                    count++;
                    nextTbCell.Visible = false;
                    lst.Add(gridViewRows[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gridViewRows[i].Cells[startIndex];
                    lst.Add(gridViewRows[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                ShowingGroupingDataInGridView(new GridViewRowCollection(lst), startIndex + 1, totalColumns - 1);
            }
            count = 1;
            lst.Clear();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            Panel2.Visible = false;
            GetData();
            MultiView1.ActiveViewIndex += 1;
        }



        //protected void gvDaillyExpenses_DataBound(object sender, EventArgs e)
        //{
        //    for (int i = gvDaillyExpenses.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = gvDaillyExpenses.Rows[i];
        //        GridViewRow previousRow = gvDaillyExpenses.Rows[i - 1];
        //        for (int j = 0; j < row.Cells.Count; j++)
        //        {
        //            if (row.Cells[j].Text == previousRow.Cells[j].Text)
        //            {
        //                if (previousRow.Cells[j].RowSpan == 0)
        //                {
        //                    if (row.Cells[j].RowSpan == 0)
        //                    {
        //                        previousRow.Cells[j].RowSpan += 2;
        //                    }
        //                    else
        //                    {
        //                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
        //                    }
        //                    row.Cells[j].Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}