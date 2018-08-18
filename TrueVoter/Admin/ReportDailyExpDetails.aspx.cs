using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter;

namespace TrueVoter.Admin
{
    public partial class ReportDailyExpDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlConnection SECcon = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterSECSS"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        CommonCode commonCode = new CommonCode();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            string MobileNo = string.Empty;
            string msg = string.Empty;
            msg = "Dear Candidate Please Fill The Todays Daily Expense in True Voter App";
            string getDailyExpenseFilledData = "SELECT DISTINCT [InsertBy] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('1','2') SELECT DISTINCT [ReffrenceMobile]  FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('3') ";

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
            string CandidateList = "SELECT  FROM [SEC_TV].[dbo].[tblRegistrationWithSymbolIDNEW](NOLOCK) WHERE [RegMobileNo] NOT IN (" + FinalMoNo + ")";
            cmd.Connection = SECcon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CandidateList;
            da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDailyExpense.DataSource = ds.Tables[0];
                gvDailyExpense.DataBind();
            }

            //string FinalMoNo = MobileNo.Substring(0, MobileNo.Length - 1);
            //string CandidateList = "SELECT DISTINCT[RegMobileNo] FROM [SEC_TV].[dbo].[tblRegistrationWithSymbolID](NOLOCK) WHERE [RegMobileNo] NOT IN (" + FinalMoNo + ")";
            //cmd.Connection = SECcon;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = CandidateList;
            //da = new SqlDataAdapter(cmd);
            //ds.Clear();
            //da.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            //    {
            //        string MoNo = Convert.ToString(ds.Tables[0].Rows[k][0]);
            //        //commonCode.SMS(MoNo, msg);
            //    }
            //}
        }
    }
}