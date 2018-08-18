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
    public partial class frmAddRepresentative : System.Web.UI.Page
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
            cmd.CommandText = "SELECT [DistrictCode],[DistrictName] FROM [TrueVoterDB].[dbo].[tblDistrictMapping]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds);

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDistirct.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select District..!!!')", true);
                }
                else if (ddlLocalBody.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select LocalBody.!!!')", true);
                }
                else if (txtMobileNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Mobile No..!!!')", true);
                }
                else if (txtRepresntativeNm.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Representative Name..!!!')", true);
                }
                else if (txtAddress.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Address..!!!')", true);
                }
                else
                {
                    string qry = "INSERT INTO [TrueVoterDB].[dbo].[tblAISPLRepresentativeDetails] ([DistrictID],[DistrictName],[LocalBodyID]," +
                                 "[LocalBodyName],[MobileNo],[RepresentativeName],[Address],[CreatedBy],[CreatedDate],[IsActive]) " +
                                 "VALUES ('" + ddlDistirct.SelectedValue + "','" + ddlDistirct.SelectedItem + "','" + ddlLocalBody.SelectedValue + "'" +
                                 ",'" + ddlLocalBody.SelectedItem + "','" + txtMobileNo.Text + "','" + txtRepresntativeNm.Text + "','" + txtAddress.Text + "'" +
                                 ",'" + mob + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','"+rbtnisactive.SelectedValue+"')";
                    int i = cc.ExecuteNonQuery(qry);
                    if (i > 0)
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
            txtMobileNo.Text = "";
            txtAddress.Text = "";
            txtRepresntativeNm.Text = "";
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds);

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

        public void BindGrid()
        {
            cmd.CommandText = "SELECT [ID],[DistrictID],[DistrictName],[LocalBodyID],[LocalBodyName],[MobileNo],[RepresentativeName],[Address]  FROM [TrueVoterDB].[dbo].[tblAISPLRepresentativeDetails] WHERE [CreatedBy]='" + mob + "' ORDER BY [ID] DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            ds.Clear();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvRepresentativeData.DataSource = ds.Tables[0];
                gvRepresentativeData.DataBind();
            }
        }

        protected void gvRepresentativeData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRepresentativeData.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            string MobileNo = txtMobileNo.Text.Trim();
            string qry = "SELECT * FROM [TrueVoterDB].[dbo].[tblAISPLRepresentativeDetails] WHERE MobileNo='" + MobileNo + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = cc.ExecuteDataset(qry);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlDistirct.SelectedValue = ds1.Tables[0].Rows[0]["DistrictID"].ToString();
                        
                        cmd.CommandText = "SELECT [ElectionId],[ElectionName],[LocalBodyType] FROM [TrueVoterDB].[dbo].[ElectionBody$] WHERE DistrictCode='" + ddlDistirct.SelectedValue + "'";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        ds.Clear();
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddlLocalBody.DataSource = ds.Tables[0];
                            ddlLocalBody.DataTextField = "ElectionName";
                            ddlLocalBody.DataValueField = "ElectionId";
                            ddlLocalBody.DataBind();
                            ddlLocalBody.Items.Insert(0, new ListItem("Select", "0"));
                            ddlLocalBody.SelectedValue = ds1.Tables[0].Rows[0]["LocalBodyID"].ToString();
                        }
                        
                        txtRepresntativeNm.Text = ds1.Tables[0].Rows[0]["RepresentativeName"].ToString();
                        txtAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        string isActivestatus = ds1.Tables[0].Rows[0]["IsActive"].ToString();
                        if (isActivestatus == "1")
                        {
                            rbtnisactive.SelectedValue = "1";
                        }
                        else
                        {
                            rbtnisactive.SelectedValue = "2";
                        }
                    }

        }
    }
}