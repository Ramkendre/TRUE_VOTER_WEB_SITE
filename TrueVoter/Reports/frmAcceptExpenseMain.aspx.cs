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
    public partial class frmAcceptExpenseMain : System.Web.UI.Page
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
                    string mNo = cc.DESDecrypt(Convert.ToString(Request.QueryString["mNo"]));
                    ShowData(mNo);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void ShowData(string mNO)
        {
            //string qry = "SELECT [CId],[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType]," +
            //             "[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID],[usrFullName],[DivisionId],[DivisionName],[ElectoralColId]," +
            //             "[ElectoralColName],[SeatNo],[ElectionType],[PartyName],[PartyTypeID],[PartyNameID],[ElectionTypeID]" +
            //             "FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber]='" + mNO + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 3);
            par[1] = new SqlParameter("@p1", mNO);
            par[2] = new SqlParameter("@p2", "0");
            par[3] = new SqlParameter("@p3", "0");
            par[4] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses", par);

            txtCandidateName.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrFullName"]);
            txtLocalBody.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);
            txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNumber"]);

            cmd = new SqlCommand();
            DataSet dsExpe = new DataSet();
            cmd.Connection = con;
            cmd.CommandText = "uspCandidateWiseDailyExp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mNO;
            da = new SqlDataAdapter(cmd);
            da.Fill(dsExpe);

            if (dsExpe.Tables[0].Rows.Count > 0)
            {
                ViewState["GridData"] = dsExpe.Tables[0];
                gvCandidateDailyEx.DataSource = dsExpe.Tables[0];
                gvCandidateDailyEx.DataBind();
            }
            else
            {
                gvCandidateDailyEx.DataSource = dsExpe.Tables[0];
                gvCandidateDailyEx.DataBind();
            }

        }

        protected void lnkAccept_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtnacpt = (LinkButton)sender;

            string AccExpId = lnkbtnacpt.CommandArgument;

            //string qryacpt = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [OffAcceptStatus]=1,[StatusUpdateDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[OfficerMoNo]='" + mob + "'  WHERE [PK_Id] ='" + AccExpId + "'";// AND [OffAcceptStatus] IS NULL";// AND [OffAcceptStatus] IS NULL //AND [Printed] IS NULL ";
            //cc.ExecuteNonQuery(qryacpt);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 4);
            par[1] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
            par[2] = new SqlParameter("@p2", mob);
            par[3] = new SqlParameter("@p3", AccExpId);
            par[4] = new SqlParameter("@p4", "0");
            //ds.Clear();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses", par);

            string mNo = cc.DESDecrypt(Convert.ToString(Request.QueryString["mNo"]));
            ShowData(mNo);
        }

        protected void lnkReject_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtnrjt = (LinkButton)sender;

            string RejExpId = lnkbtnrjt.CommandArgument;

            //string qryrjt = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [OffAcceptStatus]=2,[StatusUpdateDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[OfficerMoNo]='" + mob + "'  WHERE [PK_Id] ='" + RejExpId + "'";// AND [OffAcceptStatus] IS NULL";// AND [OffAcceptStatus] IS NULL //AND [Printed] IS NULL ";
            //cc.ExecuteNonQuery(qryrjt);

            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@p0", 5);
            par[1] = new SqlParameter("@p1", System.DateTime.Now.ToString("yyyy-MM-dd"));
            par[2] = new SqlParameter("@p2", mob);
            par[3] = new SqlParameter("@p3", RejExpId);
            par[4] = new SqlParameter("@p4", "0");
            //ds.Clear();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspGetDataForAcceptExpenses", par);

            string mNo = cc.DESDecrypt(Convert.ToString(Request.QueryString["mNo"]));
            ShowData(mNo);
        }

        protected void gvCandidateDailyEx_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCandidateDailyEx.PageIndex = e.NewPageIndex;
            gvCandidateDailyEx.DataSource = ViewState["GridData"];
            gvCandidateDailyEx.DataBind();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmAcceptExpense.aspx");
        }
        //protected void btnAccRej_Click(object sender, EventArgs e)
        //{
        //    Button btnAcpRjt = (Button)sender;
        //    string txt = btnAcpRjt.Text;
        //    string pkEx = btnAcpRjt.CommandArgument;
        //    string up = string.Empty;
        //    if (txt == "Pending")
        //    {
        //        up = "1";
        //    }
        //    else if (txt == "Reject")
        //    {
        //        up = "1";
        //    }
        //    else if (txt == "Accept")
        //    {
        //        up = "2";
        //    }
        //    string qryrjt = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [OffAcceptStatus]='" + up + "',[StatusUpdateDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[OfficerMoNo]='" + mob + "'  WHERE [PK_Id] ='" + pkEx + "'";// AND [OffAcceptStatus] IS NULL";// AND [OffAcceptStatus] IS NULL //AND [Printed] IS NULL ";
        //    cc.ExecuteNonQuery(qryrjt);
        //    string mNo = Request.QueryString["mNo"];
        //    ShowData(mNo);
        //}
    }
}