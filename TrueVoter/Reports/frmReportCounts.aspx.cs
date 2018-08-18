using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmReportCounts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        string mob = string.Empty;
        string roleID = string.Empty;
        string result = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null)
            {
                if (IsPostBack == false)
                {
                    BindDistrict();
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
            DataSet ds = new DataSet();
            ds = objBAL.BindDistrictBAL();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = ds.Tables[0];
                ddlDistirct.DataTextField = "DistrictName";
                ddlDistirct.DataValueField = "DistrictCode";
                ddlDistirct.DataBind();
                ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlDistirct.SelectedIndex = 0;
            }
            else
            {
            }
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objBAL.DistrictId = Convert.ToInt32(ddlDistirct.SelectedValue);
            ds = objBAL.BindLocalBodyBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {               
                    ddlLocalBody.DataSource = ds.Tables[0];
                    ddlLocalBody.DataTextField = "ElectionName";
                    ddlLocalBody.DataValueField = "SECElectionId";
                    ddlLocalBody.DataBind();
                    ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlLocalBody.SelectedIndex = 0;                
            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblDistrictnm.Text = ddlDistirct.SelectedItem.Text;
            lbllbdynm.Text = ddlLocalBody.SelectedItem.Text;
            gvlocalBodyWiseNominationdtls.Visible = false;
            gvWardWiseNominationDetails.Visible = false;
            gvNominationFinalList.Visible = false;

            if (ddlRptType.SelectedValue == "1")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue.ToString();
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "1";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "2")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "4";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "3")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "7";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "4")
            {
                //cmd.CommandText = "uspGetAbstractReportData";
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                //cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                //cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                //cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                //cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "10";
                //da = new SqlDataAdapter(cmd);
                //ds.Clear();
                //da.Fill(ds);

                cmd.CommandText = "uspDailyExpCountSECLive";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = "2017-12-07";//DateTime.Today.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "10";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "5")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "13";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //pnlnominationlocalBodyWise.Visible = true;
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "6")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = ddlDistirct.SelectedValue;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = ddlLocalBody.SelectedValue;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "16";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = true;
                    gvlocalBodyWiseNominationdtls.DataSource = ds.Tables[0];
                    gvlocalBodyWiseNominationdtls.DataBind();
                }
            }
        }
        protected void gvlocalBodyWiseNominationdtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvlocalBodyWiseNominationdtls.Rows[rowIndex];

            string disId = gvlocalBodyWiseNominationdtls.Rows[rowIndex].Cells[0].Text;
            string lbId = gvlocalBodyWiseNominationdtls.Rows[rowIndex].Cells[1].Text;
            string fstust = gvlocalBodyWiseNominationdtls.Rows[rowIndex].Cells[2].Text;

            if (ddlRptType.SelectedValue == "1")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "2";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "2")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "5";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "3")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "8";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "4")
            {
                //cmd.CommandText = "uspGetAbstractReportData";
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                //cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                //cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                //cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                //cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "11";
                //da = new SqlDataAdapter(cmd);
                //ds.Clear();
                //da.Fill(ds);

                cmd.CommandText = "uspDailyExpCountSECLive";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = "2017-12-07"; //result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "11";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "5")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "14";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "6")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "17";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = true;
                    gvWardWiseNominationDetails.DataSource = ds.Tables[0];
                    gvWardWiseNominationDetails.DataBind();
                }
            }
        }

        protected void gvWardWiseNominationDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvWardWiseNominationDetails.Rows[rowIndex];

            string disId = gvWardWiseNominationDetails.Rows[rowIndex].Cells[0].Text;
            string lbId = gvWardWiseNominationDetails.Rows[rowIndex].Cells[1].Text;
            string fstust = gvWardWiseNominationDetails.Rows[rowIndex].Cells[2].Text;
            string wrNo = gvWardWiseNominationDetails.Rows[rowIndex].Cells[3].Text;
            if (ddlRptType.SelectedValue == "1")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "3";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "2")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "6";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "3")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "9";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "4")
            {
                //cmd.CommandText = "uspGetAbstractReportData";
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                //cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                //cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                //cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                //cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "12";
                //da = new SqlDataAdapter(cmd);
                //ds.Clear();
                //da.Fill(ds);
                cmd.CommandText = "uspDailyExpCountSECLive";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = "2017-12-07"; //result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                //cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "12";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "5")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "15";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
            else if (ddlRptType.SelectedValue == "6")
            {
                cmd.CommandText = "uspGetAbstractReportData";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@todayDate", SqlDbType.NVarChar, 20).Value = result;
                cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 20).Value = disId;
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 20).Value = lbId;
                cmd.Parameters.Add("@formStatus", SqlDbType.NVarChar, 20).Value = fstust;
                cmd.Parameters.Add("@wardId", SqlDbType.NVarChar, 20).Value = wrNo;
                cmd.Parameters.Add("@query", SqlDbType.NVarChar, 20).Value = "18";
                da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlocalBodyWiseNominationdtls.Visible = false;
                    gvWardWiseNominationDetails.Visible = false;
                    gvNominationFinalList.Visible = true;

                    gvNominationFinalList.DataSource = ds.Tables[0];
                    gvNominationFinalList.DataBind();
                }
            }
        }

        //protected void rbtnlRptType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    gvlocalBodyWiseNominationdtls.Visible = false;
        //    gvWardWiseNominationDetails.Visible = false;
        //    gvNominationFinalList.Visible = false;

        //}

        protected void ddlRptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvlocalBodyWiseNominationdtls.Visible = false;
            gvWardWiseNominationDetails.Visible = false;
            gvNominationFinalList.Visible = false;
        }
    }
}