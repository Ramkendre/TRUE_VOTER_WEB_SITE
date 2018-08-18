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
    public partial class DailyExpenseSample5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    GetBasicData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void GetBasicData()
        {
            cmd.CommandText = "uspGetRepBasicDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mobile", mob.Trim());
            da = new SqlDataAdapter(cmd);
            DataSet dsBdetls = new DataSet();
            da.Fill(dsBdetls);
            if (dsBdetls.Tables[0].Rows.Count > 0)
            {
                //A.[PID],A.[PTID],B.[PartyType],A.[PartyName] ,RD.[DistrictId],RD.[LocalBodyId]
                //@PartyTypeId NVARCHAR(50),          //@PartyNameId NVARCHAR(50),     //@DistrictId NVARCHAR(50),
                //@LocalBodyId NVARCHAR(50),         //@CreatedBy NVARCHAR(50)
                cmd.CommandText = "uspGetCandidateList";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PartyTypeId", Convert.ToString(dsBdetls.Tables[0].Rows[0]["PTID"]));
                cmd.Parameters.AddWithValue("@PartyNameId", Convert.ToString(dsBdetls.Tables[0].Rows[0]["PID"]));
                cmd.Parameters.AddWithValue("@DistrictId", Convert.ToString(dsBdetls.Tables[0].Rows[0]["DistrictId"]));
                cmd.Parameters.AddWithValue("@LocalBodyId", Convert.ToString(dsBdetls.Tables[0].Rows[0]["LocalBodyId"]));
                cmd.Parameters.AddWithValue("@CreatedBy", mob.Trim());
                da = new SqlDataAdapter(cmd);
                DataSet dsalldetails = new DataSet();
                da.Fill(dsalldetails);
                if (dsalldetails.Tables[0].Rows.Count > 0)
                {
                    //PC.[PartyTypeId],PC.[PartyNameId],A.[PartyName],PC.[DistrictId]
                    //,PC.[LocalBodyTypeID] //,PC.[LocalBodyTypeName] //,PC.[LocalBodyId]      //,PC.[LocalBodyName]      //,PC.[ElectionTypeId]      //,PC.[ElectionType]
                    //,PC.[ElectionDate]      //,PC.[CandidateName]      //,PC.[CandidateMoNo]      //,PC.[WardNo]      //,PC.[SeatNo]      //,PC.[VerifiedId]      //,PC.[Verified]
                    //,PC.[NomiWithdrawId]      //,PC.[NomiWithdraw]      //,PC.[ElectionResultId]      //,PC.[ElectionResult]      //,PC.[CreatedBy]      //,PC.[CreatedDate]      //,PC.[IsActive]

                    lblParty.Text = Convert.ToString(dsalldetails.Tables[0].Rows[0]["PartyName"]);
                    lblLocalBody.Text = Convert.ToString(dsalldetails.Tables[0].Rows[0]["LocalBodyTypeID"]) + "-" + Convert.ToString(dsalldetails.Tables[0].Rows[0]["LocalBodyTypeName"]);
                    lblDistrictNm.Text = Convert.ToString(dsalldetails.Tables[0].Rows[0]["DistrictName"]);
                    lblVotingDate.Text = Convert.ToString(dsalldetails.Tables[0].Rows[0]["ElectionDate"]);
                    lblElection.Text = Convert.ToString(dsalldetails.Tables[0].Rows[0]["ElectionType"]);
                    lblDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                    gridViewPrivew.DataSource = dsalldetails.Tables[0];
                    gridViewPrivew.DataBind();
                }
                else
                {
                    gridViewPrivew.EmptyDataText = "No Data Found";
                    gridViewPrivew.DataBind();
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not Authorized Person to Add Party Representative'); window.location ='frmHomeUser.aspx';", true);
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

    }
}