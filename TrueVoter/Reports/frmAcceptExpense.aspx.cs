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

namespace TrueVoter.Reports
{
    public partial class frmAcceptExpense : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);

            if (mob != null)
            {
                if (IsPostBack == false)
                {
                    BindData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void BindData()
        {
            //string qry = "SELECT [RId],[usrMobileNumber],[DesignationId],[DesignationName],[LocalBodyId],[LocalBodyName],[refMobileNumber]," +
            //             "[OfficerDistrictId],[DistrictName],[Post],[AllocatedWard],[DivisionId],[DivisionName],[ElectoralColId],[ElectoralColName]" +
            //             "FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] LEFT JOIN [TrueVoterDB].[dbo].[tblDistrictMapping]" +
            //             "ON [OfficerDistrictId]=[DistrictCode] WHERE [usrMobileNumber]='" + mob + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0",1);
            par[1] = new SqlParameter("@p1", mob);
            par[2] = new SqlParameter("@p2", "0");
            par[3] = new SqlParameter("@p3", "0");
            par[4] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses",par);


            txtDistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
            txtLocalBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string qry = "SELECT [RId],[usrMobileNumber],[DesignationId],[DesignationName],[LocalBodyId],[LocalBodyName],[refMobileNumber]," +
            //             "[OfficerDistrictId],[DistrictName],[Post],[AllocatedWard],[DivisionId],[DivisionName],[ElectoralColId],[ElectoralColName]" +
            //             "FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra] LEFT JOIN [TrueVoterDB].[dbo].[tblDistrictMapping]" +
            //             "ON [OfficerDistrictId]=[DistrictCode] WHERE [usrMobileNumber]='" + mob + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 1);
            par[1] = new SqlParameter("@p1", mob);
            par[2] = new SqlParameter("@p2", "0");
            par[3] = new SqlParameter("@p3", "0");
            par[4] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses", par);
            
            txtDistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
            txtLocalBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);

            //string qry2 = "SELECT [CId],[usrFullName],[usrMobileNumber],[CandidateRoleName],[LocalBodyType],[LocalBodyName],[WardNo],[AssemblyID] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [CandidateDistrictID]='" + Convert.ToString(ds.Tables[0].Rows[0]["OfficerDistrictId"]) + "' AND [LocalBodyID]='" + Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyId"]) + "' AND [SeatNoID]='" + ddlSeat.SelectedValue + "' AND WardNo='" + txtWardNo.Text + "' ORDER BY [CId] desc ";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry2);

            SqlParameter[] par1 = new SqlParameter[10];
            par1[0] = new SqlParameter("@p0", 2);
            par1[1] = new SqlParameter("@p1", Convert.ToString(ds.Tables[0].Rows[0]["OfficerDistrictId"]));
            par1[2] = new SqlParameter("@p2", Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyId"]));
            par1[3] = new SqlParameter("@p3", ddlSeat.SelectedValue);
            par1[4] = new SqlParameter("@p4", txtWardNo.Text);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses", par1);


            if (ds.Tables[0].Rows.Count > 0)
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
            gvcandidateList.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void lnkShow_Click(object sender, EventArgs e)
        {
            string moNo = string.Empty;
            LinkButton lbtnShow = (LinkButton)sender;
            moNo = lbtnShow.CommandArgument;
            Response.Redirect("~/Reports/frmAcceptExpenseMain.aspx?mNo=" + cc.DESEncrypt(moNo) + "");
            //cmd = new SqlCommand();
            //DataSet dsExpe = new DataSet();
            //cmd.Connection = con;
            //cmd.CommandText = "uspCandidateWiseDailyExp";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mobileNo1", SqlDbType.NVarChar).Value = moNo;
            //da = new SqlDataAdapter(cmd);
            //da.Fill(dsExpe);

            //int dsCnt = dsExpe.Tables[0].Rows.Count;
            //if (dsCnt > 0)
            //{
            //    gvCandidateDailyEx.DataSource = dsExpe.Tables[0];
            //    gvCandidateDailyEx.DataBind();
            //}
            //else
            //{
            //    gvCandidateDailyEx.DataSource = dsExpe.Tables[0];
            //    gvCandidateDailyEx.DataBind();
            //}

        }

        //protected void gvCandidateDailyEx_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}



        //protected void lnkAccept_Click(object sender, EventArgs e)
        //{
        //    LinkButton lnkbtnacpt = (LinkButton)sender;

        //    string AccExpId = lnkbtnacpt.CommandArgument;

        //    string qryacpt = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [OffAcceptStatus]=1,[StatusUpdateDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[OfficerMoNo]='" + mob + "'  WHERE [PK_Id] IN (" + AccExpId + ") AND [OffAcceptStatus] IS NULL";// AND [OffAcceptStatus] IS NULL //AND [Printed] IS NULL ";
        //    cc.ExecuteNonQuery(qryacpt);

        //}

        //protected void lnkReject_Click(object sender, EventArgs e)
        //{
        //    LinkButton lnkbtnrjt = (LinkButton)sender;

        //    string RejExpId = lnkbtnrjt.CommandArgument;

        //    string qryrjt = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [OffAcceptStatus]=2,[StatusUpdateDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[OfficerMoNo]='" + mob + "'  WHERE [PK_Id] IN (" + RejExpId + ") AND [OffAcceptStatus] IS NULL";// AND [OffAcceptStatus] IS NULL //AND [Printed] IS NULL ";
        //    cc.ExecuteNonQuery(qryrjt);
        //}
    }
}