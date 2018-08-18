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
    public partial class NewChangeExpense : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void BindData()
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "GetDataOn_ExpenseOldId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ExpenseOldId", Convert.ToInt32(Request.QueryString["ExpenseId"]));
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtExpenseOldId.Text = Convert.ToString(ds.Tables[0].Rows[0]["PK_Id"]);
                    txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Date"]);
                    //ddlExpenseHead.Text = Convert.ToString(ds.Tables[1].Rows[0]["ExpenseType"]);
                    ddlExpenseHead.DataSource = ds.Tables[1];
                    ddlExpenseHead.DataTextField = "ExpenseType";
                    ddlExpenseHead.DataBind();
                    //ddlSubExpenseHead.Text = Convert.ToString(ds.Tables[1].Rows[0]["SubExpenseHead"]);
                    ddlSubExpenseHead.DataSource = ds.Tables[1];
                    ddlSubExpenseHead.DataTextField = "SubExpenseHead";
                    ddlSubExpenseHead.DataBind();
                    lblStandardRate.Text = Convert.ToString(ds.Tables[0].Rows[0]["StandardRate"]);
                    lblUnit.Text = Convert.ToString(ds.Tables[0].Rows[0]["Unit"]);
                    txtArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Qty_Size_Area"]);
                    txtYourRate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Rate"]);
                    txtTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalExpense"]);
                    //rbtnPaymentType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentType"]);
                    //rbPaymentMode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentMode"]);
                    txtPaymentType.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentType"]);
                    txtPaymentMode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaymentMode"]);
                    txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaidAmount"]);
                    txtChequeNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChequeNo"]);
                    txtBalpayment.Text = Convert.ToString(ds.Tables[0].Rows[0]["BalancePayment"]);
                    txtVenderName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirmName"]);
                    txtVenderMobNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirmOwnerMobNo"]);
                    txtBillNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]);
                    txtSourceExpense.Text = Convert.ToString(ds.Tables[0].Rows[0]["SourceOfExpense"]);
                    txtPartyotherName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]);
                    txtPartyotherMobNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyNo"]);
                    txtdifferamount.Text = Convert.ToString("");
                    txtdecisionRemark.Text = Convert.ToString("");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data is not Found...')", true);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnAddDiffer_Click(object sender, EventArgs e)
        {
            try
            {
                //string sqlid = "Select [AcceptedEntry] From [TrueVoterDB].[dbo].[tblDailyExpenses] Where PK_Id=" + txtExpenseOldId.Text + "";
                //cmd = new SqlCommand(sqlid, con);
                //con.Open();
                //string expid=Convert.ToString(cmd.ExecuteScalar());
                //con.Close();
                //if (expid == string.Empty)
                //{
                    cmd.Connection = con;
                    cmd.CommandText = "GetDataOn_ExpenseOldId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ExpenseOldId", Convert.ToInt32(txtExpenseOldId.Text));
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DateTime datetime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);

                        //  txtTotal.Text = (Convert.ToDouble(txtTotal.Text) - (Convert.ToDouble(txtYourRate.Text) * Convert.ToDouble(txtArea.Text))).ToString();

                        string query = "INSERT INTO [TrueVoterDB].[dbo].[tblDailyExpenses] ([Date],[ExpenseType],[SubExpenseType],[Qty_Size_Area],[Rate],[TotalExpense]," +
                                        "[PaymentMode],[ChequeNo],[PaidAmount],[InvoiceNo],[FirmName],[FirmOwnerMobNo],[InsertDate],[Unit],[PaymentType],[InsertBy]," +
                                        "[StandardRate],[BalancePayment],[SourceOfExpense],[PartyName],[PartyNo],[CandidateRole],[CandidateRoleName],[CandidateDistrict],[LocalBodyType]," +
                                        "[LocalBodyNameID],[WardNo],[ReffrenceMobile],[IsApproved],[EntryFrom],[IsActive],[IMEINumber],[refExpenseOldId],[DiffAmount],[DecisionRemark]) " +
                                        " VALUES ('" + datetime.ToString("yyyy-MM-dd") + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["ExpenseType"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseType"]) + "',N'" + txtArea.Text + "'" +
                                        ",N'" + txtYourRate.Text + "','" + txtdifferamount.Text + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PaymentMode"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["ChequeNo"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["PaidAmount"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]) + "'" +
                                        ",N'" + Convert.ToString(ds.Tables[0].Rows[0]["FirmName"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["FirmOwnerMobNo"]) + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                                        ",N'" + Convert.ToString(ds.Tables[0].Rows[0]["Unit"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["PaymentType"]) + "','" + Convert.ToString(Session["MobileNO"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["StandardRate"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["BalancePayment"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["SourceOfExpense"]) + "'," +
                                        "N'" + Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["PartyNo"]) + "' " +
                                        ",N'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRole"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRoleName"]) + "' " +
                                        ",N'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateDistrictID"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyNameID"]) + "'," +
                                        "N'" + Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]) + "',N'" + Convert.ToString(ds.Tables[0].Rows[0]["ReffrenceMobile"]) + "','1','2','1','" + Convert.ToString(ds.Tables[0].Rows[0]["IMEINumber"]) + "'," + txtExpenseOldId.Text + ",N'" + txtdifferamount.Text + "',N'" + txtdecisionRemark.Text + "')";

                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();

                        string ssql = "SELECT PK_Id FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE refExpenseOldId=" + txtExpenseOldId.Text + "";
                      SqlCommand  cmd1 = new SqlCommand(ssql, con);
                        con.Open();
                        string pkid = Convert.ToString(cmd1.ExecuteScalar());
                        con.Close();

                        string queryobjection = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [ExtaExpId]='" + pkid + "' WHERE [ServerID]='" + txtExpenseOldId.Text + "'";
                        SqlCommand com2 = new SqlCommand();
                        com2.CommandText = queryobjection;
                        com2.CommandType = CommandType.Text;
                        com2.Connection = con;
                        con.Open();
                        int i1 = com2.ExecuteNonQuery();
                        con.Close();

                        string querydeviation = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [AcceptedEntry]='" + pkid + "' WHERE PK_Id='" + txtExpenseOldId.Text + "'";
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3.CommandText = querydeviation;
                        cmd3.CommandType = CommandType.Text;
                        cmd3.Connection = con;
                        con.Open();
                        int i11 = cmd3.ExecuteNonQuery();
                        con.Close();

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Saved Successfully...')", true);
                        Response.Redirect("~/Reports/Deviation.aspx");
                    }
                    else
                    {

                    }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This entry already stalled by RO...')", true);
                //}
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/Deviation.aspx");
        }
    }
}
