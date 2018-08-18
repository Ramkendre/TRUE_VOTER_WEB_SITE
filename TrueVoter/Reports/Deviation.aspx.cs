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
using System.Drawing;

namespace TrueVoter.Reports
{
    public partial class Deviation : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string serviceURL = string.Empty;
        string dataString = string.Empty;
        WebClient proxy = new WebClient();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        string lbid = string.Empty; string lbtype = string.Empty;
        string[] Arrstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (!IsPostBack)
                {
                    string str = Convert.ToString((Request.QueryString["val"]));

                    // RequestID.Value= (Request.QueryString["var"] == null ? "" : Request.QueryString["var"].ToString());

                    if (str == null || str == "")
                    {
                        BindDistrict();
                    }
                    else
                    {
                        Arrstr = str.Split('$');
                        ddlDistrict.SelectedItem.Text = Convert.ToString(Arrstr[1]);
                        ddllocalbodyName.SelectedItem.Text = Convert.ToString(Arrstr[2]);
                        txtDate.Text = Convert.ToString(Arrstr[3]);
                        txtWardNo.Text = Convert.ToString(Arrstr[4]);
                        ddlDistrict.SelectedValue = Arrstr[5];
                        //ViewState["lbid"] = Arrstr[6];
                        //ViewState["lbtype"] = Arrstr[7];
                        Session.Remove("lbid");
                        Session.Remove("lbtype");
                        Session.Remove("reporttype");
                        Session["lbid"] = Arrstr[6];
                        Session["lbtype"] = Arrstr[7];
                        Session["reporttype"] = Arrstr[8];
                        ddlreporttype.SelectedItem.Text = Convert.ToString(Arrstr[8]);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void BindDistrict()
        {
            cmd.CommandText = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = ds.Tables[0];
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictCode";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                ddlDistrict.SelectedIndex = 0;
            }
            else
            {

            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistrict.SelectedValue + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddllocalbodyName.DataSource = ds.Tables[0];
                    ddllocalbodyName.DataTextField = "ElectionName";
                    ddllocalbodyName.DataValueField = "ElectionId";
                    ddllocalbodyName.DataBind();
                    ddllocalbodyName.Items.Insert(0, new ListItem("Select", "0"));
                    ddllocalbodyName.SelectedIndex = 0;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
                lbtype = Convert.ToString(ddlreporttype.SelectedValue);

                switch (lbid)
                {
                    case "0":
                        lbid = Session["lbid"].ToString();
                        lbtype = Session["lbtype"].ToString();
                        break;
                    default:
                        lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
                        lbtype = Convert.ToString(ddlreporttype.SelectedValue);
                        break;
                }

                DateTime datetime = Convert.ToDateTime(txtDate.Text);
                if (txtDate.Text != "" && lbtype != "" && txtWardNo.Text != "" && lbid != "")
                {
                    if (lbtype == "1") // Deviation and objection combine
                    {
                        serviceURL = string.Format("http://www.truevoters.in:8100/ExpenseManagement.svc/DownloadDailyExpensesWardWise?insertDate=" + datetime.ToString("yyyy-MM-dd") + "&wardNo=" + txtWardNo.Text + "&localBodyId=" + lbid + "&MaxId=0&reType=" + lbtype + "");
                        GetDeviation();
                    }
                    else if (lbtype == "2") // General Expense
                    {
                        serviceURL = string.Format("http://www.truevoters.in:8100/ExpenseManagement.svc/DownloadDailyExpensesWardWise?insertDate=" + datetime.ToString("yyyy-MM-dd") + "&wardNo=" + txtWardNo.Text + "&localBodyId=" + lbid + "&MaxId=0&reType=" + lbtype + "");
                        GetDeviation();
                    }
                    else    //Deviation on No Issue
                    {
                        serviceURL = string.Format("http://www.truevoters.in:8100/ExpenseManagement.svc/DownloadDailyExpensesWardWise?insertDate=" + datetime.ToString("yyyy-MM-dd") + "&wardNo=" + txtWardNo.Text + "&localBodyId=" + lbid + "&MaxId=0&reType=" + lbtype + "");
                        GetDeviation();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('All Fields are Mandatory');", true);
                }


            }
            catch (Exception ex)
            {

            }
        }

        public void GetDeviation()
        {
            lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
            lbtype = Convert.ToString(ddlreporttype.SelectedValue);

            switch (lbid)
            {
                case "0":
                    lbid = Session["lbid"].ToString();
                    lbtype = Session["lbtype"].ToString();
                    break;
                default:
                    lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
                    lbtype = Convert.ToString(ddlreporttype.SelectedValue);
                    break;
            }

            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);
            string partname = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            dataString = dataString.Replace("\"", "'");

            // Parse JSON into dynamic object, convenient!
            JObject results = JObject.Parse(dataString);

            dt.Columns.Add("UsrName", (typeof(string)));
            dt.Columns.Add("CandidateDistrict", (typeof(string)));
            dt.Columns.Add("LocalBodyNameID", (typeof(string)));
            dt.Columns.Add("WardNo", (typeof(string)));
            dt.Columns.Add("PartyName", (typeof(string)));
            dt.Columns.Add("ExpenseType", (typeof(string)));
            dt.Columns.Add("SubExpenseType", (typeof(string)));
            dt.Columns.Add("StandardRate", (typeof(string)));
            dt.Columns.Add("Qty_Size_Area", (typeof(string)));
            dt.Columns.Add("Rate", (typeof(string)));
            dt.Columns.Add("TotalExpense", (typeof(string)));
            dt.Columns.Add("ChequeNo", (typeof(string)));
            dt.Columns.Add("ChequeDate", (typeof(string)));
            dt.Columns.Add("Date", (typeof(string)));
            dt.Columns.Add("FirmName", (typeof(string)));
            dt.Columns.Add("InsertDate", (typeof(string)));
            dt.Columns.Add("SourceOfExpense", (typeof(string)));
            dt.Columns.Add("PaidAmount", (typeof(string)));
            dt.Columns.Add("PaymentMode", (typeof(string)));
            dt.Columns.Add("PaymentType", (typeof(string)));
            dt.Columns.Add("PK_Id", (typeof(int)));
            dt.Columns.Add("CountNo", (typeof(string)));
            dt.Columns.Add("Deviation", (typeof(decimal)));
            dt.Columns.Add("ExtaExpId", (typeof(string)));
            dt.Columns.Add("ObjectionMsg", (typeof(string)));
            dt.Columns.Add("ObjectionOnVisitedDate", (typeof(string)));
            dt.Columns.Add("DeviationMsg", (typeof(string)));
            dt.Columns.Add("DeviationOnVisitedDate", (typeof(string)));
            dt.Columns.Add("RemarkMsg", (typeof(string)));
            dt.Columns.Add("RemarkOnVisitedDate", (typeof(string)));
            dt.Columns.Add("ReffrenceMobile", (typeof(string)));

            foreach (var result in results["DownloadDailyExpensesWardWiseResult"])
            {
                cmd.Connection = con;
                //SELECT [SendMsgDate] FROM [TrueVoterDB].[dbo].[tblGeneralObjection] WHERE [ServerID]=
                if (lbtype == "1")
                {
                    if (result["NoData"].ToString() == "105")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No Deviation Entries Found !!!');", true);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT [DeviationMsg],[DeviationOnVisitedDate],[AcceptedEntry] as ExtaExpId,ReffrenceMobile," +
                                      " (Select [ElectionName] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE [ElectionId]=" + result["LocalBodyNameID"] + ") as LocalBodyName," +
                                    " (SELECT [ExpenseType] FROM [TrueVoterDB].[dbo].[tblExpenseType]  WHERE [EID]=" + result["ExpenseType"] + ") as ExpenseHead," +
                                    " (SELECT [SubExpenseType] FROM [TrueVoterDB].[dbo].[tblSubExpenseType] WHERE SEID=" + result["SubExpenseType"] + ") as SubExpenseType," +
                                    " (SELECT [DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping] WHERE [DistrictCode]=" + result["CandidateDistrict"] + ") as DistrictName " +
                                    " FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [PK_Id]=" + result["PK_Id"] + "";

                        cmd.CommandType = CommandType.Text;
                        da.SelectCommand = cmd;
                        // DataSet Ds = new DataSet();
                        da.Fill(ds);

                        if (result["PartyName"].ToString() == "00")
                        {
                            partname = "Apaksh";
                        }
                        else
                        {
                            partname = result["PartyName"].ToString();
                        }
                        dt.Rows.Add(result["UsrName"], Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]), Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]), result["WardNo"], partname, Convert.ToString(ds.Tables[0].Rows[0]["ExpenseHead"]), Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseType"]), Convert.ToString(result["StandardRate"]),   //partname
                            result["Qty_Size_Area"], result["Rate"], Convert.ToString(result["TotalExpense"]), result["ChequeNo"], result["ChequeDate"], result["Date"], result["FirmName"], result["InsertDate"], result["SourceOfExpense"],
                            result["PaidAmount"], result["PaymentMode"], result["PaymentType"], result["PK_Id"], result["CountNo"], Convert.ToDecimal(result["Deviation"]), Convert.ToString(ds.Tables[0].Rows[0]["ExtaExpId"]), Convert.ToString(null), Convert.ToString(null),
                            Convert.ToString(ds.Tables[0].Rows[0]["DeviationMsg"]), Convert.ToString(ds.Tables[0].Rows[0]["DeviationOnVisitedDate"]), Convert.ToString(null), Convert.ToString(null), Convert.ToString(ds.Tables[0].Rows[0]["ReffrenceMobile"]));
                        ds.Clear();
                    }
                }
                else if (lbtype == "2")
                {
                    if (result["NoData"].ToString() == "105")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No Objection Entries Found !!!');", true);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT [ExtaExpId],[ObjectionMsg],[ObjectionOnVisitedDate],[DeviationMsg],[DeviationOnVisitedDate],[RemarkMsg],[RemarkOnVisitedDate]," +
                                      " (Select [ElectionName] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE [ElectionId]=" + result["LocalBodyNameID"] + ") as LocalBodyName," +
                                      " (Select [ReffrenceMobile] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [PK_Id]=" + result["PK_Id"] + ") as ReffrenceMobile," +
                                    " (SELECT [ExpenseType] FROM [TrueVoterDB].[dbo].[tblExpenseType]  WHERE [EID]=" + result["ExpenseType"] + ") as ExpenseHead," +
                                    " (SELECT [SubExpenseType] FROM [TrueVoterDB].[dbo].[tblSubExpenseType] WHERE SEID=" + result["SubExpenseType"] + ") as SubExpenseType," +
                                    " (SELECT [DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping] WHERE [DistrictCode]=" + result["CandidateDistrict"] + ") as DistrictName " +
                                    " FROM [TrueVoterDB].[dbo].[tblGeneralObjection] WHERE [ServerID]=" + result["PK_Id"] + "";

                        cmd.CommandType = CommandType.Text;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        //if (ds.Tables[0].Rows.Count == null)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No Objection On this Entry !!!');", true);
                        //}
                        //else
                        //{
                        if (result["PartyName"].ToString() == "00")
                        {
                            partname = "Apaksh";
                        }
                        else
                        {
                            partname = result["PartyName"].ToString();
                        }
                        dt.Rows.Add(result["UsrName"], Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]), Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]), result["WardNo"], partname, Convert.ToString(ds.Tables[0].Rows[0]["ExpenseHead"]), Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseType"]), result["StandardRate"],   //partname
                            result["Qty_Size_Area"], result["Rate"], result["TotalExpense"], result["ChequeNo"], result["ChequeDate"], result["Date"], result["FirmName"], result["InsertDate"], result["SourceOfExpense"],
                            result["PaidAmount"], result["PaymentMode"], result["PaymentType"], result["PK_Id"], result["CountNo"], result["Deviation"], Convert.ToString(ds.Tables[0].Rows[0]["ExtaExpId"]), Convert.ToString(ds.Tables[0].Rows[0]["ObjectionMsg"]), Convert.ToString(ds.Tables[0].Rows[0]["ObjectionOnVisitedDate"]),
                            Convert.ToString(ds.Tables[0].Rows[0]["DeviationMsg"]), Convert.ToString(ds.Tables[0].Rows[0]["DeviationOnVisitedDate"]), Convert.ToString(ds.Tables[0].Rows[0]["RemarkMsg"]), Convert.ToString(ds.Tables[0].Rows[0]["RemarkOnVisitedDate"]), Convert.ToString(ds.Tables[0].Rows[0]["ReffrenceMobile"]));
                        ds.Clear();
                        //}
                    }
                }
                else
                {
                    if (result["NoData"].ToString() == "105")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No Deviation Entries Found !!!');", true);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT [DeviationMsg],[DeviationOnVisitedDate],[AcceptedEntry] as ExtaExpId," +
                                      " (Select [ElectionName] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE [ElectionId]=" + result["LocalBodyNameID"] + ") as LocalBodyName," +
                                      " (Select [ReffrenceMobile] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [PK_Id]=" + result["PK_Id"] + ") as ReffrenceMobile," +
                                    " (SELECT [ExpenseType] FROM [TrueVoterDB].[dbo].[tblExpenseType]  WHERE [EID]=" + result["ExpenseType"] + ") as ExpenseHead," +
                                    " (SELECT [SubExpenseType] FROM [TrueVoterDB].[dbo].[tblSubExpenseType] WHERE SEID=" + result["SubExpenseType"] + ") as SubExpenseType," +
                                    " (SELECT [DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping] WHERE [DistrictCode]=" + result["CandidateDistrict"] + ") as DistrictName " +
                                    " FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [PK_Id]=" + result["PK_Id"] + "";

                        cmd.CommandType = CommandType.Text;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        
                        if (result["PartyName"].ToString() == "00")
                        {
                            partname = "Apaksh";
                        }
                        else
                        {
                            partname = result["PartyName"].ToString();
                        }
                        dt.Rows.Add(result["UsrName"], Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]), Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]), result["WardNo"], partname, Convert.ToString(ds.Tables[0].Rows[0]["ExpenseHead"]), Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseType"]), result["StandardRate"],   //partname
                            result["Qty_Size_Area"], result["Rate"], result["TotalExpense"], result["ChequeNo"], result["ChequeDate"], result["Date"], result["FirmName"], result["InsertDate"], result["SourceOfExpense"],
                            result["PaidAmount"], result["PaymentMode"], result["PaymentType"], result["PK_Id"], result["CountNo"], result["Deviation"], Convert.ToString(ds.Tables[0].Rows[0]["ExtaExpId"]), null, null,
                            Convert.ToString(ds.Tables[0].Rows[0]["DeviationMsg"]), Convert.ToString(ds.Tables[0].Rows[0]["DeviationOnVisitedDate"]), null, null, Convert.ToString(ds.Tables[0].Rows[0]["ReffrenceMobile"]));
                        ds.Clear();
                    }
                }
            }
            //DataSet DsGv = new DataSet("table");
            //DsGv.Tables.Add(dt);
            GvObjection.Visible = false;
            GvDeviation.Visible = true;
            GvDeviation.DataSource = dt;
            GvDeviation.DataBind();
            ViewState["dt"] = dt;

            btnaccepted.Visible = true;
            btnsendmsg.Visible = true;
        }

        public void GetObjection()
        {
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);

            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            dataString = dataString.Replace("\"", "'");

            // Parse JSON into dynamic object, convenient!
            JObject results = JObject.Parse(dataString);

            dt.Columns.Add("userName");
            dt.Columns.Add("objID");
            dt.Columns.Add("wardNo");
            dt.Columns.Add("objectionDetails");
            dt.Columns.Add("userMobileNo");

            dt.Columns.Add("serverID");
            dt.Columns.Add("SubExpenseType");
            dt.Columns.Add("StandardRate");
            dt.Columns.Add("Qty_Size_Area");
            dt.Columns.Add("Rate");
            dt.Columns.Add("TotalExpense");
            dt.Columns.Add("ChequeNo");
            dt.Columns.Add("ChequeDate");
            dt.Columns.Add("Date");
            dt.Columns.Add("FirmName");
            dt.Columns.Add("InsertDate");
            dt.Columns.Add("SourceOfExpense");
            dt.Columns.Add("PaidAmount");
            dt.Columns.Add("PaymentMode");
            dt.Columns.Add("PaymentType");
            dt.Columns.Add("PK_Id", (typeof(int)));
            dt.Columns.Add("CountNo");
            dt.Columns.Add("Deviation");

            foreach (var result in results["DownloadGenObjExpenIdWiseResult"])
            {
                dt.Rows.Add(result["userName"], result["objID"], result["wardNo"], result["objectionDetails"],
                    result["serverID"], result["SubExpenseType"], result["StandardRate"], result["userMobileNo"],
                    result["Qty_Size_Area"], result["Rate"], result["TotalExpense"], result["ChequeNo"], result["ChequeDate"],
                    result["Date"], result["FirmName"], result["InsertDate"], result["SourceOfExpense"], result["PaidAmount"],
                    result["PaymentMode"], result["PaymentType"], result["PK_Id"], result["CountNo"], result["Deviation"]);
            }
            GvDeviation.Visible = false;
            GvObjection.Visible = true;
            GvObjection.DataSource = dt;
            GvDeviation.DataBind();
            ViewState["dt"] = dt;
        }

        //protected void OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dtsendmsg = new DataTable();
        //    try
        //    {
        //        dtsendmsg = (DataTable)ViewState["dt"];
        //        IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
        //                                     where (element.Field<int>("PK_Id") >= Convert.ToInt32(GvDeviation.SelectedRow.Cells[7].Text))
        //                                     select element;
        //        DataTable dt11 = query.CopyToDataTable<DataRow>();

        //        Application["dt11"] = dt11;

        //        Response.Redirect("~/Reports/DeviationDetails.aspx");
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void GvDeviation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvDeviation.PageIndex = e.NewPageIndex;
                DataTable DT = new DataTable();
                DT = (DataTable)ViewState["dt"];
                GvDeviation.DataSource = DT;
                GvDeviation.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvDeviation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtsendmsg = new DataTable();
            int vr = Convert.ToInt32(GvDeviation.SelectedRow.Cells[8].Text);
            try
            {
                dtsendmsg = (DataTable)ViewState["dt"];
                IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                             where (element.Field<int>("PK_Id") == vr)
                                             select element;
                DataTable dt11 = query.CopyToDataTable<DataRow>();

                Application["dt11"] = dt11;



                Response.Redirect("~/Reports/DeviationDetails.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvDeviation_SelectedIndexChanged1(object sender, EventArgs e)
        {

            lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
            lbtype = Convert.ToString(ddlreporttype.SelectedValue);

            switch (lbid)
            {
                case "0":
                    lbid = Session["lbid"].ToString();
                    lbtype = Session["lbtype"].ToString();
                    break;
                default:
                    lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
                    lbtype = Convert.ToString(ddlreporttype.SelectedValue);
                    break;
            }

            DataTable dtsendmsg = new DataTable();
            double vr = Convert.ToDouble(GvDeviation.SelectedRow.Cells[9].Text);
            try
            {
                dtsendmsg = (DataTable)ViewState["dt"];
                IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                             where (element.Field<int>("PK_Id") == Convert.ToInt32(vr))
                                             select element;
                DataTable dt11 = query.CopyToDataTable<DataRow>();

                Application["dt11"] = dt11;

                // Response.Redirect("~/Reports/DeviationDetails.aspx");
                Response.Redirect("~/Reports/DeviationDetails.aspx?var=" + vr + "$" + ddlDistrict.SelectedItem.Text + "$" + ddllocalbodyName.SelectedItem.Text + "$" + txtDate.Text + "$" + txtWardNo.Text + "$" + ddlDistrict.SelectedValue + "$" + lbid + "$" + lbtype + "$" + ddlreporttype.SelectedItem.Text + "");
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvObjection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvObjection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvDeviation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //DataTable dtsendmsg = new DataTable();
            //int vr = Convert.ToInt32(GvDeviation.SelectedRow.Cells[7].Text);
            int vr = Convert.ToInt32(((Label)GvDeviation.Rows[e.RowIndex].FindControl("PK_Id")).Text);
            try
            {
                //dtsendmsg = (DataTable)ViewState["dt"];
                //IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                //                             where (element.Field<int>("PK_Id") == vr)
                //                             select element;
                //DataTable dt11 = query.CopyToDataTable<DataRow>();

                //Application["dt11"] = dt11;

                Response.Redirect("~/Reports/ObjectionDetails.aspx?vr=" + vr + "");
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvDeviation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //protected void lnkObjection_Command(object sender, CommandEventArgs e)
        //{
        //    try
        //    {
        //        int vr = Convert.ToInt32(e.CommandArgument);
        //        // Response.Redirect("~/Reports/ObjectionDetails.aspx?var=" + vr + "$" + ddlDistrict.SelectedItem.Text + "$" + ddllocalbodyName.SelectedItem.Text + "$" + txtDate.Text + "$" + txtWardNo.Text + "");
        //        Response.Redirect("~/Reports/ObjectionDetails.aspx?var=" + vr + "");//$" + ddlDistrict.SelectedItem.Text + "$" + ddllocalbodyName.SelectedItem.Text + "$" + txtDate.Text + "$" + txtWardNo.Text + "$" + ddlDistrict.SelectedValue + "$" + ddllocalbodyName.SelectedValue + "$" + ddlreporttype.SelectedValue + "$" + ddlreporttype.SelectedItem.Text + "");
        //    }
        //    catch
        //    {

        //    }
        //}

        string GvSno = string.Empty; string Sql = string.Empty; string msgstr = string.Empty;
        protected void btnaccepted_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GvDeviation.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)GvDeviation.Rows[i].Cells[0].FindControl("ChkDeviation");

                    if (chk != null)
                    {
                        if (chk.Checked == true)
                        {
                            GvSno += Convert.ToString(GvDeviation.DataKeys[i].Value) + "','";
                        }
                    }
                    chk.Checked = false;
                }

                if (GvSno == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                }
                else
                {
                    if (GvSno != "")
                    {
                        GvSno = GvSno.Substring(0, GvSno.Length - 2);
                    }

                    if (ddlreporttype.SelectedValue == "1")  //Deviation
                    {
                        Sql = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [AcceptedEntry]='0' WHERE [PK_Id] IN('" + GvSno + ")";
                        cmd = new SqlCommand(Sql, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (ddlreporttype.SelectedValue == "2")  //Objection
                    {
                        Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [ExtaExpId]='0' WHERE [ServerID] IN('" + GvSno + ")";
                        cmd = new SqlCommand(Sql, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (ddlreporttype.SelectedValue == "3")  //Remark
                    {
                        Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [ExtaExpId]='0' WHERE [ServerID] IN('" + GvSno + ")";
                        cmd = new SqlCommand(Sql, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    GvBind(GvSno);

                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Entries Accepted Successfully !!!');", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        DataTable dt11; DataTable dtt; DataTable dtnew;
        DataTable dtnew1;
        public void GvBind(string GvSno)
        {
            string gvsno = GvSno.Replace("'"," ");
            string[] Sno = gvsno.Split(',');
            int count = Convert.ToInt32(Sno.Length);
            try
            {
                DataTable dtsendmsg = (DataTable)ViewState["dt"];
                IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                             where (element.Field<int>("PK_Id").ToString().Contains(Convert.ToString(element.Field<int>("PK_Id"))))                                   //.Contains(Convert.ToString(792732)))
                                             select element;
                dt11 = query.CopyToDataTable<DataRow>();

                //IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                //                             where (element.Field<int>("PK_Id") >= Convert.ToInt32(Sno[0]) && element.Field<int>("PK_Id") <= Convert.ToInt32(Sno[count - 1]))
                //                             select element;
                //dt11 = query.CopyToDataTable<DataRow>();

                string SQLSub = "SELECT [ObjectionMsg],[ObjectionOnVisitedDate],[RemarkMsg],[RemarkOnVisitedDate] FROM [TrueVoterDB].[dbo].[tblGeneralObjection] WHERE [ServerID] IN('" + GvSno + ")";
                SqlCommand cmd1 = new SqlCommand(SQLSub, con);
                da.SelectCommand = cmd1;
                DataSet Ds = new DataSet();
                da.Fill(Ds);
                dtnew = Ds.Tables[0];

                string SQLSub1 = "SELECT [DeviationMsg],DeviationOnVisitedDate,AcceptedEntry as ExtaExpId FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [PK_Id] IN('" + GvSno + ")";
                cmd = new SqlCommand(SQLSub1, con);
                da.SelectCommand = cmd;
                DataSet Ds1 = new DataSet();
                da.Fill(Ds1);
                dtnew1 = Ds1.Tables[0];

                dtt = new DataTable();
                dtt.Columns.Add("UsrName");
                dtt.Columns.Add("CandidateDistrict");
                dtt.Columns.Add("LocalBodyNameID");
                dtt.Columns.Add("WardNo");
                dtt.Columns.Add("PartyName");
                dtt.Columns.Add("ExpenseType");
                dtt.Columns.Add("SubExpenseType");
                dtt.Columns.Add("StandardRate");
                dtt.Columns.Add("Qty_Size_Area");
                dtt.Columns.Add("Rate");
                dtt.Columns.Add("TotalExpense");
                dtt.Columns.Add("ChequeNo");
                dtt.Columns.Add("ChequeDate");
                dtt.Columns.Add("Date");
                dtt.Columns.Add("FirmName");
                dtt.Columns.Add("InsertDate");
                dtt.Columns.Add("SourceOfExpense");
                dtt.Columns.Add("PaidAmount");
                dtt.Columns.Add("PaymentMode");
                dtt.Columns.Add("PaymentType");
                dtt.Columns.Add("PK_Id", (typeof(int)));
                dtt.Columns.Add("CountNo");
                dtt.Columns.Add("Deviation");
                dtt.Columns.Add("ExtaExpId");
                dtt.Columns.Add("ObjectionMsg");
                dtt.Columns.Add("ObjectionOnVisitedDate");
                dtt.Columns.Add("DeviationMsg");
                dtt.Columns.Add("DeviationOnVisitedDate");
                dtt.Columns.Add("RemarkMsg");
                dtt.Columns.Add("RemarkOnVisitedDate");
                dtt.Columns.Add("ReffrenceMobile");

                for (int rw = 0; rw < dt11.Rows.Count; rw++)
                {
                    dtt.Rows.Add(Convert.ToString(dt11.Rows[rw]["UsrName"]), Convert.ToString(dt11.Rows[rw]["CandidateDistrict"]), Convert.ToString(dt11.Rows[rw]["LocalBodyNameID"]), Convert.ToString(dt11.Rows[rw]["WardNo"]), Convert.ToString(dt11.Rows[rw]["PartyName"]),
                   Convert.ToString(dt11.Rows[rw]["ExpenseType"]), Convert.ToString(dt11.Rows[rw]["SubExpenseType"]), Convert.ToString(dt11.Rows[rw]["StandardRate"]),
                     Convert.ToString(dt11.Rows[rw]["Qty_Size_Area"]), Convert.ToString(dt11.Rows[rw]["Rate"]), Convert.ToString(dt11.Rows[rw]["TotalExpense"]), Convert.ToString(dt11.Rows[rw]["ChequeNo"]), Convert.ToString(dt11.Rows[rw]["ChequeDate"]), Convert.ToString(dt11.Rows[rw]["Date"]),
                     Convert.ToString(dt11.Rows[rw]["FirmName"]), Convert.ToString(dt11.Rows[rw]["InsertDate"]), Convert.ToString(dt11.Rows[rw]["SourceOfExpense"]), Convert.ToString(dt11.Rows[rw]["PaidAmount"]), Convert.ToString(dt11.Rows[rw]["PaymentMode"]), Convert.ToString(dt11.Rows[rw]["PaymentType"]),
                     Convert.ToString(dt11.Rows[rw]["PK_Id"]), Convert.ToString(dt11.Rows[rw]["CountNo"]), Convert.ToString(dt11.Rows[rw]["Deviation"]),
                     Convert.ToString(dtnew1.Rows[rw]["ExtaExpId"]), Convert.ToString(dtnew.Rows[rw]["ObjectionMsg"]),
                     Convert.ToString(dtnew.Rows[rw]["ObjectionOnVisitedDate"]), Convert.ToString(dtnew1.Rows[rw]["DeviationMsg"]),
                     Convert.ToString(dtnew1.Rows[rw]["DeviationOnVisitedDate"]), Convert.ToString(dtnew.Rows[rw]["RemarkMsg"]),
                     Convert.ToString(dtnew.Rows[rw]["RemarkOnVisitedDate"]), Convert.ToString(dt11.Rows[rw]["ReffrenceMobile"]));
                }
               

                GvDeviation.DataSource = dtt;
                GvDeviation.DataBind();
            }
            catch (Exception ex)
            {
                for (int rw = 0; rw < dt11.Rows.Count; rw++)
                {
                    dtt.Rows.Add(dt11.Rows[rw]["UsrName"], Convert.ToString(dt11.Rows[rw]["CandidateDistrict"]), Convert.ToString(dt11.Rows[rw]["LocalBodyNameID"]), dt11.Rows[rw]["WardNo"], dt11.Rows[rw]["PartyName"],
                       Convert.ToString(dt11.Rows[rw]["ExpenseType"]), Convert.ToString(dt11.Rows[rw]["SubExpenseType"]), dt11.Rows[rw]["StandardRate"],
                         dt11.Rows[rw]["Qty_Size_Area"], dt11.Rows[rw]["Rate"], dt11.Rows[rw]["TotalExpense"], dt11.Rows[rw]["ChequeNo"], dt11.Rows[rw]["ChequeDate"], dt11.Rows[rw]["Date"],
                         dt11.Rows[rw]["FirmName"], dt11.Rows[rw]["InsertDate"], dt11.Rows[rw]["SourceOfExpense"], dt11.Rows[rw]["PaidAmount"], dt11.Rows[rw]["PaymentMode"], dt11.Rows[rw]["PaymentType"],
                         dt11.Rows[rw]["PK_Id"], dt11.Rows[rw]["CountNo"], dt11.Rows[rw]["Deviation"],
                         Convert.ToString(dtnew1.Rows[rw]["ExtaExpId"]), Convert.ToString(1),
                         Convert.ToString(null), Convert.ToString(dtnew1.Rows[rw]["DeviationMsg"]),
                         Convert.ToString(null), Convert.ToString(null),
                         Convert.ToString(null), Convert.ToString(dt11.Rows[rw]["ReffrenceMobile"]));
                }

                GvDeviation.DataSource = dtt;
                GvDeviation.DataBind();
            }
        }

        protected void btnsendmsg_Click(object sender, EventArgs e)
        {
            lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
            lbtype = Convert.ToString(ddlreporttype.SelectedValue);

            switch (lbid)
            {
                case "0":
                    lbid = Session["lbid"].ToString();
                    lbtype = Session["lbtype"].ToString();
                    break;
                default:
                    lbid = Convert.ToString(ddllocalbodyName.SelectedValue);
                    lbtype = Convert.ToString(ddlreporttype.SelectedValue);
                    break;
            }

            try
            {
                for (int i = 0; i < GvDeviation.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)GvDeviation.Rows[i].Cells[0].FindControl("ChkDeviation");

                    if (chk != null)
                    {
                        if (chk.Checked == true)
                        {
                            GvSno += Convert.ToString(GvDeviation.DataKeys[i].Value) + "','";

                           // txtdatepicker.Visible = true; lbldatepicker.Visible = true;
                        }
                    }
                    chk.Checked = false;
                }

                if (GvSno == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                }
                else
                {
                    if (GvSno != "")
                    {
                        GvSno = GvSno.Substring(0, GvSno.Length - 2);
                    }

                    //////if (txtdatepicker.Text == "")
                    //////{
                    //////    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Select Visit Date !!!');", true);
                    //////}
                    ////else
                    ////{
                    //string SQL = "select [ReffrenceMobile],[PK_Id],[Date],[TotalExpense],[AcceptedEntry] from [TrueVoterDB].[dbo].[tblDailyExpenses] where [PK_Id] IN('" + GvSno + ")";
                    //da = new SqlDataAdapter(SQL, con);
                    //DataSet dsmyct = new DataSet();
                    //da.Fill(dsmyct);

                    //if (ddlreporttype.SelectedValue == "1")  //Deviation
                    //{
                    //    Sql = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [DeviationMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'  WHERE [PK_Id] IN('" + GvSno + ")";
                    //    cmd = new SqlCommand(Sql, con);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();

                    //    //if (dsmyct.Tables[0].Rows[0]["AcceptedEntry"].ToString() == "0")
                    //    //{

                    //    //}
                    //    //else
                    //    //{
                    //    //    for (int i = 0; i < dsmyct.Tables[0].Rows.Count; i++)
                    //    //    {
                    //    //        //Sql = "SELECT [SubExpenseType] FROM  [TrueVoterDB].[dbo].[tblDailyExpenses]  WHERE [PK_Id]=" + dsmyct.Tables[0].Rows[i]["PK_Id"] + "";
                    //    //        //cmd = new SqlCommand(Sql, con);
                    //    //        //con.Open();
                    //    //        //string subexpid = Convert.ToString(cmd.ExecuteScalar());
                    //    //        //con.Close();

                    //    //        //Sql = "SELECT [SubExpenseType] FROM  [TrueVoterDB].[dbo].[tblDailyExpenses]  WHERE [SEID]=" + subexpid + "";
                    //    //        //cmd = new SqlCommand(Sql, con);
                    //    //        //con.Open();
                    //    //        //string subexptype = Convert.ToString(cmd.ExecuteScalar());
                    //    //        //con.Close();

                    //    //        msgstr = "Ur expense Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString() + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " is found below standard rate. Kindly attend RO office on date "+ System.DateTime.Now.ToString("yyyy-MM-dd") +" @ 11 AM to explain the deviation.";
                    //    //        //cc.SendSMS(dsmyct.Tables[0].Rows[0]["ReffrenceMobile"].ToString(), msgstr);
                    //    //        cc.SendSMS("7875484151", msgstr);
                    //    //  //  }

                    //    //}
                    //}
                    //else if (ddlreporttype.SelectedValue == "2")  //Objection
                    //{
                    //    Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [ObjectionMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'  WHERE [ServerID] IN('" + GvSno + ")";
                    //    cmd = new SqlCommand(Sql, con);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();
                    //}
                    //else if (ddlreporttype.SelectedValue == "3")  //Remark
                    //{
                    //    Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [RemarkMsg]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'  WHERE [ServerID] IN('" + GvSno + ")";
                    //    cmd = new SqlCommand(Sql, con);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();
                    //}

                    //for (int i = 0; i < dsmyct.Tables[0].Rows.Count; i++)
                    //{
                    //    if (ddlreporttype.SelectedValue == "1")  //Deviation
                    //    {
                    //        msgstr = "Dear Candidate, your expense Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " is found below standard rate. Kindly attend RO office on date " + System.DateTime.Now.ToString("dd/MM/yyyy") + " @ 11 AM to explain the deviation.";
                    //    }
                    //    else if (ddlreporttype.SelectedValue == "3")  //Objection
                    //    {
                    //        msgstr = "Dear Candidate, your expense  Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " public has taken objection. Kindly attend RO office on date " + System.DateTime.Now.ToString("dd/MM/yyyy") + " @ 11 AM to explain about it.";
                    //    }
                    //    else if (ddlreporttype.SelectedValue == "2")  //Remark
                    //    {
                    //        msgstr = "Dear Candidate, your expense  Entry No " + dsmyct.Tables[0].Rows[i]["PK_Id"].ToString() + " dated " + dsmyct.Tables[0].Rows[i]["Date"].ToString().Substring(0, 9) + " of Rs. " + dsmyct.Tables[0].Rows[i]["TotalExpense"].ToString() + " EMC/Officer has given a remark. Kindly attend RO office on date " + System.DateTime.Now.ToString("dd/MM/yyyy") + " @ 11 AM to explain about it.";
                    //    }
                    //    //cc.SendSMS("9403397649", msgstr);
                    //    // cc.SendSMS(Convert.ToString(dsmyct.Tables[0].Rows[i]["ReffrenceMobile"]), msgstr);
                    //}
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Message Sent Successfully!!!');", true);

                    //GvBind(GvSno);

                   Response.Redirect("~/Reports/AllSms.aspx?msg=" + GvSno + "$" + lbtype + "");
                }
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void lnkAddDiffer_Command(object sender, CommandEventArgs e)
        {
            try
            {

                for (int i = 0; i < GvDeviation.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)GvDeviation.Rows[i].Cells[0].FindControl("ChkDeviation");

                    if (chk != null)
                    {
                        if (chk.Checked == true)
                        {
                            GvSno += Convert.ToString(GvDeviation.DataKeys[i].Value);
                        }
                    }
                    chk.Checked = false;
                }

                if (GvSno == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                }
                else
                {
                    //if (GvSno != "")
                    //{
                    //    GvSno = GvSno.Substring(0, GvSno);
                    //}

                    string sqlid = "Select [AcceptedEntry] From [TrueVoterDB].[dbo].[tblDailyExpenses] Where PK_Id=" + GvSno.ToString() + "";
                    cmd = new SqlCommand(sqlid, con);
                    con.Open();
                    string expid = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();
                    if (expid == string.Empty)
                    {
                        Response.Redirect("~/Reports/NewChangeExpense.aspx?ExpenseId=" + GvSno + "");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This entry already settled by RO...')", true);
                    }
                    //string SQL = "select [ReffrenceMobile] from [TrueVoterDB].[dbo].[tblDailyExpenses] where [PK_Id] IN('" + GvSno + ")";
                    //da = new SqlDataAdapter(SQL, con);
                    //DataSet dsmyct = new DataSet();
                    //da.Fill(dsmyct);

                    //Sql = "UPDATE [TrueVoterDB].[dbo].[tblGeneralObjection] SET [SendMsgDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'  WHERE [ServerID] IN('" + GvSno + ")";
                    //cmd = new SqlCommand(Sql, con);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    //for (int i = 0; i < dsmyct.Tables[0].Rows.Count; i++)
                    //{
                    //    string Msg = "Sir/Madam " + dsmyct.Tables[0].Rows[i]["FirstName"].ToString() + " " + " " + dsmyct.Tables[0].Rows[i]["LastName"].ToString() + " for installation of TRUE VOTER app and to get advantages of further facilities of the app ur area coordinator is " + dss.Tables[0].Rows[0]["JuniorName"].ToString() + " " + " " + dss.Tables[0].Rows[0]["JuniorMobNo"].ToString() + " u can call him for personal level onetime support";
                    //    msgsec.SMS_SEC(Convert.ToString(dsmyct.Tables[0].Rows[i]["RegMobileNo"]), Msg);
                    //}
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void GvDeviation_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TableCell cell = e.Row.Cells[8];
                //int quantity = int.Parse(cell.Text);
                //if (quantity > 60)
                //{
                //    cell.BackColor = Color.Red;
                //}
                //if (quantity > 40 && quantity <= 60)
                //{
                //    cell.BackColor = Color.Yellow;
                //}
                //if (quantity > 1 && quantity <= 40)
                //{
                //    cell.BackColor = Color.Orange;
                //}

                LinkButton lbClose = (LinkButton)e.Row.Cells[5].FindControl("lnkAddDiffer");
                TableCell cell = e.Row.Cells[10];
                string quantity = Convert.ToString(cell.Text);
                if (quantity == "&nbsp;")
                {
                    lbClose.Visible = true;
                }
                else if (quantity == "0")
                {
                    lbClose.Visible = false;
                }
                else if (quantity != "&nbsp;" && quantity == "0")
                {
                    lbClose.Visible = false;
                }
                else
                {
                    lbClose.Visible = false;
                }
                //DataRowView drv = e.Row.DataItem as DataRowView;
                //double deviation = Convert.ToDouble((drv["Deviation"].ToString()));
                //if (deviation > 60)
                //{
                //    e.Row.BackColor = System.Drawing.Color.Red;
                //}
                //if (deviation > 40 && deviation <= 60)
                //{
                //    e.Row.BackColor = System.Drawing.Color.Green;
                //}
                //if (deviation > 1 && deviation <= 40)
                //{
                //    e.Row.BackColor = System.Drawing.Color.Yellow;
                //}
            }
        }
    }
}