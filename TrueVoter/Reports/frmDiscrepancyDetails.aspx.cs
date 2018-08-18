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
    public partial class frmDiscrepancyDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        CommonCode cc = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                string d = Request.QueryString[0];
                if (d != "")
                {
                    try
                    {
                        d = cc.DESDecrypt(d);
                        string[] d1 = d.Split('$');
                        ViewState["MobileNo"] = d1[0].ToString();
                        hfCanMob.Value = d1[0].ToString();
                        hfDistId.Value = d1[1].ToString();
                        hfLbId.Value = d1[2].ToString();
                        hfWard.Value = d1[3].ToString();
                        hfLbTyp.Value = d1[4].ToString();

                        //DataSet dsExpe = new DataSet();
                        //SqlParameter[] par1 = new SqlParameter[1];
                        //par1[0] = new SqlParameter("@mobileNo", d1[0].ToString());

                        //dsExpe = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDailyExpense", par1);
                        //int dsCnt = dsExpe.Tables[0].Rows.Count;
                        //if (dsCnt > 0)
                        //{
                        //    ViewState["DailyExp"] = dsExpe.Tables[0];
                        //    gvDailyExpenses.DataSource = dsExpe.Tables[0];
                        //    gvDailyExpenses.DataBind();
                        //}
                        //else
                        //{
                        //    gvDailyExpenses.EmptyDataText = "No Data Found";
                        //    gvDailyExpenses.DataBind();
                        //}

                        //SqlParameter[] par2 = new SqlParameter[1];
                        //par2[0] = new SqlParameter("@mob", d1[0].ToString());
                        //DataSet dsFund = new DataSet();
                        //dsFund = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandiFundDtls", par2);
                        //if (dsFund.Tables[0].Rows.Count > 0)
                        //{
                        //    gvFundDetails.DataSource = dsFund.Tables[0];
                        //    gvFundDetails.DataBind();
                        //}
                        //else
                        //{
                        //    gvFundDetails.EmptyDataText = "No Data Found";
                        //    gvFundDetails.DataBind();
                        //}



                        SqlParameter[] par = new SqlParameter[5];
                        par[0] = new SqlParameter("@DistId", 0);
                        par[1] = new SqlParameter("@lbId", 0);
                        par[2] = new SqlParameter("@wardNo", 0);
                        par[4] = new SqlParameter("@CanMoNo", d1[0].ToString());
                        par[3] = new SqlParameter("@qry", "2");
                        DataSet ds = new DataSet();
                        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandiListWardWiseDescri", par);



                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ViewState["myData"] = ds.Tables[0];
                            FvDiscrepancyDetails.DataSource = ds.Tables[0];
                            FvDiscrepancyDetails.DataBind();

                            SqlParameter[] para = new SqlParameter[1];
                            para[0] = new SqlParameter("@CanMoNo", d1[0].ToString());
                            DataSet dsExp = new DataSet();
                            dsExp = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetTotalExpenseCandi", para);

                            try
                            {
                                if (dsExp.Tables[0].Rows.Count > 0)
                                {
                                    lblTotalExp.Text = Convert.ToString(dsExp.Tables[0].Rows[0][0]);
                                }
                            }
                            catch
                            {
                                lblTotalExp.Text = "Nill";
                            }

                            try
                            {
                                if (dsExp.Tables[1].Rows.Count > 0)
                                {
                                    try { lblExpparty.Text = Convert.ToString(dsExp.Tables[1].Rows[1][1]); }
                                    catch { lblExpparty.Text = "Nill"; }

                                    try { lblExpSelf.Text = Convert.ToString(dsExp.Tables[1].Rows[2][1]); }
                                    catch { lblExpSelf.Text = "Nill"; }

                                    try { lblExpOther.Text = Convert.ToString(dsExp.Tables[1].Rows[0][1]); }
                                    catch { lblExpOther.Text = "Nill"; }
                                    //gvSorceExp.DataSource = dsExp.Tables[1];
                                    //gvSorceExp.DataBind();
                                }
                                else
                                {
                                    lblExpparty.Text = "Nill";
                                    lblExpSelf.Text = "Nill";
                                    lblExpOther.Text = "Nill";
                                    //gvSorceExp.EmptyDataText = "No Data Found";
                                    //gvSorceExp.DataBind();
                                }
                            }
                            catch
                            {

                                //gvSorceExp.EmptyDataText = "No Data Found";
                                //gvSorceExp.DataBind();
                            }

                            try
                            {
                                if (dsExp.Tables[2].Rows.Count > 0)
                                {
                                    lblTotalFund.Text = Convert.ToString(dsExp.Tables[2].Rows[0][0]);
                                }
                            }
                            catch
                            {
                                lblTotalFund.Text = "Nill";
                            }


                            try
                            {
                                if (dsExp.Tables[3].Rows.Count > 0)
                                {
                                    try { lblSelf.Text = Convert.ToString(dsExp.Tables[3].Rows[0][1]); }
                                    catch { lblSelf.Text = "Nill"; }

                                    try { lblParty.Text = Convert.ToString(dsExp.Tables[3].Rows[1][1]); }
                                    catch { lblParty.Text = "Nill"; }

                                    try { lblSupporter.Text = Convert.ToString(dsExp.Tables[3].Rows[2][1]); }
                                    catch { lblSupporter.Text = "Nill"; }

                                    try { lblRelative.Text = Convert.ToString(dsExp.Tables[3].Rows[3][1]); }
                                    catch { lblRelative.Text = "Nill"; }

                                    try { lblFriend.Text = Convert.ToString(dsExp.Tables[3].Rows[4][1]); }
                                    catch { lblFriend.Text = "Nill"; }

                                    try { lblWellWisher.Text = Convert.ToString(dsExp.Tables[3].Rows[5][1]); }
                                    catch { lblWellWisher.Text = "Nill"; }


                                    //gvFundFrom.DataSource = dsExp.Tables[3];
                                    //gvFundFrom.DataBind();
                                }
                                else
                                {
                                    lblSelf.Text = "Nill";
                                    lblParty.Text = "Nill";
                                    lblSupporter.Text = "Nill";
                                    lblRelative.Text = "Nill";
                                    lblFriend.Text = "Nill";
                                    lblWellWisher.Text = "Nill";
                                    //gvFundFrom.EmptyDataText = "No Data Found";
                                    //gvFundFrom.DataBind();
                                }
                            }
                            catch
                            {
                                lblSelf.Text = "Nill";
                                lblParty.Text = "Nill";
                                lblSupporter.Text = "Nill";
                                lblRelative.Text = "Nill";
                                lblFriend.Text = "Nill";
                                lblWellWisher.Text = "Nill";
                                //gvFundFrom.EmptyDataText = "No Data Found";
                                //gvFundFrom.DataBind();
                            }

                            try
                            {
                                if (dsExp.Tables[4].Rows.Count > 0)
                                {
                                    lblPartyExpe.Text = Convert.ToString(dsExp.Tables[4].Rows[0][0]);
                                }
                            }
                            catch
                            {
                                lblPartyExpe.Text = "Nill";
                            }

                            try
                            {
                                if (dsExp.Tables[5].Rows.Count > 0)
                                {
                                    gvPrtyExpCan.DataSource = dsExp.Tables[5];
                                    gvPrtyExpCan.DataBind();
                                }
                                else
                                {
                                    gvPrtyExpCan.EmptyDataText = "No Data Found";
                                    gvPrtyExpCan.DataBind();
                                }
                            }
                            catch
                            {

                                gvPrtyExpCan.EmptyDataText = "No Data Found";
                                gvPrtyExpCan.DataBind();
                            }
                            try
                            {
                                if (dsExp.Tables[6].Rows.Count > 0)
                                {

                                    ViewState["DailyExp"] = dsExp.Tables[6];
                                    gvDailyExpenses.DataSource = dsExp.Tables[6];
                                    gvDailyExpenses.DataBind();
                                }
                                else
                                {
                                    gvDailyExpenses.EmptyDataText = "No Data Found";
                                    gvDailyExpenses.DataBind();
                                }
                            }
                            catch
                            {

                                gvDailyExpenses.EmptyDataText = "No Data Found";
                                gvDailyExpenses.DataBind();
                            }

                            try
                            {
                                if (dsExp.Tables[7].Rows.Count > 0)
                                {
                                    gvFundDetails.DataSource = dsExp.Tables[7];
                                    gvFundDetails.DataBind();
                                }
                                else
                                {
                                    gvFundDetails.EmptyDataText = "No Data Found";
                                    gvFundDetails.DataBind();
                                }
                            }
                            catch
                            {

                                gvFundDetails.EmptyDataText = "No Data Found";
                                gvFundDetails.DataBind();
                            }

                        }
                        else
                        {
                            ViewState["myData"] = "No Data Found";
                            FvDiscrepancyDetails.EmptyDataText = "No Data Found";
                            FvDiscrepancyDetails.DataBind();
                        }
                    }
                    catch
                    {
                        Response.Redirect("frmHomeUser.aspx");
                    }
                }
                else
                {
                    Response.Redirect("frmHomeUser.aspx");
                }
            }
        }

        protected void gvPrtyExpCan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvPrtyExpCan_DataBound(object sender, EventArgs e)
        {
            for (int i = gvPrtyExpCan.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow CurrentRow = gvPrtyExpCan.Rows[i];
                GridViewRow PreviousRow = gvPrtyExpCan.Rows[i - 1];

                if (CurrentRow.Cells[1].Text == PreviousRow.Cells[1].Text)
                {
                    if (PreviousRow.Cells[1].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[1].RowSpan == 0)
                        {
                            PreviousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[1].RowSpan = CurrentRow.Cells[1].RowSpan + 1;
                        }
                        CurrentRow.Cells[1].Visible = false;
                    }
                }
                if (CurrentRow.Cells[2].Text == PreviousRow.Cells[2].Text)
                {
                    if (PreviousRow.Cells[2].RowSpan == 0)
                    {
                        if (CurrentRow.Cells[2].RowSpan == 0)
                        {
                            PreviousRow.Cells[2].RowSpan += 2;
                        }
                        else
                        {
                            PreviousRow.Cells[2].RowSpan = CurrentRow.Cells[2].RowSpan + 1;
                        }
                        CurrentRow.Cells[2].Visible = false;
                    }
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            string qs = hfDistId.Value + "$" + hfLbId.Value + "$" + hfWard.Value + "$" + hfLbTyp.Value;
            qs = cc.DESEncrypt(qs);
            Response.Redirect("frmDiscrepancy.aspx?data=" + qs + "");
        }

        protected void ApproveRecord(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            //cmd = new SqlCommand();
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //int updatecount = 0;

            //for (int i = 0; i < gvDailyExpenses.Rows.Count; i++)// 
            //{
            //    CheckBox chkbox = ((CheckBox)gvDailyExpenses.Rows[i].Cells[12].FindControl("CheckBox1"));
            //    if (chkbox != null)
            //    {
            //        if (chkbox.Checked == true)
            //        {
            //            gvSNO += Convert.ToString(gvDailyExpenses.DataKeys[i].Value) + ",";
            //            updatecount++;
            //        }
            //    }
            //    chkbox.Checked = false;
            //}
            SqlParameter[] par = new SqlParameter[5];
            par[0] = new SqlParameter("@DistId", 0);
            par[1] = new SqlParameter("@lbId", 0);
            par[2] = new SqlParameter("@wardNo", 0);
            par[4] = new SqlParameter("@CanMoNo", ViewState["MobileNo"].ToString());
            par[3] = new SqlParameter("@qry", "2");
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCandiListWardWiseDescri", par);
            string DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
            string lb = Convert.ToString(ds.Tables[0].Rows[0]["LocalBodyName"]);
            string[] lbs = lb.Split('-');
            string lbId = lbs[0].ToString();
            string lbName = lbs[1].ToString();
            string WardNo = Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]);
            string CandidateDistrictID = Convert.ToString(ds.Tables[0].Rows[0]["CandidateDistrictID"]);
            string Date = System.DateTime.Now.ToString("yyyy-MM-dd");

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
            }

            SqlParameter[] par3 = new SqlParameter[5];
            par3[0] = new SqlParameter("@CanMoNo", ViewState["MobileNo"].ToString());
            par3[1] = new SqlParameter("@ExId", gvSNO);
            DataSet ds1 = new DataSet();
            ds1 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetIdWiseCandidateDailyExpense", par3);
            ViewState["dt"] = ds1.Tables[0];

            DataTable dtsendmsg = new DataTable();
            int vr = Convert.ToInt32(gvSNO);

            dtsendmsg = (DataTable)ViewState["dt"];

            IEnumerable<DataRow> query = from element in dtsendmsg.AsEnumerable()
                                         where (element.Field<int>("PK_Id") == vr)
                                         select element;
            DataTable dt11 = query.CopyToDataTable<DataRow>();

            Application["dt11"] = dt11;

            Response.Redirect("~/Reports/DeviationDetails.aspx?var=" + gvSNO + "$" + DistrictName + "$" + lbName + "$" + Date + "$" + WardNo + "$" + CandidateDistrictID + "$" + lbId + "$3$Deviation");
        }

        protected void gvDailyExpenses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDailyExpenses.PageIndex = e.NewPageIndex;
            gvDailyExpenses.DataSource = (DataTable)ViewState["DailyExp"];
            gvDailyExpenses.DataBind();
        }

        protected void btnsenNotice_Click(object sender, EventArgs e)
        {
            try
            {
                string qs = hfCanMob.Value + "$" + hfLbId.Value + "$" + hfWard.Value + "$" + hfLbTyp.Value + "$" + hfDistId.Value;
                qs = cc.DESEncrypt(qs);
                Response.Redirect("frmDiscrepancySendNotice.aspx?data=" + qs + "");
            }
            catch (Exception)
            {

            }
        }

    }
}