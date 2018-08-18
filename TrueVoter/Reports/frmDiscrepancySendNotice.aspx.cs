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
    public partial class frmDiscrepancySendNotice : System.Web.UI.Page
    {
        CommonCode cc = new CommonCode();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                string d = Request.QueryString[0];
                if (d != "")
                {
                    try
                    {
                        d = cc.DESDecrypt(d);
                        string[] d1 = d.Split('$');
                        hfCanMob.Value = d1[0].ToString();
                        hfLbId.Value = d1[1].ToString();
                        hfWard.Value = d1[2].ToString();
                        hfLbTyp.Value = d1[3].ToString();
                        hfDistId.Value = d1[4].ToString();
                    }
                    catch (Exception) { }
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNotice.Text != "")
                {
                    cmd.Connection = con;
                    cmd.CommandText = "InsertSendNotice";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@candidateMob", hfCanMob.Value);
                    cmd.Parameters.Add("@LBID", hfLbId.Value);
                    cmd.Parameters.Add("@Notice", txtNotice.Text);
                    cmd.Parameters.Add("@CreatedBy", Session["MobileNo"].ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //  cc.SendSMS(hfCanMob.Value,txtNotice.Text);
                    cc.SendSMS("9011177789", txtNotice.Text);
                    cc.SendSMS("9619460202", txtNotice.Text);
                    cc.SendSMS("9403397649", txtNotice.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Notice send Successfully...')", true);
                    txtNotice.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Notice...')", true);
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                string qs = hfDistId.Value + "$" + hfLbId.Value + "$" + hfWard.Value + "$" + hfLbTyp.Value + "$" + hfDistId.Value;
                qs = cc.DESEncrypt(qs);
                Response.Redirect("frmDiscrepancy.aspx?data=" + qs + "");
                //Response.Redirect("frmDiscrepancyDetails.aspx",);
            }
            catch (Exception)
            {

            }
        }
    }
}