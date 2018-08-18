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
    public partial class frmAddParty : System.Web.UI.Page
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
                if (IsPostBack == false)
                {
                    BindPartyGrid();
                    btnSubmit.Text = "Submit";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void gvParty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvParty.PageIndex = e.NewPageIndex;
            BindPartyGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (mob != null)
            {
                //string qrybn = "SELECT [PID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [ContactPersonMobile]='" + txtConPerMoNo.Text + "'";
                //ds.Clear();
                //ds = cc.ExecuteDataset(qrybn);


                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@p0", "1");
                par[1] = new SqlParameter("@p1", txtConPerMoNo.Text);
                par[2] = new SqlParameter("@p2", "0");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAddPartyGetData", par);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Entered Mobile No is Already Registered')", true);
                }
                else
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        //string qry = "INSERT INTO [TrueVoterDB].[dbo].[tblPartFieldItemMaster] ([PTID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress],[ContactPersonName],[ContactPersonMobile],[CreatedBy],[CreatedDate],[IsActive])" +
                        //             " VALUES ('" + ddlPartyType.SelectedValue + "','" + txtPartyNm.Text + "','" + txtRegiDate.Text + "','" + txtSymbolnm.Text + "','" + txtAddress.Text + "','" + txtConperNm.Text + "','" + txtConPerMoNo.Text + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','1')";
                        //int i = cc.ExecuteNonQuery(qry);

                        //string qrytwo = "SELECT MAX(PID) FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster](NOLOCK)";
                        //string j = cc.ExecuteScalar(qrytwo);

                        //string qry1 = "INSERT INTO [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] ([MobileNo],[Rep_Name],[PartyId],[CreatedBy],[CreatedDate],[IsActive],[IsAdmin])" +
                        //             " VALUES ('" + txtConPerMoNo.Text + "','" + txtConperNm.Text + "','" + j + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','1','1')";
                        //int k = cc.ExecuteNonQuery(qry1);
                        //int i = 1;

                        SqlParameter[] par1 = new SqlParameter[15];
                        par1[0] = new SqlParameter("@p0", ddlPartyType.SelectedValue.ToString());
                        par1[1] = new SqlParameter("@p1", txtPartyNm.Text);
                        par1[2] = new SqlParameter("@p2", txtRegiDate.Text);
                        par1[3] = new SqlParameter("@p3", txtSymbolnm.Text);
                        par1[4] = new SqlParameter("@p4", txtAddress.Text);
                        par1[5] = new SqlParameter("@p5", txtConperNm.Text);
                        par1[6] = new SqlParameter("@p6", txtConPerMoNo.Text);
                        par1[7] = new SqlParameter("@p7", mob);
                        par1[8] = new SqlParameter("@p8", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par1[9] = new SqlParameter("@p9", "1");
                        par1[10] = new SqlParameter("@p10", SqlDbType.Int);
                        par1[10].Direction = ParameterDirection.InputOutput;
                        
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAddPartyInsert", par1);
                        string k = par1[10].Value.ToString();

                        
                        if (k=="101")//(i > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Party Added Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Insert Failed')", true);
                        }
                        btnSubmit.Text = "Submit";
                    }
                    else
                    {
                        SqlParameter[] par1 = new SqlParameter[15];
                        par1[0] = new SqlParameter("@p0", ddlPartyType.SelectedValue.ToString());
                        par1[1] = new SqlParameter("@p1", txtPartyNm.Text);
                        par1[2] = new SqlParameter("@p2", txtRegiDate.Text);
                        par1[3] = new SqlParameter("@p3", txtSymbolnm.Text);
                        par1[4] = new SqlParameter("@p4", txtAddress.Text);
                        par1[5] = new SqlParameter("@p5", txtConperNm.Text);
                        par1[6] = new SqlParameter("@p6", txtConPerMoNo.Text);
                        par1[7] = new SqlParameter("@p7", mob);
                        par1[8] = new SqlParameter("@p8", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        par1[9] = new SqlParameter("@p9", "1");
                        par1[11] = new SqlParameter("@p11", txtpid.Text);
                        par1[10] = new SqlParameter("@p10", SqlDbType.Int);
                        par1[10].Direction = ParameterDirection.InputOutput;
                        
                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspAddPartyUpdate", par1);
                        string k = par1[10].Value.ToString();

                        
                        if (k=="101")//(i > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Party Updated Successfully')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Updated Failed')", true);
                            }



                        //string qry = "UPDATE [TrueVoterDB].[dbo].[tblPartFieldItemMaster] SET [PTID]='" + ddlPartyType.SelectedValue + "',[PartyName]='" + txtPartyNm.Text + "',[RegistrationDate]='" + txtRegiDate.Text + "'," +
                        //             "[Symbols]='" + txtSymbolnm.Text + "',[HeadAddress]='" + txtAddress.Text + "',[ContactPersonName]='" + txtConperNm.Text + "',[ContactPersonMobile]='" + txtConPerMoNo.Text + "'," +
                        //             "[ModifyBy]='" + mob + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[IsActive]='1' WHERE [PID]='" + txtpid.Text + "'";
                        //int j = cc.ExecuteNonQuery(qry);

                        //string qrytwo = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsAdmin]='0'   WHERE [PartyId]='" + txtpid.Text + "'";
                        //cc.ExecuteNonQuery(qrytwo);


                        //string qrybnck = "SELECT [MobileNo] FROM [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] WHERE [MobileNo]='" + txtConPerMoNo.Text + "'";
                        //ds.Clear();
                        //ds = cc.ExecuteDataset(qrybnck);

                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    string qrytwotwo = "UPDATE [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] SET [IsAdmin]='1',  [PartyId]='" + txtpid.Text + "',[Rep_Name]='" + txtConperNm.Text + "',[IsActive]='1' WHERE [MobileNo]='" + txtConPerMoNo.Text + "'";
                        //    cc.ExecuteNonQuery(qrytwotwo);
                        //}
                        //else
                        //{
                        //    string qry1 = "INSERT INTO [TrueVoterDB].[dbo].[tblPartyRepresentativeDetails] ([MobileNo],[Rep_Name],[PartyId],[CreatedBy],[CreatedDate],[IsActive],[IsAdmin])" +
                        //                        " VALUES ('" + txtConPerMoNo.Text + "','" + txtConperNm.Text + "','" + txtpid.Text + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','1','1')";
                        //    int k = cc.ExecuteNonQuery(qry1);
                        //}

                        // int j = 1;
                        //if (j > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Party Updated Successfully')", true);
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Record Updated Failed')", true);
                        //}

                        btnSubmit.Text = "Submit";
                    }
                    BindPartyGrid();
                    clearField();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired...')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            clearField();
        }

        public void clearField()
        {
            btnSubmit.Text = "Submit";
            ddlPartyType.SelectedIndex = 0;
            txtPartyNm.Text = string.Empty;
            txtSymbolnm.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtConPerMoNo.Text = string.Empty;
            txtConperNm.Text = string.Empty;
            txtRegiDate.Text = string.Empty;
        }

        public void BindPartyGrid()
        {
            try
            {
                //string qrybn = "SELECT [PID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [CreatedBy]='" + mob + "'";
                //ds = cc.ExecuteDataset(qrybn);

                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@p0", "2");
                par[1] = new SqlParameter("@p1", mob);
                par[2] = new SqlParameter("@p2", "0");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAddPartyGetData", par);

                gvParty.DataSource = ds.Tables[0];
                gvParty.DataBind();
            }
            catch
            {
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            string pid = btnEdit.CommandArgument;
            UpdateData(pid);
        }

        public void UpdateData(string pid)
        {
            //string editselect = "SELECT [PID],[PTID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress],[ContactPersonName],[ContactPersonMobile] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PID]='" + pid + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(editselect);

            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@p0", "3");
            par[1] = new SqlParameter("@p1", pid);
            par[2] = new SqlParameter("@p2", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAddPartyGetData", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtpid.Text = Convert.ToString(ds.Tables[0].Rows[0]["PID"]);
                txtPartyNm.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]);
                txtRegiDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegistrationDate"]);
                txtSymbolnm.Text = Convert.ToString(ds.Tables[0].Rows[0]["Symbols"]);
                txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["HeadAddress"]);
                txtConperNm.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactPersonName"]);
                txtConPerMoNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactPersonMobile"]);
                string prtytyp = Convert.ToString(ds.Tables[0].Rows[0]["PTID"]);
                ddlPartyType.SelectedValue = prtytyp;
                btnSubmit.Text = "Update";
            }
        }

        protected void txtConPerMoNo_TextChanged(object sender, EventArgs e)
        {
            chkRegiMoNo();
        }

        public void chkRegiMoNo()
        {
            //string qrybn = "SELECT [PID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [ContactPersonMobile]='" + txtConPerMoNo.Text + "'";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qrybn);

            SqlParameter[] par = new SqlParameter[3];
            par[0] = new SqlParameter("@p0", "4");
            par[1] = new SqlParameter("@p1", txtConPerMoNo.Text);
            par[2] = new SqlParameter("@p2", "0");
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAddPartyGetData", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Entered Mobile No is Already Registerd')", true);

                ddlPartyType.SelectedIndex = 0;
                txtPartyNm.Text = string.Empty;
                txtSymbolnm.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtConperNm.Text = string.Empty;
                txtRegiDate.Text = string.Empty;
            }
        }

        protected void ddlPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                //string qrybn = "SELECT [PID],[PartyName],[RegistrationDate],[Symbols],[HeadAddress] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PTID]='" + ddlPartyType.SelectedValue + "' AND [CreatedBy]='" + mob + "'";
                //ds.Clear();
                //ds = cc.ExecuteDataset(qrybn);

                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@p0", "5");
                par[1] = new SqlParameter("@p1", ddlPartyType.SelectedValue);
                par[2] = new SqlParameter("@p2", mob);
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspAddPartyGetData", par);

                gvParty.DataSource = ds.Tables[0];
                gvParty.DataBind();
            }
            catch
            {
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GridView gvPartys = new GridView();
            DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspDownloadPartys");
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPartys.DataSource = ds.Tables[0];
                gvPartys.DataBind();
            }
            else
            {
                gvPartys.EmptyDataText = "No Data Found";
                gvPartys.DataBind();
            }
            string trueVoter = "PartyMaster" + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvPartys.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvPartys.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }

        }

    }
}