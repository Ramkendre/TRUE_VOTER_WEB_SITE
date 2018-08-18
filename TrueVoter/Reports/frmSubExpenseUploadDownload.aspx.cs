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
using ClosedXML.Excel;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.Reports
{
    public partial class frmSubExpenseUploadDownload : System.Web.UI.Page
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
        /// this web page is build for upload subexpense into table tblsubexpense with excel upload for local body id wise upload facility is given inthis page
        /// also download sub expenses from tblsubexpenses with local body id wise and district id wise thats it
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
        public DataSet BindgvSubExpense()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "uspDownloadSubExpenses";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@distId", ddlDistirct.SelectedValue);
            cmd.Parameters.AddWithValue("@LocalBodyId", ddlLocalBody.SelectedValue);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            gvSubExpense.DataSource = ds.Tables[0];
            gvSubExpense.DataBind();

            return ds;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnDownloadSubExpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDistirct.SelectedValue == "" || ddlDistirct.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "alert('Please Select District')", true);
                }

                else
                {
                    DataTable dtvalue = new DataTable();
                    DataSet ds = new DataSet();
                    ds = BindgvSubExpense();
                    dtvalue = (DataTable)ds.Tables[0];
                    string excelFileName = "SubExpense.xlsx";

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
            }
            catch
            {
            }

        }

        protected void gvSubExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubExpense.PageIndex = e.NewPageIndex;
            BindgvSubExpense();
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
                        if (fileEx[0].ToString() == "SubExpTypes")
                        {
                            string strQuery = "SELECT * FROM [SubExpTypes$]";
                            DataSet dscount = GetDataTable(strQuery);

                            FetchQuestion(dscount);
                        }
                        else
                        {
                            Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  SubExpenseTypes file only.')</Script>");
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
                Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  SubExpenseTypes file only....')</Script>");
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
        string ExpenseId = "";
        string SubExpense = "";
        string InsertDate = "";
        string InsertBy = "";
        string DistId = "";
        string IsActive = "";
        string ElectionType = "";
        string LocalBodyId = "";
        public void FetchQuestion(DataSet ExcelDs)
        {
            int countVal = ExcelDs.Tables[0].Rows.Count;
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();

                for (int i = 0; i < countVal; i++)
                {
                    ExpenseId = Convert.ToString(ExcelDs.Tables[0].Rows[i][0]);
                    SubExpense = Convert.ToString(ExcelDs.Tables[0].Rows[i][1]);
                    InsertDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                    InsertBy = mob;
                    DistId = ddlDistirct.SelectedValue;
                    ElectionType = ddlLocalBodytype.SelectedValue;
                    LocalBodyId = ddlLocalBody.SelectedValue;
                    IsActive = "1";

                    InsertData(ExpenseId, SubExpense, InsertDate, InsertBy, DistId, IsActive, LocalBodyId, ElectionType);
                    count++;
                }
                Response.Write("<Script>alert('" + count + "Record Inserted Successfully..')</Script>");
                BindgvSubExpense();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }

        }

        public void InsertData(string Expense, string SubExpense, string InsertDate, string InsertBy, string DistId, string IsActive, string LocalBodyId,string ElectionType)
        {
            try
            {
                cmd.CommandText = "uspInsertSubExpenseExcel";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Expense", SqlDbType.NVarChar, 500).Value = Expense.Trim();
                cmd.Parameters.Add("@SubExpense", SqlDbType.NVarChar, 500).Value = SubExpense.Trim();
                cmd.Parameters.Add("@InsertDate", SqlDbType.NVarChar, 500).Value = InsertDate.Trim();
                cmd.Parameters.Add("@InsertBy", SqlDbType.NVarChar, 500).Value = InsertBy.Trim();
                cmd.Parameters.Add("@DistId", SqlDbType.NVarChar, 500).Value = DistId.Trim();
                cmd.Parameters.Add("@IsActive", SqlDbType.NVarChar, 500).Value = IsActive.Trim();
                cmd.Parameters.Add("@LocalBodyId", SqlDbType.NVarChar, 500).Value = LocalBodyId.Trim();
                cmd.Parameters.Add("@ElectionType", SqlDbType.NVarChar, 500).Value = ElectionType.Trim();
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


        protected void lnkbtnSampleDownload_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=SubExpTypes.xlsx");
            Response.TransmitFile(Server.MapPath("../DowManulCCExl/SubExpTypes.xlsx"));
            Response.End();
        }
    }
}