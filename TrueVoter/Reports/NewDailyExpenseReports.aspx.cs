using HttpUtils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class NewDailyExpenseReports : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = null;
        CommonCode cc = new CommonCode();
        DataSet ds = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                try
                {
                    cmd.CommandText = "uspGetReportsDetailsCount";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbtnAnsTotalNomicandi.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
                        lbbtnRegisteredCand.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);
                        lbbtnNotRegiCandidate.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
                        lbbtnDailyExpenseFilled.Text = Convert.ToString(ds.Tables[0].Rows[0][3]);
                        lbbtnDailyExpenseNotFilled.Text = Convert.ToString(ds.Tables[0].Rows[0][4]);
                        lbtnSymbolAttotedcadilist.Text = Convert.ToString(ds.Tables[0].Rows[0][5]);
                    }
                    else
                    {

                    }
                }
                catch
                {

                }
            }
        }

        //protected void btnGetDetails_Click(object sender, EventArgs e)
        //{
        //    //string query = "SELECT DISTINCT[usrMobileNumber],EC.[LocalBodyID],[CandidateDistrictID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] AS EC INNER JOIN [tblRegistrationWithSymbolIDNEWSEC] ON EC.[usrMobileNumber]=[RegMobileNo]";
        //    //ds = cc.ExecuteDataset(query);
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //    {
        //    //        string query2 = "SELECT [MobileNo] FROM [TrueVoterDB].[dbo].[tblExpenseAbstractReport] WHERE [MobileNo]='" + Convert.ToString(ds.Tables[0].Rows[i]["usrMobileNumber"]) + "' ";
        //    //        ds1 = cc.ExecuteDataset(query2);
        //    //        if (ds1.Tables[0].Rows.Count > 0)
        //    //        {
        //    //            string query3 = "UPDATE [TrueVoterDB].[dbo].[tblExpenseAbstractReport] SET [LocalBodyID]='" + Convert.ToString(ds.Tables[0].Rows[i]["LocalBodyID"]) + "',[DistID]='" + Convert.ToString(ds.Tables[0].Rows[i]["CandidateDistrictID"]) + "',[ModifiedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "' WHERE [MobileNO]='" + Convert.ToString(ds.Tables[0].Rows[i]["usrMobileNumber"]) + "'";
        //    //            cc.ExecuteNonQuery(query3);
        //    //        }
        //    //        else
        //    //        {
        //    //            string query3 = "INSERT INTO [TrueVoterDB].[dbo].[tblExpenseAbstractReport] ([MobileNo],[LocalBodyID],[DistID],[CreatedDate]) VALUES ('" + Convert.ToString(ds.Tables[0].Rows[i]["usrMobileNumber"]) + "','" + Convert.ToString(ds.Tables[0].Rows[i]["LocalBodyID"]) + "','" + Convert.ToString(ds.Tables[0].Rows[i]["CandidateDistrictID"]) + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "')";
        //    //            cc.ExecuteNonQuery(query3);
        //    //        }
        //    //    }
        //    //}
        //}

        //public void UpdateData()
        //{
        //    string query = "SELECT [MobileNo] FROM [TrueVoterDB].[dbo].[tblExpenseAbstractReport]";
        //    ds.Clear();
        //    ds = cc.ExecuteDataset(query);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            cmd.CommandText = "uspUpdateExpenseAbstractReport";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Connection = con;
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 12).Value = Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]);
        //            cmd.Parameters.Add("@DateTime", SqlDbType.NVarChar, 30).Value = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //}

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    UpdateData();
        //}

        public void ExpenseReports()
        {

        }

        //protected void btnInsertNomini_Click(object sender, EventArgs e)
        //{
        //    string endPoint = @"https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegSchedularDataMP?dateform=2017-04-28&dateto=2017-05-10";
        //    var client = new RestClient(endPoint);
        //    var json = client.MakeRequest();
        //    JObject results = JObject.Parse(json);
        //    foreach (var result in results["DownloadRegSchedularDataMPResult"])
        //    {
        //        cmd = new SqlCommand("uspInsertNominationData", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("@FIRSTNAME", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["FIRSTNAME"]);
        //        cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["MIDDLENAME"]);
        //        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LASTNAME"]);
        //        cmd.Parameters.Add("@RegMobileNo", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["CANDIDATEMOB"]);
        //        cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["DISTRICTID"]);
        //        cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["DISTRICTNAME"]);
        //        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ADDRESS"]).Replace("'", " ");
        //        cmd.Parameters.Add("@formtype", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["FORMTTYPE"]);
        //        cmd.Parameters.Add("@NominationID", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["NOMINATIONID"]);
        //        cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LOCALBODYNAME"]);
        //        cmd.Parameters.Add("@pin", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["PIN"]);
        //        cmd.Parameters.Add("@GroupID", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["GROUPID"]);
        //        cmd.Parameters.Add("@TalukaId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["TALUKAID"]);
        //        cmd.Parameters.Add("@TalukaName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["TALUKANAME"]);
        //        cmd.Parameters.Add("@localbodyid", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LOCALBODYID"]);
        //        cmd.Parameters.Add("@ElectrolId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ELECTROLDIVISIONID"]);
        //        cmd.Parameters.Add("@ElectrolClgId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ELECTROLCLGID"]);
        //        cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["CREATEDDATE"]);
        //        cmd.Parameters.Add("@wardid", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["WARDID"]);
        //        cmd.Parameters.Add("@SU_Status", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["SU_STATUS"]);
        //        cmd.Parameters.Add("@SubChk", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["SUBCHK"]);
        //        cmd.Parameters.Add("@withdrawal_Status", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["WITHDRAWAL_STATUS"]);
        //        cmd.Parameters.Add("@Aff_FinalSubmission", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["AFF_FINALSUBMISSION"]);
        //        cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "2";
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}

        //protected void btnUpdateNomini_Click(object sender, EventArgs e)
        //{
        //    string endPoint = @"https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadRegSchedularDataMP?dateform=2017-04-28&dateto=2017-05-10";
        //    var client = new RestClient(endPoint);
        //    var json = client.MakeRequest();
        //    JObject results = JObject.Parse(json);
        //    foreach (var result in results["DownloadRegSchedularDataMPResult"])
        //    {
        //        cmd = new SqlCommand("uspInsertNominationData", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("@FIRSTNAME", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["FIRSTNAME"]);
        //        cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["MIDDLENAME"]);
        //        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LASTNAME"]);
        //        cmd.Parameters.Add("@RegMobileNo", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["CANDIDATEMOB"]);
        //        cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["DISTRICTID"]);
        //        cmd.Parameters.Add("@DistrictName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["DISTRICTNAME"]);
        //        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ADDRESS"]).Replace("'", " ");
        //        cmd.Parameters.Add("@formtype", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["FORMTTYPE"]);
        //        cmd.Parameters.Add("@NominationID", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["NOMINATIONID"]);
        //        cmd.Parameters.Add("@LocalBodyName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LOCALBODYNAME"]);
        //        cmd.Parameters.Add("@pin", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["PIN"]);
        //        cmd.Parameters.Add("@GroupID", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["GROUPID"]);
        //        cmd.Parameters.Add("@TalukaId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["TALUKAID"]);
        //        cmd.Parameters.Add("@TalukaName", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["TALUKANAME"]);
        //        cmd.Parameters.Add("@localbodyid", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["LOCALBODYID"]);
        //        cmd.Parameters.Add("@ElectrolId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ELECTROLDIVISIONID"]);
        //        cmd.Parameters.Add("@ElectrolClgId", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["ELECTROLCLGID"]);
        //        cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["CREATEDDATE"]);
        //        cmd.Parameters.Add("@wardid", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["WARDID"]);
        //        cmd.Parameters.Add("@SU_Status", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["SU_STATUS"]);
        //        cmd.Parameters.Add("@SubChk", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["SUBCHK"]);
        //        cmd.Parameters.Add("@withdrawal_Status", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["WITHDRAWAL_STATUS"]);
        //        cmd.Parameters.Add("@Aff_FinalSubmission", SqlDbType.NVarChar, 500).Value = Convert.ToString(result["AFF_FINALSUBMISSION"]);
        //        cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "1";
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnCheckDailyExpe_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "6";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnNominiLoginUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "1";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }

        protected void btnRegisteredCand_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "2";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterRegi_Candidate " + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch
            {

            }
        }

        protected void btnNotRegiCandidate_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "3";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterNot_Regi_Candidate " + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDailyExpenseFilled_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "4";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterDailyExp_Filled_Candi " + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDailyExpenseNotFilled_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "5";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterDailyExp_Not_Filled_Candi " + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void gvReports_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvReports.PageIndex = e.NewSelectedIndex;
            gvReports.DataSource = ViewState["data"];
            gvReports.DataBind();
        }

        protected void lbtnSymbolAttotedcadilist_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "7";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterSymbolAllotedCandiList " + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lbtnAnsTotalNomicandi_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("uspGetReportsDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 500).Value = "8";
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["data"] = null;
                    ViewState["data"] = ds.Tables[0];
                    gvReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                    gvReports.DataSource = ds.Tables[0];
                    gvReports.DataBind();
                    string trueVoter = "TrueVoterNomiCandiList" + System.DateTime.Today.ToString("dd-MM-yyyy");
                    if (gvReports.Visible)
                    {
                        //Response.Clear();
                        Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                        // Response.Charset = "";
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        gvReports.RenderControl(hTextWriter);
                        Response.Write(sWriter.ToString());
                        Response.End();
                    }
                    //gvReports.DataSource = ds.Tables[0];
                    //gvReports.DataBind();
                }
                else
                {
                    gvReports.EmptyDataText = "No Data Found";
                    gvReports.DataBind();
                }
            }
            catch
            {

            }
        }
    }
}