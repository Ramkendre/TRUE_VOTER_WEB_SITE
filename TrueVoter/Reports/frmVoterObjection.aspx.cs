using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using Microsoft.ApplicationBlocks.Data;


namespace TrueVoter.Reports
{
    public partial class frmVoterObjection : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private string aid = "639250";
        private string pin = "M@h123";
        //string stringResult = null;
        private WebProxy objProxy1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindDistrict();
            }
        }

        public DataSet GetData(string queryId, string distId)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspVoterObjectionQuerys";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@queryId", SqlDbType.NVarChar, 10).Value = queryId;
                cmd.Parameters.Add("@DistId", SqlDbType.NVarChar, 10).Value = distId;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return ds;
            }
            catch
            {
                return ds;
            }
        }

        public void BindDistrict()
        {
            DataSet dsDist = new DataSet();
            dsDist = GetData("1", "0");

            if (dsDist.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = ds.Tables[0];
                ddlDistrict.DataTextField = "Name_E";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();

                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string distId = ddlDistrict.SelectedValue.ToString();
                DataSet dsLocalBody = GetData("2", distId);

                ddlLocalBodyId.DataSource = dsLocalBody.Tables[0];
                ddlLocalBodyId.DataTextField = "ElectionName";
                ddlLocalBodyId.DataValueField = "ElectionId";
                ddlLocalBodyId.DataBind();

                ddlLocalBodyId.Items.Add("--Select--");
                ddlLocalBodyId.SelectedIndex = ddlLocalBodyId.Items.Count - 1;
            }
            catch
            {

            }

        }
        protected void btnGetOtp_Click(object sender, EventArgs e)
        {
            try
            {
                //string query = "SELECT * FROM [TrueVoterDB].[dbo].[tblVoterObjection] WHERE [UserMobileNo]='" + txtMobileNo.Text.Trim() + "'";
                //cmd = new SqlCommand(query, con);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds);

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@mobNo",txtMobileNo.Text.Trim());
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetVoterObjectionByMoNo", par);





                Random otpGenerator = new Random();
                string otpNumber = otpGenerator.Next(1000, 9999).ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string otp = ds.Tables[0].Rows[0]["OTP"].ToString();
                    if (otp == "0")
                    {
                        //string query1 = "UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + txtName.Text + "',[EmailId]='" + txtemail.Text + "',[IMEINo]='0',"
                        //    +"[OTP]='" + otpNumber + "',[ModifyBy]='" + txtMobileNo.Text + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' "
                        //     +"WHERE [UserMobileNo]='" + txtMobileNo.Text + "'";
                        //cmd = new SqlCommand(query1, con);
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();


                        SqlParameter[] par1 = new SqlParameter[10];
                        par1[0] = new SqlParameter("@Name", txtName.Text);
                        par1[1] = new SqlParameter("@mail", txtemail.Text);
                        par1[2] = new SqlParameter("@otp", otpNumber);
                        par1[3] = new SqlParameter("@ModimobNo", txtMobileNo.Text);
                        par1[4] = new SqlParameter("@ModiDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par1[5] = new SqlParameter("@mobNo", txtMobileNo.Text);
                        par1[6] = new SqlParameter("@qry", "1");
                        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspUpdateVoterObjection", par1);
                    }
                    else
                    {
                        otpNumber = otp;
                        //string query1 = "UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + txtName.Text + "',[EmailId]='" + txtemail.Text + "',[IMEINo]='0',[OTP]='" + otpNumber + "',[ModifyBy]='" + txtMobileNo.Text + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo]='" + txtMobileNo.Text + "'";
                        //cmd = new SqlCommand(query1, con);
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();


                        SqlParameter[] par1 = new SqlParameter[10];
                        par1[0] = new SqlParameter("@Name", txtName.Text);
                        par1[1] = new SqlParameter("@mail", txtemail.Text);
                        par1[2] = new SqlParameter("@otp", otpNumber);
                        par1[3] = new SqlParameter("@ModimobNo", txtMobileNo.Text);
                        par1[4] = new SqlParameter("@ModiDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par1[5] = new SqlParameter("@mobNo", txtMobileNo.Text);
                        par1[6] = new SqlParameter("@qry", "2");
                        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspUpdateVoterObjection", par1);

                        //otp send
                        string passwordMessage = "OTP for " + txtName.Text + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                        SendSMS(txtMobileNo.Text.Trim(), passwordMessage);
                    }
                }
                else
                {
                    //string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblVoterObjection] ([Name],[UserMobileNo],[EmailId],[IMEINo],[OTP],[CreatedBy],[CreatedDate]) " +
                    //           " VALUES ('" + txtName.Text + "','" + txtMobileNo.Text.Trim() + "','" + txtemail.Text + "','0','" + otpNumber + "','" + txtMobileNo.Text.Trim() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "') ";

                    //cmd = new SqlCommand(sqlQuery, con);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();


                    SqlParameter[] par1 = new SqlParameter[10];
                    par1[0] = new SqlParameter("@Name", txtName.Text);
                    par1[1] = new SqlParameter("@mail", txtemail.Text);
                    par1[2] = new SqlParameter("@otp", otpNumber);
                    par1[3] = new SqlParameter("@ModimobNo", txtMobileNo.Text);
                    par1[4] = new SqlParameter("@ModiDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par1[5] = new SqlParameter("@mobNo", txtMobileNo.Text);
                    par1[6] = new SqlParameter("@qry", "3");
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspUpdateVoterObjection", par1);


                    //otp send
                    string passwordMessage = "OTP for " + txtName.Text + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                    SendSMS(txtMobileNo.Text.Trim(), passwordMessage);

                }
            }
            catch
            {

            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            //string query = "SELECT * FROM [TrueVoterDB].[dbo].[tblVoterObjection] WHERE [UserMobileNo]='" + txtMobileNo.Text.Trim() + "'";
            //cmd = new SqlCommand(query, con);
            //da = new SqlDataAdapter(cmd);
            //da.Fill(ds);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@mobNo", txtMobileNo.Text.Trim());
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetVoterObjectionByMoNo", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string otp = ds.Tables[0].Rows[0]["OTP"].ToString();
                string userOTP = txtOtp.Text.Trim();
                if (otp == userOTP)
                {
                    Session["OffMobileNo"] = ds.Tables[0].Rows[0]["UserMobileNo"].ToString();
                    Session["offName"] = ds.Tables[0].Rows[0]["Name"].ToString();
                    Session["OffEmailId"] = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    Session["DistId"] = ddlDistrict.SelectedValue;
                    Session["LocalBody"] = ddlLocalBody.SelectedValue;
                    Session["LocalBodyId"] = ddlLocalBodyId.SelectedValue;
                    Session["ComplaintType"] = ddlComplaints.SelectedValue;
                    Response.Redirect("~/Reports/frmVoterObjsec.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid OTP')", true);
                }
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtOtp.Text = string.Empty;
            ddlDistrict.SelectedIndex = 0;
            ddlComplaints.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlLocalBodyId.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Home");
        }
        protected string SendSMS(string Mobile_Number, string Message)
        {
            Mobile_Number = "91" + Mobile_Number;
            System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
                objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }
                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();
                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();
                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

    }
}