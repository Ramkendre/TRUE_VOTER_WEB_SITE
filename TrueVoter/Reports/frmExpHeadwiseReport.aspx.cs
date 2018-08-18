using ClosedXML.Excel;
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
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmExpHeadwiseReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    BindDistrict();
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
            else
            {

            }
        }

        public void BindDistrict()
        {
            DataSet ds = new DataSet();
            ds = objBAL.BindDistrictBAL();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDistirct.DataSource = ds.Tables[0];
                ddlDistirct.DataTextField = "DistrictName";
                ddlDistirct.DataValueField = "DistrictCode";
                ddlDistirct.DataBind();
                ddlDistirct.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlDistirct.SelectedIndex = 0;
            }
            else
            {
            }
        }

        protected void ddlDistirct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            objBAL.DistrictId = Convert.ToInt32(ddlDistirct.SelectedValue);
            ds = objBAL.BindLocalBodyBAL(objBAL);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocalBody.DataSource = ds.Tables[0];
                ddlLocalBody.DataTextField = "ElectionName";
                ddlLocalBody.DataValueField = "SECElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] par = new SqlParameter[10];
                par[1] = new SqlParameter("@p1", ddlDistirct.SelectedValue);
                par[2] = new SqlParameter("@p2", ddlLocalBody.SelectedValue);
                par[3] = new SqlParameter("@p3", ddlWard.SelectedValue);

                int i = Convert.ToInt32(ddlReporttype.SelectedValue);

                switch (i)
                {
                    case 1:
                        par[4] = new SqlParameter("@p4", "0");
                        par[5] = new SqlParameter("@p5", "0");
                        par[0] = new SqlParameter("@p0", i);
                        break;
                    case 2:
                        par[4] = new SqlParameter("@p4", "0");
                        par[5] = new SqlParameter("@p5", "0");
                        par[0] = new SqlParameter("@p0", i);
                        break;
                    case 3:
                        par[4] = new SqlParameter("@p4", txtDate.Text);
                        par[5] = new SqlParameter("@p5", "0");
                        par[0] = new SqlParameter("@p0", i);
                        break;
                    case 4:
                        par[4] = new SqlParameter("@p4", ddlHead.SelectedValue);
                        par[5] = new SqlParameter("@p5", "0");
                        par[0] = new SqlParameter("@p0", i);
                        break;
                    //case 5:
                    //    par[4] = new SqlParameter("@p4", txtDate.Text);
                    //    par[5] = new SqlParameter("@p5", txtToDate.Text);
                    //    par[0] = new SqlParameter("@p0", i);
                    //    break;
                    default:
                        par[4] = new SqlParameter("@p4", "0");
                        par[0] = new SqlParameter("@p0", "0");
                        par[5] = new SqlParameter("@p5", "0");
                        break;
                }
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetExppenseReports", par);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["MyData"] = "00";
                    ViewState["MyData"] = ds.Tables[0];
                    gvExpByHead.DataSource = ds.Tables[0];
                    gvExpByHead.DataBind();
                    lblRecoredTotal.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                    btnExcelDownload.Visible = true;
                }
                else
                {
                    gvExpByHead.EmptyDataText = "No Data Found";
                    gvExpByHead.DataBind();
                    lblRecoredTotal.Text = "00";
                }
            }

            catch
            {

            }
        }

        public void ExcelDownload(DataTable dtvalue)
        {
            string excelFileName = "ExpenseReport" + System.DateTime.Now.ToString("ddMMyyyymmss") + ".xlsx";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtvalue, "AcExcel");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + excelFileName + "");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["MyData"] = null;
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBodytype.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlReporttype.SelectedIndex = 0;
            ddlHead.SelectedIndex = 0;
            ddlWard.SelectedIndex = 0;
            gvExpByHead.DataSource = null;
            gvExpByHead.DataBind();
            lblRecoredTotal.Text = "00";
            pnlDate.Visible = false;
            pnlToDate.Visible = false;
            pnlExpHead.Visible = false;
        }

        protected void btnExcelDownload_Click(object sender, EventArgs e)
        {
            DataTable td = (DataTable)ViewState["MyData"];
            try
            {
                if (td.Rows.Count > 0)
                {
                    ExcelDownload(td);
                }
            }
            catch
            {
                DataTable emptyTabe = new DataTable();
                emptyTabe.Columns.Add("Data");
                emptyTabe.Rows.Add("No Data Found");
                ExcelDownload(emptyTabe);
            }
        }

        protected void ddlReporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReporttype.SelectedValue == "3")
            {
                pnlExpHead.Visible = false;
                pnlDate.Visible = true;
                pnlToDate.Visible = false;
            }
            else if (ddlReporttype.SelectedValue == "4")
            {
                pnlExpHead.Visible = true;
                pnlDate.Visible = false;
                pnlToDate.Visible = false;
            }
            //else if (ddlReporttype.SelectedValue == "5")
            //{
            //    pnlExpHead.Visible = false;
            //    pnlDate.Visible = true;
            //    pnlToDate.Visible = true;
            //}
            else
            {
                pnlExpHead.Visible = false;
                pnlDate.Visible = false;
                pnlToDate.Visible = false;
            }

        }


    }
}