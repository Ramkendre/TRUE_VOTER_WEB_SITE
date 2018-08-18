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



namespace TrueVoter.Reports
{
    public partial class DemoReportPage : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                loadView1();

                lblLastsendmsgid.Visible = true;
                cmd = new SqlCommand("select max([NominationId]) from [tblNominationDetailsMsg]", con);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string dataString = string.Empty;
            WebClient proxy = new WebClient();
            if (ddlLocalbodyType.SelectedValue == "5")
            {
                if (ddlreport.SelectedValue.ToString() == "AL")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform="+ txtDateFrom.Text +"&dateto="+ txtDateTo.Text +"");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
                else if (ddlreport.SelectedValue.ToString() == "P")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text + "&dateto=" + txtDateTo.Text + "");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
                else if (ddlreport.SelectedValue.ToString() == "F")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text + "&dateto=" + txtDateTo.Text + "");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
                else if (ddlreport.SelectedValue.ToString() == "WY")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text + "&dateto=" + txtDateTo.Text + "");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
                else if (ddlreport.SelectedValue.ToString() == "R")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text + "&dateto=" + txtDateTo.Text + "");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
                else if (ddlreport.SelectedValue.ToString() == "RO")
                {
                    if (txtDateFrom.Text == "" || txtDateTo.Text == "")
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text + "&dateto=" + txtDateTo.Text + "");
                    }
                    else
                    {
                        serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataMP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "&reportStatus=" + ddlreport.SelectedValue.ToString() + "");
                    }
                }
               
            }
            else if (ddlLocalbodyType.SelectedValue == "2")
            {
                serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataZP?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "");
            }
            else if (ddlLocalbodyType.SelectedValue == "3")
            {
                serviceURL = string.Format("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegDataPS?localbodyid=" + ddlLocalbodyName.SelectedValue.ToString() + "&localbodytype=" + ddlLocalbodyType.SelectedValue.ToString() + "&dateform=" + txtDateFrom.Text.ToString() + "&dateto=" + txtDateTo.Text.ToString() + "");
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
            dt.Columns.Add("NOMINATIONID",(typeof(int)));
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
            gvReport.DataSource = dt;
            gvReport.DataBind();
            lblCount.Visible = true;
            lblCount.Text = dt.Rows.Count.ToString();
            ViewState["dt"] = dt;
            //ClearData();
        }

        //public void ClearData()
        //{
        //    ddlDistrict.SelectedItem.Text = "--Se";
        //    ddlLocalbodyName.SelectedItem.Text = "";
        //    ddlLocalbodyType.SelectedItem.Text = "";
        //    ddlreport.SelectedItem.Text = "";
        //    txtDateFrom.Text = "";
        //    txtDateTo.Text = "";
        //}

        protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReport.PageIndex = e.NewPageIndex;
            DataTable DT = new DataTable();
            DT = (DataTable)ViewState["dt"];
            gvReport.DataSource = DT;
            gvReport.DataBind();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dtValue = new DataTable();
            try
            {
                dtValue = (DataTable)ViewState["dt"];

                string excelFileName = "NominationRegData.xlsx";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtValue, "AcExcel");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + excelFileName + "");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                    }
                }
            }
            catch { }
        }

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