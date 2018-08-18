using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmVoterObjectionDtls : System.Web.UI.Page
    {
        string mob = string.Empty;
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        CommonCode cc = new CommonCode();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    btnExcel.Visible = false;
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
            else
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    btnExcel.Visible = false;
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
        }
        //[ID],[MobileNo],[Name],[EmailID],[DistrictId],[LocalBody],[LocalBodyID],[ComplaintType],[ACNo],[PARTNo],[SRNo],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[Latitude],[Longitude],[IsCorrect],[IsCorLatitude],[IsCorLongitude],[IsCorrectedBy],[IsCorrectedDate],[IsCorRefMobNo],[IsApprove],[IsAppLatitude],[IsAppLongitude],[IsApproveBy],[IsApproveDate],[IsAppRefMobNo],[CreatedDate],[ExpectedWard],[DocID]
        public DataSet BindGrid()
        {
            #region COMMENT
            //string qurey = string.Empty;
            //if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text == "")
            //{
            //    qurey = "SELECT [ID],[MobileNo],[Name],[LocalBodyID],[ACNo],[PARTNo],[SRNo],[ExpectedWard],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[IsCorrect],[IsCorrectedBy] AS CorrectedBy,[IsApprove] AS IsApproved,[IsApproveBy] AS ApprovedBy,[CreatedDate] AS ObjectionDate FROM [TrueVoterDB].[dbo].[tblComplaint]  WHERE [ACNo]='" + txtACNO.Text.Trim() + "'";
            //}
            //else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text == "")
            //{
            //    qurey = "SELECT [ID],[MobileNo],[Name],[LocalBodyID],[ACNo],[PARTNo],[SRNo],[ExpectedWard],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[IsCorrect],[IsCorrectedBy] AS CorrectedBy,[IsApprove] AS IsApproved,[IsApproveBy] AS ApprovedBy,[CreatedDate] AS ObjectionDate FROM [TrueVoterDB].[dbo].[tblComplaint] WHERE [ACNo]='" + txtACNO.Text.Trim() + "' AND [PARTNo]='" + txtPartNo.Text.Trim() + "'";
            //}
            //else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text != "")
            //{
            //    qurey = "SELECT [ID],[MobileNo],[Name],[LocalBodyID],[ACNo],[PARTNo],[SRNo],[ExpectedWard],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[IsCorrect],[IsCorrectedBy] AS CorrectedBy,[IsApprove] AS IsApproved,[IsApproveBy] AS ApprovedBy ,[CreatedDate] AS ObjectionDate FROM [TrueVoterDB].[dbo].[tblComplaint] WHERE [ACNo]='" + txtACNO.Text.Trim() + "' AND [PARTNo]='" + txtPartNo.Text.Trim() + "' AND [ExpectedWard]='" + txtExpectedWard.Text.Trim() + "'";
            //}
            //else if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text != "")
            //{
            //    qurey = "SELECT [ID],[MobileNo],[Name],[LocalBodyID],[ACNo],[PARTNo],[SRNo],[ExpectedWard],[VoterName],[VoterMoNo],[ObjectionType],[Remark],[IsCorrect],[IsCorrectedBy] AS CorrectedBy,[IsApprove] AS IsApproved,[IsApproveBy] AS ApprovedBy,[CreatedDate] AS ObjectionDate FROM [TrueVoterDB].[dbo].[tblComplaint] WHERE [ACNo]='" + txtACNO.Text.Trim() + "'  AND [ExpectedWard]='" + txtExpectedWard.Text.Trim() + "'";
            //}
            //ds.Clear();
            //return ds = cc.ExecuteDataset(qurey);
            #endregion


            if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text == "")
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@p1", txtACNO.Text.Trim());
                par[1] = new SqlParameter("@p2", "0");
                par[2] = new SqlParameter("@p3", "0");
                par[3] = new SqlParameter("@p4", "1");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetComplaints", par);
            }
            else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text == "")
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@p1", txtACNO.Text.Trim());
                par[1] = new SqlParameter("@p2", txtPartNo.Text.Trim());
                par[2] = new SqlParameter("@p3", "0");
                par[3] = new SqlParameter("@p4", "2");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetComplaints", par);
            }
            else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text != "")
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@p1", txtACNO.Text.Trim());
                par[1] = new SqlParameter("@p2", txtPartNo.Text.Trim());
                par[2] = new SqlParameter("@p3", txtExpectedWard.Text.Trim());
                par[3] = new SqlParameter("@p4", "3");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetComplaints", par);
            }
            else if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text != "")
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@p1", txtACNO.Text.Trim());
                par[1] = new SqlParameter("@p2", "0");
                par[2] = new SqlParameter("@p3", txtExpectedWard.Text.Trim());
                par[3] = new SqlParameter("@p4", "4");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetComplaints", par);
            }

            return ds;

        }

        public DataSet BindGridView()
        {
            cmd.CommandText = "uspDownloadVoterObjection";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text == "")
            {
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 10).Value = "1";
                cmd.Parameters.Add("@ACNo", SqlDbType.NVarChar, 10).Value = txtACNO.Text.Trim();
                cmd.Parameters.Add("@PARTNo", SqlDbType.NVarChar, 10).Value = txtPartNo.Text.Trim();
                cmd.Parameters.Add("@ExpecWard", SqlDbType.NVarChar, 10).Value = txtExpectedWard.Text.Trim();
            }
            else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text == "")
            {
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 10).Value = "2";
                cmd.Parameters.Add("@ACNo", SqlDbType.NVarChar, 10).Value = txtACNO.Text.Trim();
                cmd.Parameters.Add("@PARTNo", SqlDbType.NVarChar, 10).Value = txtPartNo.Text.Trim();
                cmd.Parameters.Add("@ExpecWard", SqlDbType.NVarChar, 10).Value = txtExpectedWard.Text.Trim();
            }
            else if (txtACNO.Text != "" && txtPartNo.Text != "" && txtExpectedWard.Text != "")
            {
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 10).Value = "3";
                cmd.Parameters.Add("@ACNo", SqlDbType.NVarChar, 10).Value = txtACNO.Text.Trim();
                cmd.Parameters.Add("@PARTNo", SqlDbType.NVarChar, 10).Value = txtPartNo.Text.Trim();
                cmd.Parameters.Add("@ExpecWard", SqlDbType.NVarChar, 10).Value = txtExpectedWard.Text.Trim();
            }
            else if (txtACNO.Text != "" && txtPartNo.Text == "" && txtExpectedWard.Text != "")
            {
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 10).Value = "4";
                cmd.Parameters.Add("@ACNo", SqlDbType.NVarChar, 10).Value = txtACNO.Text.Trim();
                cmd.Parameters.Add("@PARTNo", SqlDbType.NVarChar, 10).Value = txtPartNo.Text.Trim();
                cmd.Parameters.Add("@ExpecWard", SqlDbType.NVarChar, 10).Value = txtExpectedWard.Text.Trim();
            }
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;

        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GridView gvData = new GridView();
            gvData.AllowPaging = false;
            gvData.DataSource = BindGrid();
            gvData.DataBind();

            string VoterObjection = "VoterObjection" + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvVoterObjection.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + VoterObjection + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvData.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            gvVoterObjection.DataSource = BindGrid();
            gvVoterObjection.DataBind();
            btnExcel.Visible = true;
        }
        protected void gvVoterObjection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoterObjection.PageIndex = e.NewPageIndex;
            gvVoterObjection.DataSource = BindGrid();
            gvVoterObjection.DataBind();
            btnExcel.Visible = true;
        }

        protected void gvVoterObjection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TableCell EntryBy = e.Row.Cells[12];
            //    if (EntryBy.Text == "1")
            //    {
            //        EntryBy.Text = "Accepted";
            //        //EntryBy.BackColor = System.Drawing.Color.Green;
            //    }
            //    else //(EntryBy.Text == "" || EntryBy.Text == "1" )
            //    {
            //        EntryBy.Text = "Rejected";
            //        //EntryBy.BackColor = System.Drawing.Color.Red;
            //    }

            //    TableCell EntryByApp = e.Row.Cells[14];
            //    if (EntryBy.Text == "1")
            //    {
            //        EntryByApp.Text = "Approved";
            //        //EntryBy.BackColor = System.Drawing.Color.Green;
            //    }
            //    else //(EntryBy.Text == "" || EntryBy.Text == "1" )
            //    {
            //        EntryByApp.Text = "Disapproved";
            //        //EntryBy.BackColor = System.Drawing.Color.Red;
            //    }
            //}
                
        }

        //protected void lnkDoc_Click(object sender, EventArgs e)
        //{
        //    string gvSNO = string.Empty;
        //    LinkButton lnkRemoveDeactive = (LinkButton)sender;
        //    gvSNO = lnkRemoveDeactive.CommandArgument;

        //    //string qurey = "SELECT [DocumentPhoto] FROM [TrueVoterDB].[dbo].[tblComplaintPhotos] WHERE [ComID]='" + gvSNO + "'";
        //   // ds.Clear();
        //   // ds = cc.ExecuteDataset(qurey);
        //   // string src = "data:image/gif;base64," + Convert.ToString(ds.Tables[0].Rows[0][0]);
        //    Response.Redirect("PageToShowImage.aspx?UserId=" + gvSNO);
        //   // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "DisplayImage(this)", true);
        //}

        //protected void lnkHome_Click(object sender, EventArgs e)
        //{
        //    string gvSNO = string.Empty;
        //    LinkButton lnkRemoveDeactive = (LinkButton)sender;
        //    gvSNO = lnkRemoveDeactive.CommandArgument;

        //    string qurey = "SELECT [HomePhoto] FROM [TrueVoterDB].[dbo].[tblComplaintPhotos] WHERE [ComID]='" + gvSNO + "'";
        //    ds.Clear();
        //    ds = cc.ExecuteDataset(qurey);
        //}
    }
}