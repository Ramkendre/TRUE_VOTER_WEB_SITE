using Microsoft.ApplicationBlocks.Data;
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
    public partial class frmUploadBoothAddress : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        OleDbConnection conn = new OleDbConnection();
        string mob = string.Empty;
        string Refmob = string.Empty;
        string roleID = string.Empty;
        string conPath = "";
        int count;
        string fileExtension = string.Empty;
        AddProformNo5BAL objBAL = new AddProformNo5BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    BindDistrict();
                    BindGridView();
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

        public void BindGridView()
        {
            try
            {
                GetRefMoNo();
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@Mob", mob);
                DataSet dsBooth = new DataSet();
                dsBooth = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetMyUploadedBoothAddress", par);
                if (dsBooth.Tables[0].Rows.Count > 0)
                {
                    gvBoothAddress.DataSource = dsBooth.Tables[0];
                    gvBoothAddress.DataBind();
                }
                else
                {
                    gvBoothAddress.EmptyDataText = "No Data Found";
                    gvBoothAddress.DataBind();
                }
            }
            catch
            {
            }
        }

        public void GetRefMoNo()
        {
            mob = Convert.ToString(Session["MobileNO"]);
            if (mob != "")
            {
                try
                {
                    SqlParameter[] par = new SqlParameter[1];
                    par[0] = new SqlParameter("@Mob", mob);
                    DataSet dsRef = new DataSet();
                    dsRef = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetRefMoNo", par);
                    if (dsRef.Tables[0].Rows.Count > 0)
                    {
                        Refmob = Convert.ToString(dsRef.Tables[0].Rows[0][0]);
                    }
                }
                catch
                {
                }
            }
            else
            {
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlDistirct.SelectedIndex > 0 && ddlLocalBody.SelectedIndex > 0 && ddlLocalBodytype.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
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
                            if (fileEx[0].ToString() == "BoothAdd")
                            {
                                string strQuery = "SELECT * FROM [BoothAdd$]";
                                DataSet dscount = GetDataTable(strQuery);
                                GetRefMoNo();
                                FetchQuestion(dscount);
                            }
                            else
                            {
                                Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  Booth Address file only.. ')</Script>");
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) file only')</Script>");
                    }
                }
                catch
                {
                    Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) Booth Address file only.. ')</Script>");
                }
            }
            else
            {
                Response.Write("<Script>alert('Please Select All Details')</Script>");
            }
        }

        public DataSet GetDataTable(string strQuery)
        {

            DataSet tempDs = null;
            string filePath = Server.MapPath("File_Upload\\" + FileId.FileName);
            fileExtension = Path.GetExtension(filePath);
            if (this.fileExtension == ".xls")
            {
                conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
            }
            else
            {
                conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
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

        string Ward = ""; string BoothNo = ""; string BoothAddress = "";
        string CreatedBy = ""; string ReffrenceMo = ""; string LocalBodyId = "";
        string Lat = ""; string Long = ""; string IMEI = ""; string LocalBodytype = "";

        public void FetchQuestion(DataSet ExcelDs)
        {
            int countVal = ExcelDs.Tables[0].Rows.Count;

            for (int i = 0; i < countVal; i++)
            {
                Ward = Convert.ToString(ExcelDs.Tables[0].Rows[i][1]);
                BoothNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][2]);
                BoothAddress = Convert.ToString(ExcelDs.Tables[0].Rows[i][3]);
                CreatedBy = mob;
                ReffrenceMo = Refmob;
                LocalBodyId = ddlLocalBody.SelectedValue;
                LocalBodytype = ddlLocalBodytype.SelectedValue;
                Lat = "0";
                Long = "0";
                IMEI = "0";

                InsertData(Ward, BoothNo, BoothAddress, CreatedBy, ReffrenceMo, LocalBodyId, Lat, Long, IMEI, LocalBodytype);
            }
            Clear();
            
            Response.Write("<Script>alert('Record Inserted :" + count + "')</Script>");
        }

        public void InsertData(string Ward, string BoothNo, string BoothAddress, string CreatedBy, string ReffrenceMo, string LocalBodyId, string Lat, string Long, string IMEI, string LocalBodytype)
        {
            try
            {
                if (Ward.Trim() != "" && BoothNo.Trim() != "" && BoothAddress.Trim() != "" && ReffrenceMo.Trim() != "" && CreatedBy.Trim() != "")
                {
                    SqlParameter[] par1 = new SqlParameter[11];
                    par1[0] = new SqlParameter("@Ward", Ward);
                    par1[1] = new SqlParameter("@BoothNo", BoothNo);
                    par1[2] = new SqlParameter("@BoothAddress", BoothAddress);
                    par1[3] = new SqlParameter("@CreatedBy", CreatedBy);
                    par1[4] = new SqlParameter("@ReffrenceMo", ReffrenceMo);
                    par1[5] = new SqlParameter("@LocalBodyId", LocalBodyId);
                    par1[6] = new SqlParameter("@Lat", Lat);
                    par1[7] = new SqlParameter("@Long", Long);
                    par1[8] = new SqlParameter("@IMEI", IMEI);
                    par1[9] = new SqlParameter("@LocalBodytype", LocalBodytype);
                    par1[10] = new SqlParameter("@CreatedDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertBoothAddFromExcel", par1);
                    count++;
                }
                else
                {
                }
            }
            catch
            {

            }
        }

        protected void lnkbtnSampleDownload_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=BoothAdd.xlsx");
            Response.TransmitFile(Server.MapPath("../DowManulCCExl/BoothAdd.xlsx"));
            Response.End();
        }

        public void Clear()
        {
            ddlDistirct.SelectedIndex = 0;
            ddlLocalBody.SelectedIndex = 0;
            ddlLocalBodytype.SelectedIndex = 0;
            FileId.Dispose();
            BindGridView();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}