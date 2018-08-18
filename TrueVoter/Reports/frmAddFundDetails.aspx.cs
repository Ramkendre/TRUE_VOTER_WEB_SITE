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
    public partial class frmAddFundDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        CommonCode cc = new CommonCode();
        DataSet ds = new DataSet();
        string mob = string.Empty;
        string query = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (IsPostBack == false)
                {
                    btnSubmit.Text = "Submit";
                    //mob = Session["MobileNo"].ToString();
                    BindGridView();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public string loginSession()
        {
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
            return mob;
        }

        public void ClearMethod()
        {
            try
            {
                btnSubmit.Text = "Submit";
                txtDate.Text = "";
                ddlFrom.SelectedValue = "0";
                ddlPaidBy.SelectedValue = "0";
                ddlSelectFundType.SelectedValue = "0";
                txtAmount.Text = "";
                txtChkDtls.Text = "";
                txtmobNo.Text = "";
                txtAddress.Text = "";
                txtproviderbnkDtls.Text = "";
                txtProviderName.Text = "";
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Date..!!!')", true);
                }
                else if (ddlFrom.SelectedItem.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select From Name.!!!')", true);
                }
                else if (ddlSelectFundType.SelectedItem.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Fund Type..!!!')", true);
                }
                else if (txtAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Amount..!!!')", true);
                }
                else if (ddlPaidBy.SelectedItem.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select paid By..!!!')", true);
                }
                else if (txtChkDtls.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter check Details..!!!')", true);
                }
                else if (txtAddress.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter proper Address..!!!')", true);
                }

                //mob = loginSession();
               // string sql = string.Empty;
                //if (btnSubmit.Text == "Submit")
                //{
                //    sql = "INSERT INTO [tblFundDetails] " +
                //             "([Date],[FromWhom],[FundType],[Amount],[PaidBy],[CheckNo],[ProviderBankName],[ProviderName],[Address],[MobileNo],[CreatedBy],[CreatedDate])" +
                //              " VALUES ('" + txtDate.Text.ToString() + "','" + ddlFrom.SelectedValue.ToString() + "','" + ddlSelectFundType.SelectedValue.ToString() + "','" + txtAmount.Text.ToString() + "','" + ddlPaidBy.SelectedItem.Text.ToString() + "', " +
                //               "'" + txtChkDtls.Text.ToString() + "','" + txtproviderbnkDtls.Text.ToString() + "','" + txtProviderName.Text.ToString() + "','" + txtAddress.Text.ToString() + "','" + txtmobNo.Text.ToString() + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                //}
                //else
                //{
                //    sql = "UPDATE [tblFundDetails] SET [Date]='" + txtDate.Text.ToString() + "',[FromWhom]='" + ddlFrom.SelectedValue.ToString() + "'," +
                //          "[FundType]='" + ddlSelectFundType.SelectedValue.ToString() + "',[Amount]='" + txtAmount.Text.ToString() + "'," +
                //          "[PaidBy]='" + ddlPaidBy.SelectedItem.Text.ToString() + "',[CheckNo]='" + txtChkDtls.Text.ToString() + "'," +
                //          "[ProviderBankName]='" + txtproviderbnkDtls.Text.ToString() + "',[ProviderName]='" + txtProviderName.Text.ToString() + "'," +
                //          "[Address]='" + txtAddress.Text.ToString() + "',[MobileNo]='" + txtmobNo.Text.ToString() + "',[ModifyBy]='" + mob + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [FundID]='" + txtFundID.Text + "'";
                //}
                //int i = cc.ExecuteNonQuery(sql);

                string k = string.Empty;
                if (btnSubmit.Text == "Submit")
                {
                    SqlParameter[] par = new SqlParameter[20];
                    par[0] = new SqlParameter("@p1",txtDate.Text.ToString());
                    par[1] = new SqlParameter("@p2",ddlFrom.SelectedValue.ToString());
                    par[2] = new SqlParameter("@p3",ddlSelectFundType.SelectedValue.ToString());
                    par[3] = new SqlParameter("@p4",txtAmount.Text.ToString());
                    par[4] = new SqlParameter("@p5",ddlPaidBy.SelectedItem.Text.ToString());
                    par[5] = new SqlParameter("@p6",txtChkDtls.Text.ToString());
                    par[6] = new SqlParameter("@p7",txtproviderbnkDtls.Text.ToString());
                    par[7] = new SqlParameter("@p8",txtProviderName.Text.ToString());
                    par[8] = new SqlParameter("@p9",txtAddress.Text.ToString());
                    par[9] = new SqlParameter("@p10",txtmobNo.Text.ToString());
                    par[10] = new SqlParameter("@p11",mob);
                    par[11] = new SqlParameter("@p12",System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par[12] = new SqlParameter("@p13","0");
                    par[13] = new SqlParameter("@p14",SqlDbType.Int);
                    par[13].Direction=ParameterDirection.InputOutput;
                    par[14] = new SqlParameter("@p15", "1");
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertFundDetailsWeb", par);
                    k = par[13].Value.ToString();
                }
                else
                {
                    SqlParameter[] par = new SqlParameter[20];
                    par[0] = new SqlParameter("@p1", txtDate.Text.ToString());
                    par[1] = new SqlParameter("@p2", ddlFrom.SelectedValue.ToString());
                    par[2] = new SqlParameter("@p3", ddlSelectFundType.SelectedValue.ToString());
                    par[3] = new SqlParameter("@p4", txtAmount.Text.ToString());
                    par[4] = new SqlParameter("@p5", ddlPaidBy.SelectedItem.Text.ToString());
                    par[5] = new SqlParameter("@p6", txtChkDtls.Text.ToString());
                    par[6] = new SqlParameter("@p7", txtproviderbnkDtls.Text.ToString());
                    par[7] = new SqlParameter("@p8", txtProviderName.Text.ToString());
                    par[8] = new SqlParameter("@p9", txtAddress.Text.ToString());
                    par[9] = new SqlParameter("@p10", txtmobNo.Text.ToString());
                    par[10] = new SqlParameter("@p11", mob);
                    par[11] = new SqlParameter("@p12", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par[12] = new SqlParameter("@p13", txtFundID.Text);
                    par[13] = new SqlParameter("@p14", SqlDbType.Int);
                    par[13].Direction = ParameterDirection.InputOutput;
                    par[14] = new SqlParameter("@p15", "2");
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertFundDetailsWeb", par);
                    k = par[13].Value.ToString();
                }

                if (k == "101")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Submitted Successfully..')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Not Submitted')", true);
                }
                ClearMethod();
                BindGridView();
            }
            catch
            {

            }
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
        protected void ddlFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFrom.SelectedValue == "3" || ddlFrom.SelectedValue == "4" || ddlFrom.SelectedValue == "5" || ddlFrom.SelectedValue == "6")
                {
                    pnlMoNo.Visible = true;
                    pnlProviderBankName.Visible = true;
                    pnlprovidername.Visible = true;
                }
                else
                {
                    pnlMoNo.Visible = false;
                    pnlProviderBankName.Visible = false;
                    pnlprovidername.Visible = false;
                }
            }
            catch
            {

            }
        }
        public void BindGridView()
        {
            //query = "SELECT [FundID],[Date],[FromWhom],[FundType],[Amount],[PaidBy],[CheckNo],[CheckDate],[ProviderBankName],[ProviderName],[Address],[MobileNo],[IsActive] FROM [TrueVoterDB].[dbo].[tblFundDetails] WHERE [CreatedBy]='" + mob + "' ORDER BY [FundID] DESC";
            //ds = cc.ExecuteDataset(query);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@mob", mob);
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetFundDetails", par);
            gvFundDetails.DataSource = ds.Tables[0];
            gvFundDetails.DataBind();
        }
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            string gvSrNo = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkbtnSubmit = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            gvSrNo = lnkbtnSubmit.CommandArgument;

            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblFundDetails] SET [IsActive]='1'  WHERE [FundID]= '" + gvSrNo + "'";
            //cc.ExecuteNonQuery(qry);

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@gvSrNo", gvSrNo);
            par[1] = new SqlParameter("@qry", "1");
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetFundDetailsStatusChange", par);
            BindGridView();
        }
        protected void lnkDeactive_Click(object sender, EventArgs e)
        {
            string gvSrNo = string.Empty;
            cmd = new SqlCommand();
            LinkButton lnkbtnSubmit = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            gvSrNo = lnkbtnSubmit.CommandArgument;

            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblFundDetails] SET [IsActive]='0'  WHERE [FundID]= '" + gvSrNo + "'";
            //cc.ExecuteNonQuery(qry);
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@gvSrNo", gvSrNo);
            par[1] = new SqlParameter("@qry", "2");
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetFundDetailsStatusChange", par);
            BindGridView();
        }
        protected void gvFundDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFundDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            string fundId = lnkEdit.CommandArgument;
            btnSubmit.Text = "Update";
            //string qry = "SELECT [FundID],[Date],[FromWhom],[FundType],[Amount],[PaidBy],[CheckNo],[CheckDate],[ProviderBankName],[ProviderName],[Address],[MobileNo],[IsActive] FROM [TrueVoterDB].[dbo].[tblFundDetails] WHERE [FundID]='" + fundId + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@p1", fundId);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetFundDetailsById", par);
                        
            txtFundID.Text = fundId;
            txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Date"]);
            txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
            txtmobNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
            txtChkDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["CheckNo"]);
            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
            txtproviderbnkDtls.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProviderBankName"]);
            txtProviderName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProviderName"]);

            string byWHm = Convert.ToString(ds.Tables[0].Rows[0]["FromWhom"]);
            ddlFrom.SelectedValue = byWHm;
            if (byWHm == "3" || byWHm == "4" || byWHm == "5" || byWHm == "6")
            {
                pnlMoNo.Visible = true;
                pnlProviderBankName.Visible = true;
                pnlprovidername.Visible = true;
            }
            else
            {
                pnlMoNo.Visible = false;
                pnlProviderBankName.Visible = false;
                pnlprovidername.Visible = false;
            }
            string fntyp = Convert.ToString(ds.Tables[0].Rows[0]["FundType"]);
            ddlSelectFundType.SelectedValue = fntyp;

            string PaidBy = Convert.ToString(ds.Tables[0].Rows[0]["PaidBy"]);
            ddlPaidBy.SelectedValue = PaidBy;

        }
    }
}