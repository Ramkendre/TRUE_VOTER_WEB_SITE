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
    public partial class frmaddExpenseByOfficerTwo : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode commoncode = new CommonCode();
        string mob = string.Empty;
        string candiMoNo = string.Empty;
        string offRole = string.Empty;
        string[] mesuringUnit = { "Select Unit", "Rs.PerSq.Feet", "Rs.PerDay", "Rs" };
        protected void Page_Load(object sender, EventArgs e)
        {
            string MobileNo = Convert.ToString(Session["MobileNo"]);

            if (MobileNo != null)
            {
                mob = Convert.ToString(Session["MobileNo"]);
                candiMoNo = commoncode.DESDecrypt(Convert.ToString(Request.QueryString["mNo"]));
                if (candiMoNo != null)
                {
                    if (IsPostBack != true)
                    {
                        offRole = Convert.ToString(Session["MainRole"]);
                        BindExpenseHead();
                        BindGridView();
                    }
                }
                else
                {
                    Response.Redirect("../Reports/frmaddExpenseByOfficerOne.aspx");
                }
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }

        }

        public void BindExpenseHead()
        {
            //string qry = "SELECT [EID],[ExpenseType] FROM [TrueVoterDB].[dbo].[tblExpenseType] ";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qry);
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspBindExpenseHead");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlExpenseHead.DataSource = ds.Tables[0];
                ddlExpenseHead.DataTextField = "ExpenseType";
                ddlExpenseHead.DataValueField = "EID";
                ddlExpenseHead.DataBind();

                ddlExpenseHead.Items.Add("--Select--");
                ddlExpenseHead.SelectedIndex = ddlExpenseHead.Items.Count - 1;
            }
            else
            {
            }
        }

        protected void ddlExpenseHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string qryone = "SELECT [CandidateDistrictID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + mob + "'";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qryone);
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@p1", "1");
            par[1] = new SqlParameter("@p2", mob);
            par[2] = new SqlParameter("@p3", "0");
            par[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par);

            //string qrytwo = "SELECT [SEID],[SubExpenseType],[EID] FROM [TrueVoterDB].[dbo].[tblSubExpenseType] WHERE [EID]='" + ddlExpenseHead.SelectedValue + "' AND [DistId] IN ('Default','" + ds.Tables[0].Rows[0]["CandidateDistrictID"].ToString() + "')";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qrytwo);
            SqlParameter[] par1 = new SqlParameter[5];
            par1[0] = new SqlParameter("@p1", "2");
            par1[1] = new SqlParameter("@p2", ddlExpenseHead.SelectedValue);
            par1[2] = new SqlParameter("@p3", ds.Tables[0].Rows[0]["CandidateDistrictID"].ToString());
            par1[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubExpenseHead.DataSource = ds.Tables[0];
                ddlSubExpenseHead.DataTextField = "SubExpenseType";
                ddlSubExpenseHead.DataValueField = "SEID";
                ddlSubExpenseHead.DataBind();

                ddlSubExpenseHead.Items.Add("--Select--");
                ddlSubExpenseHead.SelectedIndex = ddlSubExpenseHead.Items.Count - 1;
            }
        }

        protected void ddlSubExpenseHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string qrytre = "SELECT [CandidateDistrictID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + mob + "'";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qrytre);

            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@p1", "1");
            par[1] = new SqlParameter("@p2", mob);
            par[2] = new SqlParameter("@p3", "0");
            par[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par);


            //string qryfor = "SELECT TOP 1 [StandardRate],[MeasuringUnit] FROM [TrueVoterDB].[dbo].[tblExpenseMaster] WHERE [ExpenseType]='" + ddlExpenseHead.SelectedValue + "' AND [SubExpenseType]='" + ddlSubExpenseHead.SelectedValue + "' AND [ApplicableFor]='" + ds.Tables[0].Rows[0]["CandidateDistrictID"].ToString() + "' ORDER BY Id DESC";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qryfor);
            SqlParameter[] par1 = new SqlParameter[5];
            par1[0] = new SqlParameter("@p1", "3");
            par1[1] = new SqlParameter("@p2", ddlExpenseHead.SelectedValue);
            par1[2] = new SqlParameter("@p3", ddlSubExpenseHead.SelectedValue);
            par1[3] = new SqlParameter("@p4", ds.Tables[0].Rows[0]["CandidateDistrictID"].ToString());
            DataSet dsStan = new DataSet();
            dsStan = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblStandardRate.Text = ds.Tables[0].Rows[0][0].ToString();
                // string[] mesuringUnit = { "Select Unit", "Rs.PerSq.Feet", "Rs.PerDay", "Rs" };

                string units = ds.Tables[0].Rows[0][1].ToString();

                if (units == "1")
                {
                    lblUnit.Text = "Rs.PerSq.Feet";
                }
                else if (units == "2")
                {
                    lblUnit.Text = "Rs.PerDay";
                }
                else if (units == "3")
                {
                    lblUnit.Text = "Rs";
                }
                else
                {
                    lblUnit.Text = "No Unit";
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbPaymentMode.SelectedValue == "1")
            {
                pnlChequeNo.Visible = true;
            }
            else
            {
                pnlChequeNo.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //cmd.CommandText = "";
            //string exqry = "SELECT [usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + candiMoNo + "' AND [CandidateRole] IN (1,2)";
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(exqry);

            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@p1", "4");
            par[1] = new SqlParameter("@p2", mob);
            par[2] = new SqlParameter("@p3", "0");
            par[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par);

            string ipAdd = GetIPAddress();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["CandidateRole"]) == "3")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You registerd as Representative you can not fill Daily Expense')", true);
                }
                else
                {
                    if (ddlExpenseHead.SelectedItem.Text == "--Select--" || ddlExpenseHead.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Expense Head')", true);
                    }
                    else if (ddlSubExpenseHead.SelectedItem.Text == "--Select--" || ddlSubExpenseHead.SelectedValue == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Sub Expense Head')", true);
                    }
                    else if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Expense Date')", true);
                    }
                    else if (txtArea.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Area/Size/Quantity')", true);
                    }
                    else if (txtYourRate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Your Rate')", true);
                    }
                    else if (txtAmount.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Amount')", true);
                    }
                    else
                    {
                        //string query = "INSERT INTO [TrueVoterDB].[dbo].[tblDailyExpenses] ([Date],[ExpenseType],[SubExpenseType],[Qty_Size_Area],[Rate],[TotalExpense]," +
                        //            "[PaymentMode],[ChequeNo],[PaidAmount],[InvoiceNo],[FirmName],[FirmOwnerMobNo],[InsertDate],[InsertBy],[Unit],[PaymentType]," +
                        //            "[StandardRate],[BalancePayment],[SourceOfExpense],[PartyName],[PartyNo],[CandidateRole],[CandidateRoleName],[CandidateDistrict],[LocalBodyType]," +
                        //            "[LocalBodyNameID],[WardNo],[ReffrenceMobile],[IsApproved],[EntryFrom],[IsActive],[IMEINumber],[AddExpOfficerRole]) "
                        //            + "VALUES ('" + txtDate.Text + "','" + Convert.ToString(ddlExpenseHead.SelectedValue) + "','" + Convert.ToString(ddlSubExpenseHead.SelectedValue) + "','" + txtArea.Text + "'" +
                        //            ",'" + txtYourRate.Text + "','" + txtTotal.Text + "','" + rbPaymentMode.SelectedItem.Text + "','" + txtChequeNo.Text + "','" + txtAmount.Text + "','" + txtBillNo.Text + "'" +
                        //            ",'" + txtVenderName.Text + "','" + txtVenderMobNo.Text + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + mob + "'" +
                        //            ",'" + lblUnit.Text + "','" + rbtnPaymentType.SelectedItem.Text + "','" + lblStandardRate.Text + "','" + txtBalpayment.Text + "','" + rbtnSourceExpense.SelectedItem.Text + "'," +
                        //            "'" + txtPartyotherName.Text + "','" + txtPartyotherMobNo.Text + "','" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRole"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRoleName"]) + "'," +
                        //            "'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateDistrictID"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyID"]) + "'," +
                        //            "'" + Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]) + "','" + candiMoNo + "','1','2','1','" + ipAdd + "','" + offRole + "')";
                        //int i = commoncode.ExecuteNonQuery(query);
                        
                        
                        string deviation = CalDaviation();
                        SqlParameter[] par1 = new SqlParameter[36];
                        par1[0] = new SqlParameter("@p1", txtDate.Text);
                        par1[1] = new SqlParameter("@p2", Convert.ToString(ddlExpenseHead.SelectedValue));
                        par1[2] = new SqlParameter("@p3", Convert.ToString(ddlSubExpenseHead.SelectedValue));

                        par1[3] = new SqlParameter("@p4", txtArea.Text);
                        par1[4] = new SqlParameter("@p5", txtYourRate.Text);
                        par1[5] = new SqlParameter("@p6", txtTotal.Text);

                        par1[6] = new SqlParameter("@p7", rbPaymentMode.SelectedItem.Text);
                        par1[7] = new SqlParameter("@p8", txtChequeNo.Text);
                        par1[8] = new SqlParameter("@p9", txtAmount.Text);

                        par1[9] = new SqlParameter("@p10", txtBillNo.Text);
                        par1[10] = new SqlParameter("@p11", txtVenderName.Text);
                        par1[11] = new SqlParameter("@p12", txtVenderMobNo.Text);

                        par1[12] = new SqlParameter("@p13", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par1[13] = new SqlParameter("@p14", Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNumber"]));
                        par1[14] = new SqlParameter("@p15", lblUnit.Text);

                        par1[15] = new SqlParameter("@p16", rbtnPaymentType.SelectedItem.Text);
                        par1[16] = new SqlParameter("@p17", lblStandardRate.Text);
                        par1[17] = new SqlParameter("@p18", txtBalpayment.Text);

                        par1[18] = new SqlParameter("@p19", rbtnSourceExpense.SelectedItem.Text);
                        par1[19] = new SqlParameter("@p20", txtPartyotherName.Text);
                        par1[20] = new SqlParameter("@p21", txtPartyotherMobNo.Text);

                        par1[21] = new SqlParameter("@p22", Convert.ToString(ds.Tables[0].Rows[0]["CandidateRole"]));
                        par1[22] = new SqlParameter("@p23", Convert.ToString(ds.Tables[0].Rows[0]["CandidateRoleName"]));
                        par1[23] = new SqlParameter("@p24", Convert.ToString(ds.Tables[0].Rows[0]["CandidateDistrictID"]));

                        par1[24] = new SqlParameter("@p25", Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]));
                        par1[25] = new SqlParameter("@p26", Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyID"]));
                        par1[26] = new SqlParameter("@p27", Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]));

                        par1[27] = new SqlParameter("@p28", Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNumber"]));
                        par1[28] = new SqlParameter("@p29", "1");
                        par1[29] = new SqlParameter("@p30", "2");

                        par1[30] = new SqlParameter("@p31", "1");
                        par1[31] = new SqlParameter("@p32", ipAdd);
                        par1[32] = new SqlParameter("@p33", deviation);
                        par1[34] = new SqlParameter("@p35", offRole);
                        par1[33] = new SqlParameter("@p34", SqlDbType.Int);
                        par1[33].Direction = ParameterDirection.InputOutput;
                        SqlHelper.ExecuteNonQuery(contrue, CommandType.StoredProcedure, "uspInsertDailyExpenseWeb", par1);
                        string k = par1[33].Value.ToString();
                        BindGridView();
                        if (k == "101")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted Successfully...!!!')", true);
                            clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted Failed...!!!')", true);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First as Candidate')", true);
            }


        }

        public string CalDaviation()
        {
            string devi = "0";
            try
            {
                string a = lblStandardRate.Text;
                if (a.Equals(""))
                {
                    return devi;
                }
                try
                {
                    double d = 0;
                    double b = Convert.ToDouble(lblStandardRate.Text);
                    double c = Convert.ToDouble(txtYourRate.Text);
                    d = ((b - c) / b) * 100;
                    d = Convert.ToDouble(string.Format("{0:0.00}", d));
                    return d.ToString();
                }
                catch
                {
                    return devi;
                }
            }
            catch
            {
                return devi;
            }
        }
        protected void txtYourRate_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToDouble(txtYourRate.Text) * Convert.ToDouble(txtArea.Text)).ToString();
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtAmount.Text) > Convert.ToDouble(txtTotal.Text))
            {
                txtAmount.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                txtBalpayment.Text = (Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtAmount.Text)).ToString();
                txtAmount.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            lblStandardRate.Text = "";
            txtDate.Text = string.Empty;
            lblUnit.Text = "";
            txtArea.Text = "";
            txtYourRate.Text = "";
            txtTotal.Text = "";
            txtAmount.Text = "";
            txtVenderMobNo.Text = "";
            txtVenderName.Text = "";
            txtBillNo.Text = "";
            txtPartyotherName.Text = "";
            txtPartyotherMobNo.Text = "";
            txtBalpayment.Text = "";
            txtChequeNo.Text = "";
            // BindExpenseHead();
            ddlExpenseHead.SelectedIndex = ddlExpenseHead.Items.Count - 1;
            ddlSubExpenseHead.SelectedIndex = ddlSubExpenseHead.Items.Count - 1;
            rbPaymentMode.SelectedIndex = 0;
            rbtnPaymentType.SelectedIndex = 0;
            rbtnSourceExpense.SelectedIndex = 0;
        }

        public void killSession()
        {
            Session.Abandon();
            //Session["YourItem"] = null;
            //Session.Remove(YourItem");
            Session.Clear();

            //Session.Remove(usrMobileNumber");
            //Session.Remove("CandidateRole"); 
            //Session.Remove("CandidateRoleName"); 
            //Session.Remove("CandidateDistrictID"); 
            //Session.Remove("LocalBodyType");
            //Session.Remove("LocalBodyName");
            //Session.Remove("WardNo"); 
            //Session.Remove("LocalBodyID"); 
            //Session.Remove("AssemblyID"); 


            //Session["usrMobileNumber"] = null;
            //Session["CandidateRole"] = null;
            //Session["CandidateRoleName"] = null;
            //Session["CandidateDistrictID"] = null;
            //Session["LocalBodyType"] = null;
            //Session["LocalBodyName"] = null;
            //Session["WardNo"] = null;
            //Session["LocalBodyID"] = null;
            //Session["AssemblyID"] = null;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //killSession();
            Response.Redirect("../Reports/frmaddExpenseByOfficerOne.aspx");
        }

        public void BindGridView()
        {


            //string qry1 = "SELECT DE.[PK_Id],DE.[Date], DE.[InsertBy] ,DE.[PartyName]," +
            //           " DE.[PartyNo], DE.[CandidateRole], DE.[CandidateRoleName], DM.[Name_M] AS DistrictName, DE.[LocalBodyType]," +
            //           " DE.[LocalBodyNameID], CEI.[WardNo],CEI.[SeatNo],CEI.[ElectionType],CEI.[PartyName] AS PN, DE.[ReffrenceMobile],CEI.[LocalBodyName],CEI.[ElectionDate],ET.[ExpenseType]," +
            //           " ETS.[SubExpenseType], DE.[Qty_Size_Area], DE.[Rate], DE.[TotalExpense], DE.[PaymentMode]," +
            //           " DE.[PaidAmount], DE.[InvoiceNo], DE.[SourceOfExpense],DE.[CandidateRole], DE.[PartyName], DE.[PartyNo],DE.[IsApproved]" +
            //           " FROM [TrueVoterDB].[dbo].[tblDailyExpenses] AS DE" +
            //           " LEFT JOIN [TrueVoterDB].[dbo].[tblExpenseType] AS ET ON DE.[ExpenseType]=ET.[EID]" +
            //           " LEFT JOIN [TrueVoterDB].[dbo].[tblSubExpenseType] AS ETS ON DE.[SubExpenseType]=ETS.[SEID]" +
            //           " LEFT JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] AS CEI ON DE.[ReffrenceMobile]=CEI.[usrMobileNumber]" +
            //           " LEFT JOIN [TrueVoterDB].[dbo].[Districts] DM ON DM.[Id]=CEI.[CandidateDistrictID]" +
            //           " WHERE DE.[InsertBy] ='" + mob + "' AND [ReffrenceMobile]='" + candiMoNo + "' AND EntryFrom='2' ORDER BY [PK_Id] DESC" +

            //            " SELECT (SELECT Name+' '+LName FROM [TrueVoterDB].[dbo].[Logins] where UserName='" + candiMoNo + "') AS Name ,[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + candiMoNo + "' AND [CandidateRole] IN (1,2)";

            //ds = new DataSet();
            //ds.Clear();
            //ds = commoncode.ExecuteDataset(qry1);

            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@p1", "5");
            par[1] = new SqlParameter("@p2", mob);
            par[2] = new SqlParameter("@p3", candiMoNo);
            par[3] = new SqlParameter("@p4", "0");
            ds = new DataSet();
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(contrue, CommandType.StoredProcedure, "uspGetCandidateData", par);

            txtCandidateMoNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["usrMobileNumber"]);
            txtCandidateLocalBody.Text = Convert.ToString(ds.Tables[1].Rows[0]["LocalBodyName"]);
            txtName.Text = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);

            gvDaillyExpenses.DataSource = ds.Tables[0];
            gvDaillyExpenses.DataBind();
        }

        protected void gvDaillyExpenses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDaillyExpenses.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        public string GetIPAddress()
        {

            string computerName = System.Net.Dns.GetHostName();
            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(computerName);
            System.Net.IPAddress[] ipAddress = ipEntry.AddressList;

            return computerName = ipAddress[1].ToString();
            //computerName = computerName + "|" + ipAddress[0].ToString();
            //computerName = computerName + "|" + ipAddress[1].ToString();
        }

    }
}