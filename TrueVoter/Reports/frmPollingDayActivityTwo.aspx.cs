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
    public partial class frmPollingDayActivityTwo : System.Web.UI.Page
    {
        string mob = string.Empty;
        string roleID = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);
            string qrystrData = Request.QueryString["pollingId"];
            //qrystrData = "35426";
            if (roleID != null && roleID != "" && mob != null && mob != "" && qrystrData != "")
            {
                if (IsPostBack == false)
                {
                    GetVoteTimeData(qrystrData);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void GetVoteTimeData(string qrystrData)
        {
            SqlParameter[] par = new SqlParameter[10];
            par[0] = new SqlParameter("@Id", qrystrData);
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetVoteTimeDetails", par);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfDistId.Value = Convert.ToString(ds.Tables[0].Rows[0]["DISTID"]);
                hfLbId.Value = Convert.ToString(ds.Tables[0].Rows[0]["LOCALBODYID"]);
                hfLbType.Value = Convert.ToString(ds.Tables[0].Rows[0]["LOCALBODY"]);
                hfMaleCnt.Value = Convert.ToString(ds.Tables[0].Rows[0]["MALE"]);
                hfFemaleCnt.Value = Convert.ToString(ds.Tables[0].Rows[0]["FEMALE"]);
                hfOtherCnt.Value = Convert.ToString(ds.Tables[0].Rows[0]["OTHER"]);


                lbllbtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]);
                lblLbName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectionName"]);
                lblWard.Text = Convert.ToString(ds.Tables[0].Rows[0]["WARDNO"]);
                lblBooth.Text = Convert.ToString(ds.Tables[0].Rows[0]["BOOTHNO"]);

                int intTo = Convert.ToInt32((ds.Tables[0].Rows[0]["MALE"])) + Convert.ToInt32((ds.Tables[0].Rows[0]["FEMALE"])) + Convert.ToInt32((ds.Tables[0].Rows[0]["OTHER"]));
                hfTotal.Value = intTo.ToString();
                lblt.Text = intTo.ToString();
                string Total = "Male : " + Convert.ToString(ds.Tables[0].Rows[0]["MALE"]) + "  Female : " + Convert.ToString(ds.Tables[0].Rows[0]["FEMALE"]) + "   Other : " + Convert.ToString(ds.Tables[0].Rows[0]["OTHER"]);
                lblTotal.Text = Total;
                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        try
                        {
                            string time = Convert.ToString(ds.Tables[1].Rows[i]["Time"]);

                            switch (time)
                            {
                                case "7:30 to 9:30":
                                    RT12.Text = Convert.ToString(ds.Tables[1].Rows[i]["MALE"]);
                                    RT13.Text = Convert.ToString(ds.Tables[1].Rows[i]["FEMALE"]);
                                    RT14.Text = Convert.ToString(ds.Tables[1].Rows[i]["OTHER"]);
                                    RT15.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalVoters"]);
                                    RT16.Text = Convert.ToString(ds.Tables[1].Rows[i]["Percentage"]);
                                    break;

                                case "7:30 to 11:30":
                                    RT22.Text = Convert.ToString(ds.Tables[1].Rows[i]["MALE"]);
                                    RT23.Text = Convert.ToString(ds.Tables[1].Rows[i]["FEMALE"]);
                                    RT24.Text = Convert.ToString(ds.Tables[1].Rows[i]["OTHER"]);
                                    RT25.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalVoters"]);
                                    RT26.Text = Convert.ToString(ds.Tables[1].Rows[i]["Percentage"]);
                                    break;

                                case "7:30 to 1:30":
                                    RT32.Text = Convert.ToString(ds.Tables[1].Rows[i]["MALE"]);
                                    RT33.Text = Convert.ToString(ds.Tables[1].Rows[i]["FEMALE"]);
                                    RT34.Text = Convert.ToString(ds.Tables[1].Rows[i]["OTHER"]);
                                    RT35.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalVoters"]);
                                    RT36.Text = Convert.ToString(ds.Tables[1].Rows[i]["Percentage"]);
                                    break;

                                case "7:30 to 3:30":
                                    RT42.Text = Convert.ToString(ds.Tables[1].Rows[i]["MALE"]);
                                    RT43.Text = Convert.ToString(ds.Tables[1].Rows[i]["FEMALE"]);
                                    RT44.Text = Convert.ToString(ds.Tables[1].Rows[i]["OTHER"]);
                                    RT45.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalVoters"]);
                                    RT46.Text = Convert.ToString(ds.Tables[1].Rows[i]["Percentage"]);
                                    break;
                                case "7:30 to 5:30":

                                    RT52.Text = Convert.ToString(ds.Tables[1].Rows[i]["MALE"]);
                                    RT53.Text = Convert.ToString(ds.Tables[1].Rows[i]["FEMALE"]);
                                    RT54.Text = Convert.ToString(ds.Tables[1].Rows[i]["OTHER"]);
                                    RT55.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalVoters"]);
                                    RT56.Text = Convert.ToString(ds.Tables[1].Rows[i]["Percentage"]);
                                    break;
                            }
                        }
                        catch
                        {

                        }
                    }

                }
            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] par = new SqlParameter[20];
                par[0] = new SqlParameter("@RECORDTYPE", "RECORD");
                par[1] = new SqlParameter("@TIME", Convert.ToString(RT11.Text));
                par[2] = new SqlParameter("@MALE", Convert.ToString(RT12.Text));
                par[3] = new SqlParameter("@FEMALE", Convert.ToString(RT13.Text));
                par[4] = new SqlParameter("@OTHER", Convert.ToString(RT14.Text));
                par[5] = new SqlParameter("@TotalVoters", Convert.ToString(RT15.Text));
                par[6] = new SqlParameter("@Percentage", Convert.ToString(RT16.Text));
                par[7] = new SqlParameter("@WARDNO", Convert.ToString(lblWard.Text));
                par[8] = new SqlParameter("@BOOTHNO", Convert.ToString(lblBooth.Text));
                par[9] = new SqlParameter("@DISTID", Convert.ToString(hfDistId.Value));
                par[10] = new SqlParameter("@TALUKAID", "0");
                par[11] = new SqlParameter("@LOCALBODYID", Convert.ToString(hfLbId.Value));
                par[12] = new SqlParameter("@LOCALBODY", Convert.ToString(hfLbType.Value));
                par[13] = new SqlParameter("@IMEI", "0");
                par[14] = new SqlParameter("@STATUS", "0");
                par[15] = new SqlParameter("@Createdby", mob);
                par[16] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par[17] = new SqlParameter("@IsActive", "1");
                par[18] = new SqlParameter("@returnValue", SqlDbType.Int);
                par[18].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateVoteTimeDetails", par);
                int r1 = Convert.ToInt32(par[18].Value);

                SqlParameter[] par1 = new SqlParameter[20];
                par1[0] = new SqlParameter("@RECORDTYPE", "RECORD");
                par1[1] = new SqlParameter("@TIME", Convert.ToString(RT21.Text));
                par1[2] = new SqlParameter("@MALE", Convert.ToString(RT22.Text));
                par1[3] = new SqlParameter("@FEMALE", Convert.ToString(RT23.Text));
                par1[4] = new SqlParameter("@OTHER", Convert.ToString(RT24.Text));
                par1[5] = new SqlParameter("@TotalVoters", Convert.ToString(RT25.Text));
                par1[6] = new SqlParameter("@Percentage", Convert.ToString(RT26.Text));
                par1[7] = new SqlParameter("@WARDNO", Convert.ToString(lblWard.Text));
                par1[8] = new SqlParameter("@BOOTHNO", Convert.ToString(lblBooth.Text));
                par1[9] = new SqlParameter("@DISTID", Convert.ToString(hfDistId.Value));
                par1[10] = new SqlParameter("@TALUKAID", "0");
                par1[11] = new SqlParameter("@LOCALBODYID", Convert.ToString(hfLbId.Value));
                par1[12] = new SqlParameter("@LOCALBODY", Convert.ToString(hfLbType.Value));
                par1[13] = new SqlParameter("@IMEI", "0");
                par1[14] = new SqlParameter("@STATUS", "0");
                par1[15] = new SqlParameter("@Createdby", mob);
                par1[16] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par1[17] = new SqlParameter("@IsActive", "1");
                par1[18] = new SqlParameter("@returnValue", SqlDbType.Int);
                par1[18].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateVoteTimeDetails", par1);
                int r2 = Convert.ToInt32(par1[18].Value);

                SqlParameter[] par2 = new SqlParameter[20];
                par2[0] = new SqlParameter("@RECORDTYPE", "RECORD");
                par2[1] = new SqlParameter("@TIME", Convert.ToString(RT31.Text));
                par2[2] = new SqlParameter("@MALE", Convert.ToString(RT32.Text));
                par2[3] = new SqlParameter("@FEMALE", Convert.ToString(RT33.Text));
                par2[4] = new SqlParameter("@OTHER", Convert.ToString(RT34.Text));
                par2[5] = new SqlParameter("@TotalVoters", Convert.ToString(RT35.Text));
                par2[6] = new SqlParameter("@Percentage", Convert.ToString(RT36.Text));
                par2[7] = new SqlParameter("@WARDNO", Convert.ToString(lblWard.Text));
                par2[8] = new SqlParameter("@BOOTHNO", Convert.ToString(lblBooth.Text));
                par2[9] = new SqlParameter("@DISTID", Convert.ToString(hfDistId.Value));
                par2[10] = new SqlParameter("@TALUKAID", "0");
                par2[11] = new SqlParameter("@LOCALBODYID", Convert.ToString(hfLbId.Value));
                par2[12] = new SqlParameter("@LOCALBODY", Convert.ToString(hfLbType.Value));
                par2[13] = new SqlParameter("@IMEI", "0");
                par2[14] = new SqlParameter("@STATUS", "0");
                par2[15] = new SqlParameter("@Createdby", mob);
                par2[16] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par2[17] = new SqlParameter("@IsActive", "1");
                par2[18] = new SqlParameter("@returnValue", SqlDbType.Int);
                par2[18].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateVoteTimeDetails", par2);
                int r3 = Convert.ToInt32(par2[18].Value);

                SqlParameter[] par3 = new SqlParameter[20];
                par3[0] = new SqlParameter("@RECORDTYPE", "RECORD");
                par3[1] = new SqlParameter("@TIME", Convert.ToString(RT41.Text));
                par3[2] = new SqlParameter("@MALE", Convert.ToString(RT42.Text));
                par3[3] = new SqlParameter("@FEMALE", Convert.ToString(RT43.Text));
                par3[4] = new SqlParameter("@OTHER", Convert.ToString(RT44.Text));
                par3[5] = new SqlParameter("@TotalVoters", Convert.ToString(RT45.Text));
                par3[6] = new SqlParameter("@Percentage", Convert.ToString(RT46.Text));
                par3[7] = new SqlParameter("@WARDNO", Convert.ToString(lblWard.Text));
                par3[8] = new SqlParameter("@BOOTHNO", Convert.ToString(lblBooth.Text));
                par3[9] = new SqlParameter("@DISTID", Convert.ToString(hfDistId.Value));
                par3[10] = new SqlParameter("@TALUKAID", "0");
                par3[11] = new SqlParameter("@LOCALBODYID", Convert.ToString(hfLbId.Value));
                par3[12] = new SqlParameter("@LOCALBODY", Convert.ToString(hfLbType.Value));
                par3[13] = new SqlParameter("@IMEI", "0");
                par3[14] = new SqlParameter("@STATUS", "0");
                par3[15] = new SqlParameter("@Createdby", mob);
                par3[16] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par3[17] = new SqlParameter("@IsActive", "1");
                par3[18] = new SqlParameter("@returnValue", SqlDbType.Int);
                par3[18].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateVoteTimeDetails", par3);
                int r4 = Convert.ToInt32(par3[18].Value);

                SqlParameter[] par4 = new SqlParameter[20];
                par4[0] = new SqlParameter("@RECORDTYPE", "RECORD");
                par4[1] = new SqlParameter("@TIME", Convert.ToString(RT51.Text));
                par4[2] = new SqlParameter("@MALE", Convert.ToString(RT52.Text));
                par4[3] = new SqlParameter("@FEMALE", Convert.ToString(RT53.Text));
                par4[4] = new SqlParameter("@OTHER", Convert.ToString(RT54.Text));
                par4[5] = new SqlParameter("@TotalVoters", Convert.ToString(RT55.Text));
                par4[6] = new SqlParameter("@Percentage", Convert.ToString(RT56.Text));
                par4[7] = new SqlParameter("@WARDNO", Convert.ToString(lblWard.Text));
                par4[8] = new SqlParameter("@BOOTHNO", Convert.ToString(lblBooth.Text));
                par4[9] = new SqlParameter("@DISTID", Convert.ToString(hfDistId.Value));
                par4[10] = new SqlParameter("@TALUKAID", "0");
                par4[11] = new SqlParameter("@LOCALBODYID", Convert.ToString(hfLbId.Value));
                par4[12] = new SqlParameter("@LOCALBODY", Convert.ToString(hfLbType.Value));
                par4[13] = new SqlParameter("@IMEI", "0");
                par4[14] = new SqlParameter("@STATUS", "0");
                par4[15] = new SqlParameter("@Createdby", mob);
                par4[16] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par4[17] = new SqlParameter("@IsActive", "1");
                par4[18] = new SqlParameter("@returnValue", SqlDbType.Int);
                par4[18].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertUpdateVoteTimeDetails", par4);
                int r5 = Convert.ToInt32(par4[18].Value);

                if ((r1 == 102 || r1 == 101) && (r2 == 102 || r2 == 101) && (r3 == 102 || r3 == 101) && (r4 == 102 || r4 == 101) && (r5 == 102 || r5 == 101))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Msg", "alert('Data Submitted Successfully')", true);
                }
            }
            catch
            {
                DataSet ds = new DataSet();
                hfDistId.Value = "";
            }
        }

        protected void gvPollingData_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }


    }
}