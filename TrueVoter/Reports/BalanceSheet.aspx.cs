using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Reflection;

namespace TrueVoter.Reports
{
    public partial class BalanceSheet : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        //int Result = 0;
        string strReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            QueryData();
            loginSession();
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
        public void QueryData()
        {
            //txtUserID.Text = Request.QueryString["UserID"];
           // txtTransactionsID.Text = Request.QueryString["TransectionID"];
            //txtOrderId.Text = Request.QueryString["OrderID"];
            //txtMobileNo.Text = Request.QueryString["MobileNo"];

           // txtUserID.Text = this.Context.Items["UserID"].ToString();


            //if (Page.PreviousPage != null)
            //{
            //    Type objType = Page.PreviousPage.GetType();
            //    MethodInfo objMethodInfo = objType.GetMethod("UserID");
            //    txtUserID.Text =Convert.ToString(objMethodInfo.Invoke(Page.PreviousPage, null));
 
            //}

            if (Application["UserID"] != null)
            {
                txtUserID.Text=Application["UserID"].ToString();
                txtOrderId.Text = Application["OrderID"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string returnVal = string.Empty;
            try
            {
                cmd.CommandText = "UspSmsInformation";
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = txtUserID.Text;
                cmd.Parameters.Add("@OrderId", SqlDbType.NVarChar).Value = txtOrderId.Text;
                //cmd.Parameters.Add("@TransectionId", SqlDbType.NVarChar).Value = txtTransactionsID.Text;
               // cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                cmd.Parameters.Add("@NoOfSMS", SqlDbType.NVarChar).Value = txtNoOfSms.Text;               
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = txtAmount.Text;
                cmd.Parameters.Add("@SmsCost", SqlDbType.NVarChar).Value = txtSmsCost.Text;
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = mob;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = txtDate.Text;    
                
                cmd.Parameters.Add("@returnvalue", SqlDbType.Int).Direction = ParameterDirection.Output;               
                cmd.ExecuteNonQuery();
                returnVal = cmd.Parameters["@returnvalue"].Value.ToString();
                if (returnVal.Equals("104"))
                {
                    //strReturn = returnVal;
                   //cc.SendSMS();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Submited Successfully.!!!')", true);
                }
            }
            catch
            {
                strReturn = returnVal;    
            }
            finally
            {
                con.Close();
            }
        }
    }
}