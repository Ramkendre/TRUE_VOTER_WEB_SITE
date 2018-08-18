using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace TrueVoter.Reports
{
    public partial class frmAddPartyRepresentative : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    // GetBasicData();
                    BindGridView();

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void txtPartyReMoNo_TextChanged(object sender, EventArgs e)
        {
            //string s = "SELECT [usrMobileNumber],[CandidateRole],[CandidateRoleName],[DistrictName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID]" +
            //            ",[usrFullName],[NominationDate],[ElectionDate],[ResultDate],[Age],[OrderNo],[OfficerName],[FatherName],[Place],[MarketPerMoNO],[DivisionId],[DivisionName]" +
            //            ",[ElectoralColId],[ElectoralColName],[SeatNo],[ElectionType],[PartyName],[PartyType],[PartyTypeID],[PartyNameID],[ElectionTypeID],[SeatNoID],[BankName],[BankAccNo]" +
            //            ",[ElectionTyp],[BlockId],[SECNomiStatus],[InsertedDate] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] LEFT join [TrueVoterDB].[dbo].[tblDistrictMapping]" +
            //            "ON [CandidateDistrictID]=[DistrictCode] LEFT JOIN [TrueVoterDB].[dbo].[tblPartyTypeFieldItem] ON [PartyTypeID]=[PTID]  where [usrMobileNumber]='" + txtPartyReMoNo.Text.Trim() + "'";
            //DataSet ds1 = new DataSet();
            //ds1 = cc.ExecuteDataset(s);



            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@p1", "1");
            par[1] = new SqlParameter("@p2", txtPartyReMoNo.Text.Trim());
            par[2] = new SqlParameter("@p3", "0");
            par[3] = new SqlParameter("@p4", "0");
            DataSet ds1 = new DataSet();
            ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWebNew", par);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                string pt = Convert.ToString(ds1.Tables[0].Rows[0]["PartyTypeID"]);
                string ln = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyName"]);
                string cd = Convert.ToString(ds1.Tables[0].Rows[0]["CandidateDistrictID"]);
                string dn = Convert.ToString(ds1.Tables[0].Rows[0]["DistrictName"]);
                if (pt != "" && ln != "" && cd != "")
                {
                    txtDist.Text = dn;
                    txtLbName.Text = ln;
                    txtParty.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyName"]);
                    txtPartyType.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyType"]);
                    hdnfieldpartytypID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyTypeID"]);
                    hdnfieldpartyID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyNameID"]);
                    hdnfieldDist.Value = Convert.ToString(ds1.Tables[0].Rows[0]["CandidateDistrictID"]);
                    hdnFieldLocal.Value = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyID"]);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Fill Register Mobile No Extra Details')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Register Your Mobile No')", true);
            }

        }



        //public void GetBasicData()
        //{
        //    //string qry = "SELECT A.[PID],A.[PTID],B.[PartyType],A.[PartyName] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] AS A " +
        //    //             "INNER JOIN [TrueVoterDB].[dbo].[tblPartyTypeFieldItem] AS B ON A.[PTID]=B.[PTID] WHERE [ContactPersonMobile]='" + mob + "'";
        //    //ds1.Clear();
        //    //ds1 = cc.ExecuteDataset(qry);
        //    cmd.CommandText = "uspBindRepsData";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = mob;
        //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "1";
        //    da = new SqlDataAdapter(cmd);
        //    DataSet ds1 = new DataSet();
        //    da.Fill(ds1);

        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        txtParty.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyName"]);
        //        txtPartyType.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyType"]);
        //        hdnfieldpartytypID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PTID"]);
        //        hdnfieldpartyID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PID"]);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('You are not Authorized Person to Add Party Representative'); window.location='frmHomeUser.aspx';", true);

        //        //Response.Redirect("~/Reports/frmHomeUser.aspx");
        //    }
        //}

        public void BindGridView()
        {
            //string gv = "SELECT [ID],[MobileNo],[Rep_Name],[PartyId],[PartyName],[HeadAddress],[Symbols],[RegistrationDate],[RoleId],[RoleName],[DistrictId],[DistrictName],[LocalBodyId],[ElectionName],PR.[IsActive]" +
            //            "FROM [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] AS PR INNER JOIN [TrueVoterDB].[dbo].[ElectionBody$]  " +
            //            "ON [LocalBodyId]=[ElectionId] INNER JOIN [TrueVoterDB].[dbo].[tblPartFieldItemMaster] " +
            //            "ON [PartyId]=[PID] WHERE PR.[CreatedBy]='" + mob + "' ORDER BY [ID] DESC";
            //ds.Clear();
            //ds = cc.ExecuteDataset(gv);
            cmd.CommandText = "uspBindRepsData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = mob;
            cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "2";
            da = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            ViewState["gridData"] = ds1.Tables[0];
            gvPartyRepresData.DataSource = ds1.Tables[0];
            gvPartyRepresData.DataBind();
        }
        //public void BindDistrict()
        //{
        //    //string dist = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
        //    //DataSet DS = new DataSet();
        //    //DS = cc.ExecuteDataset(dist);

        //    cmd.CommandText = "uspBindDistrict";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    cmd.Parameters.Clear();
        //    da = new SqlDataAdapter(cmd);
        //    DataSet DS = new DataSet();
        //    da.Fill(DS);

        //    if (DS.Tables[0].Rows.Count > 0)
        //    {
        //        ddlDistirct.DataSource = DS.Tables[0];
        //        ddlDistirct.DataTextField = "DistrictName";
        //        ddlDistirct.DataValueField = "DistrictCode";
        //        ddlDistirct.DataBind();
        //        ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlDistirct.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //    }
        //}
        //protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //string lb = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
        //    //ds.Clear();
        //    //ds = cc.ExecuteDataset(lb);
        //    cmd.CommandText = "uspBindRepsData";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = ddlDistirct.SelectedValue;
        //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "3";
        //    da = new SqlDataAdapter(cmd);
        //    DataSet ds1 = new DataSet();
        //    da.Fill(ds1);

        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        ddlLocalBody.DataSource = ds1.Tables[0];
        //        ddlLocalBody.DataTextField = "ElectionName";
        //        ddlLocalBody.DataValueField = "ElectionId";
        //        ddlLocalBody.DataBind();
        //        ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlLocalBody.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string qry = string.Empty;
            int i = 0;
            //if (ddlPartyType.SelectedValue == "" || ddlPartyType.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Select Party Type')", true);
            //}
            //else if (ddlParty.SelectedValue == "" || ddlParty.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Select Party')", true);
            //}
            if (ddlRole.SelectedValue == "" || ddlRole.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Select Role')", true);
            }
            else if (txtDist.Text == "" || txtDist.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Fill Register Mobile No Extra Details')", true);
            }
            else if (txtLbName.Text == "" || txtLbName.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Fill Register Mobile No Extra Details')", true);
            }
            else if (txtRepresNm.Text == "" || txtRepresNm.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Enter Representative Name')", true);
            }
            else if (txtPartyReMoNo.Text == "" || txtPartyReMoNo.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please Enter Representative MobileNo')", true);
            }
            else
            {
                #region
               
                //string qryone = "Select [ID],[PartyId],[MobileNo],[RoleId],[DistrictId],[LocalBodyId] FROM [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] WHERE  [MobileNo]='" + txtPartyReMoNo.Text.Trim() + "'";
                //DataSet dtset = new DataSet();
                //dtset = cc.ExecuteDataset(qryone);

                //SqlParameter[] par = new SqlParameter[5];
                //par[0] = new SqlParameter("@p1", "2");
                //par[1] = new SqlParameter("@p2", txtPartyReMoNo.Text.Trim());
                //par[2] = new SqlParameter("@p3", "0");
                //par[3] = new SqlParameter("@p4", "0");
                //DataSet dtset = new DataSet();
                //dtset = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandidateExtraWebNew", par);


                //cmd.CommandText = "uspInsertRepsData";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = con;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("@partyReMo", SqlDbType.NVarChar, 10).Value = txtPartyReMoNo.Text.Trim();
                //cmd.Parameters.Add("@hdnFieldPId", SqlDbType.NVarChar, 10).Value = hdnfieldpartyID.Value;
                //cmd.Parameters.Add("@representativeNm", SqlDbType.NVarChar, 500).Value = txtRepresNm.Text;
                //cmd.Parameters.Add("@role", SqlDbType.NVarChar, 500).Value = ddlRole.SelectedValue;
                //cmd.Parameters.Add("@roleName", SqlDbType.NVarChar, 500).Value = ddlRole.SelectedItem.Text;
                //cmd.Parameters.Add("@distID", SqlDbType.NVarChar, 500).Value = ddlDistirct.SelectedValue;
                //cmd.Parameters.Add("@localBodyID", SqlDbType.NVarChar, 500).Value = ddlLocalBody.SelectedValue;
                //cmd.Parameters.Add("@status", SqlDbType.NVarChar, 500).Value = rbtnStatus.SelectedValue;
                //cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 500).Value = mob;
                //cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 500).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                //con.Open();
                //i= cmd.ExecuteNonQuery();
                //con.Close();

                //if (dtset.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToString(dtset.Tables[0].Rows[0]["PartyId"]) == hdnfieldpartyID.Value && Convert.ToString(dtset.Tables[0].Rows[0]["MobileNo"]) == txtPartyReMoNo.Text.Trim())
                //    {
                //        string qry2 = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsActive]='0' WHERE  [PartyId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["PartyId"]) + "' AND [RoleId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["RoleId"]) + "' AND [DistrictId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["DistrictId"]) + "' AND [LocalBodyId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["LocalBodyId"]) + "' ";
                //        cc.ExecuteNonQuery(qry2);


                //        qry = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [Rep_Name]='" + txtRepresNm.Text + "',[PartyId]='" + hdnfieldpartyID.Value + "'," +
                //                    "[RoleId]='" + ddlRole.SelectedValue + "',[RoleName]='" + ddlRole.SelectedItem + "',[DistrictId]='" + hdnfieldDist.Value + "' " +
                //                    ",[LocalBodyId]='" + hdnFieldLocal.Value + "',[IsActive]='" + rbtnStatus.SelectedValue + "',[ModifiedBy]='" + mob + "',[Modifieddate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' " +
                //                    "WHERE [PartyId]='" + hdnfieldpartyID.Value + "' AND [MobileNo]='" + txtPartyReMoNo.Text.Trim() + "'";
                //        i = cc.ExecuteNonQuery(qry);
                //    }
                //    else
                //    {
                //        string qry2 = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsActive]='0' WHERE [PartyId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["PartyId"]) + "' AND [RoleId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["RoleId"]) + "' AND [DistrictId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["DistrictId"]) + "' AND [LocalBodyId]='" + Convert.ToString(dtset.Tables[0].Rows[0]["LocalBodyId"]) + "' ";
                //        cc.ExecuteNonQuery(qry2);

                //        qry = "INSERT INTO [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] ([MobileNo],[Rep_Name],[PartyId]," +
                //                                       "[RoleId],[RoleName],[DistrictId],[LocalBodyId],[IsActive],[CreatedBy],[CreatedDate]) VALUES (" +
                //                                       "'" + txtPartyReMoNo.Text.Trim() + "','" + txtRepresNm.Text + "','" + hdnfieldpartyID.Value + "'" +
                //                                       ",'" + ddlRole.SelectedValue + "','" + ddlRole.SelectedItem + "','" + hdnfieldDist.Value + "'" +
                //                                       ",'" + hdnFieldLocal.Value + "','" + rbtnStatus.SelectedValue + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                //        i = cc.ExecuteNonQuery(qry);
                //    }
                //}
                //else
                //{
                //    string qry62 = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsActive]='0' WHERE [PartyId]='" + hdnfieldpartyID.Value + "' AND [RoleId]='" + ddlRole.SelectedValue + "' AND [DistrictId]='" + hdnfieldDist.Value + "' AND [LocalBodyId]='" + hdnFieldLocal.Value + "' ";
                //    cc.ExecuteNonQuery(qry62);

                //    qry = "INSERT INTO [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] ([MobileNo],[Rep_Name],[PartyId]," +
                //                "[RoleId],[RoleName],[DistrictId],[LocalBodyId],[IsActive],[CreatedBy],[CreatedDate]) VALUES (" +
                //                "'" + txtPartyReMoNo.Text.Trim() + "','" + txtRepresNm.Text + "','" + hdnfieldpartyID.Value + "'" +
                //                ",'" + ddlRole.SelectedValue + "','" + ddlRole.SelectedItem + "','" + hdnfieldDist.Value + "'" +
                //                ",'" + hdnFieldLocal.Value + "','" + rbtnStatus.SelectedValue + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                //    i = cc.ExecuteNonQuery(qry);
                //}
                #endregion
                SqlParameter[] par = new SqlParameter[11];
                par[0] = new SqlParameter("@repName", txtRepresNm.Text);
                par[1] = new SqlParameter("@prtyId", hdnfieldpartyID.Value.ToString());
                par[2] = new SqlParameter("@ddlroleId", ddlRole.SelectedValue.ToString());
                par[3] = new SqlParameter("@ddlroleName", ddlRole.SelectedItem.ToString());

                par[4] = new SqlParameter("@dist", hdnfieldDist.Value.ToString());
                par[5] = new SqlParameter("@lbId", hdnFieldLocal.Value.ToString());
                par[6] = new SqlParameter("@status", rbtnStatus.SelectedValue.ToString());
                par[7] = new SqlParameter("@mob",mob);
                par[8] = new SqlParameter("@dt", System.DateTime.Now.ToString("yyyy-MM-dd"));
                par[9] = new SqlParameter("@PartyReMoNo", txtPartyReMoNo.Text.ToString());
                par[10] = new SqlParameter("@returnValue", SqlDbType.Int);
                par[10].Direction = ParameterDirection.InputOutput;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAddPartyRepresentative", par);

                string j = par[10].Value.ToString();

                if (j=="101")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Submitted Successfully..')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Basic Data Not Submitted')", true);
                }
                ClearMethod();
                BindGridView();

            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ClearMethod();
        }

        public void ClearMethod()
        {
            btnSubmit.Text = "Submit";
            txtPartyReMoNo.Text = string.Empty;
            txtpid.Text = string.Empty;
            txtRepresNm.Text = string.Empty;
            ddlRole.SelectedValue = "0";
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

        protected void lnkbtnDeActive_Click(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            string pid = lnkEdit.CommandArgument;
            cmd.CommandText = "uspUpdatePartyRep";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 10).Value = pid;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 10).Value = mob;
            cmd.Parameters.Add("@Modifieddate", SqlDbType.NVarChar, 10).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "1";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsActive]='0' ,[ModifiedBy]='" + mob + "',[Modifieddate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [ID]='" + pid + "'";
            //cc.ExecuteNonQuery(qry);
            BindGridView();
        }

        protected void lnkbtnisActive_Click(object sender, EventArgs e)
        {
            LinkButton lnkEdit = (LinkButton)sender;
            string pid = lnkEdit.CommandArgument;

            cmd.CommandText = "uspUpdatePartyRep";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 10).Value = pid;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar, 10).Value = mob;
            cmd.Parameters.Add("@Modifieddate", SqlDbType.NVarChar, 10).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "2";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //string qry = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsActive]='1' ,[ModifiedBy]='" + mob + "',[Modifieddate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [ID]='" + pid + "'";
            //cc.ExecuteNonQuery(qry);
            BindGridView();
        }

        protected void gvPartyRepresData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPartyRepresData.PageIndex = e.NewPageIndex;
            gvPartyRepresData.DataSource = ViewState["gridData"];
            gvPartyRepresData.DataBind();
        }

        //protected void txtPartyReMoNo1_TextChanged(object sender, EventArgs e)
        //{
        //    //string txtch = "Select * FROM [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] WHERE  [MobileNo]='" + txtPartyReMoNo.Text.Trim() + "' AND [IsActive]='1'";
        //    //DataSet dsd = new DataSet();
        //    //dsd = cc.ExecuteDataset(txtch);
        //    cmd.CommandText = "uspBindRepsData";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = txtPartyReMoNo.Text.Trim();
        //    cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "4";
        //    da = new SqlDataAdapter(cmd);
        //    DataSet dsd = new DataSet();
        //    da.Fill(dsd);
        //    if (dsd.Tables[0].Rows.Count > 0)
        //    {
        //        string distnm = dsd.Tables[0].Rows[0]["DistrictId"].ToString();

        //        //string dist = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
        //        //DataSet DS = new DataSet();
        //        //DS = cc.ExecuteDataset(dist);
        //        cmd.CommandText = "uspBindDistrict";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = con;
        //        cmd.Parameters.Clear();
        //        da = new SqlDataAdapter(cmd);
        //        DataSet DS = new DataSet();
        //        da.Fill(DS);
        //        if (DS.Tables[0].Rows.Count > 0)
        //        {
        //            ddlDistirct.DataSource = DS.Tables[0];
        //            ddlDistirct.DataTextField = "DistrictName";
        //            ddlDistirct.DataValueField = "DistrictCode";
        //            ddlDistirct.DataBind();
        //            ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlDistirct.SelectedValue = distnm;
        //        }

        //        string lid = dsd.Tables[0].Rows[0]["LocalBodyId"].ToString();

        //        //string lb = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + distnm + "'";
        //        //ds.Clear();
        //        //ds = cc.ExecuteDataset(lb);
        //        cmd.CommandText = "uspBindRepsData";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = con;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = ddlDistirct.SelectedValue;
        //        cmd.Parameters.Add("@query", SqlDbType.NVarChar, 10).Value = "3";
        //        da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ddlLocalBody.DataSource = ds.Tables[0];
        //            ddlLocalBody.DataTextField = "ElectionName";
        //            ddlLocalBody.DataValueField = "ElectionId";
        //            ddlLocalBody.DataBind();
        //            ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlLocalBody.SelectedValue = lid;
        //        }
        //        ddlRole.SelectedValue = dsd.Tables[0].Rows[0]["RoleId"].ToString();
        //        txtRepresNm.Text = dsd.Tables[0].Rows[0]["Rep_Name"].ToString();
        //    }
        //    else
        //    {

        //    }
        //}

        //protected void ddlPartyType_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    string qry = " SELECT [PID],[PTID],[PartyName]FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PTID]='" + ddlPartyType.SelectedValue + "'";
        //    DataSet DsParty = new DataSet();
        //    DsParty = cc.ExecuteDataset(qry);

        //    if (DsParty.Tables[0].Rows.Count > 0)
        //    {
        //        ddlParty.DataSource = DsParty.Tables[0];
        //        ddlParty.DataTextField = "PartyName";
        //        ddlParty.DataValueField = "PID";
        //        ddlParty.DataBind();
        //        ddlParty.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlParty.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //    }
        //}
    }
}