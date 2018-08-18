using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TrueVoter.Reports
{
    public partial class TrueVoterReports : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        //SqlConnection contrue = new SqlConnection("Data Source=103.16.140.243;Initial Catalog=TrueVoterDB;User ID=TrueVoter;Password=TrueVoter@#123;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDistrict();
            }
        }

        public void BindDistrict()
        {
            cmd.CommandText = " SELECT [DistrictId],[DistrictName],[StateId],[DID] FROM [TrueVoterDB].[dbo].[DistrictMaster] WHERE [StateId] = 27 AND [DID] <> 27 ORDER BY [DistrictName] ASC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = ds.Tables[0];
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataBind();

                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            }
        }

        public void BindLocalBody()
        {
            cmd.CommandText = " SELECT [DistrictId],[DistrictName],[StateId],[DID] FROM [TrueVoterDB].[dbo].[DistrictMaster] WHERE [StateId] = 27 AND [DID] <> 27 ORDER BY [DistrictName] ASC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = ds.Tables[0];
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictId";
                ddlDistrict.DataBind();

                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            }
        }


        public void BindGridReports()
        {
            string sqlQuery = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            dt.Columns.Add(new DataColumn("Mobile", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("EntryDate", typeof(string)));
            dt.Columns.Add(new DataColumn("RefMobile", typeof(string)));
            dt.Columns.Add(new DataColumn("DistrictName", typeof(string)));
            dt.Columns.Add(new DataColumn("Designation", typeof(string)));
            dt.Columns.Add(new DataColumn("LookingAfter", typeof(string)));
            dt.Columns.Add(new DataColumn("LocalBody", typeof(string)));


            if (ddlRole.SelectedValue == "0" && ddlDistrict.SelectedItem.Text == "--Select--" && txtRefMbNo.Text == "") // No Fields are Select
            {
                lblResult.Text = "Please Select at least one value...";
            }
            if (ddlRole.SelectedValue != "0" && ddlDistrict.SelectedItem.Text != "--Select--" && txtRefMbNo.Text != "") // All Fields are Select
            {
                string sql1 = " SELECT DISTINCT [usrMobileNumber] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [DesignationId] = '" + ddlRole.SelectedValue + "'";
                DataSet ds1 = new DataSet();
                SqlCommand cmd1 = new SqlCommand(sql1, contrue);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds1.Tables[0].Rows.Count;

                    for (int i = 0; i < count1; i++)
                    {
                        string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                                      " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                                      " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                                      " WHERE  [TrueVoterDB].[dbo].[Logins].[MobileNo] = '" + ds1.Tables[0].Rows[i][0] + "' AND [TrueVoterDB].[dbo].[Logins].[District] = '" + ddlDistrict.SelectedValue + "' AND [TrueVoterDB].[dbo].[Logins].[RefMobileNo] LIKE '" + txtRefMbNo.Text.Trim() + "%' ORDER BY [ID] DESC";

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(ds2);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds1.Tables[0].Rows[i][0] + "'";
                            DataSet ds3 = new DataSet();
                            SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                            da3.Fill(ds3);

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                            }
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue != "0" && ddlDistrict.SelectedItem.Text == "--Select--" && txtRefMbNo.Text == "") // Only designation / role select
            {

                string sql1 = " SELECT DISTINCT [usrMobileNumber] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [DesignationId] = '" + ddlRole.SelectedValue + "'";
                DataSet ds1 = new DataSet();
                SqlCommand cmd1 = new SqlCommand(sql1, contrue);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds1.Tables[0].Rows.Count;

                    for (int i = 0; i < count1; i++)
                    {
                        string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                                      " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                                      " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                                      " WHERE  [TrueVoterDB].[dbo].[Logins].[mobileNo] = '" + ds1.Tables[0].Rows[i][0] + "' ORDER BY [ID] DESC";

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(ds2);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds1.Tables[0].Rows[i][0] + "'";
                            DataSet ds3 = new DataSet();
                            SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                            da3.Fill(ds3);

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                            }
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue != "0" && ddlDistrict.SelectedItem.Text != "--Select--" && txtRefMbNo.Text == "") //role and designation
            {
                string sql1 = " SELECT DISTINCT [usrMobileNumber] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [DesignationId] = '" + ddlRole.SelectedValue + "'";
                DataSet ds1 = new DataSet();
                SqlCommand cmd1 = new SqlCommand(sql1, contrue);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds1.Tables[0].Rows.Count;

                    for (int i = 0; i < count1; i++)
                    {
                        string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                                      " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                                      " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                                      " WHERE  [TrueVoterDB].[dbo].[Logins].[mobileNo] = '" + ds1.Tables[0].Rows[i][0] + "' AND [TrueVoterDB].[dbo].[Logins].[District] = '" + ddlDistrict.SelectedValue + "' ORDER BY [ID] DESC";

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(ds2);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds1.Tables[0].Rows[i][0] + "'";
                            DataSet ds3 = new DataSet();
                            SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                            da3.Fill(ds3);

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                            }
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue != "0" && ddlDistrict.SelectedItem.Text == "--Select--" && txtRefMbNo.Text != "")  //role & reference mobile
            {
                string sql1 = " SELECT DISTINCT [usrMobileNumber] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [DesignationId] = '" + ddlRole.SelectedValue + "'";
                DataSet ds1 = new DataSet();
                SqlCommand cmd1 = new SqlCommand(sql1, contrue);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds1.Tables[0].Rows.Count;

                    for (int i = 0; i < count1; i++)
                    {
                        string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                                      " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                                      " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                                      " WHERE  [TrueVoterDB].[dbo].[Logins].[mobileNo] = '" + ds1.Tables[0].Rows[i][0] + "' AND [TrueVoterDB].[dbo].[Logins].[RefMobileNo] LIKE '" + txtRefMbNo.Text.Trim() + "%' ORDER BY [ID] DESC";

                        DataSet ds2 = new DataSet();
                        SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                        da2.Fill(ds2);

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds1.Tables[0].Rows[i][0] + "'";
                            DataSet ds3 = new DataSet();
                            SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                            da3.Fill(ds3);

                            if (ds3.Tables[0].Rows.Count > 0)
                            {
                                dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                            }
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue == "0" && ddlDistrict.SelectedItem.Text != "--Select--" && txtRefMbNo.Text != "")  //District & reference mobile
            {

                string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                              " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                              " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                              " WHERE  [TrueVoterDB].[dbo].[Logins].[District] = '" + ddlDistrict.SelectedValue + "' AND [TrueVoterDB].[dbo].[Logins].[RefMobileNo] LIKE '" + txtRefMbNo.Text.Trim() + "%' ORDER BY [ID] DESC";

                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds2.Tables[0].Rows.Count;
                    for (int i = 0; i < count1; i++)
                    {
                        string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds2.Tables[0].Rows[i][2] + "'";
                        DataSet ds3 = new DataSet();
                        SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                        da3.Fill(ds3);

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue == "0" && ddlDistrict.SelectedItem.Text == "--Select--" && txtRefMbNo.Text != "")  // reference mobile
            {
                string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                              " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                              " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                              " WHERE  [TrueVoterDB].[dbo].[Logins].[RefMobileNo] LIKE '" + txtRefMbNo.Text.Trim() + "%' ORDER BY [ID] DESC";

                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds2.Tables[0].Rows.Count;
                    for (int i = 0; i < count1; i++)
                    {
                        string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds2.Tables[0].Rows[i][2] + "'";
                        DataSet ds3 = new DataSet();
                        SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                        da3.Fill(ds3);

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[i]["DesignationName"].ToString(), ds3.Tables[0].Rows[i]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[i]["LocalBodyName"].ToString());
                        }
                    }
                }
            }
            if (ddlRole.SelectedValue == "0" && ddlDistrict.SelectedItem.Text != "--Select--" && txtRefMbNo.Text == "")  //District
            {
                string sql2 = " SELECT TOP 20 [Name] AS firstName,[LName] AS lastName,[MobileNo] AS mobileNo,[address], [EmailId] AS eMailId,[InsertDate] AS EntryDate, [RefMobileNo] AS RefMobileNo,[District],[DistrictName] " +
                              " FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[DistrictMaster]" +
                              " ON [TrueVoterDB].[dbo].[Logins].[District] = [TrueVoterDB].[dbo].[DistrictMaster].[DistrictId]" +
                              " WHERE  [TrueVoterDB].[dbo].[Logins].[District] = '" + ddlDistrict.SelectedValue + "' ORDER BY [ID] DESC";

                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand(sql2, contrue);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int count1 = ds2.Tables[0].Rows.Count;
                    for (int i = 0; i < count1; i++)
                    {
                        string sql3 = " SELECT [usrMobileNumber],[DesignationName],[LokingAfterName],[LocalBodyName],[EmergencyNum1] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] WHERE [usrMobileNumber] = '" + ds2.Tables[0].Rows[i][2] + "'";
                        DataSet ds3 = new DataSet();
                        SqlCommand cmd3 = new SqlCommand(sql3, contrue);
                        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                        da3.Fill(ds3);

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            dt.Rows.Add(ds2.Tables[0].Rows[i]["firstName"].ToString(), ds2.Tables[0].Rows[i]["lastName"].ToString(), ds2.Tables[0].Rows[i]["mobileNo"].ToString(), ds2.Tables[0].Rows[i]["address"].ToString(), ds2.Tables[0].Rows[i]["eMailId"].ToString(), ds2.Tables[0].Rows[i]["EntryDate"].ToString(), ds2.Tables[0].Rows[i]["RefMobileNo"].ToString(), ds2.Tables[0].Rows[i]["DistrictName"].ToString(), ds3.Tables[0].Rows[0]["DesignationName"].ToString(), ds3.Tables[0].Rows[0]["LokingAfterName"].ToString(), ds3.Tables[0].Rows[0]["LocalBodyName"].ToString());
                        }
                    }
                }
            }


            if (dt.Rows.Count > 0)
            {
                gvTReports.DataSource = dt;
                gvTReports.DataBind();
            }
            else
            {
                gvTReports.EmptyDataText = "NO DATA FOUND...!!!";
                gvTReports.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridReports();
            btnExportExcel.Visible = true;
        }

        protected void gvTReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTReports.PageIndex = e.NewPageIndex;
            BindGridReports();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            gvTReports.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            this.BindGridReports();
            string trueVoter = "TrueVoter " + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvTReports.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvTReports.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }
    }
}