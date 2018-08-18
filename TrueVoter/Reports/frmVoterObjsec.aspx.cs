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
using Microsoft.ApplicationBlocks.Data;

namespace TrueVoter.Reports
{
    public partial class frmVoterObjsec : System.Web.UI.Page
    {
        string MobileNo = string.Empty;
        string UserName = string.Empty;
        string UserEmail = string.Empty;
        string DistID = string.Empty;
        string LocalBody = string.Empty;
        string LocalBodyId = string.Empty;
        string ComplaintType = string.Empty;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = null;
        
        string[] arrObjectionType = new string[] { "Name Not Found in Voter List", "Allocated To Wrong Ward" };
        string[] arrLocalBody = new string[] { "--Select--", "Municiple Corporation", "Municiple Council", "Nagar Panchayat", "Zilla Parishad", "Panchayat Samiti" };
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OffMobileNo"] != null)
            {
                MobileNo = Session["OffMobileNo"].ToString();
                UserName = Session["offName"].ToString();
                UserEmail = Session["OffEmailId"].ToString();
                DistID = Session["DistId"].ToString();
                LocalBody = Session["LocalBody"].ToString();
                LocalBodyId = Session["LocalBodyId"].ToString();
                ComplaintType = Session["ComplaintType"].ToString();
                BindGrid();
            }
            else
            {
                Response.Redirect("~/Admin/Home");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                string imageValue1 = string.Empty;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspInsertObjectionDetailsWeb";
                cmd.Connection = con;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 10).Value = MobileNo;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10).Value = UserName;
                cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 100).Value = UserEmail;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = DistID;

                cmd.Parameters.Add("@LocalBody", SqlDbType.NVarChar, 10).Value = LocalBody;
                cmd.Parameters.Add("@LocalBodyID", SqlDbType.NVarChar, 30).Value = LocalBodyId;
                cmd.Parameters.Add("@ComplaintType", SqlDbType.NVarChar, 30).Value = ComplaintType;
                cmd.Parameters.Add("@ACNo", SqlDbType.NVarChar, 10).Value = txtAssemblyNo.Text;

                cmd.Parameters.Add("@PARTNo", SqlDbType.NVarChar, 10).Value = txtpartNo.Text;
                cmd.Parameters.Add("@SRNo", SqlDbType.NVarChar, 10).Value = txtSrNo.Text;
                cmd.Parameters.Add("@VoterName", SqlDbType.NVarChar, 500).Value = txtVoterName.Text;
                cmd.Parameters.Add("@VoterMoNo", SqlDbType.NVarChar, 10).Value = txtVotermobileNo.Text;

                cmd.Parameters.Add("@ObjectionType", SqlDbType.NVarChar, 10).Value = ddlobjectionType.SelectedValue;
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar, 100).Value = txtAddress.Text;
                cmd.Parameters.Add("@ExpectedWardNo", SqlDbType.NVarChar, 20).Value = txtWard.Text;
                cmd.Parameters.Add("@DocId", SqlDbType.NVarChar, 10).Value = ddlDocList.SelectedValue;

                cmd.Parameters.Add("@Latitude", SqlDbType.NVarChar, 15).Value = 0;
                cmd.Parameters.Add("@Longitude", SqlDbType.NVarChar, 15).Value = 0;
                cmd.Parameters.Add("@IMEI", SqlDbType.NVarChar, 20).Value = 0;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 20).Value = System.DateTime.Now.ToString("yyyy-MM-dd");

                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = MobileNo;
                if (ufImages.HasFile)
                {
                    string filePath = ufImages.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;

                    if (ext == ".jpg" || ext == ".png" || ext == ".gif")
                    {
                        Stream fs = ufImages.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        imageValue1 = Convert.ToBase64String(bytes);
                        cmd.Parameters.Add("@PhotoOne", SqlDbType.NVarChar).Value = imageValue1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PhotoOne", SqlDbType.NVarChar).Value = "NA";
                    }
                }
                else
                {
                    cmd.Parameters.Add("@PhotoOne", SqlDbType.NVarChar).Value = "NA";
                }

                if (ufImage2.HasFile)
                {
                    string filePath = ufImage2.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;

                    if (ext == ".jpg" || ext == ".png" || ext == ".gif")
                    {
                        Stream fs = ufImage2.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        imageValue1 = Convert.ToBase64String(bytes);
                        cmd.Parameters.Add("@PhotoTwo", SqlDbType.NVarChar).Value = imageValue1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@PhotoTwo", SqlDbType.NVarChar).Value = "NA";
                    }
                }
                else
                {
                    cmd.Parameters.Add("@PhotoTwo", SqlDbType.NVarChar).Value = "NA";
                }
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGrid();
            }
            catch
            {

            }
        }

        protected void gvVoterObjection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoterObjection.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Home");
            Session.Abandon();
            Session.Clear();
        }

        public void BindGrid()
        {
            DataSet dsCompl = new DataSet();
            try
            {
                //string query = "SELECT * FROM [TrueVoterDB].[dbo].[tblComplaint] INNER JOIN [TrueVoterDB].[dbo].[tblComplaintPhotos]" +
                //               "ON [TrueVoterDB].[dbo].[tblComplaint].[ID]=[TrueVoterDB].[dbo].[tblComplaintPhotos].[ComID]" +
                //               "WHERE [TrueVoterDB].[dbo].[tblComplaint].[MobileNo]='" + MobileNo + "' ORDER BY [TrueVoterDB].[dbo].[tblComplaint].[ID] DESC";
                //cmd = new SqlCommand(query, con);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(dsCompl);


                SqlParameter[] par=new SqlParameter[1];
                par[0] = new SqlParameter("@MoNo",MobileNo);
                dsCompl = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCompliantPhotos", par);


                if (dsCompl.Tables[0].Rows.Count > 0)
                {
                    gvVoterObjection.DataSource = dsCompl.Tables[0];
                    gvVoterObjection.DataBind();
                }
                else
                {
                    gvVoterObjection.DataSource = dsCompl.Tables[0];
                    gvVoterObjection.DataBind();
                }
            }
            catch
            {

            }
        }

        public void Clear()
        {
            txtAssemblyNo.Text = string.Empty;
            txtpartNo.Text = string.Empty;
            txtSrNo.Text = string.Empty;
            txtVotermobileNo.Text = string.Empty;
            txtVoterName.Text = string.Empty;
            txtWard.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlDocList.SelectedIndex = 0;
            ddlobjectionType.SelectedIndex = 0;
        }

        protected void gvVoterObjection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.Cells[9].Text == "1")
                {
                    e.Row.Cells[9].Text = arrObjectionType[0].ToString();
                }
                else if (e.Row.Cells[9].Text == "2")
                {
                    e.Row.Cells[9].Text = arrObjectionType[1].ToString();
                }

                if (e.Row.Cells[7].Text == "1")
                {
                    e.Row.Cells[7].Text = arrLocalBody[1].ToString();
                }
                else if (e.Row.Cells[7].Text == "2")
                {
                    e.Row.Cells[7].Text = arrLocalBody[2].ToString();
                }
                else if (e.Row.Cells[7].Text == "3")
                {
                    e.Row.Cells[7].Text = arrLocalBody[3].ToString();
                }
                else if (e.Row.Cells[7].Text == "4")
                {
                    e.Row.Cells[7].Text = arrLocalBody[4].ToString();
                }
                else if (e.Row.Cells[7].Text == "5")
                {
                    e.Row.Cells[7].Text = arrLocalBody[5].ToString();
                }
            }
            catch
            {
            }

        }


    }
}