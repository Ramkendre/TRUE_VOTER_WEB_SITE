﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class AddProformaNo6 : System.Web.UI.Page
    {
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        string mob = string.Empty;
        string roleID = string.Empty;
        CommonCode cc = new CommonCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null && roleID != "" && mob != null && mob != "")
            {
                if (IsPostBack == false)
                {
                    GetBasicData();
                    BindExpenseHead();
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

        public void GetBasicData()
        {
            string s = "SELECT [usrMobileNumber],[CandidateRole],[CandidateRoleName],[DistrictName],[CandidateDistrictID],[LocalBodyType],[LocalBodyTypeName],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID]" +
                        ",[usrFullName],[NominationDate],[ElectionDate],[ResultDate],[Age],[OrderNo],[OfficerName],[FatherName],[Place],[MarketPerMoNO],[DivisionId],[DivisionName]" +
                        ",[ElectoralColId],[ElectoralColName],[SeatNo],[ElectionType],[PartyName],[PartyType],[PartyTypeID],[PartyNameID],[ElectionTypeID],[SeatNoID],[BankName],[BankAccNo]" +
                        ",[ElectionTyp],[BlockId],[SECNomiStatus],[InsertedDate] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] LEFT join [TrueVoterDB].[dbo].[tblDistrictMapping]" +
                        "ON [CandidateDistrictID]=[DistrictCode] LEFT JOIN [TrueVoterDB].[dbo].[tblPartyTypeFieldItem] ON [PartyTypeID]=[PTID] LEFT JOIN [TrueVoterDB].[dbo].[LocalBodyTypeMaster]" +
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
                if (pt != "" && ln != "" && cd != "" )
                {
                    txtDistrict.Text = Convert.ToString(ds1.Tables[0].Rows[0]["DistrictName"]);
                    txtLBName.Text = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyName"]);
                    txtLBtype.Text = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyTypeName"]);

                    hdnfieldpartytypID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyTypeID"]);
                    hdnfieldpartyID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["PartyNameID"]);
                    hfDistID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["CandidateDistrictID"]);
                    hfLbNameID.Value = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyID"]);
                    hfLType.Value = Convert.ToString(ds1.Tables[0].Rows[0]["LocalBodyType"]);
                    hfEletypeId.Value = Convert.ToString(ds1.Tables[0].Rows[0]["ElectionTypeID"]);
                    hfEletypeName.Value = Convert.ToString(ds1.Tables[0].Rows[0]["ElectionType"]);
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
                    objBAL.ElectionTypeId = Convert.ToInt32(hfEletypeId.Value);
                    objBAL.ElectionType = hfEletypeName.Value;
                    objBAL.ExpenseDate = Convert.ToDateTime(txtExpenseDate.Text);
                    objBAL.ExpenseHeadId = Convert.ToInt32(ddlExpenseHead.SelectedValue);
                    objBAL.ExpenseHeadName = Convert.ToString(ddlExpenseHead.SelectedItem.Text);
                    objBAL.SubExpenseHeadId = Convert.ToInt32(ddlSubExpenseHead.SelectedValue);
                    objBAL.SubExpenseHeadName = Convert.ToString(ddlSubExpenseHead.SelectedItem.Text);
                    objBAL.Description = txtDescription.Text;
                    objBAL.Amount = txtAmount.Text;
                    objBAL.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                    objBAL.CreatedBy = mob;
                    objBAL.IsActive = "1";

                    if (btnSubmit.Text == "Submit")
                    {
                        i = objBAL.InsertProformaNo6Data(objBAL);
                    }
                    else
                    {
                        i = objBAL.UpdateProformaNo6Data(objBAL);
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            ddlExpenseHead.SelectedIndex = 0;
            ddlSubExpenseHead.SelectedIndex = 0;
            txtExpenseDate.Text = "";
            txtAmount.Text = "";
            txtDescription.Text = "";
            btnSubmit.Text = "Submit";
        }

        public void BindGridView()
        {
            DataSet ds = new DataSet();
            objBAL.CreatedBy = mob;
            ds = objBAL.BindGridViewBALProforma6(objBAL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPartyExpense.DataSource = ds.Tables[0];
                gvPartyExpense.DataBind();
            }
            else
            {
            }
        }

        public void BindExpenseHead()
        {
            DataSet ds = new DataSet();
            ds = objBAL.BindPartyExpenseHeadBAL();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlExpenseHead.DataSource = ds.Tables[0];
                ddlExpenseHead.DataTextField = "ExpenseType";
                ddlExpenseHead.DataValueField = "EID";
                ddlExpenseHead.DataBind();

                ddlExpenseHead.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlExpenseHead.SelectedIndex = 0;
            }
            else
            {
            }
        }
        protected void ddlExpenseHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objBAL.DistrictId = Convert.ToInt32(hfDistID.Value);
            objBAL.ExpenseHead = Convert.ToString(ddlExpenseHead.SelectedValue);
            ds = objBAL.BindPartySubExpenseHeadBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlSubExpenseHead.DataSource = ds.Tables[0];
                ddlSubExpenseHead.DataTextField = "SubExpenseType";
                ddlSubExpenseHead.DataValueField = "SEID";
                ddlSubExpenseHead.DataBind();

                ddlSubExpenseHead.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSubExpenseHead.SelectedIndex = 0;
            }
        }
        protected void gvPartyExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPartyExpense.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gvPartyExpense_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cm = e.CommandName;
            if (cm == "Active")
            {
                objBAL.Id = id;
                objBAL.IsActive = "1";
                objBAL.ChangeStatusProformaNo6BAL(objBAL);
                BindGridView();
            }
            else if (cm == "DeActive")
            {
                objBAL.Id = id;
                objBAL.IsActive = "0";
                objBAL.ChangeStatusProformaNo6BAL(objBAL);
                BindGridView();
            }
            else
            {

                DataSet ds = new DataSet();
                objBAL.Id = Convert.ToInt32(id);
                ds = objBAL.BindSelectedDataProformaNo6BAL(objBAL);
                btnSubmit.Text = "Update";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtId.Text = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                    string localBody = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyId"]);
                    string distID = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);


                    hfLbNameID.Value = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyId"]);
                    hfDistID.Value = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);
                    hfLType.Value = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyTypeID"]);
                    hdnfieldpartyID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PartyNameId"]);
                    hdnfieldpartytypID.Value = Convert.ToString(ds.Tables[0].Rows[0]["PartyTypeId"]);

                    txtLBtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyTypeName"]);
                    txtDistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    txtLBName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);
                   

                    //if (distID != "0")
                    //{
                    //    DataSet ds2 = new DataSet();
                    //    ds2 = objBAL.BindDistrictBAL();
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        ddlDistirct.DataSource = ds2.Tables[0];
                    //        ddlDistirct.DataTextField = "DistrictName";
                    //        ddlDistirct.DataValueField = "DistrictCode";
                    //        ddlDistirct.DataBind();
                    //        ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        ddlDistirct.SelectedValue = distID;
                    //    }

                    //    DataSet ds4 = new DataSet();
                    //    objBAL.DistrictId = Convert.ToInt32(distID);
                    //    ds4 = objBAL.BindLocalBodyBAL(objBAL);

                    //    if (ds4.Tables[0].Rows.Count > 0)
                    //    {
                    //        ddlLocalBody.DataSource = ds4.Tables[0];
                    //        ddlLocalBody.DataTextField = "ElectionName";
                    //        ddlLocalBody.DataValueField = "ElectionId";
                    //        ddlLocalBody.DataBind();
                    //        ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                    //        ddlLocalBody.SelectedValue = localBody;
                    //    }

                    //}
                    string ExpenseHead = Convert.ToString(ds.Tables[0].Rows[0]["ExpenseHeadId"]);
                    string SubExpenseHead = Convert.ToString(ds.Tables[0].Rows[0]["SubExpenseHeadId"]);
                    if (distID != "0")
                    {
                        DataSet dsExpenseHead = new DataSet();
                        //dsExpenseHead = objBAL.BindExpenseHeadBAL();
                        dsExpenseHead = objBAL.BindPartyExpenseHeadBAL();
                        if (dsExpenseHead.Tables[0].Rows.Count > 0)
                        {
                            ddlExpenseHead.DataSource = dsExpenseHead.Tables[0];
                            ddlExpenseHead.DataTextField = "ExpenseType";
                            ddlExpenseHead.DataValueField = "EID";
                            ddlExpenseHead.DataBind();
                            ddlExpenseHead.Items.Add("--Select--");
                            ddlExpenseHead.SelectedValue = ExpenseHead;
                        }

                        DataSet dsSubExp = new DataSet();
                        objBAL.DistrictId = Convert.ToInt32(hfDistID.Value);
                        objBAL.ExpenseHead = Convert.ToString(ddlExpenseHead.SelectedValue);
                        //dsSubExp = objBAL.BindSubExpenseHeadBAL(objBAL);
                        dsSubExp = objBAL.BindPartySubExpenseHeadBAL(objBAL);
                        if (dsSubExp.Tables[0].Rows.Count > 0)
                        {
                            ddlSubExpenseHead.DataSource = dsSubExp.Tables[0];
                            ddlSubExpenseHead.DataTextField = "SubExpenseType";
                            ddlSubExpenseHead.DataValueField = "SEID";
                            ddlSubExpenseHead.DataBind();
                            ddlSubExpenseHead.Items.Add("--Select--");
                            ddlSubExpenseHead.SelectedValue = SubExpenseHead;
                        }

                    }
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExpenseDate"]);
                    txtExpenseDate.Text = dt.ToString("yyyy-MM-dd");
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                    txtAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);

                }
                else
                {

                }
            }
        }
    }
}