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
    public partial class frmSplitAt : System.Web.UI.Page
    {
        CommonCode cc = new CommonCode();
        SqlCommand cmd = null;
        DataSet ds = new DataSet();
        string mob = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
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
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
        public void clear()
        {
            txtACNO.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtFormSrNo.Text = string.Empty;
            txtToSrNo.Text = string.Empty;
            txtWardNo.Text = string.Empty;
            txtSplitNo.Text = string.Empty;

        }
        public void BindGridView()
        {
            string qry = "SELECT *  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WHERE [ACNO]='" + txtACNO.Text.Trim() + "' AND [PartNo]='" + txtPartNo.Text.Trim() + "' AND [WardNo]='" + txtWardNo.Text.Trim() + "'AND [SrNoFrom]='" + txtFormSrNo.Text.Trim() + "' AND [SrNoTo]='" + txtToSrNo.Text.Trim() + "' ";
            ds.Clear();
            ds = cc.ExecuteDataset(qry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvBoothAdd.DataSource = ds.Tables[0];
                gvBoothAdd.DataBind();
                pnlallData.Visible = false;
                pnlbooth.Visible = true;
                BindShowGridView();
            }
            else
            {
                gvBoothAdd.DataSource = ds.Tables[0];
                gvBoothAdd.DataBind();
            }
        }
        protected void SubmitRecord(object sender, EventArgs e)
        {
            if (txtSplitNo.Text == null || txtSplitNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid Split..!!!')", true);
            }
            else
            {
                string gvSrNo = string.Empty;
                cmd = new SqlCommand();
                LinkButton lnkbtnSubmit = (LinkButton)sender;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                gvSrNo = lnkbtnSubmit.CommandArgument;
                string qry = "SELECT SrNo, ACNO, PartNo, SrNoFrom, SrNoTo, WardNo, FromUser, ToUser, roletype, CreateDate, CreatedBy, ModifiedDate, ModifiedBy, Latitude, Longitude, vstatus, IsActive, Voters, BoothNo, SplitFrom, UpdatedBy FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WHERE [SrNo]='" + gvSrNo + "'";
                ds.Clear();
                ds = cc.ExecuteDataset(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int frm = Convert.ToInt32(ds.Tables[0].Rows[0]["SrNoFrom"]);
                    int tosr = Convert.ToInt32(ds.Tables[0].Rows[0]["SrNoTo"]);
                    if (frm < tosr)
                    {
                        int spltno = Convert.ToInt32(txtSplitNo.Text.Trim());
                        if (spltno > frm && spltno < tosr)
                        {
                            int newSrto = spltno - 1;
                            int voters = (newSrto - frm) + 1;

                            string qry1 = "INSERT INTO [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] (ACNO, PartNo, SrNoFrom, SrNoTo, WardNo, FromUser, ToUser, roletype, CreateDate, CreatedBy,Latitude, Longitude, vstatus, IsActive, Voters,BoothNo,SplitFrom, UpdatedBy)" +
                                          " VALUES ('" + Convert.ToString(ds.Tables[0].Rows[0]["ACNO"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PartNo"]) + "','" + frm + "','" + newSrto + "','" + Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["FromUser"]) + "'," +
                                          " '" + Convert.ToString(ds.Tables[0].Rows[0]["ToUser"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["roletype"]) + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Longitude"]) + "'" +
                                          " ,'" + Convert.ToString(ds.Tables[0].Rows[0]["vstatus"]) + "','1','" + voters + "','" + Convert.ToString(ds.Tables[0].Rows[0]["BoothNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["SrNo"]) + "','" + mob + "')";
                            cc.ExecuteNonQuery(qry1);

                            int voters2 = (tosr - spltno) + 1;

                            string qry2 = "INSERT INTO [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] (ACNO, PartNo, SrNoFrom, SrNoTo, WardNo, FromUser, ToUser, roletype, CreateDate, CreatedBy,Latitude, Longitude, vstatus, IsActive, Voters,BoothNo,SplitFrom, UpdatedBy)" +
                                          " VALUES ('" + Convert.ToString(ds.Tables[0].Rows[0]["ACNO"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["PartNo"]) + "','" + spltno + "','" + tosr + "','" + Convert.ToString(ds.Tables[0].Rows[0]["WardNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["FromUser"]) + "'," +
                                          " '" + Convert.ToString(ds.Tables[0].Rows[0]["ToUser"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["roletype"]) + "','" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "','" + Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["Longitude"]) + "'" +
                                          " ,'" + Convert.ToString(ds.Tables[0].Rows[0]["vstatus"]) + "','1','" + voters2 + "','" + Convert.ToString(ds.Tables[0].Rows[0]["BoothNo"]) + "','" + Convert.ToString(ds.Tables[0].Rows[0]["SrNo"]) + "','" + mob + "')";
                            cc.ExecuteNonQuery(qry2);

                            string qry3 = "UPDATE [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] SET [IsActive]='0' WHERE [SrNo]='" + Convert.ToString(ds.Tables[0].Rows[0]["SrNo"]) + "'";
                            cc.ExecuteNonQuery(qry3);

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Entry Splited Successfully..!!!')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Valid Split No..!!!')", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Valid Split No..!!!')", true);
                    }
                }
                // clear();
                pnlallData.Visible = true;
                pnlbooth.Visible = false;
                BindShowGridView();
            }
        }

        public void BindShowGridView()
        {
            string qry = "SELECT *  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WHERE [ACNO]='" + txtACNO.Text.Trim() + "' AND [PartNo]='" + txtPartNo.Text.Trim() + "' AND [WardNo]='" + txtWardNo.Text.Trim() + "' ORDER BY [SrNo] DESC ";
            ds.Clear();
            ds = cc.ExecuteDataset(qry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShowData.DataSource = ds.Tables[0];
                gvShowData.DataBind();
                // pnlallData.Visible = false;
                // pnlbooth.Visible = true;
            }
            else
            {
                gvShowData.DataSource = ds.Tables[0];
                gvShowData.DataBind();
            }
        }

        protected void gvShowData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowData.PageIndex = e.NewPageIndex;
            BindShowGridView();
        }

        protected void gvBoothAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBoothAdd.PageIndex = e.NewPageIndex;
            BindGridView();
        }

    }
}