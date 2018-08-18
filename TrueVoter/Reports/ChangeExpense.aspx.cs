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
    public partial class ChangeExpense : System.Web.UI.Page
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

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "GetDataOn_ExpenseOldId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ExpenseOldId", Convert.ToInt32(txtExpenseOldId.Text));
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DateTime datetime =Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
                    
                    txtTotal.Text = (Convert.ToDouble(txtTotal.Text) - (Convert.ToDouble(txtYourRate.Text) * Convert.ToDouble(txtArea.Text))).ToString();

                    string query = "INSERT INTO [TrueVoterDB].[dbo].[tblDailyExpenses] ([Date],[ExpenseType],[SubExpenseType],[Qty_Size_Area],[Rate],[TotalExpense]," +
                                    "[PaymentMode],[ChequeNo],[PaidAmount],[InvoiceNo],[FirmName],[FirmOwnerMobNo],[InsertDate],[Unit],[PaymentType],[InsertBy] " +
                                    "[StandardRate],[BalancePayment],[SourceOfExpense],[PartyName],[PartyNo],[CandidateRole],[CandidateRoleName],[CandidateDistrict],[LocalBodyType]," +
                                    "[LocalBodyNameID],[WardNo],[ReffrenceMobile],[IsApproved],[EntryFrom],[IsActive],[IMEINumber],[refExpenseOldId]) " +
                                    " VALUES ('" + datetime.ToString("yyyy-MM-dd") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["ExpenseType"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseType"]) + "','" + txtArea.Text + "'" +
                                    ",'" + txtYourRate.Text + "','" + txtTotal.Text + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PaymentMode"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["ChequeNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PaidAmount"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]) + "'" +
                                    ",'" + Convert.ToString(ds.Tables[0].Rows[0]["FirmName"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["FirmOwnerMobNo"]) + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' ,'" + Convert.ToString(Session["MobileNO"]) + "'" +
                                    ",'" + Convert.ToString(ds.Tables[0].Rows[0]["Unit"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PaymentType"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["StandardRate"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["BalancePayment"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["SourceOfExpense"]) + "'," +
                                    "'" + Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PartyNo"]) + "' " +
                                    ",'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRole"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateRoleName"]) + "' " +
                                    ",'" + Convert.ToString(ds.Tables[0].Rows[0]["CandidateDistrictID"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyNameID"]) + "'," +
                                    "'" + Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["ReffrenceMobile"]) + "','1','2','1','" + Convert.ToString(ds.Tables[0].Rows[0]["IMEINumber"]) + "',"+ txtExpenseOldId.Text +")";

                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    int i = cmd.ExecuteNonQuery();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Save Successfully...')", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "GetDataOn_ExpenseOldId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ExpenseOldId", Convert.ToInt32(txtExpenseOldId.Text));
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
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

                    pnlExpense.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data is not Found...')", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}