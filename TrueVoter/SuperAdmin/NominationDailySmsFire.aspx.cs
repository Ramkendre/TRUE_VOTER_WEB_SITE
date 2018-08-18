using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using TrueVoter.App_Code.BAL;


namespace TrueVoter.SuperAdmin
{
    public partial class NominationDailySmsFire : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection("server=52.172.181.246,1433;Initial Catalog=TrueVoterDB;User id=truevoter;Password=myabhinavit@123;");
        SqlConnection con = new SqlConnection("server=103.10.191.60;Initial Catalog=TrueVoterDB;User id=sa;Password=K17jyjo8/T+6z2v;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        DataSet DS = new DataSet();
        DataTable dt = new DataTable();
        string json = string.Empty;
        string serviceURL = string.Empty;
        CommonCode cc = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadView1();

                //lblLastsendmsgid.Visible = true;
                //cmd = new SqlCommand("select max([NominationId]) from [tblNominationDetailsMsg]", con);
                //con.Open();
                //lblLastsendmsgid.Text = Convert.ToString(cmd.ExecuteScalar());
                //con.Close();
            }
        }

        public void loadView1()
        {
            string sql = "select [DistrictCode],[DistrictName] FROM [tblDistrictMapping]";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            ddlDistrict.DataSource = ds.Tables[0];
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictCode";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("--Select--");
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        }

        protected void ddlLocalbodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select [LBID],[LBName] FROM [tblLocalBody_SEC] where [DistId]='" + ddlDistrict.SelectedValue.ToString() + "' and [LBType]='" + ddlLocalbodyType.SelectedValue.ToString() + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            ddlLocalbodyName.DataSource = ds.Tables[0];

            ddlLocalbodyName.DataTextField = "LBName";
            ddlLocalbodyName.DataValueField = "LBID";
            ddlLocalbodyName.DataBind();
            ddlLocalbodyName.Items.Add("--Select--");
            ddlLocalbodyName.SelectedIndex = ddlLocalbodyName.Items.Count - 1;
        }

        List<NominationBAL> listNom = new List<NominationBAL>();
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string dataString = string.Empty; string sql = string.Empty;
                WebClient proxy = new WebClient();
                if (ddlLocalbodyType.SelectedValue == "5")
                {
                    if (ddlreport.SelectedValue.ToString() == "AL")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                    else if (ddlreport.SelectedValue.ToString() == "P")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                    else if (ddlreport.SelectedValue.ToString() == "F")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                    else if (ddlreport.SelectedValue.ToString() == "WY")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                    else if (ddlreport.SelectedValue.ToString() == "R")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                    else if (ddlreport.SelectedValue.ToString() == "RO")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    }
                }
                else if (ddlLocalbodyType.SelectedValue == "2")
                {
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataZP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=&dateto=");
                }
                else if (ddlLocalbodyType.SelectedValue == "3")
                {
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataPS?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=&dateto=");
                }
                byte[] data = proxy.DownloadData(serviceURL);
                Stream stream = new MemoryStream(data);

                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
                dataString = dataString.Replace("\"", "'");

                JObject results = JObject.Parse(dataString);

                foreach (var result in results["DownloadRegDataMPResult"])
                {
                    sql = "SELECT COUNT(*) FROM [tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + result["CANDIDATEMOB"] + "'";
                    string tvcount = Convert.ToString(cc.ExecuteScalar(sql));
                    if (tvcount == string.Empty || tvcount == "0")
                    {
                        listNom.Add(new NominationBAL()
                            {
                                candidateMob = Convert.ToString(result["CANDIDATEMOB"]),
                                firstName = Convert.ToString(result["FIRSTNAME"]),
                                lastName = Convert.ToString(result["LASTNAME"]),
                                localBodyName = Convert.ToString(result["LOCALBODYNAME"]),
                                nominationId = Convert.ToString(result["NOMINATIONID"])
                            });
                    }
                    else
                    {

                    }
                }
                EMPGRIDDATA.DataSource = listNom.ToList();
                EMPGRIDDATA.DataBind();
               // ViewState["listData"] = listNom;
                lblCount.Visible = true;
                lblCount.Text = listNom.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void TrueVoterInstallMsg(string firstName, string lastName, string candidateMob, string lbname)
        {
            string sql1 = string.Empty; string sql11 = string.Empty;
            string sql111 = string.Empty; string sql = string.Empty;
            string tvcount = string.Empty; string dailyexpcount = string.Empty;

            sql1 = "SELECT COUNT(*) FROM [tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + candidateMob + "'";
            tvcount = Convert.ToString(cc.ExecuteScalar(sql1));
            if (tvcount == string.Empty || tvcount == "0")
            {
                 string sqlcount = "SELECT COUNT([TvReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                string tvcountstr = Convert.ToString(cc.ExecuteScalar(sqlcount));

                if (Convert.ToInt32(tvcountstr) < 4)
                {
                    int counttv = Convert.ToInt32(tvcountstr);
                    int totalcunt = counttv + 1;

                    txtmsg.Text = "Remainder Msg No."+ totalcunt +", U r hereby informed that its mandatory to fill daily election expenses through True Voter app only for NWCMC election. Pl download TRUE VOTER app from Playstore and use it to fill daily expenses. Get printout of Proforma 1 from website www.truevoters.in and submit to RO OFFICE.";

                    sql = "INSERT INTO tblNominationDailySmsCount(FirstName,LastName,CandidateMobile,LocalBodyName,Message,TvReminderCount,DailyExpReminderCount) " +
                         " VALUES(N'" + firstName + "',N'" + lastName + "',N'" + candidateMob + "','" + lbname + "','" + txtmsg.Text.ToString() + "','1','0')";
                    cc.ExecuteNonQuery(sql);

                    cc.SendSMS(candidateMob.ToString(), txtmsg.Text);
                }
                else
                {
                    string sqlFinalcount = "SELECT COUNT([FinalNtMsgReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                    string tvcountFinal = Convert.ToString(cc.ExecuteScalar(sqlFinalcount));
                    int counttv = Convert.ToInt32(tvcountFinal);
                    int totalcunt = counttv + 1;

                    string msg = "Please Note : Submitting daily expenses in any other way or manually will be considered as not in manner as prescribed by State Election Commission, and would make liable for action. Submit it through TRUE Voter app only.";

                    sql11 = "UPDATE tblNominationDailySmsCount SET FinalNoteMsg='" + msg + "',FinalNtMsgReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "'";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob, msg);
                }
            }
            else
            {
                string sqlcount = "SELECT COUNT([TvReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                string tvcountstr = Convert.ToString(cc.ExecuteScalar(sqlcount));
                if (Convert.ToInt32(tvcountstr) < 4)
                {
                    int counttv = Convert.ToInt32(tvcountstr);

                    int totalcunt = counttv + 1;

                    txtmsg.Text = "Remainder Msg No." + totalcunt + ", U r hereby informed that its mandatory to fill daily election expenses through True Voter app only for NWCMC election. Pl download TRUE VOTER app from Playstore and use it to fill daily expenses. Get printout of Proforma 1 from website www.truevoters.in and submit to RO OFFICE.";

                    sql11 = "UPDATE tblNominationDailySmsCount SET Message='" + txtmsg.Text + "',TvReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "' and TvReminderCount IS NOT NULL";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob.ToString(), txtmsg.Text);
                }
                else
                {
                    string sqlFinalcount = "SELECT COUNT([FinalNtMsgReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                    string tvcountFinal = Convert.ToString(cc.ExecuteScalar(sqlFinalcount));
                    int counttv = Convert.ToInt32(tvcountFinal);
                    int totalcunt = counttv + 1;

                    string msg = "Please Note : Submitting daily expenses in any other way or manually will be considered as not in manner as prescribed by State Election Commission, and would make liable for action. Submit it through TRUE Voter app only.";

                    sql11 = "UPDATE tblNominationDailySmsCount SET FinalNoteMsg='" + msg + "',FinalNtMsgReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "'";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob, msg);
                }
            }
        }

        public void DailyExpenseMsg(string firstName, string lastName, string candidateMob, string lbname)
        {
            string sql1 = string.Empty; string sql11 = string.Empty;
            string sql111 = string.Empty; string sql = string.Empty;
            string tvcount = string.Empty; string dailyexpcount = string.Empty;

            string sms = "Dear Candidate " + firstName + " " + lastName + " u have not filled any expenses dated " + System.DateTime.Now.ToString("yyyy-MM-dd") + " through TRUE VOTER app. ignore if already filled or if no expenses.";

            sql1 = "SELECT COUNT(*) FROM [tblDailyExpenses] WHERE [ReffrenceMobile]='" + candidateMob + "' and [InsertDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
            tvcount = Convert.ToString(cc.ExecuteScalar(sql1));
            if (tvcount == string.Empty || tvcount == "0")
            {
                 string sqlcount = "SELECT COUNT([DailyExpReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                string tvcountstr = Convert.ToString(cc.ExecuteScalar(sqlcount));
                if (Convert.ToInt32(tvcountstr) < 4)
                {
                    int counttv = Convert.ToInt32(tvcountstr);
                    int totalcunt = counttv + 1;

                    sql11 = "UPDATE tblNominationDailySmsCount SET DailyExpMessage='" + sms + "',DailyExpReminderCount='"+ totalcunt +"' WHERE CandidateMobile='" + candidateMob + "'";
                    cc.ExecuteNonQuery(sql11);

                    //cc.SendSMS(candidateMob, txtmsg.Text);
                    cc.SendSMS(candidateMob.ToString(), sms);
                }
                else
                {
                    string sqlFinalcount = "SELECT COUNT([FinalNtMsgReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                    string tvcountFinal = Convert.ToString(cc.ExecuteScalar(sqlFinalcount));
                    int counttv = Convert.ToInt32(tvcountFinal);
                    int totalcunt = counttv + 1;

                    string msg = "Please Note : Submitting daily expenses in any other way or manually will be considered as not in manner as prescribed by State Election Commission, and would make liable for action. Submit it through TRUE Voter app only.";

                    sql11 = "UPDATE tblNominationDailySmsCount SET FinalNoteMsg='" + msg + "',FinalNtMsgReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "'";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob, msg);
                }
            }
            else
            {
                string sqlcount = "SELECT COUNT([DailyExpReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                string tvcountstr = Convert.ToString(cc.ExecuteScalar(sqlcount));
                if (Convert.ToInt32(tvcountstr) < 4)
                {
                    int counttv = Convert.ToInt32(tvcountstr);

                    int totalcunt = counttv + 1;

                    sql11 = "UPDATE tblNominationDailySmsCount SET DailyExpMessage='" + sms + "',DailyExpReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "' and DailyExpReminderCount IS NOT NULL";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob.ToString(), sms);
                }
                else
                {
                    string sqlFinalcount = "SELECT COUNT([FinalNtMsgReminderCount]) FROM [tblNominationDailySmsCount] WHERE [CandidateMobile]='" + candidateMob + "'";
                    string tvcountFinal = Convert.ToString(cc.ExecuteScalar(sqlFinalcount));
                    int counttv = Convert.ToInt32(tvcountFinal);
                    int totalcunt = counttv + 1;

                    string msg = "Please Note : Submitting daily expenses in any other way or manually will be considered as not in manner as prescribed by State Election Commission, and would make liable for action. Submit it through TRUE Voter app only.";

                    sql11 = "UPDATE tblNominationDailySmsCount SET FinalNoteMsg='" + msg + "',FinalNtMsgReminderCount='" + totalcunt + "' WHERE CandidateMobile='" + candidateMob + "'";
                    cc.ExecuteNonQuery(sql11);

                    cc.SendSMS(candidateMob, msg);
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("../Admin/Login.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSendSms_Click(object sender, EventArgs e)
        {
            string dataString = string.Empty; string sql = string.Empty;
            WebClient proxy = new WebClient();
            if (ddlLocalbodyType.SelectedValue == "5")
            {
                if (ddlreport.SelectedValue.ToString() == "AL")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }
                else if (ddlreport.SelectedValue.ToString() == "P")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }
                else if (ddlreport.SelectedValue.ToString() == "F")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }
                else if (ddlreport.SelectedValue.ToString() == "WY")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }
                else if (ddlreport.SelectedValue.ToString() == "R")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }
                else if (ddlreport.SelectedValue.ToString() == "RO")
                {
                    //if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    //{
                    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=&dateto=");
                    //}
                    //else
                    //{
                    //    serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    //}
                }

            }
            else if (ddlLocalbodyType.SelectedValue == "2")
            {
                serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataZP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=&dateto=");
            }
            else if (ddlLocalbodyType.SelectedValue == "3")
            {
                serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataPS?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=&dateto=");
            }
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            dataString = dataString.Replace("\"", "'");

            JObject results = JObject.Parse(dataString);

            //dt.Columns.Add("FIRSTNAME");
            //dt.Columns.Add("MIDDLENAME");
            //dt.Columns.Add("LASTNAME");
            //dt.Columns.Add("CANDIDATEMOB");
            //dt.Columns.Add("NOMINATIONID", (typeof(int)));
            //dt.Columns.Add("DISTRICTID");
            //dt.Columns.Add("DISTRICTNAME");
            //dt.Columns.Add("FORMTTYPE");
            //dt.Columns.Add("WARDID");
            //dt.Columns.Add("LOCALBODYNAME");
            //dt.Columns.Add("CREATEDDATE");

            if (ddlLocalbodyType.SelectedValue == "5")
            {
                if (ddlmsgStatus.SelectedValue == "1")
                {
                    foreach (var result in results["DownloadRegDataMPResult"])
                    {
                        TrueVoterInstallMsg(result["FIRSTNAME"].ToString(), result["LASTNAME"].ToString(), result["CANDIDATEMOB"].ToString(), result["LOCALBODYNAME"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message Send Successfully...');", true);
                    }
                    // TrueVoterInstallMsg("GAJANAN", "DESHMUKH", "9011901133", "Nanded Waghala Municipal Corporation");
                }
                else if (ddlmsgStatus.SelectedValue == "2")
                {
                    foreach (var result in results["DownloadRegDataMPResult"])
                    {
                        DailyExpenseMsg(result["FIRSTNAME"].ToString(), result["LASTNAME"].ToString(), result["CANDIDATEMOB"].ToString(), result["LOCALBODYNAME"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message Send Successfully...');", true);
                    }
                    // DailyExpenseMsg("KANTABAI", "MUTHA", "9422173820", "Nanded Waghala Municipal Corporation");
                }
            }
            else if (ddlLocalbodyType.SelectedValue == "2")
            {
                foreach (var result in results["DownloadRegDataZPResult"])
                {
                    dt.Rows.Add(result["FIRSTNAME"], result["MIDDLENAME"], result["LASTNAME"], result["CANDIDATEMOB"], result["NOMINATIONID"], result["DISTRICTID"], result["DISTRICTNAME"], result["FORMTTYPE"], result["WARDID"], result["LOCALBODYNAME"], result["CREATEDDATE"]);
                }
            }
            else if (ddlLocalbodyType.SelectedValue == "3")
            {
                foreach (var result in results["DownloadRegDataPSResult"])
                {
                    dt.Rows.Add(result["FIRSTNAME"], result["MIDDLENAME"], result["LASTNAME"], result["CANDIDATEMOB"], result["NOMINATIONID"], result["DISTRICTID"], result["DISTRICTNAME"], result["FORMTTYPE"], result["WARDID"], result["LOCALBODYNAME"], result["CREATEDDATE"]);
                }
            }
        }

        protected void EMPGRIDDATA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EMPGRIDDATA.PageIndex = e.NewPageIndex;
            //List<NominationBAL> lstData = new List<NominationBAL>();
            listNom = (List<NominationBAL>)ViewState["listData"];
            EMPGRIDDATA.DataSource = listNom.ToList();
            EMPGRIDDATA.DataBind();
        }

        //protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void btnExportExcel_Click(object sender, EventArgs e)
        //{
        //    DataTable dtValue = new DataTable();
        //    try
        //    {
        //        dtValue = (DataTable)ViewState["dt"];

        //        string excelFileName = "NominationRegData.xlsx";

        //        using (XLWorkbook wb = new XLWorkbook())
        //        {
        //            wb.Worksheets.Add(dtValue, "AcExcel");

        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.Charset = "";
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("content-disposition", "attachment;filename=" + excelFileName + "");

        //            using (MemoryStream MyMemoryStream = new MemoryStream())
        //            {
        //                wb.SaveAs(MyMemoryStream);
        //                MyMemoryStream.WriteTo(Response.OutputStream);
        //                Response.Flush();
        //            }
        //        }
        //    }
        //    catch { }
        //}

        //protected void btnsendmsg_Click(object sender, EventArgs e)
        //{
        //    DataTable dtsendmsg = new DataTable();
        //    try
        //    {
        //        //if (txtNomid.Text != "")
        //        //{
        //            dtsendmsg = (DataTable)ViewState["dt"];
        //            IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
        //                                         where (element.Field<int>("NOMINATIONID") >= Convert.ToInt32(txtNomid.Text))
        //                                         select element;
        //            // IEnumerable<DataRow> query1 = query.Where(p => p.Field<int>("NOMINATIONID") >= Convert.ToInt32(txtNomid.Text));
        //            DataTable dt11 = query.CopyToDataTable<DataRow>();
        //            //foreach (var item in results_msg)
        //            //{
        //            //    string msg = "Congratulations to fill Nomination form of ur Local Body Election. U will have to fill daily Election expenses through True Voter app only. Download it from Play store. For support call 7767008611. For Advance Version call Anvesh 9049699944";
        //            //    cc.SendSMS(item.ItemArray.ToString(), msg.ToString());
        //            //}
        //            for (int i = 0; i < dt11.Rows.Count; i++)
        //            {
        //                //string msg = "Congratulations to fill Nomination form of ur Local Body Election. U will have to fill daily Election expenses through True Voter app only. Download it from Play store. For support call 7767008611/12/13/14/15.";
        //                string msg = "Congratulations to fill Nomination form of ur Local Body Election. U will have to fill daily Election expenses through True Voter app only. Download it from Play store. For support Advance version call 7767008611 or 7767008612.";
        //                //cc.SendSMS("7875484151", msg.ToString());

        //                cmd = new SqlCommand("insert into [tblNominationDetailsMsg]([NominationId],[CreatedDate],[MessageBody]) values(" + dt11.Rows[i]["NOMINATIONID"] + ",'" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','"+ msg +"')", con);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Send msg successfully');", true);
        //            }

        //        //}
        //        //else
        //        //{
        //        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('please Enter Nomination Id');", true);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}