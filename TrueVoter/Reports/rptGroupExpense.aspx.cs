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
    public partial class rptGroupExpense : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        string groupId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string d = Request.QueryString[0];
            if (d != "")
            {
                d = cc.DESDecrypt(d);
                string[] d1 = d.Split('$');
                mob = d1[0].ToString();
                groupId = d1[1].ToString();
                bindBasicGroupData(mob, groupId);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void bindBasicGroupData(string mobNo,string gId)
        {
            try
            {
                SqlParameter[] par=new SqlParameter[2];
                par[0] = new SqlParameter("@mob",mob);
                par[1] = new SqlParameter("@gId", gId);

                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(con,CommandType.StoredProcedure,"usprptGroupExpenseDetails",par);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblGroupName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProgramName"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["ProgramName"]);
                    lblcandidateName1.Text = Convert.ToString(ds.Tables[0].Rows[0]["M1Name"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["M1Name"]);
                    lblcandidateName2.Text = Convert.ToString(ds.Tables[0].Rows[0]["M2Name"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["M2Name"]);
                    lblcandidateName3.Text = Convert.ToString(ds.Tables[0].Rows[0]["M3Name"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["M3Name"]);
                    lblcandidateName4.Text = Convert.ToString(ds.Tables[0].Rows[0]["M4Name"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["M4Name"]);
                    lblProgramdt.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                        //Convert.ToString(ds.Tables[0].Rows[0]["ProgramDate"]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0]["ProgramDate"]);

                    lblDistrictNm.Text = Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["DistrictName"]); ;
                    lblParty.Text = Convert.ToString(ds.Tables[1].Rows[0]["PN"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["PN"]);
                    lblElection.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionType"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["ElectionType"]);
                    lblLocalBodyId.Text = Convert.ToString(ds.Tables[1].Rows[0]["LocalBodyName"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["LocalBodyName"]);
                    lblVotingDate.Text = Convert.ToString(ds.Tables[1].Rows[0]["ElectionDate"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["ElectionDate"]);
                    lblWardNo.Text = Convert.ToString(ds.Tables[1].Rows[0]["WardNo"]) == "" ? "--" : Convert.ToString(ds.Tables[1].Rows[0]["WardNo"]);
                    lblPGroupExp.Text = Convert.ToString(ds.Tables[3].Rows[0][0]) == "" ? "--" : Convert.ToString(ds.Tables[3].Rows[0][0]);
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gvDaillyExpenses.DataSource = ds.Tables[2];
                        gvDaillyExpenses.DataBind();
                        gvDaillyExpenses.FooterRow.Cells[9].Text = "एकूण";
                        gvDaillyExpenses.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                        gvDaillyExpenses.FooterRow.Cells[10].Text = ds.Tables[2].Compute("Sum(TotalExpense)", "").ToString();
                    }
                    else
                    {
                        gvDaillyExpenses.EmptyDataText = "Nil Data";
                        gvDaillyExpenses.DataBind();
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        NO1.Text = Convert.ToString(ds.Tables[0].Rows[0][3])==""?"--":Convert.ToString(ds.Tables[0].Rows[0][3]);
                        M1.Text = Convert.ToString(ds.Tables[0].Rows[0][4]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][4]);
                        S1.Text = Convert.ToString(ds.Tables[0].Rows[0][5]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][5]);
                        ST1.Text = Convert.ToString(ds.Tables[0].Rows[0][6]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][6]);


                        NO2.Text = Convert.ToString(ds.Tables[0].Rows[0][7]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][7]);
                        M2.Text = Convert.ToString(ds.Tables[0].Rows[0][8]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][8]);
                        S2.Text = Convert.ToString(ds.Tables[0].Rows[0][9]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][9]);
                        ST2.Text = Convert.ToString(ds.Tables[0].Rows[0][10]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][10]);


                        NO3.Text = Convert.ToString(ds.Tables[0].Rows[0][11]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][11]);
                        M3.Text = Convert.ToString(ds.Tables[0].Rows[0][12]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][12]);
                        S3.Text = Convert.ToString(ds.Tables[0].Rows[0][13]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][13]);
                        ST3.Text = Convert.ToString(ds.Tables[0].Rows[0][14]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][14]);

                        NO4.Text = Convert.ToString(ds.Tables[0].Rows[0][15]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][15]);
                        M4.Text = Convert.ToString(ds.Tables[0].Rows[0][16]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][16]);
                        S4.Text = Convert.ToString(ds.Tables[0].Rows[0][17]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][17]);
                        ST4.Text = Convert.ToString(ds.Tables[0].Rows[0][18]) == "" ? "--" : Convert.ToString(ds.Tables[0].Rows[0][18]);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('No Data Found..')", true);
                }
            }
            catch
            {

            }
        }
    }
}