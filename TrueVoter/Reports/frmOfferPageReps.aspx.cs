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
    public partial class frmOfferPageReps : System.Web.UI.Page
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
                    BindDistrict();
                    BindPartytype();
                    BindGrid();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        public void BindDistrict()
        {
            //cmd.CommandText = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);

            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindDistrict");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = ds.Tables[0];
                ddlDistirct.DataTextField = "DistrictName";
                ddlDistirct.DataValueField = "DistrictCode";
                ddlDistirct.DataBind();
                ddlDistirct.Items.Insert(0, new ListItem("Select", "0"));
                ddlDistirct.SelectedIndex = 0;
            }
            else
            {

            }
        }
        public void BindPartytype()
        {
            //cmd.CommandText = "SELECT [PTID],[PartyType] FROM [TrueVoterDB].[dbo].[tblPartyTypeFieldItem]";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindPartyType");
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
        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@distID", ddlDistirct.SelectedValue.ToString());
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindLocalBodyDistrictWise", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds.Tables[0];
                ddlLocalBody.DataTextField = "ElectionName";
                ddlLocalBody.DataValueField = "ElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("Select", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }
        protected void ddlPartytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT [PID],[PTID],[PartyName] FROM [TrueVoterDB].[dbo].[tblPartFieldItemMaster] WHERE [PTID]='" + ddlPartytype.SelectedValue + "'";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //da.Fill(ds);
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@PartyType", ddlPartytype.SelectedValue.ToString());
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindParty", par);
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                #region

                if (ddlDistirct.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District..!!!')", true);
                }
                else if (ddlLocalBody.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select LocalBody.!!!')", true);
                }
                else if (ddlPartytype.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Party Type..!!!')", true);
                }
                else if (ddlPartyName.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Party..!!!')", true);
                }
                else if (ddlOfferOn.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Offer On..!!!')", true);
                }
                else if (txtofferHead.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Offer Name..!!!')", true);
                }
                else if (txtCode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Offer Code..!!!')", true);
                }
                else if (txtValidFrom.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Validity Start Date..!!!')", true);
                }
                else if (txtValidTo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Validity End Date..!!!')", true);
                }
                else
                {
                #endregion
                    //string qry = "INSERT INTO [TrueVoterDB].[dbo].[tblOffers] ([DistrictID],[District],[LocalBodyID],[LocalBodyName],[PartyID],[PartyName]," +
                    //                 "[OfferNo],[OfferName],[OfferHeading],[OfferCode],[OfferStartDate],[OfferEndDate],[CreatedBy],[CreatedDate])" +
                    //        "VALUES ('" + ddlDistirct.SelectedValue + "','" + ddlDistirct.SelectedItem + "','" + ddlLocalBody.SelectedValue + "','" + ddlLocalBody.SelectedItem + "'" +
                    //        ",'" + ddlPartyName.SelectedValue + "','" + ddlPartyName.SelectedItem + "','" + ddlOfferOn.SelectedValue + "'" +
                    //        ",'" + ddlOfferOn.SelectedItem + "','" + txtofferHead.Text + "','" + txtCode.Text + "','" + txtValidFrom.Text + "','" + txtValidTo.Text + "','" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    //int i = cc.ExecuteNonQuery(qry);

                    SqlParameter[] par1 = new SqlParameter[15];
                    par1[0] = new SqlParameter("@p0", ddlDistirct.SelectedValue.ToString());
                    par1[1] = new SqlParameter("@p1", ddlDistirct.SelectedItem.ToString());
                    par1[2] = new SqlParameter("@p2", ddlLocalBody.SelectedValue.ToString());
                    par1[3] = new SqlParameter("@p3", ddlLocalBody.SelectedItem.ToString());
                    par1[4] = new SqlParameter("@p4", ddlPartyName.SelectedValue.ToString());
                    par1[5] = new SqlParameter("@p5", ddlPartyName.SelectedItem.ToString());
                    par1[6] = new SqlParameter("@p6", ddlOfferOn.SelectedValue.ToString());
                    par1[7] = new SqlParameter("@p7", ddlOfferOn.SelectedItem.ToString());
                    par1[8] = new SqlParameter("@p8", Convert.ToString(txtofferHead.Text));
                    par1[9] = new SqlParameter("@p9", Convert.ToString(txtCode.Text));
                    par1[10] = new SqlParameter("@p10", Convert.ToString(txtValidFrom.Text));
                    par1[11] = new SqlParameter("@p11", Convert.ToString(txtValidTo.Text));
                    par1[12] = new SqlParameter("@p12", Convert.ToString(mob));
                    par1[13] = new SqlParameter("@p13", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par1[14] = new SqlParameter("@p14",SqlDbType.Int);
                    par1[14].Direction = ParameterDirection.InputOutput;
                    ds.Clear();
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertOffer", par1);
                    string i=par1[14].Value.ToString();
                    if (i.Equals("101"))
                    { ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Submitted Successfully..')", true); }
                    else
                    { ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Submition Failed..')", true); }
                    Clear();
                    BindGrid();
                }
            }
            catch
            {

            }
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlOfferOn.SelectedIndex = 0;
            ddlPartytype.SelectedIndex = 0;
            ddlPartyName.SelectedIndex = 0;
            txtCode.Text = "";
            txtofferHead.Text = "";
            txtValidFrom.Text = "";
            txtValidTo.Text = "";
        }
        public void BindGrid()
        {
            //cmd.CommandText = "SELECT [OfferID],[DistrictID],[District],[LocalBodyID],[LocalBodyName],[PartyID],[PartyName],[OfferNo],[OfferName],[OfferHeading],[OfferCode],[OfferStartDate],[OfferEndDate]  FROM [TrueVoterDB].[dbo].[tblOffers] WHERE [CreatedBy]='" + mob + "' ORDER BY [OfferID] DESC";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //da.SelectCommand = cmd;
            //ds.Clear();
            //da.Fill(ds);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@mob", mob);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspBindOffers", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvOfferDetails.DataSource = ds.Tables[0];
                gvOfferDetails.DataBind();
            }
        }

        protected void gvOfferDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfferDetails.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}