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

namespace TrueVoter.Reports
{
    public partial class frmUploadVoterAnalysisData : System.Web.UI.Page
    {
        string fileExtension = string.Empty;
        OleDbConnection conn = new OleDbConnection();
        SqlConnection con = new SqlConnection("server=103.10.191.60;Initial Catalog=DBVoterAnalysis;User id=sa;Password=K17jyjo8/T+6z2v; Max Pool Size=300");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string conPath = "";
        int count;
        string mob = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();
                if (IsPostBack != true)
                {
                    BindGridView();
                }
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
        }

        protected void lnkbtnSampleDownload_Click(object sender, EventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=VoterAnalysisDetails.xlsx");
            Response.TransmitFile(Server.MapPath("../DowManulCCExl/VoterAnalysisDetails.xlsx"));
            Response.End();
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
                        if (fileEx[0].ToString() == "VoterAnalysisDetails")
                        {
                            string strQuery = "SELECT * FROM [VoterDetails$]";
                            DataSet dscount = GetDataTable(strQuery);

                            FetchQuestion(dscount);
                        }
                        else
                        {
                            Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  Control Chart file only.')</Script>");
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
                Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  Control Chart file only....')</Script>");
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
        string ACNO = ""; string PARTNO = ""; string SrNo = ""; string IdCard = ""; string VoterMobileNo = "";
        string ColorChangeValue = ""; string IsVoted = ""; string Caste = "";
        string Occupation = ""; string QualificationValue = ""; string PartyId = ""; string AdharCardNo = "";
        string DOB = ""; string BoothNo = ""; string Address = ""; string Area = ""; string Building_Society = ""; string Religion = "";

        public void FetchQuestion(DataSet ExcelDs)
        {
            int countVal = ExcelDs.Tables[0].Rows.Count;
            if (Session["MobileNo"] != null)
            {
                mob = Session["MobileNo"].ToString();

                for (int i = 0; i < countVal; i++)
                {
                    ACNO = Convert.ToString(ExcelDs.Tables[0].Rows[i][0]);
                    PARTNO = Convert.ToString(ExcelDs.Tables[0].Rows[i][1]);
                    SrNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][2]);
                    IdCard = Convert.ToString(ExcelDs.Tables[0].Rows[i][3]);

                    VoterMobileNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][4]);
                    ColorChangeValue = Convert.ToString(ExcelDs.Tables[0].Rows[i][5]);
                    Caste = Convert.ToString(ExcelDs.Tables[0].Rows[i][6]);
                    Occupation = Convert.ToString(ExcelDs.Tables[0].Rows[i][7]);

                    QualificationValue = Convert.ToString(ExcelDs.Tables[0].Rows[i][8]);
                    PartyId = Convert.ToString(ExcelDs.Tables[0].Rows[i][9]);
                    AdharCardNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][10]);
                    DOB = Convert.ToString(ExcelDs.Tables[0].Rows[i][11]);


                    Address = Convert.ToString(ExcelDs.Tables[0].Rows[i][12]);
                    Area = Convert.ToString(ExcelDs.Tables[0].Rows[i][13]);
                    Building_Society = Convert.ToString(ExcelDs.Tables[0].Rows[i][14]);
                    Religion = Convert.ToString(ExcelDs.Tables[0].Rows[i][15]);

                    BoothNo = "0";
                    IsVoted = "0";
                    if (ACNO != "" && PARTNO != "" && SrNo != "")
                    {
                        InsertData(ACNO, PARTNO, SrNo, IdCard, VoterMobileNo, ColorChangeValue, IsVoted, Caste, Occupation, QualificationValue, PartyId, AdharCardNo, DOB, BoothNo, Address, Area, Building_Society, Religion);
                        count++;
                    }
                }
                Response.Write("<Script>alert('" + count + " Record Inserted Successfully..')</Script>");
                BindGridView();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }

        }

        public void InsertData(string ACNO, string PARTNO, string SrNo,
                                string IdCard, string VoterMobileNo, string ColorChangeValue,
                                string IsVoted, string Caste, string Occupation,
                                string QualificationValue, string PartyId, string AdharCardNo,
                                string DOB, string BoothNo, string Address,
                                string Area, string Building_Society, string Religion)
        {
            try
            {
                cmd.CommandText = "uspInsertVoterDetailsData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ACNO", SqlDbType.NVarChar, 500).Value = ACNO.Trim();
                cmd.Parameters.Add("@PARTNO", SqlDbType.NVarChar, 500).Value = PARTNO.Trim();
                cmd.Parameters.Add("@SrNo", SqlDbType.NVarChar, 500).Value = SrNo.Trim();

                cmd.Parameters.Add("@IdCard", SqlDbType.NVarChar, 500).Value = IdCard.Trim();
                cmd.Parameters.Add("@VoterMobileNo", SqlDbType.NVarChar, 500).Value = VoterMobileNo.Trim();
                cmd.Parameters.Add("@ColorChangeValue", SqlDbType.NVarChar, 500).Value = ColorChangeValue.Trim();

                cmd.Parameters.Add("@IsVoted", SqlDbType.NVarChar, 500).Value = IsVoted.Trim();
                cmd.Parameters.Add("@Caste", SqlDbType.NVarChar, 500).Value = Caste.Trim();
                cmd.Parameters.Add("@Occupation", SqlDbType.NVarChar, 500).Value = Occupation.Trim();

                cmd.Parameters.Add("@QualificationValue", SqlDbType.NVarChar, 500).Value = QualificationValue.Trim();
                cmd.Parameters.Add("@PartyId", SqlDbType.NVarChar, 500).Value = PartyId.Trim();
                cmd.Parameters.Add("@AdharCardNo", SqlDbType.NVarChar, 500).Value = AdharCardNo.Trim();

                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 500).Value = DOB.Trim();
                cmd.Parameters.Add("@BoothNo", SqlDbType.NVarChar, 500).Value = BoothNo.Trim();
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = Address.Trim();

                cmd.Parameters.Add("@Area", SqlDbType.NVarChar, 500).Value = Area.Trim();
                cmd.Parameters.Add("@Building_Society", SqlDbType.NVarChar, 500).Value = Building_Society.Trim();
                cmd.Parameters.Add("@Religion", SqlDbType.NVarChar, 500).Value = Religion.Trim();

                cmd.Parameters.Add("@CreateDate", SqlDbType.NVarChar, 500).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 500).Value = mob.Trim();
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

        protected void gvVoterDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoterDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        public void BindGridView()
        {
            string str = "SELECT * FROM tblUploadedVAData Where CreatedBy='" + mob + "'";
            cmd = new SqlCommand(str, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvVoterDetails.DataSource = ds.Tables[0];
                gvVoterDetails.DataBind();
            }
            else
            {
                gvVoterDetails.EmptyDataText = "No Data Found";
                gvVoterDetails.DataBind();
            }
        }
    }
}