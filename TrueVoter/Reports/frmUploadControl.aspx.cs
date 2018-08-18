//using BLL;
//using BOL;
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
    public partial class frmUploadControl : System.Web.UI.Page
    {
        string fileExtension = string.Empty;
        OleDbConnection conn = new OleDbConnection();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
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
                //mob = objlogin.UserInformation.MobileNo;
                BindGridView();
            }
            else
            {
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void BindGridView()
        {
            DataSet ds2 = new DataSet();
            try
            {
                string query = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreateDate],[CreatedBy],[Latitude],[Longitude],[vstatus],[Voters],[IsActive] FROM [TrueVoterDB].[dbo].[tblControlChartUploadData] WHERE [CreatedBy]='" + mob + "' ORDER BY [SrNo] DESC";
                cmd = new SqlCommand(query, con);

                //cmd.CommandText = "uspSelectControlChartUploadData";
                //cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds2;
                    GridView1.DataBind();
                }
                else
                {

                }
            }
            catch
            {

            }
        }
        public DataSet GetDataTable(string strQuery)
        {

            DataSet tempDs = null;
            string filePath = Server.MapPath("File_Upload\\" + FileId.FileName);
            fileExtension = Path.GetExtension(filePath);
            if (this.fileExtension == ".xls")
            {
                conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
            }
            else
            {
                conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
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
        public void InsertData(string AcNo, string PartNo, string WardNo, string FromSrNo, string ToSrNo, string RoleType, string Lat, string Long, string VoterStatus, int voter)
        {
            try
            {
                string str2 = "INSERT INTO [TrueVoterDB].[dbo].[tblControlChartUploadData] ([ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype]," +
                                             "[CreateDate],[CreatedBy],[Latitude],[Longitude],[vstatus],[Voters]) VALUES " +
                                             "('" + AcNo + "','" + PartNo + "','" + FromSrNo + "','" + ToSrNo + "' ,'" + WardNo + "','" + txtvoterstaffNo.Text.Trim() + "','" + txthigoffNo.Text.Trim() + "'" +
                                             ",'" + RoleType + "' ,'" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + "','" + mob + "','" + Lat + "'" +
                                             ",'" + Long + "','" + VoterStatus + "','" + voter + "')";
                con.Open();
                SqlCommand cmd6 = new SqlCommand(str2, con);
                cmd6.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        string AcNo = ""; string PartNo = ""; string WardNo = "";
        string FromSrNo = ""; string ToSrNo = ""; string RoleType = "";
        string Lat = ""; string Long = ""; string VoterStatus = "";
        public void FetchQuestion(DataSet ExcelDs)
        {
            int countVal = ExcelDs.Tables[0].Rows.Count;

            for (int i = 0; i < 10; i++)
            {
                AcNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][1]);
                PartNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][2]);
                WardNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][3]);
                FromSrNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][4]);
                ToSrNo = Convert.ToString(ExcelDs.Tables[0].Rows[i][5]);
                RoleType = Convert.ToString(ExcelDs.Tables[0].Rows[i][6]);
                //FromUser = Convert.ToString(ExcelDs.Tables[0].Rows[i][7]);
                //toUser = Convert.ToString(ExcelDs.Tables[0].Rows[i][8]);
                Lat = Convert.ToString(ExcelDs.Tables[0].Rows[i][11]);
                Long = Convert.ToString(ExcelDs.Tables[0].Rows[i][12]);
                VoterStatus = Convert.ToString(ExcelDs.Tables[0].Rows[i][13]);

                int voter = (Convert.ToInt32(ToSrNo) - Convert.ToInt32(FromSrNo)) + 1;

                InsertData(AcNo, PartNo, WardNo, FromSrNo, ToSrNo, RoleType, Lat, Long, VoterStatus, voter);
                count++;
            }
            txthigoffNo.Text = "";
            txtvoterstaffNo.Text = "";
            Response.Write("<Script>alert('Record Inserted :" + count + "')</Script>");
        }
        // DataSet ExcelDB;
        public string excelSubject = "";
        protected void btnAdd_Click(object sender, EventArgs e)
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

                        string sheetName = aa.Substring(0, 31);
                        // excelSubject = "ControlChart";
                        string sheetcheck = sheetName.Substring(29, 2);
                        if (sheetcheck == "Co")
                        {
                            string strQuery = "SELECT * FROM [" + sheetName + "$]";
                            DataSet dscount = GetDataTable(strQuery);

                            FetchQuestion(dscount);
                        }
                        else
                        {
                            Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  Control Chart file only.. ')</Script>");
                        }
                    }
                    else
                    {
                        Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) file only')</Script>");
                    }
                }
                else
                {
                    Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook) file only')</Script>");
                }
            }
            catch
            {
                Response.Write("<Script>alert('Please upload .xls or .xlsx(Excel WorkBook)  Control Chart file only.. ')</Script>");
            }
        }
        protected void gvUploadCC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        protected void InsertRecord(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;
            LinkButton lnkRemove = (LinkButton)sender;
            cmd.Connection = con;
            DataSet ds1 = new DataSet();
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkbox = (CheckBox)GridView1.Rows[i].Cells[13].FindControl("CheckBox1");

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
            string query = "SELECT [SrNo],[ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreateDate],[CreatedBy],[Latitude],[Longitude],[vstatus],[Voters] FROM [TrueVoterDB].[dbo].[tblControlChartUploadData]  WHERE [SrNo] IN (" + gvSNO + ") AND IsActive=0 ";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds1);
            int insertCount = 0;
            int dsCount = ds1.Tables[0].Rows.Count;
            if (dsCount > 0)
            {
                for (int i = 0; i < dsCount; i++)
                {
                    string query1 = "INSERT INTO [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] ([ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreateDate],[CreatedBy],[Latitude],[Longitude],[vstatus],[Voters]) " +
                                    " VALUES ('" + ds1.Tables[0].Rows[i]["ACNO"] + "','" + ds1.Tables[0].Rows[i]["PartNo"] + "','" + ds1.Tables[0].Rows[i]["SrNoFrom"] + "'" +
                                    ",'" + ds1.Tables[0].Rows[i]["SrNoTo"] + "','" + ds1.Tables[0].Rows[i]["WardNo"] + "'" +
                                     ",'" + ds1.Tables[0].Rows[i]["FromUser"] + "','" + ds1.Tables[0].Rows[i]["ToUser"] + "'" +
                                    ",'" + ds1.Tables[0].Rows[i]["roletype"] + "','" + ds1.Tables[0].Rows[i]["CreateDate"] + "','" + ds1.Tables[0].Rows[i]["CreatedBy"] + "'" +
                                    ",'" + ds1.Tables[0].Rows[i]["Latitude"] + "','" + ds1.Tables[0].Rows[i]["Longitude"] + "','" + ds1.Tables[0].Rows[i]["vstatus"] + "','" + ds1.Tables[0].Rows[i]["Voters"] + "')";
                    cmd = new SqlCommand(query1, con);
                    con.Open();
                    int j = cmd.ExecuteNonQuery();

                    string query2 = "UPDATE [TrueVoterDB].[dbo].[tblControlChartUploadData] SET  [IsActive] = 1 , [ModifiedDate] = '" + System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss tt") + "', [ModifiedBy] = '" + mob + "' WHERE [SrNo] IN (" + gvSNO + ")";
                    cmd = new SqlCommand(query2, con);
                    int k = cmd.ExecuteNonQuery();
                    con.Close();
                    insertCount++;

                }
                Response.Write("<Script>alert('Record Inserted Sucessfully:" + insertCount + "')</Script>");
            }
            else
            {

            }
            BindGridView();
        }
        protected void DeleteRecord(object sender, EventArgs e)
        {
            string gvSNO = string.Empty;

            LinkButton lnkRemoveDeactive = (LinkButton)sender;
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            int updatecount = 0;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkbox = ((CheckBox)GridView1.Rows[i].Cells[13].FindControl("CheckBox1"));
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

            cmd.CommandText = "DELETE FROM [TrueVoterDB].[dbo].[tblControlChartUploadData]  WHERE [SrNo] IN (" + gvSNO + ")";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //lblResult.Text = updatecount + " Records are Updated Successfully.!!!";
            //lblResult.ForeColor = Color.Green;

            BindGridView();
        }
    }
}