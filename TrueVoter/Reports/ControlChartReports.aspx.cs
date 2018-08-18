using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TrueVoter.Reports
{
    public partial class ControlChartReports : System.Web.UI.Page
    {
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
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
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
        }

        public void BindGridControlChart()
        {
            string sqlQuery = string.Empty;
            cmd.Connection = contrue;
            cmd.CommandText = "uspDownloadChontrolChartWebPage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            if (rbtnFirst.SelectedValue == "0")
            {
                if (RadioButtonList2.SelectedValue == "0")
                {
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtMobileNo2.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "9";
                }
                else
                {
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtMobileNo2.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "10";
                }
            }
            else if (rbtnFirst.SelectedValue == "1")
            {
                if (txtPartNo.Text == "" || txtPartNo.Text == "0")
                {

                    if (rbtnSearchBy.SelectedValue == "0")
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "1";
                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "2";


                        }
                    }
                    else
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "3";


                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "4";
                        }
                    }
                }
                else
                {
                    if (rbtnSearchBy.SelectedValue == "0")
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "5";



                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "6";
                        }
                    }
                    else
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "7";

                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "8";

                        }
                    }
                }
            }
            else if (rbtnFirst.SelectedValue == "2")
            {
                cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtacNoDate.Text.Trim();
                cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtdate.Text.Trim();
                cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "11";
            }
            else
            {
                cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtSRNOID.Text.Trim();
                cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "12";
            }

            da.SelectCommand = cmd;
            da.Fill(ds);
            //gvControlChart.DataSource = ds.Tables[0];
            //gvControlChart.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvControlChart.DataSource = ds.Tables[0];
                gvControlChart.DataBind();

                lblCountNo.Text = ds.Tables[0].Rows.Count.ToString();
                lblCountNo1.Text = ds.Tables[1].Rows[0][0].ToString();//ds.Tables[1].Rows.Count.ToString();

                gvMapData.DataSource = ds.Tables[0];
                gvMapData.DataBind();
            }
            else
            {
                gvControlChart.EmptyDataText = "No Record Found..!!!";
                gvControlChart.DataBind();

                lblCountNo.Text = ds.Tables[0].Rows.Count.ToString();
                lblCountNo1.Text = ds.Tables[1].Rows[0][0].ToString(); //ds.Tables[1].Rows.Count.ToString();
                gvMapData.EmptyDataText = "No Record Found..!!!";
                gvMapData.DataBind();
            }
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            BindGridControlChart();
            btnExportToExcel.Visible = true;
            btnUnformatedData.Visible = true;
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            gvControlChart.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            this.BindGridControlChart();
            string trueVoter = "TrueVoter " + System.DateTime.Today.ToString("dd-MM-yyyy");
            if (gvControlChart.Visible)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvControlChart.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('New Changes are getting done in download process, It will be made available soon please try later...!!!')", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void gvControlChart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvControlChart.PageIndex = e.NewPageIndex;
            BindGridControlChart();
        }

        protected void btnMap_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridControlChart();
                MultiView1.ActiveViewIndex += 1;
            }
            catch
            {
            }
        }

        public void ShowData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] 
            { new DataColumn("ACNO", typeof(string)),new DataColumn("PartNo", typeof(string)),
              new DataColumn("Latitude",typeof(string)),new DataColumn("longitude",typeof(string)),
              new DataColumn("SrNoFrom",typeof(string)),new DataColumn("SrNoTo",typeof(string))});
            foreach (GridViewRow row in gvMapData.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                    if (chkRow.Checked)
                    {
                        dt.Rows.Add(row.Cells[1].Text.Trim().ToString(), row.Cells[2].Text.Trim().ToString(), row.Cells[8].Text.Trim().ToString(), row.Cells[9].Text.Trim().ToString(), row.Cells[3].Text.Trim().ToString(), row.Cells[4].Text.Trim().ToString());
                    }
                }
            }
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();
        }

        protected void btnShowlatlong_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void gvMapData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMapData.PageIndex = e.NewPageIndex;
            BindGridControlChart();
        }

        protected void btnUnformatedData_Click(object sender, EventArgs e)
        {

            gvvisiblefalse.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
            this.BindUnformatedData();
            string trueVoter = "TrueVoterUnformated" + System.DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
            if (gvvisiblefalse.Visible == false)
            {
                //Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                // Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                gvvisiblefalse.RenderControl(hTextWriter);
                Response.Write(sWriter.ToString());
                Response.End();
            }

        }

        public void BindUnformatedData()
        {
            //string sqlQuery = string.Empty;
            DataSet dsunformetedData = new DataSet();
            cmd.Connection = contrue;
            cmd.CommandText = "uspDownloadChontrolChartWebPageunformated";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            if (rbtnFirst.SelectedValue == "0")
            {
                if (RadioButtonList2.SelectedValue == "0")
                {
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtMobileNo2.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "9";
                }
                else
                {
                    cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                    cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtMobileNo2.Text.Trim();
                    cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "10";
                }
            }
            else if (rbtnFirst.SelectedValue == "1")
            {
                if (txtPartNo.Text == "" || txtPartNo.Text == "0")
                {

                    if (rbtnSearchBy.SelectedValue == "0")
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "1";

                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "2";
                        }
                    }
                    else
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "3";
                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "4";
                        }
                    }
                }
                else
                {
                    if (rbtnSearchBy.SelectedValue == "0")
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "5";
                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "6";
                        }
                    }
                    else
                    {
                        if (txtUserNo.Text == "" || txtUserNo.Text == "0")
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "7";
                        }
                        else
                        {
                            cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtAcNo.Text.Trim();
                            cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtPartNo.Text.Trim();
                            cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = txtUserNo.Text.Trim();
                            cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "8";
                        }
                    }
                }
            }
            else if (rbtnFirst.SelectedValue == "2")
            {
                cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtacNoDate.Text.Trim();
                cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = txtdate.Text.Trim();
                cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "11";
            }
            else
            {
                cmd.Parameters.Add("@acNo", SqlDbType.NVarChar).Value = txtSRNOID.Text.Trim();
                cmd.Parameters.Add("@partNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@userMoNo", SqlDbType.NVarChar).Value = "0";
                cmd.Parameters.Add("@query", SqlDbType.NVarChar).Value = "12";
            }
            da.SelectCommand = cmd;
            da.Fill(dsunformetedData);

            if (dsunformetedData.Tables[0].Rows.Count > 0)
            {
                gvvisiblefalse.DataSource = dsunformetedData.Tables[0];
                gvvisiblefalse.DataBind();
            }
            else
            {

            }

        }

        protected void rbtnFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnFirst.SelectedValue == "0")
            {
                pnlMobileNo.Visible = true;
                pnlAcWiseDetails.Visible = false;
                pnldateWise.Visible = false;
                pnlIDWise.Visible = false;
            }
            else if (rbtnFirst.SelectedValue == "1")
            {
                pnlAcWiseDetails.Visible = true;
                pnlMobileNo.Visible = false;
                pnldateWise.Visible = false;
                pnlIDWise.Visible = false;
            }
            else if (rbtnFirst.SelectedValue == "2")
            {
                pnlAcWiseDetails.Visible = false;
                pnlMobileNo.Visible = false;
                pnldateWise.Visible = true;
                pnlIDWise.Visible = false;
            }
            else
            {
                pnlIDWise.Visible = true;
                pnlMobileNo.Visible = false;
                pnlAcWiseDetails.Visible = false;
                pnldateWise.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }
    }
}