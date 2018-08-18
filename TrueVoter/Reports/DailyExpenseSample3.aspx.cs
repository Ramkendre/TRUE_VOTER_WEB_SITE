//using BLL;
//using BOL;
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
    public partial class DailyExpenseSample3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        DataSet ds = new DataSet();
        string mob = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["MobileNo"] != null)
                    {
                        mob = Session["MobileNo"].ToString();
                        //string sqlExist = "SELECT * FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber] = '" + mob + "' AND [CandidateRole] IN (2,1)";

                        //SqlCommand cmd = new SqlCommand(sqlExist, con);
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //DataSet dsExist = new DataSet();
                        //da.Fill(dsExist);

                        //if (dsExist.Tables[0].Rows.Count > 0)
                        //{
                        //    txtName.Text = dsExist.Tables[0].Rows[0]["usrFullName"].ToString();
                        //    txtNomiDate.Text = dsExist.Tables[0].Rows[0]["NominationDate"].ToString();
                        //    txteletionDt.Text = dsExist.Tables[0].Rows[0]["ElectionDate"].ToString();
                        //    txtresultDt.Text = dsExist.Tables[0].Rows[0]["ResultDate"].ToString();
                        //    txtAge.Text = dsExist.Tables[0].Rows[0]["Age"].ToString();
                        //    txtfathername.Text = dsExist.Tables[0].Rows[0]["FatherName"].ToString();
                        //    //txtofficerName.Text = dsExist.Tables[0].Rows[0]["OfficerName"].ToString();
                        //    txtOrderNo.Text = dsExist.Tables[0].Rows[0]["OrderNo"].ToString();
                        //    txtplaces.Text = dsExist.Tables[0].Rows[0]["Place"].ToString();
                        //    MultiView1.ActiveViewIndex += 1;
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid MobileNumber..!!!')", true);
                        //    Response.Redirect("../Reports/frmHome.aspx");
                        //}


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                        Response.Redirect("../Admin/Login.aspx");
                    }
                }
                else
                {

                }
                MultiView1.Visible = false;
            }
            catch 
            {
            
            }
        }

        public void Getdata()
        {
            try
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    #region
                    //string Query = "SELECT L.[UserName],L.[Status],L.[Name],L.[Mname],L.[LName],L.[EmailId],L.[UserType],L.[address],L.[State]" +
                    //                ",L.[District],L.[Taluka],L.[IsApproved],LE.[CandidateRole],LE.[CandidateRoleName],LE.[CandidateDistrictID],DT.[Name_E]" +
                    //                ",LE.[LocalBodyType],LE.[LocalBodyName],LE.[WardNo],LE.[LocalBodyID],EB.[ElectionName],LE.[AssemblyID],LE.[usrFullName]" +
                    //                ",LE.[NominationDate],LE.[ElectionDate],LE.[ResultDate],LE.[Age],LE.[OrderNo],LE.[OfficerName],LE.[FatherName],LE.[Place] FROM [TrueVoterDB].[dbo].[Logins] AS L " +
                    //                "INNER JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] AS LE ON L.[UserName]=LE.[usrMobileNumber]" +
                    //                "LEFT JOIN [TrueVoterDB].[dbo].[ElectionBody$] AS EB ON LE.[LocalBodyID]=EB.[ElectionId]" +
                    //                "LEFT JOIN [TrueVoterDB].[dbo].[Districts] AS DT ON LE.[CandidateDistrictID]=DT.[Id]" +
                    //                "WHERE  L.[UserName]='" + mob + "'";
                    //cmd.Connection = con;
                    //cmd.CommandText = Query;
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(ds);
                    //MoNo = Session["MobileNo"].ToString();
                    #endregion
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "uspDownloadcandiDailyExpsam3SECLock";//"uspDownloadcandiDailyExpsam3";
                    cmd.Parameters.Add("@mobileno", SqlDbType.NVarChar).Value = mob;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Close();
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblname.Text = ds.Tables[0].Rows[0]["usrFullName"].ToString();
                        if (Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]) == "5")
                        {
                            //string ElectName = Convert.ToString(ds.Tables[0].Rows[0]["ElectoralColId"]) + "-" + Convert.ToString(ds.Tables[0].Rows[0]["ElectoralColName"]) + "";
                            string ElectName = Convert.ToString(ds.Tables[0].Rows[0]["ElectoralColName"]);
                            lblname2.Text = ElectName;
                        }
                        //else if (Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyType"]) == "4")
                        //{
                        //    string ElectName = Convert.ToString(ds.Tables[0].Rows[0]["DivisionId"]) + "-" + Convert.ToString(ds.Tables[0].Rows[0]["DivisionName"]) + "";
                        //    lblname2.Text = ElectName;
                        //}
                        else
                        {
                            lblname2.Text = Convert.ToString(ds.Tables[0].Rows[0]["ElectionName"]);
                        }
                        lblNominationDate.Text = ds.Tables[0].Rows[0]["NominationDate"].ToString();
                        lblWardNo.Text = ds.Tables[0].Rows[0]["WardNo"].ToString();
                        lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                        lblplace.Text = ds.Tables[0].Rows[0]["Name_E"].ToString();
                        lblResultDate2.Text = ds.Tables[0].Rows[0]["ResultDate"].ToString();
                        lblResultDate.Text = ds.Tables[0].Rows[0]["ResultDate"].ToString();
                        lbltodate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                        lblfathername.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                        lblAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                        lblElectiondate.Text = ds.Tables[0].Rows[0]["ElectionDate"].ToString();
                        //lblOrderNO.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                        lblplace.Text = ds.Tables[0].Rows[0]["Place"].ToString();
                        lblofficerName.Text = ds.Tables[0].Rows[0]["usrFullName"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Candidate Data Not Found...'); window.location='frmHomeUser.aspx'", true);
                    }
                }

                else 
                {
                   
                   Response.Redirect("../Admin/Login.aspx"); 
                }
            }
            catch
            {
            }
        }

        
        protected void lnkbtnOrder1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expences_Procedure.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expences Procedure.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder2_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Election_Expense_Order_1.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Election Expense Order 1.pdf"));
            Response.End();
        }

        protected void lnkbtnOrder3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Expenses_Format_Order 2.pdf");
            Response.TransmitFile(Server.MapPath("../PDFFiles/Expenses Format Order 2.pdf"));
            Response.End();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Getdata();
            MultiView1.ActiveViewIndex += 2;
            MultiView1.Visible = true;
            Panel1.Visible = false;
        }



    }
}