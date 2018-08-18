using System;
using System.Collections.Generic;
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
    public partial class Dynamic_Messaging : System.Web.UI.Page
    {
       // SqlConnection con = new SqlConnection("server=52.172.181.246,1433;Initial Catalog=TrueVoterDB;User id=truevoter;Password=myabhinavit@123;");
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

                lblLastsendmsgid.Visible = true;
                cmd = new SqlCommand("select [NominationId] from tblNominationDetailsMsg where MessageBody like '%Congratulations to fill Nomination form%' order by Id desc", con);
                con.Open();
                lblLastsendmsgid.Text = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
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

        protected void gvSECData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvSECData.PageIndex = e.NewPageIndex;
                DataTable DT = new DataTable();
                DT = (DataTable)ViewState["dt"];
                gvSECData.DataSource = DT;
                gvSECData.DataBind();
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
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
               
                string dataString = string.Empty;
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

                // Parse JSON into dynamic object, convenient!
                JObject results = JObject.Parse(dataString);

                dt.Columns.Add("FIRSTNAME");
                dt.Columns.Add("MIDDLENAME");
                dt.Columns.Add("LASTNAME");
                dt.Columns.Add("CANDIDATEMOB");
                dt.Columns.Add("NOMINATIONID", (typeof(int)));
                dt.Columns.Add("DISTRICTID");
                dt.Columns.Add("DISTRICTNAME");
                dt.Columns.Add("FORMTTYPE");
                dt.Columns.Add("WARDID");
                dt.Columns.Add("LOCALBODYNAME");
                dt.Columns.Add("CREATEDDATE");
                if (ddlLocalbodyType.SelectedValue == "5")
                {
                    foreach (var result in results["DownloadRegDataMPResult"])
                    {
                        dt.Rows.Add(result["FIRSTNAME"], result["MIDDLENAME"], result["LASTNAME"], result["CANDIDATEMOB"], result["NOMINATIONID"], result["DISTRICTID"], result["DISTRICTNAME"], result["FORMTTYPE"], result["WARDID"], result["LOCALBODYNAME"], result["CREATEDDATE"]);
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
                gvSECData.DataSource = dt;
                gvSECData.DataBind();
                lblCount.Visible = true;
                lblCount.Text = dt.Rows.Count.ToString();
                ViewState["dt"] = dt;

                //System.Threading.Thread.Sleep(7000);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnsendmsg_Click(object sender, EventArgs e)
        {
            DataTable dtsendmsg = new DataTable();
            try
            {
                //string script = "$(document).ready(function () { $('[id*=btnsendmsg]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                //System.Threading.Thread.Sleep(7000);

                if (txtNomid.Text != "")
                {
                    dtsendmsg = (DataTable)ViewState["dt"];
                    IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                                 where (element.Field<int>("NOMINATIONID") >= Convert.ToInt32(txtNomid.Text))
                                                 select element;
                    // IEnumerable<DataRow> query1 = query.Where(p => p.Field<int>("NOMINATIONID") >= Convert.ToInt32(txtNomid.Text));
                    DataTable dt11 = query.CopyToDataTable<DataRow>();
                    //foreach (var item in results_msg)
                    //{
                    //    string msg = "Congratulations to fill Nomination form of ur Local Body Election. U will have to fill daily Election expenses through True Voter app only. Download it from Play store. For support call 7767008611. For Advance Version call Anvesh 9049699944";
                    //    cc.SendSMS(item.ItemArray.ToString(), msg.ToString());
                    //}
                    for (int i = 0; i < dt11.Rows.Count; i++)
                    {
                        string msg = txtMeassage.Text.ToString();
                        cc.SendSMS(dt11.Rows[i]["CANDIDATEMOB"].ToString(), msg.ToString());

                        cmd = new SqlCommand("insert into tblNominationDetailsMsg([NominationId],[FirstName],[LastName],[CandidateMob],[MessageBody],[Flag],[FormType],[CreatedDate]) values(" + dt11.Rows[i]["NOMINATIONID"] + ",'" + dt11.Rows[i]["FIRSTNAME"] + "','" + dt11.Rows[i]["LASTNAME"] + "','" + dt11.Rows[i]["CANDIDATEMOB"] + "','" + msg.ToString() + "'," + 1 + ",'" + dt11.Rows[i]["FORMTTYPE"] + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    dtsendmsg = (DataTable)ViewState["dt"];
                    IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                                 select element;
                    // IEnumerable<DataRow> query1 = query.Where(p => p.Field<int>("NOMINATIONID") >= Convert.ToInt32(txtNomid.Text));
                    DataTable dt11 = query.CopyToDataTable<DataRow>();
                    //foreach (var item in results_msg)
                    //{
                    //    string msg = "Congratulations to fill Nomination form of ur Local Body Election. U will have to fill daily Election expenses through True Voter app only. Download it from Play store. For support call 7767008611. For Advance Version call Anvesh 9049699944";
                    //    cc.SendSMS(item.ItemArray.ToString(), msg.ToString());
                    //}
                    for (int i = 0; i < dt11.Rows.Count; i++)
                    {
                        string msg = txtMeassage.Text.ToString();
                        cc.SendSMS(dt11.Rows[i]["CANDIDATEMOB"].ToString(), msg.ToString());

                        cmd = new SqlCommand("insert into tblNominationDetailsMsg([NominationId],[FirstName],[LastName],[CandidateMob],[MessageBody],[Flag],[FormType],[CreatedDate]) values(" + dt11.Rows[i]["NOMINATIONID"] + ",'" + dt11.Rows[i]["FIRSTNAME"] + "','" + dt11.Rows[i]["LASTNAME"] + "','" + dt11.Rows[i]["CANDIDATEMOB"] + "','" + msg.ToString() + "'," + 1 + ",'" + dt11.Rows[i]["FORMTTYPE"] + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    lblmsgstatus.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message send Sucessfully....');", true);
                }
            }
            catch (Exception)
            {
                throw;
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
    }
}