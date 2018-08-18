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
    public partial class AddProformaNo5 : System.Web.UI.Page
    {
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        CommonCode cc = new CommonCode();
        string mob = string.Empty;
        string roleID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    //BindDistrict();
                    GetBasicData();
                    BindGridView();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        //public void BindDistrict()
        //{
        //    DataSet ds = new DataSet();
        //    ds = objBAL.BindDistrictBAL();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlDistirct.DataSource = ds.Tables[0];
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
        //    DataSet ds = new DataSet();
        //    objBAL.DistrictId = Convert.ToInt32(ddlDistirct.SelectedValue);
        //    ds = objBAL.BindLocalBodyBAL(objBAL);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlLocalBody.DataSource = ds.Tables[0];
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

        //public void BindPartyType()
        //{
        //    DataSet ds = new DataSet();
        //    ds = objBAL.BindPartyTypeBAL();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlPartytype.DataSource = ds.Tables[0];
        //        ddlPartytype.DataTextField = "PartyType";
        //        ddlPartytype.DataValueField = "PTID";
        //        ddlPartytype.DataBind();
        //        ddlPartytype.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlPartytype.SelectedIndex = 0;
        //    }
        //    else
        //    {

        //    }
        //}

        //protected void ddlPartytype_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataSet ds = new DataSet();
        //    objBAL.PartyTypeId = Convert.ToInt32(ddlPartytype.SelectedValue);
        //    ds = objBAL.BindPartyBAL(objBAL);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ddlPartyName.DataSource = ds.Tables[0];
        //        ddlPartyName.DataTextField = "PartyName";
        //        ddlPartyName.DataValueField = "PID";
        //        ddlPartyName.DataBind();
        //        ddlPartyName.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlPartyName.SelectedIndex = 0;
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (mob != null)
            {
                try
                {
                    int i = 0;
                    objBAL.Id = Convert.ToInt32(txtId.Text);
                    objBAL.PartyTypeId = Convert.ToInt32(hdnfieldpartytypID.Value);
                    objBAL.PartyNameId = Convert.ToInt32(hdnfieldpartyID.Value);
                    objBAL.DistrictId = Convert.ToInt32(hfDistID.Value);
                    objBAL.LocalBodyTypeID = Convert.ToInt32(hfLType.Value);
                    objBAL.LocalBodyTypeName = txtLBtype.Text;
                    objBAL.LocalBodyId = Convert.ToInt32(hfLbNameID.Value);
                    objBAL.LocalBodyName = txtLBName.Text;
                    objBAL.ElectionTypeId = Convert.ToInt32(ddlElectionType.SelectedValue);
                    objBAL.ElectionType = ddlElectionType.SelectedItem.Text;
                    objBAL.ElectionDate = Convert.ToDateTime(txtElectionDate.Text);
                    objBAL.CandidateName = ddlCandList.SelectedItem.Text;
                    objBAL.CandidateMoNo = ddlCandList.SelectedValue;
                    objBAL.WardNo = txtWardNo.Text;
                    objBAL.SeatNo = ddlSeatNo.SelectedItem.Text;
                    objBAL.VerifiedId = Convert.ToInt32(rbtnVerificationSuccess.SelectedValue);
                    objBAL.Verified = rbtnVerificationSuccess.SelectedItem.Text;
                    objBAL.NomiWithdrawId = Convert.ToInt32(rbtnWithdeowalYes.SelectedValue);
                    objBAL.NomiWithdraw = rbtnWithdeowalYes.SelectedItem.Text;
                    objBAL.ElectionResultId = Convert.ToInt32(rbtnElectionWon.SelectedValue);
                    objBAL.ElectionResult = rbtnElectionWon.SelectedItem.Text;
                    objBAL.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                    objBAL.CreatedBy = mob;
                    objBAL.IsActive = "1";

                    if (btnSubmit.Text == "Submit")
                    {
                        i = objBAL.InsertData(objBAL);
                    }
                    else
                    {
                        i = objBAL.UpdateData(objBAL);
                    }
                    if (i > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Inserted Successfully')", true);
                        Clear();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Inserted Failed')", true);
                        Clear();
                    }
                    BindGridView();
                }
                catch
                {
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Session Expired'); window.location='Admin/Login.aspx';", true);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                //Response.Redirect("../Admin/Login.aspx");
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            ddlCandList.SelectedIndex = 0;
            //ddlDistirct.SelectedIndex = 0;
            ddlElectionType.SelectedIndex = 0;
            //ddlLocalBody.SelectedIndex = 0;
            //ddlLocalBodytype.SelectedIndex = 0;
            ddlCandList.Items.Clear();
            //ddlPartyName.SelectedIndex = 0;
            //ddlPartytype.SelectedIndex = 0;
            ddlSeatNo.SelectedIndex = 0;
            txtElectionDate.Text = "";
            txtWardNo.Text = "";
            btnSubmit.Text = "Submit";
        }

        protected void gvCandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCandidateList.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        public void BindGridView()
        {
            DataSet ds = new DataSet();
            objBAL.CreatedBy = mob;
            ds = objBAL.BindGridViewBAL(objBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCandidateList.DataSource = ds.Tables[0];
                gvCandidateList.DataBind();
            }
            else
            {
            }
        }

        protected void gvCandidateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cm = e.CommandName;
            if (cm == "Active")
            {
                objBAL.Id = id;
                objBAL.IsActive = "1";
                objBAL.ChangeStatusBAL(objBAL);
                BindGridView();
            }
            else if (cm == "DeActive")
            {
                objBAL.Id = id;
                objBAL.IsActive = "0";
                objBAL.ChangeStatusBAL(objBAL);
                BindGridView();
            }
            else
            {

                DataSet ds = new DataSet();
                objBAL.Id = Convert.ToInt32(id);
                ds = objBAL.BindSelectedData(objBAL);
                btnSubmit.Text = "Update";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtId.Text = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ElectionDate"]);
                    txtElectionDate.Text = dt.ToString("yyyy-MM-dd");
                    txtWardNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]);
                    
                    string st= Convert.ToString(ds.Tables[0].Rows[0]["SeatNo"]);
                    if(st=="A")
                    {
                        ddlSeatNo.SelectedValue = "1";
                    }
                    else if (st == "B")
                    {
                        ddlSeatNo.SelectedValue = "2";
                    }
                    else if (st == "C")
                    {
                        ddlSeatNo.SelectedValue = "3";
                    }
                    else if (st == "D")
                    {
                        ddlSeatNo.SelectedValue = "4";
                    }
                    else if (st == "E")
                    {
                        ddlSeatNo.SelectedValue = "5";
                    }
                    else
                    {
                        ddlSeatNo.SelectedValue = "0";
                    }
                    ddlElectionType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ElectionTypeId"]);
                    rbtnVerificationSuccess.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VerifiedId"]);
                    rbtnElectionWon.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ElectionResultId"]);
                    rbtnWithdeowalYes.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["NomiWithdrawId"]);

                    hfLbNameID.Value = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyId"]);
                    hfDistID.Value = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);
                    hfLType.Value = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyTypeID"]);

                    txtDistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    txtLBName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);
                    txtPartyType.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyTypeName"]);

                    //if (distID != "0" || distID != "")
                    //{
                    //    DataSet ds2 = new DataSet();
                    //    ds2 = objBAL.BindDistrictBAL();
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        //ddlDistirct.DataSource = ds2.Tables[0];
                    //        //ddlDistirct.DataTextField = "DistrictName";
                    //        //ddlDistirct.DataValueField = "DistrictCode";
                    //        //ddlDistirct.DataBind();
                    //        //ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        //ddlDistirct.SelectedValue = distID;
                    //    }

                    //    DataSet ds4 = new DataSet();
                    //    objBAL.DistrictId = Convert.ToInt32(distID);
                    //    ds4 = objBAL.BindLocalBodyBAL(objBAL);

                    //    if (ds4.Tables[0].Rows.Count > 0)
                    //    {
                    //        //ddlLocalBody.DataSource = ds4.Tables[0];
                    //        //ddlLocalBody.DataTextField = "ElectionName";
                    //        //ddlLocalBody.DataValueField = "ElectionId";
                    //        //ddlLocalBody.DataBind();
                    //        //ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        //ddlLocalBody.SelectedValue = localBody;
                    //    }

                    //}
                    //string party = Convert.ToString(ds.Tables[0].Rows[0]["PartyNameId"]);
                    //string prtytypeId = Convert.ToString(ds.Tables[0].Rows[0]["PartyTypeId"]);
                    //if (prtytypeId != "0" || prtytypeId !="")
                    //{
                    //    DataSet ds1 = new DataSet();
                    //    ds1 = objBAL.BindPartyTypeBAL();

                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        ddlPartytype.DataSource = ds1.Tables[0];
                    //        ddlPartytype.DataTextField = "PartyType";
                    //        ddlPartytype.DataValueField = "PTID";
                    //        ddlPartytype.DataBind();
                    //        ddlPartytype.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        ddlPartytype.SelectedValue = prtytypeId;
                    //    }

                    //    DataSet ds3 = new DataSet();
                    //    objBAL.PartyTypeId = Convert.ToInt32(prtytypeId);
                    //    ds3 = objBAL.BindPartyBAL(objBAL);

                    //    if (ds3.Tables[0].Rows.Count > 0)
                    //    {
                    //        ddlPartyName.DataSource = ds3.Tables[0];
                    //        ddlPartyName.DataTextField = "PartyName";
                    //        ddlPartyName.DataValueField = "PID";
                    //        ddlPartyName.DataBind();
                    //        ddlPartyName.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        ddlPartyName.SelectedValue = party;
                    //    }

                    //}
                    string CandiMoNo = Convert.ToString(ds.Tables[0].Rows[0]["CandidateMoNo"]);
                    if (CandiMoNo != "")
                    {
                        CandidateList();
                        ddlCandList.SelectedValue = CandiMoNo;
                    }
                }
                else
                {

                }
            }
        }

        public void CandidateList()
        {
            DataSet ds = new DataSet();
            objBAL.DistrictId = Convert.ToInt32(hfDistID.Value);
            objBAL.LocalBodyId = Convert.ToInt32(hfLbNameID.Value);
            objBAL.PartyTypeId = Convert.ToInt32(hdnfieldpartytypID.Value);
            objBAL.PartyNameId = Convert.ToInt32(hdnfieldpartyID.Value);
            objBAL.SeatNo = Convert.ToString(ddlSeatNo.SelectedItem.Text);
            objBAL.WardNo = Convert.ToString(txtWardNo.Text);
            ds = objBAL.BindCandidatesBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCandList.DataSource = ds.Tables[0];
                ddlCandList.DataTextField = "usrFullName";
                ddlCandList.DataValueField = "usrMobileNumber";
                ddlCandList.DataBind();
                ddlCandList.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlCandList.SelectedIndex = 0;
            }
            else
            {

            }
        }

        protected void ddlSeatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCandList.Items.Clear();
            CandidateList();
        }
        public void GetBasicData()
        {
            string s = "SELECT [usrMobileNumber],[CandidateRole],[CandidateRoleName],[DistrictName],[CandidateDistrictID],[LocalBodyType],[LocalBodyTypeName],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID]" +
                        ",[usrFullName],[NominationDate],[ElectionDate],[ResultDate],[Age],[OrderNo],[OfficerName],[FatherName],[Place],[MarketPerMoNO],[DivisionId],[DivisionName]" +
                        ",[ElectoralColId],[ElectoralColName],[SeatNo],[ElectionType],[PartyName],[PartyType],[PartyTypeID],[PartyNameID],[ElectionTypeID],[SeatNoID],[BankName],[BankAccNo]" +
                        ",[ElectionTyp],[BlockId],[SECNomiStatus],[InsertedDate] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] LEFT join [TrueVoterDB].[dbo].[tblDistrictMapping]" +
                        "ON [CandidateDistrictID]=[DistrictCode] LEFT JOIN [TrueVoterDB].[dbo].[tblPartyTypeFieldItem] ON [PartyTypeID]=[PTID] LEFT JOIN [TrueVoterDB].[dbo].[LocalBodyTypeMaster]"+
                        "ON [LBTId]=[LocalBodyType] where [usrMobileNumber]='" + mob.Trim() + "'";
            DataSet ds1 = new DataSet();
            ds1 = cc.ExecuteDataset(s);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                string pt = Convert.ToString(ds1.Tables[0].Rows[0]["PartyTypeID"]);
                string ln = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyName"]);
                string cd = Convert.ToString(ds1.Tables[0].Rows[0]["CandidateDistrictID"]);
                string dn = Convert.ToString(ds1.Tables[0].Rows[0]["DistrictName"]);
                string lt = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyType"]);
                if (pt != "" && ln != "" && cd != "")
                {
                    txtDistrict.Text = Convert.ToString(ds1.Tables[0].Rows[0]["DistrictName"]);
                    txtLBName.Text = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyName"]);
                    txtLBtype.Text = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyTypeName"]);

                    txtParty.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyName"]);
                    txtPartyType.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyType"]);
                    hdnfieldpartytypID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyTypeID"]);
                    hdnfieldpartyID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyNameID"]);
                    hfDistID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["CandidateDistrictID"]);
                    hfLbNameID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyID"]);
                    hfLType.Value = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyType"]);
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
            
            
            //string qry = " SELECT A.[PID],A.[PTID],B.[PartyType],A.[PartyName] FROM [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] AS RD "+
            //             " INNER JOIN [TrueVoterDB].[dbo].[tblPartFieldItemMaster] AS A ON RD.[PartyId]=A.[PID] "+
            //             " INNER JOIN [TrueVoterDB].[dbo].[tblPartyTypeFieldItem] AS B ON A.[PTID]=B.[PTID] WHERE RD.[IsActive]='1' AND RD.[MobileNo]='" + mob + "'";
            //DataSet ds1 = new DataSet();
            //ds1 = cc.ExecuteDataset(qry);
            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    txtParty.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyName"]);
            //    txtPartyType.Text = Convert.ToString(ds1.Tables[0].Rows[0]["PartyType"]);
            //    hdnfieldpartytypID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PTID"]);
            //    hdnfieldpartyID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PID"]);//"2";//
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('You are not Authorized Person to Add Party Representative')", true);

            //    Response.Redirect("~/Reports/frmHomeUser.aspx");
            //}
        }
    }
}