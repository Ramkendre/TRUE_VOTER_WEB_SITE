using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace TrueVoter.Admin
{
    public partial class OfficerSms : System.Web.UI.Page
    {
        CommonCode cc = new CommonCode();
        DataSet ds = new DataSet();
        string serviceURL = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadView1();
            }
        }
        public void loadView1()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                string sql = "select [DistrictCode],[DistrictName] FROM [tblDistrictMapping]";
                using (var da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(ds);
                    ddlDistrict.DataSource = ds.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictCode";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Add("--Select--");
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
        }

        protected void btnsendmsg_Click(object sender, EventArgs e)
        {
            try
            {
                string cunt = string.Empty;

                using (var connections = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
                {
                    using (var command = new SqlCommand("SELECT COUNT(*) FROM [tblNewDataCandi_Reg] WHERE LocalBodyID='14008'", connections))
                    {
                        command.Connection = connections;
                        connections.Open();
                        cunt = Convert.ToString(command.ExecuteScalar());
                        connections.Close();
                    }
                }

                string dataString = string.Empty;
                WebClient proxy = new WebClient();

                serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/NominationReportCount?lbId=" + ddlLocalbodyName.SelectedValue.ToString() + "&type="+ ddlLocalbodyType.SelectedValue +"");

                byte[] data = proxy.DownloadData(serviceURL);
                Stream stream = new MemoryStream(data);

                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
                dataString = dataString.Replace("\"", "'");

                JObject results = JObject.Parse(dataString);

                foreach (var result in results["NominationReportCountResult"])
                {
                    //string msg = "Dear Sir, Nomination Report of NWCMC Election: Date 19/9/2017 ,Total Nomination :" + result["nomAll"] + " ,Ro Submitted :" + result["nomRoCheck"] + " ,Rejected :" + result["nomRejected"] + " ,Withdrawl :" + result["nomWithDrawal"] + ",Final :" + result["nomFinal"] + ",True voter installed candidtes :" + cunt + "";
                    //string msg = "Nomination Report of NWCMC Election: Date 19/9/2017, Total Nomination: " + result["nomAll"] + ", Ro Submitted:" + result["nomRoCheck"] + ", Rejected:" + result["nomRejected"] + ", Withdrawal: " + result["nomWithDrawal"] +", Final: " + result["nomFinal"] + ", True voter installed candidtes: " + cunt + "";

                    string msg = "Nomination Report of NWCMC Election: \nDate: "+ System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") +", \nTotal Nominations: " + result["nomAll"] + ",\nRO Submitted: " + result["nomRoCheck"] + ",\nRejected: " + result["nomRejected"] + ",\nWithdrawal: " + result["nomWithDrawal"] + ",\nFinal: " + result["nomFinal"] + ",\nTrue Voter App installed Candidates: " + cunt + "";

                    if (result["nodata"].ToString() == "107" || result["error"].ToString() == "106")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message Can Not send');", true);
                    }
                    else
                    {
                        switch (ddlreport.SelectedValue)
                        {
                            case "1":
                                cc.SendSMS("9011177789", msg);
                                //cc.SendSMS("9403397649", msg);
                                cc.SendSMS("9011177744", msg);
                                break;
                            case "2":

                                string mono = txtMoNo.Text;
                                string[] m = mono.Split(',');
                                foreach (var item in m)
                                {
                                    if (item.Length < 10)
                                    {
                                        //cc.SendSMS(item, msg);
                                    }
                                    else
                                    {
                                        cc.SendSMS(item, msg);
                                    }
                                }

                                //cc.SendSMS("9619460202", msg);
                                //cc.SendSMS("9421506998", msg);
                                //cc.SendSMS("9421506998", msg);
                                //cc.SendSMS("9421506998", msg);
                                break;
                        }

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message send Sucessfully');", true);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void ddlLocalbodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
                {
                    string sql = "select [LBID],[LBName] FROM [tblLocalBody_SEC] where [DistId]='" + ddlDistrict.SelectedValue.ToString() + "' and [LBType]='" + ddlLocalbodyType.SelectedValue.ToString() + "'";
                    using (var da = new SqlDataAdapter(sql, con))
                    {
                        da.Fill(ds);
                        ddlLocalbodyName.DataSource = ds.Tables[0];

                        ddlLocalbodyName.DataTextField = "LBName";
                        ddlLocalbodyName.DataValueField = "LBID";
                        ddlLocalbodyName.DataBind();
                        ddlLocalbodyName.Items.Add("--Select--");
                        ddlLocalbodyName.SelectedIndex = ddlLocalbodyName.Items.Count - 1;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}