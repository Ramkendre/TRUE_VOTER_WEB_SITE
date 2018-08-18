using Microsoft.ApplicationBlocks.Data;
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
    public partial class ExtraDetails : System.Web.UI.Page
    {
        //LoginBLL objlogin = new LoginBLL();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string mob = string.Empty;
        string roleID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["MainRole"]);
            loginSession();
            HideMenu(roleID);

            if (!IsPostBack)
            {
                BindPartyType();
                if (mob != null && mob != "")
                {
                    //string sqlExist = "SELECT * FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] WHERE [usrMobileNumber] = '" + mob + "' AND [CandidateRole] IN (2,1,4)";

                    //cmd = new SqlCommand(sqlExist, con);
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataSet dsExist = new DataSet();
                    //da.Fill(dsExist);


                    SqlParameter[] par = new SqlParameter[5];
                    par[0] = new SqlParameter("@p1", "1");
                    par[1] = new SqlParameter("@p2", mob);
                    par[2] = new SqlParameter("@p3", "0");
                    par[3] = new SqlParameter("@p4", "0");
                    DataSet dsExist = new DataSet();
                    dsExist = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWeb", par);

                    if (dsExist.Tables[0].Rows.Count > 0)
                    {
                        txtCandidateName.Text = dsExist.Tables[0].Rows[0]["usrFullName"].ToString();
                        txtMoNo.Text = mob.Trim();
                        txtNominationDate.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["NominationDate"]);
                        txtElectionDate.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["ElectionDate"]);
                        txtResultDate.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["ResultDate"]);
                        txtAge.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["Age"]);
                        txtFatherName.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["FatherName"]);

                        string partyTypeID = Convert.ToString(dsExist.Tables[0].Rows[0]["PartyTypeID"]);
                        if (partyTypeID == "" || partyTypeID == "0")
                        {

                        }
                        else
                        {
                            //cmd.CommandText = "SELECT [PTID],[PartyType] FROM [TrueVoterDB].[dbo].[tblPartyTypeFieldItem](NOLOCK)";
                            //cmd.CommandType = CommandType.Text;
                            //cmd.Connection = con;
                            //da.SelectCommand = cmd;
                            //ds.Clear();
                            //da.Fill(ds);

                            SqlParameter[] par1 = new SqlParameter[5];
                            par1[0] = new SqlParameter("@p1", "2");
                            par1[1] = new SqlParameter("@p2", "0");
                            par1[2] = new SqlParameter("@p3", "0");
                            par1[3] = new SqlParameter("@p4", "0");
                            ds.Clear();
                            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWeb", par1);


                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ddlPartytype.DataSource = ds.Tables[0];
                                ddlPartytype.DataTextField = "PartyType";
                                ddlPartytype.DataValueField = "PTID";
                                ddlPartytype.DataBind();
                                ddlPartytype.Items.Insert(0, new ListItem("Select", "0"));
                                //ddlPartyName.SelectedIndex = 0;
                                ddlPartytype.SelectedValue = partyTypeID;
                            }
                        }

                        string PartyNameID = Convert.ToString(dsExist.Tables[0].Rows[0]["PartyNameID"]);
                        if (PartyNameID == "" || PartyNameID == "0")
                        {

                        }
                        else
                        {
                            //cmd.CommandText = "SELECT [PID],[PTID],[PartyName] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PTID]='" + partyTypeID + "'";
                            //cmd.CommandType = CommandType.Text;
                            //cmd.Connection = con;
                            //da.SelectCommand = cmd;
                            //ds.Clear();
                            //da.Fill(ds);

                            SqlParameter[] par1 = new SqlParameter[5];
                            par1[0] = new SqlParameter("@p1", "3");
                            par1[1] = new SqlParameter("@p2", partyTypeID);
                            par1[2] = new SqlParameter("@p3", "0");
                            par1[3] = new SqlParameter("@p4", "0");
                            ds.Clear();
                            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWeb", par1);


                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ddlPartyName.DataSource = ds.Tables[0];
                                ddlPartyName.DataTextField = "PartyName";
                                ddlPartyName.DataValueField = "PID";
                                ddlPartyName.DataBind();
                                ddlPartyName.SelectedValue = PartyNameID;
                                //ddlPartyName.Items.Add("--Select--");
                                //ddlPartyName.Items.Insert(0, new ListItem("Select", "0"));
                            }
                        }
                        string ElectionType = Convert.ToString(dsExist.Tables[0].Rows[0]["ElectionTypeID"]);
                        if (ElectionType == "" || ElectionType == "0")
                        {
                            ddlElectionType.SelectedValue = "0";
                        }
                        else
                        {
                            ddlElectionType.SelectedValue = ElectionType;
                        }
                        //txtOrder.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["OrderNo"]);
                        txtPlace.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["Place"]);
                        //ddlSeatNo.SelectedValue = Convert.ToString(dsExist.Tables[0].Rows[0]["SeatNoID"]);
                        string seatNOId = Convert.ToString(dsExist.Tables[0].Rows[0]["SeatNoID"]);

                        if (seatNOId == "" || seatNOId == "0")
                        {
                            ddlSeatNo.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlSeatNo.SelectedValue = seatNOId;
                        }
                        try
                        {
                            ddlElectionType.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["ElectionType"]);
                        }
                        catch
                        {

                        }

                        txtBankAccNo.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["BankAccNo"]);
                        txtBankName.Text = Convert.ToString(dsExist.Tables[0].Rows[0]["BankName"]);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid MobileNumber..!!!'); windows.location='~/Reports/frmHomeUser.aspx'", true);
                        //Response.Redirect("~/Reports/frmHomeUser.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");// Response.Redirect("~/Reports/frmHomeUser.aspx");
                }
            }
            else
            {

            }
        }
        public string loginSession()
        {
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
            return mob;
        }
        public void BindPartyType()
        {
            //cmd.CommandText = "SELECT [PTID],[PartyType] FROM [TrueVoterDB].[dbo].[tblPartyTypeFieldItem](NOLOCK)";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);

            SqlParameter[] par1 = new SqlParameter[5];
            par1[0] = new SqlParameter("@p1", "2");
            par1[1] = new SqlParameter("@p2", "0");
            par1[2] = new SqlParameter("@p3", "0");
            par1[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWeb", par1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartytype.DataSource = ds.Tables[0];
                ddlPartytype.DataTextField = "PartyType";
                ddlPartytype.DataValueField = "PTID";
                ddlPartytype.DataBind();
                ddlPartytype.Items.Insert(0, new ListItem("Select", "0"));
                ddlPartytype.SelectedIndex = 0;
            }
            else
            {

            }
        }

        public void HideMenu(string rollId)
        {
            if (rollId == "4")
            {
                lblNominationDate.Visible = false;
                txtNominationDate.Visible = false;
                RequiredFieldValidatorDate.Visible = false;
                lblElectionDate.Visible = false;
                txtElectionDate.Visible = false;
                RequiredFieldValidatorEleDate.Visible = false;
                lblSeatNo.Visible = false;
                ddlSeatNo.Visible = false;
                //lblElectionType.Visible = false;
                //ddlElectionType.Visible = false;
                Label1.Visible = false;
                txtResultDate.Visible = false;
                Label4.Visible = false;
                txtBankName.Visible = false;
                Label2.Visible = false;
                txtBankAccNo.Visible = false;
                //lblPartyName.Visible = false;
                //ddlPartytype.Visible = false;
                //Label3.Visible = false;
                //ddlPartyName.Visible = false;
            }
            else
            {
            }
        }

        public void ClearAll()
        {
            txtNominationDate.Text = string.Empty;
            txtElectionDate.Text = string.Empty;
            txtResultDate.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtBankAccNo.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            ddlPartyName.SelectedIndex = -1;
            //txtOrder.Text = string.Empty;
            txtPlace.Text = string.Empty;
            ddlSeatNo.SelectedIndex = 0;
            ddlElectionType.SelectedIndex = 0;
            ddlPartytype.SelectedIndex = 0;
            try
            {
                ddlPartyName.SelectedIndex = 0;
            }
            catch
            {
                ddlPartyName.Text = "";
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string MobileNo = loginSession();
            //string sqlExist = "UPDATE [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] SET [usrFullName]=N'" + txtCandidateName.Text + "'," +
            //                           "[NominationDate]=N'" + txtNominationDate.Text + "',[ElectionDate]=N'" + txtElectionDate.Text + "'," +
            //                           "[ResultDate]=N'" + txtResultDate.Text + "',[Age]=N'" + txtAge.Text + "'," +
            //                           "[OrderNo]=N'0',[OfficerName]='0',[FatherName]=N'" + txtFatherName.Text + "'," +
            //                           "[Place]=N'" + txtPlace.Text + "',[SeatNo]=N'" + ddlSeatNo.SelectedItem.Text + "',[ElectionType]=N'" + ddlElectionType.SelectedItem + "'," +
            //                           "[PartyName]=N'" + ddlPartyName.SelectedItem + "',[PartyTypeID]='" + ddlPartytype.SelectedValue + "',[PartyNameID]='" + ddlPartyName.SelectedValue + "'," +
            //                          " [ElectionTypeID]='" + ddlElectionType.SelectedValue + "',[SeatNoID]='" + ddlSeatNo.SelectedValue + "',[BankName]='" + txtBankName.Text + "',[BankAccNo]='" + txtBankAccNo.Text + "' WHERE [usrMobileNumber]='" + MobileNo + "'";
            //SqlCommand cmd = new SqlCommand(sqlExist, con);
            //con.Open();
            //int i = cmd.ExecuteNonQuery();
            //con.Close();

            SqlParameter[] par1 = new SqlParameter[20];
            par1[0] = new SqlParameter("@p0",MobileNo);
            par1[1] = new SqlParameter("@p1",txtCandidateName.Text);
            par1[2] = new SqlParameter("@p2",txtNominationDate.Text);
		    par1[3] = new SqlParameter("@p3",txtElectionDate.Text);
            par1[4] = new SqlParameter("@p4",txtResultDate.Text);
		    par1[5] = new SqlParameter("@p5",txtAge.Text);
            par1[6] = new SqlParameter("@p6","0");
            par1[7] = new SqlParameter("@p7", "0");
		    par1[8] = new SqlParameter("@p8",txtFatherName.Text);
            par1[9] = new SqlParameter("@p9",txtPlace.Text);
		    par1[10] = new SqlParameter("@p10",ddlSeatNo.SelectedItem.Text);
		    par1[11] = new SqlParameter("@p11",ddlElectionType.SelectedItem.ToString());
            par1[12] = new SqlParameter("@p12", ddlPartyName.SelectedItem.ToString());
		    par1[13] = new SqlParameter("@p13",ddlPartytype.SelectedValue);
		    par1[14] = new SqlParameter("@p14",ddlPartyName.SelectedValue);
            par1[15] = new SqlParameter("@p15",ddlElectionType.SelectedValue);
		    par1[16] = new SqlParameter("@p16",ddlSeatNo.SelectedValue);
		    par1[17] = new SqlParameter("@p17",txtBankName.Text);
		    par1[18] = new SqlParameter("@p18",txtBankAccNo.Text);
            par1[19] = new SqlParameter("@p19", SqlDbType.Int);
            par1[19].Direction = ParameterDirection.InputOutput;
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspUpdateCandidateExtraWeb", par1);
            string k=par1[19].Value.ToString();
            if (k=="101")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Submitted Successfully..')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Not Submitted')", true);
            }
        }


        protected void ddlPartytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT [PID],[PTID],[PartyName] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PTID]='" + ddlPartytype.SelectedValue + "'";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //da.Fill(ds);
            SqlParameter[] par1 = new SqlParameter[5];
            par1[0] = new SqlParameter("@p1", "3");
            par1[1] = new SqlParameter("@p2", ddlPartytype.SelectedValue);
            par1[2] = new SqlParameter("@p3", "0");
            par1[3] = new SqlParameter("@p4", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWeb", par1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyName.DataSource = ds.Tables[0];
                ddlPartyName.DataTextField = "PartyName";
                ddlPartyName.DataValueField = "PID";
                ddlPartyName.DataBind();
                ddlPartyName.Items.Insert(0, new ListItem("Select", "0"));
                ddlPartyName.SelectedIndex = 0;
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }
    }
}