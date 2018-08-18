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
    public partial class FundcollectionDetails : System.Web.UI.Page
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
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
                BindGridView();
            }
            else
            {
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

                mob = loginSession();
                string ipAdd = GetIPAddress();
                //string sql = "INSERT INTO [tblFundDetails] " +
                //          "([Date],[FromWhom],[FundType],[Amount],[PaidBy],[CheckNo],[ProviderBankName],[ProviderName],[Address],[MobileNo],[CreatedBy],[CreatedDate],[IMEINo])" +
                //           " VALUES ('" + txtDate.Text.ToString() + "','" + ddlFrom.SelectedValue.ToString() + "','" + ddlSelectFundType.SelectedValue.ToString() + "','" + txtAmount.Text.ToString() + "','" + ddlPaidBy.SelectedItem.Text.ToString() + "', " +
                //            "'" + txtChkDtls.Text.ToString() + "','" + txtproviderbnkDtls.Text.ToString() + "','" + txtProviderName.Text.ToString() + "','" + txtAddress.Text.ToString() + "','" + txtmobNo.Text.ToString() + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + ipAdd + "')";
                //SqlCommand cmd = new SqlCommand(sql, con);
                //con.Open();
                //int i = cmd.ExecuteNonQuery();
                //con.Close();

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
                par[12] = new SqlParameter("@p13", ipAdd);
                par[13] = new SqlParameter("@p14", SqlDbType.Int);
                par[14].Direction = ParameterDirection.InputOutput;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertFundDetailsNew", par);
                string i = par[13].Value.ToString();
                if (i == "101")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Submitted Successfully..')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Not Submitted')", true);
                }
                ClearMethod();
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

                    //lblproviderbankNo.Visible = true;
                    //txtproviderbnkDtls.Visible = true;
                    //lblprovidername.Visible = true;
                    //txtProviderName.Visible = true;
                    //lblMobNo.Visible = true;
                    //txtmobNo.Visible = true;
                }
                else
                {
                    pnlMoNo.Visible = false;
                    pnlProviderBankName.Visible = false;
                    pnlprovidername.Visible = false;
                    //lblproviderbankNo.Visible = false;
                    //txtproviderbnkDtls.Visible = false;
                    //lblprovidername.Visible = false;
                    //txtProviderName.Visible = false;
                    //lblMobNo.Visible = false;
                    //txtmobNo.Visible = false;
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
            //gvFundDetails.DataSource = ds.Tables[0];
            //gvFundDetails.DataBind();

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@mob", mob);
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetFundDetailsNew", par);
            gvFundDetails.DataSource = ds.Tables[0];
            gvFundDetails.DataBind();
        }

        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            string gvSrNo = string.Empty;
            //cmd = new SqlCommand();
            LinkButton lnkbtnSubmit = (LinkButton)sender;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;

            gvSrNo = lnkbtnSubmit.CommandArgument;

            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblFundDetails] SET [IsActive]='1'  WHERE [FundID]= '" + gvSrNo + "'";
            //cc.ExecuteNonQuery(qry);
            //BindGridView();


            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@gvSrNo", gvSrNo);
            par[1] = new SqlParameter("@qry", "1");
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetFundDetailsStatusChange", par);
            BindGridView();

        }

        protected void lnkDeactive_Click(object sender, EventArgs e)
        {
            string gvSrNo = string.Empty;
            //cmd = new SqlCommand();
            LinkButton lnkbtnSubmit = (LinkButton)sender;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;

            gvSrNo = lnkbtnSubmit.CommandArgument;

            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblFundDetails] SET [IsActive]='0'  WHERE [FundID]= '" + gvSrNo + "'";
            //cc.ExecuteNonQuery(qry);
            //BindGridView();


            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@gvSrNo", gvSrNo);
            par[1] = new SqlParameter("@qry", "2");
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetFundDetailsStatusChange", par);
            BindGridView();
        }

        protected void gvFundDetails_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvFundDetails.PageIndex = e.NewSelectedIndex;
            BindGridView();
        }
    }
}