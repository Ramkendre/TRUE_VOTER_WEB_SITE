using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmUploadStandardRates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        OleDbConnection conn = new OleDbConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        string mob = string.Empty;
        string roleID = string.Empty;
        DataSet ds = new DataSet();
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        CommonCode cc = new CommonCode();
        string fileExtension = string.Empty;
        string conPath = "";
        int count;
        /// <summary>
        /// this web page is build for upload Standard Rates into table tblExpenseMaster with excel upload for local body id wise upload facility is given in this page
        /// also download Standard Rates from tblExpenseMaster with local body id wise and district id wise thats it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);

            if (roleID != null)
            {
                if (IsPostBack == false)
                {
                    BindDistrict();
                    BindGridView();
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

        public void BindGridView()
        {
            cmd.CommandText = "uspDownloadStandardRates";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@mob", SqlDbType.NVarChar, 500).Value = mob.Trim();
            cmd.Parameters.Add("@Dist", SqlDbType.NVarChar, 500).Value = "0";
            cmd.Parameters.Add("@LBType", SqlDbType.NVarChar, 500).Value = "0";
            cmd.Parameters.Add("@LB", SqlDbType.NVarChar, 500).Value = "0";
            cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 500).Value = "1";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvStandardRates.DataSource = ds.Tables[0];
                gvStandardRates.DataBind();
            }
            else
            {
                gvStandardRates.EmptyDataText = "No Data Found";
                gvStandardRates.DataBind();
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
                ddlLocalBody.DataValueField = "ElectionId";
                ddlLocalBody.DataBind();
                ddlLocalBody.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLocalBody.SelectedIndex = 0;
            }
            else
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            try
            {
                if (FileId.HasFile)
                {
                    string path = "";
                    path = Server.MapPath("File_Upload");
                    path = path + "\\" + FileId.FileName;
                    string aa = FileId.FileName;
                    string[] fileEx = aa.Split('.');
                    string fileExtention = fileEx[1].ToString();

                    if (fileExtention == "xls" || fileExtention == "xlsx")
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            FileId.SaveAs(path);
                        }
                        else
                        {
                            FileId.SaveAs(path);
                        }
                        if (fileEx[0].ToString() == "StandardRates")
                        {
                            string strQuery = "SELECT * FROM [StandardRates$]";
                            DataSet dscount = GetDataTable(strQuery);

                            FetchQuestion(dscount);
                        }
                        else
                        {
                            Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  StandardRates file only.')</Script>");
                        }
                    }
                    else
                    {
                        Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) file only..')</Script>");
                    }
                }
                else
                {
                    Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) file only...')</Script>");
                }

            }
            catch
            {
                Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  StandardRates file only....')</Script>");
            }
        }

        public DataSet GetDataTable(string strQuery)
        {

            DataSet tempDs = null;
            string filePath = Server.MapPath("File_Upload\\" + FileId.FileName);
            fileExtension = System.IO.Path.GetExtension(filePath);
            if (this.fileExtension == ".xls")
            {
                conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
            }
            else
            {
                conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
            }
            conn = new OleDbConnection(conPath);
            try
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
                tempDs = new DataSet();
                adapter.Fill(tempDs);

            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "')</Script>");
            }
            finally
            {
                conn.Close();
            }
            return tempDs;
        }
        string Expense = "";
        string SubExpense = "";
        string Description = "";
        string StandardRate = "";
        string InsertDate = "";
        string InsertBy = "";
        string DistId = "";
        string ElectionType = "";
        string LocalBodyId = "";
        string IsActive = "";
        string MeasuringUnit = "";

        public void FetchQuestion(DataSet ExcelDs)
        {
            int countVal = ExcelDs.Tables[0].Rows.Count;
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();

                for (int i = 0; i < countVal; i++)
                {
                    Expense = Convert.ToString(ExcelDs.Tables[0].Rows[i][0]);
                    SubExpense = Convert.ToString(ExcelDs.Tables[0].Rows[i][1]);
                    MeasuringUnit = Convert.ToString(ExcelDs.Tables[0].Rows[i][2]);
                    Description = Convert.ToString(ExcelDs.Tables[0].Rows[i][3]);
                    StandardRate = Convert.ToString(ExcelDs.Tables[0].Rows[i][4]);
                    InsertDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                    InsertBy = mob;
                    DistId = ddlDistirct.SelectedValue;
                    ElectionType = ddlLocalBodytype.SelectedValue;

                    LocalBodyId = ddlLocalBody.SelectedValue;
                    IsActive = "1";

                    InsertData(Expense, SubExpense, MeasuringUnit, Description, StandardRate, InsertDate, InsertBy, DistId, ElectionType, LocalBodyId, IsActive);
                    count++;
                }
                Response.Write("<Script>alert('" + count + "Record Inserted Successfully..')</Script>");
                BindGridView();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }

        }

        public void InsertData(string Expense, string SubExpense, string MeasuringUnit, string Description, string StandardRate, string InsertDate, string InsertBy, string DistId, string ElectionType, string LocalBodyId, string IsActive)
        {
            try
            {
                cmd.CommandText = "uspInsertStandardratesExcel";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Expense", SqlDbType.NVarChar, 500).Value = Expense.Trim();
                cmd.Parameters.Add("@SubExpense", SqlDbType.NVarChar, 500).Value = SubExpense.Trim();
                cmd.Parameters.Add("@MeasuringUnit", SqlDbType.NVarChar, 500).Value = MeasuringUnit.Trim();

                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value = Description.Trim();
                cmd.Parameters.Add("@StandardRate", SqlDbType.NVarChar, 500).Value = StandardRate.Trim();
                cmd.Parameters.Add("@InsertDate", SqlDbType.NVarChar, 500).Value = InsertDate.Trim();

                cmd.Parameters.Add("@InsertBy", SqlDbType.NVarChar, 500).Value = InsertBy.Trim();
                cmd.Parameters.Add("@DistId", SqlDbType.NVarChar, 500).Value = DistId.Trim();
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 500).Value = ElectionType.Trim();

                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 500).Value = LocalBodyId.Trim();
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 500).Value = IsActive.Trim();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void gvStandardRates_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStandardRates.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void lnkbtnSampleDownload_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=StandardRates.xlsx");
            Response.TransmitFile(Server.MapPath("../DowManulCCExl/StandardRates.xlsx"));
            Response.End();
        }

        protected void btnDownloadSubExpen_Click(object sender, EventArgs e)
        {
            if (ddlDistirct.SelectedValue == "" || ddlDistirct.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this,typeof(Page),"Alert","alert('Please Select District')",true);
            }
            else if (ddlLocalBodytype.SelectedValue == "" || ddlLocalBodytype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Please Select LocalBody Type')", true);
            }
            else if (ddlLocalBody.SelectedValue == "" || ddlLocalBody.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Please Select LocalBody')", true);
            }
            else
            {
                cmd.CommandText = "uspDownloadStandardRates";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@mob", SqlDbType.NVarChar, 500).Value = "0";
                cmd.Parameters.Add("@Dist", SqlDbType.NVarChar, 500).Value = ddlDistirct.SelectedValue.Trim();
                cmd.Parameters.Add("@LBType", SqlDbType.NVarChar, 500).Value = ddlLocalBodytype.SelectedValue.Trim();
                cmd.Parameters.Add("@LB", SqlDbType.NVarChar, 500).Value = ddlLocalBody.SelectedValue.Trim();
                cmd.Parameters.Add("@qry", SqlDbType.NVarChar, 500).Value = "2";
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                GridView gvDown = new GridView();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDown.DataSource = ds.Tables[0];
                    gvDown.DataBind();
                }
                else
                {
                    gvDown.EmptyDataText = "No Data Found";
                    gvDown.DataBind();
                }

                gvDown.AllowPaging = false; //This Line is for Export Data to Excel while Paging is Apply on gridView
                string trueVoter = "TrueVoterStandardRates " + System.DateTime.Today.ToString("dd-MM-yyyy");
                if (gvDown.Visible)
                {
                    //Response.Clear();
                    Response.AddHeader("content-disposition", "attachment; filename=" + trueVoter + ".xls");
                    // Response.Charset = "";
                    Response.ContentType = "application/excel";
                    StringWriter sWriter = new StringWriter();
                    HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                    gvDown.RenderControl(hTextWriter);
                    Response.Write(sWriter.ToString());
                    Response.End();
                }
            }
        }
    }
}