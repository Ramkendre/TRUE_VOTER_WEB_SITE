using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.IO;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
namespace TrueVoter.Reports
{
    public partial class ElectionDates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ArrayList ArryLst1 = new ArrayList();
        ArrayList ArryLst2 = new ArrayList();
        string mobile = string.Empty;
        string ReturnData = string.Empty;
        string List = string.Empty;
        StringBuilder objStringBuilder = new StringBuilder();
        string aFactor = "";
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MobileNO"] != null)
            {
                mobile = Session["MobileNO"].ToString();
                if (!IsPostBack)
                {
                    DDLStateBind();
                }
                gvBind();
            }
            else
            {
                Response.Redirect("../Reports/frmHome.aspx");
            }
        }

        public void DDLStateBind()
        {
            try
            {
                //cmd.CommandText = "SELECT DISTINCT([MDDS STC]),[STATE NAME] FROM [TrueVoterDB].[dbo].[tblVillageMaster] WHERE [MDDS STC]=27 order by [STATE NAME] ASC";
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = con;
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                //da.SelectCommand = cmd;
                //da.Fill(ds);

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@StateId", "27");
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetState", par);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlState.DataSource = ds.Tables[0];
                    ddlState.DataTextField = "StateName"; // "STATE NAME";
                    ddlState.DataValueField = "StateId"; //"MDDS STC";
                    ddlState.DataBind();

                    ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlState.SelectedIndex = 0;
                }
            }
            catch { }
            finally { con.Close(); }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cmd.CommandText = "SELECT DISTINCT([MDDS DTC]),[DISTRICT NAME] FROM [TrueVoterDB].[dbo].[tblVillageMaster] WHERE [MDDS STC]='" + ddlState.SelectedValue.ToString() + "' AND [MDDS DTC] Not In(000) order by [DISTRICT NAME] ASC";
                //cmd.CommandType = CommandType.Text;
                //cmd.Connection = con;
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                //da.SelectCommand = cmd;
                //da.Fill(ds);

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@StateId", ddlState.SelectedValue.ToString());
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetDistrict", par);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = ds.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";// "DISTRICT NAME";
                    ddlDistrict.DataValueField = "DistId";// "MDDS DTC";
                    ddlDistrict.DataBind();

                    ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistrict.SelectedIndex = 0;

                    //ddlDistrict.Items.Add("--Select--");
                    //ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
            catch { }
            finally { con.Close(); }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cmd.CommandText = "SELECT DISTINCT([MDDS Sub_DT]),[SUB-DISTRICT NAME] FROM [TrueVoterDB].[dbo].[tblVillageMaster] WHERE [MDDS DTC]='" + ddlDistrict.SelectedValue.ToString() + "' AND [MDDS Sub_DT] NOT IN(00000) ORDER BY [SUB-DISTRICT NAME] ASC";
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.Text;
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                //da.SelectCommand = cmd;
                //da.Fill(ds);

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@DistId", ddlDistrict.SelectedValue.ToString());
                ds.Clear();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetTaluka", par);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlBlock.DataSource = ds.Tables[0];
                    ddlBlock.DataTextField = "TalukaName";// "SUB-DISTRICT NAME";
                    ddlBlock.DataValueField = "TalukaId";// "MDDS Sub_DT";
                    ddlBlock.DataBind();

                    ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlBlock.SelectedIndex = 0;
                }
            }
            catch { }
            finally { con.Close(); }
        }

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd.CommandText = "SELECT DISTINCT([MDDS PLCN]),[Village] FROM [TrueVoterDB].[dbo].[tblVillageMaster] WHERE [MDDS Sub_DT]='" + ddlBlock.SelectedValue.ToString() + "' AND [MDDS PLCN] Not In(000000) order by Village ASC";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //da.SelectCommand = cmd;
            //da.Fill(ds);

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@TalukaId", ddlBlock.SelectedValue.ToString());
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetVillage", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlVillage.DataSource = ds.Tables[0];
                ddlVillage.DataTextField = "VillageName";// "Village";
                ddlVillage.DataValueField = "VillageId";// "MDDS PLCN";
                ddlVillage.DataBind();

                ddlVillage.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlVillage.SelectedIndex = 0;
            }
        }

        protected void ddlGrampanchaytType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlGrampanchaytType.SelectedItem.Text == "Gat Grampanchayt")
                {
                    lblVillagesAttachedToGrampanchayt.Visible = true;
                    lstbox1.Visible = true;
                    btnleft.Visible = true;
                    btnRight.Visible = true;
                    lstbox2.Visible = true;

                    //cmd.CommandText = "SELECT DISTINCT([MDDS PLCN]),[Village] FROM [TrueVoterDB].[dbo].[tblVillageMaster] WHERE [MDDS Sub_DT]='" + ddlBlock.SelectedValue.ToString() + "' order by Village ASC";
                    //cmd.CommandType = CommandType.Text;
                    //cmd.Connection = con;
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //da.SelectCommand = cmd;
                    //ds.Clear();
                    //da.Fill(ds);
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@TalukaId", ddlBlock.SelectedValue.ToString());
                    ds.Clear();
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetVillage", par);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lstbox1.DataSource = ds.Tables[0];
                        lstbox1.DataTextField = "VillageName";// "Village";
                        lstbox1.DataValueField = "VillageId";// "MDDS PLCN";
                        lstbox1.DataBind();
                    }
                }
                else
                {
                    lblVillagesAttachedToGrampanchayt.Visible = false;
                    lstbox1.Visible = false;
                    btnleft.Visible = false;
                    btnRight.Visible = false;
                    lstbox2.Visible = false;
                }
            }
            catch { }
            finally { con.Close(); }

        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbox1.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstbox1.Items.Count; i++)
                    {
                        if (lstbox1.Items[i].Selected)
                        {
                            if (!ArryLst1.Contains(lstbox1.Items[i]))
                            {
                                ArryLst1.Add(lstbox1.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ArryLst1.Count; i++)
                    {
                        if (!lstbox2.Items.Contains(((ListItem)ArryLst1[i])))
                        {
                            lstbox2.Items.Add(((ListItem)ArryLst1[i]));
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnleft_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbox2.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstbox2.Items.Count; i++)
                    {
                        if (lstbox2.Items[i].Selected)
                        {
                            if (!ArryLst2.Contains(lstbox2.Items[i]))
                            {
                                ArryLst2.Add(lstbox2.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ArryLst2.Count; i++)
                    {
                        if (!lstbox1.Items.Contains(((ListItem)ArryLst2[i])))
                        {
                            lstbox1.Items.Add(((ListItem)ArryLst2[i]));
                        }
                        lstbox2.Items.Remove(((ListItem)ArryLst2[i]));
                    }
                    lstbox1.SelectedIndex = -1;
                }
            }
            catch
            {

            }
        }

        public void SelectAllTextInListBox()
        {

            foreach (ListItem item in lstbox2.Items)
            {
                //ReturnData=Convert.ToString(item.Selected = true);                
                //objStringBuilder.Append(ReturnData);
                //List = objStringBuilder + ",";
                if (item.Selected)
                {
                    count += 1;
                    aFactor += item.Value + ",";
                }
            }
        }
        public void gvBind()
        {
            DataSet ds2 = new DataSet();
            try
            {

                //cmd.CommandText = "SELECT [SId],[Village],[GrampanchaytType],[MembersInGp],[PESA],[TypeofBody],[EstabilishmentofBody],[RetirementofBody] FROM [TrueVoterDB].[dbo].[ElectionDate]  WHERE [Createdby]='" + mobile + "' order by SId DESC";
                //cmd.Connection = con;
                //cmd.CommandType = CommandType.Text;
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();
                //}
                //da.SelectCommand = cmd;
                //da.Fill(ds2);


                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@mobile", mobile);
                ds2.Clear();
                ds2 = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetElectionDate", par);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    gvElectionDates.DataSource = ds2.Tables[0];
                    gvElectionDates.DataBind();
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
                ds2.Clear();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                SelectAllTextInListBox();

                cmd.CommandText = "UspUploadElectionDate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = ddlState.SelectedValue.ToString();
                cmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = ddlDistrict.SelectedValue.ToString();
                cmd.Parameters.Add("@Block", SqlDbType.NVarChar).Value = ddlBlock.SelectedValue.ToString();
                cmd.Parameters.Add("@Village", SqlDbType.NVarChar).Value = ddlVillage.SelectedValue.ToString();
                cmd.Parameters.Add("@GrampanchaytType", SqlDbType.NVarChar).Value = ddlGrampanchaytType.SelectedValue.ToString();
                cmd.Parameters.Add("@VillageList", SqlDbType.NVarChar).Value = aFactor.ToString();
                cmd.Parameters.Add("@VillageListCount", SqlDbType.NVarChar).Value = count.ToString();
                cmd.Parameters.Add("@MembersInGp", SqlDbType.NVarChar).Value = txtNoofMembersinGP.Text;
                cmd.Parameters.Add("@GpType", SqlDbType.NVarChar).Value = ddlGpType.SelectedValue.ToString();
                cmd.Parameters.Add("@TypeofBody", SqlDbType.NVarChar).Value = ddlTypeofBody.SelectedItem.ToString();
                cmd.Parameters.Add("@EstabilishmentofBody", SqlDbType.NVarChar).Value = txtEstabilishmentofBody.Text;
                cmd.Parameters.Add("@RetirementofBody", SqlDbType.NVarChar).Value = txtRetirementofBody.Text;
                cmd.Parameters.Add("@Createdby", SqlDbType.NVarChar).Value = mobile.ToString();
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString();
                cmd.Parameters.Add("@returnvalue", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@GrmSvkMobNo", SqlDbType.NVarChar).Value = txtGrmSvkMobNo.Text.ToString();
                i = cmd.ExecuteNonQuery();
                ReturnData = cmd.Parameters["@returnvalue"].Value.ToString();
                if (i.Equals(-1))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record  Submited Successfully.!!!')", true);
                    clear();
                    gvBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not Inserted!!!')", true);
                }
            }
            catch { }
            finally { con.Close(); }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SelectAllTextInListBox();
        }

        protected void txtEstabilishmentofBody_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(txtEstabilishmentofBody.Text);
                DateTime answer = date.AddYears(5);
                DateTime dt = answer.AddDays(-1);
                txtRetirementofBody.Text = dt.ToString("yyyy-MM-dd");
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter valid Date')", true);
            }
        }

        protected void ddlTypeofBody_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTypeofBody.SelectedValue == "2")
                {
                    txtEstabilishmentofBody.Text = "Null";
                    txtRetirementofBody.Text = "Null";
                }
            }
            catch
            {

            }
        }

        protected void gvElectionDates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvElectionDates.PageIndex = e.NewPageIndex;
            gvBind();
        }

        public void clear()
        {
            ddlState.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            ddlVillage.SelectedIndex = 0;
            ddlBlock.SelectedIndex = 0;
            ddlGpType.SelectedIndex = 0;
            ddlGrampanchaytType.SelectedIndex = 0;
            ddlTypeofBody.SelectedIndex = 0;
            txtRetirementofBody.Text = string.Empty;
            txtEstabilishmentofBody.Text = string.Empty;
            txtNoofMembersinGP.Text = string.Empty;
            lstbox1.Items.Clear();
            lstbox2.Items.Clear();

        }
    }
}