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
    public partial class ReportForDailyExpense : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlConnection SECcon = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterSECSS"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            // FindCandidates();
        }

        public void FindCandidate()
        {
            string MobileNo = string.Empty;
            string msg = string.Empty;
            msg = "Dear Candidate Please Fill The Todays Daily Expense in True Voter App";
            string getDailyExpenseFilledData = "SELECT DISTINCT [InsertBy] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('1','2')" +//
                                               "SELECT DISTINCT [ReffrenceMobile]  FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('3') ";//

            DataSet ds = commonCode.ExecuteDataset(getDailyExpenseFilledData);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MobileNo += "'" + Convert.ToString(ds.Tables[0].Rows[i][0]) + "',";
                }
                for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                {
                    MobileNo += "'" + Convert.ToString(ds.Tables[0].Rows[j][0]) + "',";
                }
            }
            else
            {

            }
            string FinalMoNo = MobileNo.Substring(0, MobileNo.Length - 1);
            //string CandidateList = "SELECT DISTINCT[RegMobileNo] FROM [SEC_TV].[dbo].[tblRegistrationWithSymbolIDNEW](NOLOCK) WHERE [RegMobileNo] NOT IN (" + FinalMoNo + ")";
            string CQuery = "SELECT DISTINCT[RegMobileNo],[FirstName],[MiddleName],[LastName],[Address],[DistrictId],[DistrictName],[LocalBodyName],[Code],[GroupID],[pin],[formtype],[localbodyid],[CreatedDate],[wardid] FROM [TrueVoterDB].[dbo].[tblRegistrationWithSymbolIDNEW](NOLOCK) WHERE [RegMobileNo] NOT IN (" + FinalMoNo + ")";
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CQuery;
            da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds);
            ViewState["gvViewStateData"] = ds.Tables[0];
            gvCandidateList.DataSource = ds.Tables[0];
            gvCandidateList.DataBind();
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            //    {
            //        string MoNo = Convert.ToString(ds.Tables[0].Rows[k][0]);
            //    }
            //}
        }

        public void FindCandidates()
        {
            cmd.CommandText = "uspDailyExpenseFilledReports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string quryValue = string.Empty;
            if (rblReporttype.SelectedValue == "0")
            {
                quryValue = "1";
            }
            else
            {
                quryValue = "2";
            }
            cmd.Parameters.Add("@qry", SqlDbType.NChar).Value = quryValue;
            cmd.Parameters.Add("@para", SqlDbType.NChar).Value = "0";
            da = new SqlDataAdapter(cmd);
            DataSet objds = new DataSet();
            da.Fill(objds);
            ViewState["gvViewStateData"] = objds.Tables[0];
            gvCandidateList.DataSource = objds.Tables[0];
            gvCandidateList.DataBind();
            lblCounttotal.Text = Convert.ToString(objds.Tables[0].Rows.Count);
        }

        protected void gvCandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCandidateList.PageIndex = e.NewPageIndex;
            gvCandidateList.DataSource = ViewState["gvViewStateData"];
            gvCandidateList.DataBind();

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string quryValue = string.Empty;
            string pfdName = string.Empty;
            if (rblReporttype.SelectedValue == "0")
            {
                quryValue = "1";
                pfdName = "ListOfDailyExpenseFilledCandidate";
            }
            else if (rblReporttype.SelectedValue == "2")
            {
                quryValue = "3";
                pfdName = "ListOfDailyExpenseDistrictWise";
            }
            else if (rblReporttype.SelectedValue == "1")
            {
                quryValue = "2";
                pfdName = "ListOfDailyExpenseNotFilledCandidate";
            }
            cmd.CommandText = "uspDailyExpenseFilledReports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@qry", SqlDbType.NChar).Value = quryValue;
            da = new SqlDataAdapter(cmd);
            DataSet objds = new DataSet();
            da.Fill(objds);

            GridView gvData = new GridView();
            gvData.AllowPaging = false;
            gvData.DataSource = objds.Tables[0];
            gvData.DataBind();

            //Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + pfdName + "" + System.DateTime.Now + ".xls");
            // Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            gvData.RenderControl(hTextWriter);
            Response.Write(sWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "uspDailyExpenseFilledReports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string quryValue = string.Empty;
            DataSet objds = new DataSet();
            if (rblReporttype.SelectedValue == "0")
            {
                quryValue = "1";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@qry", SqlDbType.NChar).Value = quryValue;
                cmd.Parameters.Add("@para", SqlDbType.NChar).Value = "0";
                da = new SqlDataAdapter(cmd);
                objds.Clear();
                da.Fill(objds);
                gvCandidateList.DataSource = objds.Tables[0];
                gvCandidateList.DataBind();
                lblCounttotal.Text = Convert.ToString(objds.Tables[0].Rows.Count);

                GridView gvData = new GridView();
                gvData.AllowPaging = false;
                gvData.DataSource = objds.Tables[0];
                gvData.DataBind();

                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=Report" + System.DateTime.Now + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvData.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
            else if (rblReporttype.SelectedValue == "1")
            {
                quryValue = "2";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@qry", SqlDbType.NChar).Value = quryValue;
                cmd.Parameters.Add("@para", SqlDbType.NChar).Value = "0";
                da = new SqlDataAdapter(cmd);
                objds.Clear();
                da.Fill(objds);
                gvCandidateList.DataSource = objds.Tables[0];
                gvCandidateList.DataBind();
                lblCounttotal.Text = Convert.ToString(objds.Tables[0].Rows.Count);

                GridView gvData = new GridView();
                gvData.AllowPaging = false;
                gvData.DataSource = objds.Tables[0];
                gvData.DataBind();

                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=Report" + System.DateTime.Now + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvData.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
            else if (rblReporttype.SelectedValue == "2")
            {
                quryValue = "4";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar).Value = quryValue;
                cmd.Parameters.Add("@para", SqlDbType.NVarChar).Value = ddlDistName.SelectedValue;
                cmd.CommandTimeout = 950;
                objds.Clear();
                con.Close();
                con.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(objds);
                con.Close();
                gvCandidateList.DataSource = objds.Tables[0];
                gvCandidateList.DataBind();
                lblCounttotal.Text = Convert.ToString(objds.Tables[0].Rows.Count);

                GridView gvData = new GridView();
                gvData.AllowPaging = false;
                gvData.DataSource = objds.Tables[0];
                gvData.DataBind();

                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=Report" + System.DateTime.Now + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvData.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }


        }

        protected void rblReporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblReporttype.SelectedValue == "2")
            {
                pnlDist.Visible = true;
                BindDistrict();
            }
            else
            {
                pnlDist.Visible = false;
            }
        }

        public void BindDistrict()
        {
            string DistQury = "SELECT [SrNo],[DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping](NOLOCK)";
            DataSet objDs = new DataSet();
            objDs = commonCode.ExecuteDataset(DistQury);

            if (objDs.Tables[0].Rows.Count > 0)
            {
                ddlDistName.DataSource = objDs.Tables[0];
                ddlDistName.DataTextField = "DistrictName";
                ddlDistName.DataValueField = "DistrictCode";
                ddlDistName.DataBind();

                ddlDistName.Items.Insert(0, "Select");
                ddlDistName.SelectedIndex = 0;
            }
        }
    }
}