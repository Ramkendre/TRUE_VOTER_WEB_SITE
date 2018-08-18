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
    public partial class AllSms : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        string msfstring = string.Empty;

        protected void btnSmsSend_Click(object sender, EventArgs e)
        {
            string Sql = string.Empty;
            try
            {
                msfstring = Request.QueryString["msg"];
                string[] arrayString = msfstring.Split('$');
                if (txtdatepicker.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Select Visit Date and Time !!!');", true);
                }
                else
                {
                    //string SQL = "select [ReffrenceMobile],[PK_Id],[Date],[TotalExpense],[AcceptedEntry] from [TrueVoterDB].[dbo].[tblDailyExpenses] where [PK_Id] IN('" + arrayString[0].ToString() + ")";
                    //da = new SqlDataAdapter(SQL, con);
                    //DataSet dsmyct = new DataSet();
                    //da.Fill(dsmyct);

                    SqlParameter[] par1 = new SqlParameter[5];
                    par1[0] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par1[1] = new SqlParameter("@p2", txtdatepicker.Text);
                    par1[2] = new SqlParameter("@p3", arrayString[0].ToString());
                    par1[3] = new SqlParameter("@p4", "2");
                    DataSet dsmyct = new DataSet();
                    dsmyct = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAllsmsPage", par1);


                    if (arrayString[1].ToString() == "3")  //Deviation
                    {
                        //Sql = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [DeviationMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[DeviationOnVisitedDate]='" + txtdatepicker.Text + "'  WHERE [PK_Id] IN('" + arrayString[0].ToString() + ")";
                        //cmd = new SqlCommand(Sql, con);
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();

                        SqlParameter[] par = new SqlParameter[5];
                        par[0] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par[1] = new SqlParameter("@p2", txtdatepicker.Text);
                        par[2] = new SqlParameter("@p3", arrayString[0].ToString());
                        par[3] = new SqlParameter("@p4", "2");
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAllsmsPage", par);
                    }
                    else if (arrayString[1].ToString() == "1")  //Objection
                    {
                        //Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [ObjectionMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[ObjectionOnVisitedDate]='" + txtdatepicker.Text +"'  WHERE [ServerID] IN('" + arrayString[0].ToString() + ")";
                        //cmd = new SqlCommand(Sql, con);
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();

                        SqlParameter[] par = new SqlParameter[5];
                        par[0] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par[1] = new SqlParameter("@p2", txtdatepicker.Text);
                        par[2] = new SqlParameter("@p3", arrayString[0].ToString());
                        par[3] = new SqlParameter("@p4", "3");
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAllsmsPage", par);
                    }
                    else if (arrayString[1].ToString() == "2")  //Remark
                    {
                        //Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [RemarkMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[RemarkOnVisitedDate]='" + txtdatepicker.Text + "'  WHERE [ServerID] IN('" + arrayString[0].ToString() + ")";
                        //cmd = new SqlCommand(Sql, con);
                        //con.Open();
                        //cmd.ExecuteNonQuery();
                        //con.Close();

                        SqlParameter[] par = new SqlParameter[5];
                        par[0] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par[1] = new SqlParameter("@p2", txtdatepicker.Text);
                        par[2] = new SqlParameter("@p3", arrayString[0].ToString());
                        par[3] = new SqlParameter("@p4", "4");
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAllsmsPage", par);
                    }

                    string msgstr = string.Empty;
                    for (int i = 0; i < dsmyct.Tables[0].Rows.Count; i++)
                    {
                        if (arrayString[1].ToString() == "3")  //Deviation
                        {
                            msgstr = "Dear Candidate, your expense Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " is found below standard rate. Kindly attend RO office on date " + txtdatepicker.Text + " to explain the deviation.";
                        }
                        else if (arrayString[1].ToString() == "1")  //Objection
                        {
                            msgstr = "Dear Candidate, your expense  Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " public has taken objection. Kindly attend RO office on date " + txtdatepicker.Text + " to explain about it.";
                        }
                        else if (arrayString[1].ToString() == "2")  //Remark
                        {
                            msgstr = "Dear Candidate, your expense  Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " EMC/Officer has given a remark. Kindly attend RO office on date " + txtdatepicker.Text + " to explain about it.";
                        }
                        //cc.SendSMS("9403397649", msgstr);
                        cc.SendSMS(Convert.ToString(dsmyct.Tables[0].Rows[i]["ReffrenceMobile"]), msgstr);
                    }
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message Sent Successfully!!!');", true);

                    Response.Redirect("~/Reports/Deviation.aspx");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}