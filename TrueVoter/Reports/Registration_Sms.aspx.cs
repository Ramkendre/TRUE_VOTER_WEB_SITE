using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using TrueVoter;
using Microsoft.ApplicationBlocks.Data;

namespace TrueVoter.Reports
{
    public partial class Registration_Sms : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds55 = new DataSet();
        string strReturn = string.Empty;
        CommonCode objCommonCode = new CommonCode();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string returnVal = string.Empty;
            string Password = txtPassword.Text;
            string data52 = string.Empty;
            string Result = string.Empty;
            Password = objCommonCode.DESEncrypt(Password);
            try
            {
                using (SqlConnection con1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
                {
                    SqlParameter[] par = new SqlParameter[11];
                    par[0] = new SqlParameter("@MobileNo", txtMobileNo.Text);
                    par[1] = new SqlParameter("@type", 1);
                    par[2] = new SqlParameter("@returnvalue", SqlDbType.Int);
                    par[2].Direction = ParameterDirection.InputOutput;
                    ds = SqlHelper.ExecuteDataset(con1, CommandType.StoredProcedure, "UspDownloadRegistration_Sms", par);
                    Result = par[2].Value.ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Mobile No is Already Registered.!!!')", true);
                    }
                    else
                    {
                        SqlParameter[] par52 = new SqlParameter[11];
                        par52[0] = new SqlParameter("@UserId", txtUserId.Text);
                        par52[1] = new SqlParameter("@UserName_Sms", txtUserName.Text);
                        par52[2] = new SqlParameter("@Password", Password);
                        par52[3] = new SqlParameter("@NoofSms", txtNoofSms.Text);
                        par52[4] = new SqlParameter("@OrderId", txtOrderId.Text);
                        par52[5] = new SqlParameter("@Createdby", txtMobileNo.Text);
                        par52[6] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par52[7] = new SqlParameter("@MobileNo", txtMobileNo.Text);
                        par52[8] = new SqlParameter("@type", 1);
                        par52[9] = new SqlParameter("@returnvalue", SqlDbType.Int);
                        par52[9].Direction = ParameterDirection.InputOutput;
                        SqlHelper.ExecuteNonQuery(con1, CommandType.StoredProcedure, "UspRegistration_Sms", par52);
                        Result = par52[9].Value.ToString();
                        if (Result.Equals("106"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Submited Successfully.!!!')", true);
                        }

                    }

                    //Support Team Login Table
                    if (txtMobileNo.Text != string.Empty)
                    {
                        ds55.Clear();
                        SqlParameter[] par55 = new SqlParameter[11];
                        par55[0] = new SqlParameter("@MobileNo", txtMobileNo.Text);
                        par55[1] = new SqlParameter("@type", 2);
                        par55[2] = new SqlParameter("@returnvalue", SqlDbType.Int);
                        par55[2].Direction = ParameterDirection.InputOutput;
                        ds55 = SqlHelper.ExecuteDataset(con1, CommandType.StoredProcedure, "UspDownloadRegistration_Sms", par55);
                        Result = par[2].Value.ToString();
                        if (ds55.Tables[0].Rows.Count > 0)
                        {//Update Sati 

                            //SqlParameter[] par56 = new SqlParameter[11];
                            //par56[0] = new SqlParameter("@UserId", 0);
                            //par56[1] = new SqlParameter("@UserName_Sms", txtUserName.Text);
                            //par56[2] = new SqlParameter("@Password", Password);
                            //par56[3] = new SqlParameter("@NoofSms", 0);
                            //par56[4] = new SqlParameter("@OrderId", 0);
                            //par56[5] = new SqlParameter("@Createdby", txtMobileNo.Text);
                            //par56[6] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                            //par56[7] = new SqlParameter("@MobileNo", txtMobileNo.Text);
                            //par56[8] = new SqlParameter("@type", 2);
                            //par56[9] = new SqlParameter("@returnvalue", SqlDbType.Int);
                            //par56[9].Direction = ParameterDirection.InputOutput;
                            //SqlHelper.ExecuteNonQuery(con1, CommandType.StoredProcedure, "UspRegistration_Sms", par52);
                            //Result = par56[9].Value.ToString();
                        }
                        else
                        {
                            SqlParameter[] par56 = new SqlParameter[11];
                            par56[0] = new SqlParameter("@UserId", 0);
                            par56[1] = new SqlParameter("@UserName_Sms", txtUserName.Text);
                            par56[2] = new SqlParameter("@Password", txtPassword.Text);
                            par56[3] = new SqlParameter("@NoofSms", 0);
                            par56[4] = new SqlParameter("@OrderId", 0);
                            par56[5] = new SqlParameter("@Createdby", txtMobileNo.Text);
                            par56[6] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                            par56[7] = new SqlParameter("@MobileNo", txtMobileNo.Text);
                            par56[8] = new SqlParameter("@type", 2);
                            par56[9] = new SqlParameter("@returnvalue", SqlDbType.Int);
                            par56[9].Direction = ParameterDirection.InputOutput;
                            SqlHelper.ExecuteNonQuery(con1, CommandType.StoredProcedure, "UspRegistration_Sms", par56);
                            Result = par56[9].Value.ToString();
                        }
                    }
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
            //string returnVal = string.Empty;
            //string Password = txtPassword.Text;
            //Password = objCommonCode.DESEncrypt(Password);
            //try
            //{
            //    cmd.CommandText = "UspRegistration_Sms";
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }
            //    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = txtUserId.Text;
            //    cmd.Parameters.Add("@UserName_Sms", SqlDbType.NVarChar).Value = txtUserName.Text;
            //    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
            //    cmd.Parameters.Add("@NoofSms", SqlDbType.NVarChar).Value = txtNoofSms.Text;
            //    cmd.Parameters.Add("@OrderId", SqlDbType.NVarChar).Value = txtOrderId.Text;
            //    cmd.Parameters.Add("@Createdby", SqlDbType.NVarChar).Value = txtMobileNo.Text;
            //    cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            //    cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
            //    cmd.Parameters.Add("@returnvalue", SqlDbType.Int).Direction = ParameterDirection.Output;
            //    cmd.ExecuteNonQuery();
            //    returnVal = cmd.Parameters["@returnvalue"].Value.ToString();
            //    if (returnVal.Equals("106"))
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Submited Successfully.!!!')", true);
            //    }
            //}
            //catch 
            //{
            //    strReturn = returnVal;    
            //}
            //finally 
            //{
            //    con.Close();
            //}
        }
    }
}