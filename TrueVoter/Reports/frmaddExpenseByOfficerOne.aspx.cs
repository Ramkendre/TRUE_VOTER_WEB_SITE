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
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmaddExpenseByOfficerOne : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
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
            //cmd.CommandText = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);
            DataSet ds = new DataSet();
            ds = objBAL.BindDistrictBAL();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = ds.Tables[0];
                ddlDistirct.DataTextField = "DistrictName";
                ddlDistirct.DataValueField = "DistrictCode";
                ddlDistirct.DataBind();
                ddlDistirct.Items.Insert(0, new ListItem("Select", "0"));
                ddlDistirct.SelectedIndex = 0;
            }
            else
            {

            }
        }

        //public void BindData()
        //{
        //    string qry = "SELECT [RId],[usrMobileNumber],[DesignationId],[DesignationName],[LocalBodyId],[LocalBodyName],[refMobileNumber]," +
        //                 "[OfficerDistrictId],[DistrictName],[Post],[AllocatedWard],[DivisionId],[DivisionName],[ElectoralColId],[ElectoralColName]" +
        //                 "FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] LEFT JOIN [TrueVoterDB].[dbo].[tblDistrictMapping]" +
        //                 "ON [OfficerDistrictId]=[DistrictCode] WHERE [usrMobileNumber]='" + mob + "'";
        //    ds.Clear();
        //    ds = cc.ExecuteDataset(qry);
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string qry2 = "SELECT [CId],[usrFullName],[usrMobileNumber],[CandidateRoleName],[LocalBodyType],[LocalBodyName],
            //[WardNo],[AssemblyID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [CandidateDistrictID]='" + ddlDistirct.SelectedValue + "' 
            //AND [LocalBodyID]='" + ddlLocalBody.SelectedValue + "' AND [SeatNoID]='" + ddlSeat.SelectedValue + "' AND WardNo='" + txtWardNo.Text + "' ORDER BY [CId] desc ";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry2);

            SqlParameter[] par1 = new SqlParameter[10];
            par1[0] = new SqlParameter("@p0", 2);
            par1[1] = new SqlParameter("@p1", ddlDistirct.SelectedValue);
            par1[2] = new SqlParameter("@p2", ddlLocalBody.SelectedValue);
            par1[3] = new SqlParameter("@p3", ddlSeat.SelectedValue);
            par1[4] = new SqlParameter("@p4", txtWardNo.Text);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataAddExpenseByOff", par1);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcandidateList.DataSource = ds.Tables[0];
                gvcandidateList.DataBind();
            }
            else
            {
                gvcandidateList.DataSource = ds.Tables[0];
                gvcandidateList.DataBind();
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }
        protected void gvcandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvcandidateList.PageIndex = e.NewPageIndex;
            //BindData();
        }
        protected void lnkShow_Click(object sender, EventArgs e)
        {
            string moNo = string.Empty;
            LinkButton lbtnShow = (LinkButton)sender;
            moNo = lbtnShow.CommandArgument;

            Response.Redirect("~/Reports/frmaddExpenseByOfficerTwo.aspx?mNo=" + cc.DESEncrypt(moNo) + "");
        }

        protected void ddllbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 1);
            par[1] = new SqlParameter("@p1", ddlDistirct.SelectedValue);
            par[2] = new SqlParameter("@p2", "0");
            par[3] = new SqlParameter("@p3", "0");
            par[4] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataAddExpenseByOff", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds.Tables[0];
                ddlLocalBody.DataTextField = "ElectionName";
                ddlLocalBody.DataValueField = "ElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("Select", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);
            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 1);
            par[1] = new SqlParameter("@p1", ddlDistirct.SelectedValue);
            par[2] = new SqlParameter("@p2", "0");
            par[3] = new SqlParameter("@p3", "0");
            par[4] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataAddExpenseByOff", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds.Tables[0];
                ddlLocalBody.DataTextField = "ElectionName";
                ddlLocalBody.DataValueField = "ElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("Select", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }
    }
}