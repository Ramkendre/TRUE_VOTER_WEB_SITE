//using BLL;
//using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class updateControlChart : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        //string mob1 = "8308344627";
        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
                lblMobileNo.Text = mob;
                txtMobileNo.Text = mob;

            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }

        }

        public int ActiveRecordCount()
        {
            int count = 0;

            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [IsActive] = '1' AND [FromUser]='" + txtMobileNo.Text.Trim() + "'  ORDER BY [SrNoFrom],[SrNo]";
                }
                else
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [IsActive] = '1' AND [ToUser]='" + txtMobileNo.Text.Trim() + "' ORDER BY [SrNoFrom],[SrNo] ";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [IsActive] = '1' AND ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (ToUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom] ";
                }
                else
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [IsActive] = '1' AND ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (FromUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom]";
                }
            }
            DataSet dsval = new DataSet();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(dsval);

            if (dsval.Tables[0].Rows.Count > 0)
            {
                count = dsval.Tables[0].Rows.Count;
            }

            return count;
        }

        public int DeactiveRecordCount()
        {
            int count = 0;

            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ([IsActive] IS NULL OR [IsActive] = 0) AND [FromUser]='" + txtMobileNo.Text.Trim() + "'  ORDER BY [SrNoFrom],[SrNo]";

                }
                else
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ([IsActive] IS NULL OR [IsActive] = 0) AND [ToUser]='" + txtMobileNo.Text.Trim() + "' ORDER BY [SrNoFrom],[SrNo]";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ([IsActive] IS NULL OR [IsActive] = 0) AND ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (ToUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom]";
                }
                else
                {
                    cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ([IsActive] IS NULL OR [IsActive] = 0) AND ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (FromUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom]";
                }
            }

            DataSet dsval1 = new DataSet();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(dsval1);

            if (dsval1.Tables[0].Rows.Count > 0)
            {
                count = dsval1.Tables[0].Rows.Count;
            }

            return count;
        }

        public int ActiveRecordVotersCount()
        {
            int count = 0;

            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    cmd.CommandText = "SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE  [FromUser]='" + txtMobileNo.Text.Trim() + "' AND [IsActive]='1' ";
                }
                else
                {
                    cmd.CommandText = "SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE  [ToUser]='" + txtMobileNo.Text.Trim() + "' AND [IsActive]='1'";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    cmd.CommandText = "SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (ToUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) AND [IsActive] ='1'";
                }
                else
                {
                    cmd.CommandText = "SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (FromUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) AND [IsActive] ='1'";
                }
            }
            DataSet dsval = new DataSet();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(dsval);

            try
            {
                count = Convert.ToInt32(dsval.Tables[0].Rows[0][0]);
            }
            catch
            {
                count = 0;
            }

            return count;
        }

        public int DeactiveRecordVotersCount()
        {
            int count = 0;

            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    cmd.CommandText = " SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE  [FromUser]='" + txtMobileNo.Text.Trim() + "'  AND ([IsActive] is Null OR [IsActive]='0') ";

                }
                else
                {
                    cmd.CommandText = " SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE  [ToUser]='" + txtMobileNo.Text.Trim() + "'  AND ([IsActive] is Null OR [IsActive]='0') ";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    cmd.CommandText = " SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (ToUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) AND ([IsActive] is Null OR [IsActive]='0')";
                }
                else
                {
                    cmd.CommandText = "SELECT SUM(Voters) AS ApprovedVoterCount FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (FromUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) AND ([IsActive] is Null OR [IsActive]='0')";
                }
            }

            DataSet dsval1 = new DataSet();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = contrue;
            da.SelectCommand = cmd;
            da.Fill(dsval1);
            try
            {
                count = Convert.ToInt32(dsval1.Tables[0].Rows[0][0]);
            }
            catch
            {
                count = 0;
            }

            return count;
        }

        public void BindData()
        {
            cmd.Connection = contrue;
            cmd.CommandText = "uspSelectCChartdata";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    //cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [FromUser]='" + txtMobileNo.Text.Trim() + "'  ORDER BY [SrNoFrom],[SrNo]";
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "1";

                }
                else
                {
                    //cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [ToUser]='" + txtMobileNo.Text.Trim() + "' ORDER BY [SrNoFrom],[SrNo]";
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "2";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    //cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (ToUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom]";
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcno.Text.Trim();
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtSeatNo.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "3";
                }
                else
                {
                    //cmd.CommandText = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreatedBy],[vstatus],[Latitude],[Longitude],[CreateDate],[IsActive] FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE ACNO='" + txtAcno.Text.Trim() + "' AND PartNo='" + txtSeatNo.Text.Trim() + "' AND (FromUser IN('" + mob + "','9158696414') OR CreatedBy IN('" + mob + "','9158696414')) ORDER BY [SrNoFrom]";
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcno.Text.Trim();
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtSeatNo.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "4";
                }
            }

            da.SelectCommand = cmd;
            da.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();

        }

        public DataSet GetData(SqlCommand cmd)
        {
            int i = cmd.ExecuteNonQuery();
            da.Fill(ds);
            return ds;
        }


        protected void EditCandidate(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void UpdateCandidate(object sender, GridViewUpdateEventArgs e)
        {
            string returnvalue = string.Empty;
            string acNo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtACNO")).Text;
            string partNo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPartNo")).Text;
            string wardNo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtWardNo")).Text;
            string status = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlstatus")).SelectedValue;
            string sectionNo = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSectionNo")).Text;
            string Id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblSrNo")).Text;


            cmd.Connection = contrue;
            // cmd.CommandType = CommandType.Text;

            cmd.CommandText = "uspUpdateControlChartNew";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            //cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] SET [ACNO]=@ACNO, [PartNo]=@PartNo,[WardNo]=@WardNo, [ModifiedDate]=@ModifiedDate, [ModifiedBy]=@ModifiedBy, [vstatus]=@vstatus WHERE [SrNo]=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ACNO", SqlDbType.Int).Value = acNo;
            cmd.Parameters.Add("@PartNo", SqlDbType.VarChar).Value = partNo;
            cmd.Parameters.Add("@WardNo", SqlDbType.VarChar).Value = wardNo;
            cmd.Parameters.Add("@vstatus", SqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@sectionNo", SqlDbType.VarChar).Value = sectionNo;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = mob;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.VarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt");

            cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            returnvalue = cmd.Parameters["@returnValue"].Value.ToString();
            cmd.Connection.Close();
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void DeactiveCandidate(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            LinkButton lnkRemove = (LinkButton)sender;
            cmd.Connection = contrue;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkbox = (CheckBox)GridView1.Rows[i].Cells[12].FindControl("CheckBox1");

                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemove.CommandArgument;
                updatecount = 1;
            }

            // cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] SET  [IsActive] = 0 , [ModifiedDate] = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + "', [ModifiedBy] = '" + mob + "' WHERE [SrNo] IN (" + gvSNO + ")";

            cmd.CommandText = "uspUpdateControlChartMultipleApprove";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = gvSNO;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt");
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = mob;
            cmd.Parameters.Add("@ActDeaQry", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

            string returnvalue = string.Empty;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            returnvalue = cmd.Parameters["@returnValue"].Value.ToString();
            cmd.Connection.Close();
            BindData();
        }

        protected void ActiveCandidate(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = contrue;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkbox = (CheckBox)GridView1.Rows[i].Cells[12].FindControl("CheckBox1");
                if (chkbox != null)
                {
                    if (chkbox.Checked == true)
                    {
                        gvSNO += Convert.ToString(GridView1.DataKeys[i].Value) + ",";
                        updatecount++;
                    }
                }
                chkbox.Checked = false;
            }

            if (gvSNO != "")
            {
                gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
            }
            else
            {
                gvSNO = lnkRemoveDeactive.CommandArgument;
                updatecount = 1;
            }

            //cmd.CommandText = "UPDATE [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] SET  [IsActive] = 1 , [ModifiedDate] = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + "', [ModifiedBy] = '" + mob + "' WHERE [SrNo] IN (" + gvSNO + ")";

            //contrue.Open();
            //cmd.ExecuteNonQuery();
            //contrue.Close();

            cmd.CommandText = "uspUpdateControlChartMultipleApprove";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = gvSNO;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt");
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar).Value = mob;
            cmd.Parameters.Add("@ActDeaQry", SqlDbType.Int).Value = 2;
            cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.Output;
            string returnvalue = string.Empty;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            returnvalue = cmd.Parameters["@returnValue"].Value.ToString();
            cmd.Connection.Close();
            BindData();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            BindData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            BindData();
            lblActiveCount.Text = Convert.ToString(ActiveRecordCount());
            lblDectiveCount.Text = Convert.ToString(DeactiveRecordCount());
            lblAppVoterCount.Text = Convert.ToString(ActiveRecordVotersCount());
            lblNotAppVoterCount.Text = Convert.ToString(DeactiveRecordVotersCount());

        }

        protected void rbtnSerchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rbtnSerchBy.SelectedValue == "1")
            {
                this.pnlACPART.Visible = true;
                this.pnlMobileNo.Visible = false;

            }
            else
            {
                this.pnlMobileNo.Visible = true;
                this.pnlACPART.Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        string isActive = e.Row.Cells[16].Text;
            //        if (isActive == "True")
            //        {
            //            e.Row.BackColor = System.Drawing.Color.Green;
            //        }
            //        else
            //        {
            //            e.Row.BackColor = System.Drawing.Color.Red;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            pnlACPART.Visible = false;
            Response.Redirect("~/Reports/frmHomeUser.aspx");
        }

        protected void btnduplicate_Click(object sender, EventArgs e)
        {
            FindDuplicate();
            lblActiveCount.Text = Convert.ToString(ActiveRecordCount());
            lblDectiveCount.Text = Convert.ToString(DeactiveRecordCount());
        }

        public void FindDuplicate()
        {
            cmd.Connection = contrue;
            cmd.CommandText = "uspSelectCChartduplicate";
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (rbtnSerchBy.SelectedValue == "2")
            {
                if (rbtnmobileno.SelectedValue == "2")
                {
                    //SELECT * FROM (SELECT * , count(*) over (partition by [ACNO],[PartNo],[SrNoFrom],[SrNoTo]) cnt  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WITH (NOLOCK)) t1 WHERE cnt > 1 AND [FromUser]=@mobileNo -- ORDER BY [SrNoFrom],[SrNo]
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "1";

                }
                else
                {
                    //SELECT * FROM (SELECT * , count(*) over (partition by [ACNO],[PartNo],[SrNoFrom],[SrNoTo]) cnt  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WITH (NOLOCK)) t1 WHERE cnt > 1 AND [ToUser]=@mobileNo --ORDER BY [SrNoFrom],[SrNo]
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "2";
                }
            }
            else
            {
                if (rbofficer.SelectedValue == "1")
                {
                    //SELECT * FROM (SELECT * , count(*) over (partition by [ACNO],[PartNo],[SrNoFrom],[SrNoTo]) cnt  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WITH (NOLOCK)) t1 WHERE cnt > 1 AND ACNO=@acNo AND PartNo=@partNo AND (ToUser IN(@mobileNo,'9158696414') OR CreatedBy IN(@mobileNo,'9158696414')) --ORDER BY [SrNoFrom]
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcno.Text.Trim();
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtSeatNo.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "3";

                }
                else
                {
                    //SELECT * FROM (SELECT * , count(*) over (partition by [ACNO],[PartNo],[SrNoFrom],[SrNoTo]) cnt  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WITH (NOLOCK)) t1 WHERE cnt > 1 AND ACNO=@acNo AND PartNo=@partNo AND (FromUser IN(@mobileNo,'9158696414') OR CreatedBy IN(@mobileNo,'9158696414')) --ORDER BY [SrNoFrom]
                    cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar).Value = mob;
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcno.Text.Trim();
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtSeatNo.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "4";
                }
            }

            da.SelectCommand = cmd;
            da.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }
    }
}