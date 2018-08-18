using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;

namespace TrueVoter.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        LoginBAL objloginBAL = new LoginBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Warn.Visible = false;
            fail.Visible = false;
            if (!Page.IsPostBack)
            {
                txtUserName.Focus();
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
            }
        }
        //public string rbCheck()
        //{
        //    string selectedValues="2";
        //    if (rbtnCandidate.Checked == true)
        //    {
        //        selectedValues = "3";
        //    }
        //    else if (rbtnOfficer.Checked == true)
        //    {
        //        selectedValues = "2";
        //    }
        //    return selectedValues;
        //}


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Select Role')", true);
            }
            else
            {
                objloginBAL.UserName = txtUserName.Text;
                objloginBAL.PassWord = txtPassword.Text;
                objloginBAL.Role = ddlRole.SelectedValue;
                CommonCode commoncode = new CommonCode();
                objloginBAL.PassWord = commoncode.DESEncrypt(objloginBAL.PassWord);

                DataSet dsLoginDetails = objloginBAL.GetLoginDetails(objloginBAL);
                if (dsLoginDetails != null && dsLoginDetails.Tables.Count > 0 && dsLoginDetails.Tables[0].Rows.Count > 0)
                {

                    string userType = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["UserType"]);
                    string mainRole = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["MainRole"]);
                    string SECStatus = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["SECNomiStatus"]);
                    if (userType == "3" && (mainRole == "1" || mainRole == "2") && SECStatus == "1")
                    {
                        Session["RegID"] = dsLoginDetails.Tables[0].Rows[0]["RegId"];
                        Session["MobileNo"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["MobileNo"]);
                        Session["NAME"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["NAME"]);
                        Session["DOB"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["DOB"]);
                        Session["EmailId"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["EmailId"]);
                        Session["UserType"] = userType;
                        Session["MainRole"] = mainRole;
                        Session["RoleName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["RoleName"]);
                        Session["LBID"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LBID"]);
                        Session["District"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["District"]);
                        Session["LocalBodyName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LocalBodyName"]);
                        Response.Redirect("~/Reports/frmHomeUser.aspx");
                    }
                    else
                    {
                        Warn.Visible = true;
                    }

                    if (userType == "2")
                    {
                        Session["RegID"] = dsLoginDetails.Tables[0].Rows[0]["RegId"];
                        Session["MobileNo"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["MobileNo"]);
                        Session["NAME"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["NAME"]);
                        Session["DOB"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["DOB"]);
                        Session["EmailId"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["EmailId"]);
                        Session["UserType"] = userType;
                        Session["MainRole"] = mainRole;
                        Session["RoleName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["RoleName"]);
                        Session["LBID"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LBID"]);
                        Session["District"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["District"]);
                        Session["LocalBodyName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LocalBodyName"]);
                        Response.Redirect("~/Reports/frmHomeUser.aspx");
                    }

                    if (userType == "3" && mainRole == "4")
                    {
                        Session["RegID"] = dsLoginDetails.Tables[0].Rows[0]["RegId"];
                        Session["MobileNo"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["MobileNo"]);
                        Session["NAME"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["NAME"]);
                        Session["DOB"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["DOB"]);
                        Session["EmailId"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["EmailId"]);
                        Session["UserType"] = userType;
                        Session["MainRole"] = mainRole;
                        Session["RoleName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["RoleName"]);
                        Session["LBID"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LBID"]);
                        Session["District"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["District"]);
                        Session["LocalBodyName"] = Convert.ToString(dsLoginDetails.Tables[0].Rows[0]["LocalBodyName"]);
                        Response.Redirect("~/Reports/frmHomeUser.aspx");
                    }
                }
                else
                {
                    fail.Visible = true;
                }
            }
        }

        protected void lnkbtnForgotp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || txtUserName.Text.Length < 10)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter valid 10 Digits Mobile No. in the UserName field!!!')", true);
                }
                else
                {
                    objloginBAL.UserName = txtUserName.Text;
                    DataSet dsPwdDetails = objloginBAL.GetLoginPassword(objloginBAL);
                    CommonCode commoncode = new CommonCode();
                    if (dsPwdDetails.Tables[0].Rows.Count > 0)
                    {
                        string pwd2 = commoncode.DESDecrypt(dsPwdDetails.Tables[0].Rows[0]["Password"].ToString());
                        string msg = "Dear " + dsPwdDetails.Tables[0].Rows[0]["NAME"] + " you installed TRUE VOTER. Your password for login is " + pwd2 + "";
                        commoncode.SMS(txtUserName.Text, msg);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First...')", true);
                    }
                }
            }
            catch
            {

            }
        }

        //protected void btnSendpwd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        objloginBAL.UserName = txtUserName.Text;
        //        DataSet dsPwdDetails = objloginBAL.GetLoginPassword(objloginBAL);
        //        CommonCode commoncode = new CommonCode();
        //        if (dsPwdDetails.Tables[0].Rows.Count > 0)
        //        {
        //            string pwd2 = commoncode.DESDecrypt(dsPwdDetails.Tables[0].Rows[0]["Password"].ToString());
        //            string msg = "Dear " + dsPwdDetails.Tables[0].Rows[0]["NAME"] + " you installed TRUE VOTER. Your password for login is " + pwd2 + "";
        //            commoncode.SMS(txtUserName.Text, msg);
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Register First...')", true);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}


    }
}