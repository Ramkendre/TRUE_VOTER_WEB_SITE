using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TrueVoter.Reports
{
    public partial class AssignLatLog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myctConnectionString"].ConnectionString);
        SqlConnection contrue = new SqlConnection(ConfigurationManager.ConnectionStrings["Assignlat"].ConnectionString);
        //SqlConnection contrue = new SqlConnection("Data Source=103.16.140.243;Initial Catalog=TrueVoterDB;User ID=TrueVoter;Password=TrueVoter@#123;");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        string tableName = string.Empty;
        string ACNo = string.Empty;
        string PartNo = string.Empty;
        int Count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            cnt.Visible = false;
            Latname0.Visible = false;
        }

        public string GettableName()
        {
            try
            {
                string tempACNo = txtAcNo.Text;
                int i = tempACNo.Length;
                if (i == 1)
                {
                    ACNo = "00" + "" + tempACNo + "";
                }
                if (i == 2)
                {
                    ACNo = "0" + "" + tempACNo + "";
                }
                else if (i == 3)
                {
                    ACNo = txtAcNo.Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Invalid AC No...!!!')", true);
                }
                string tempPartNo = txtPartNo.Text;
                int j = tempPartNo.Length;
                if (j == 1)
                {
                    PartNo = "00" + "" + tempPartNo + "";
                }
                else if (j == 2)
                {
                    PartNo = "0" + "" + tempPartNo + "";
                }
                else if (j == 3)
                {
                    PartNo = txtPartNo.Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Invalid Part No...!!!')", true);
                }
                tableName = "AC" + "" + ACNo + "" + "part" + "" + PartNo + "";

                return tableName;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                string tN = GettableName();
                string sqlQuery = "SELECT LTRIM(RTRIM([FM_NAMEEN]))+' '+LTRIM(RTRIM([LASTNAMEEN])) AS Name,[IDCARD_NO] FROM [AC_" + ACNo + "_ECI2016].[dbo]." + "[" + "" + tN + "" + "] WHERE FM_NAMEEN LIKE'" + txtsearch.Text + "%'";
                cmd.Connection = contrue;
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["griddata"] = ds.Tables[0];
                    gvAsslatlog.DataSource = ds.Tables[0];
                    gvAsslatlog.DataBind();
                }
                else
                {
                    gvAsslatlog.EmptyDataText = "No Record Found..!!!";
                    gvAsslatlog.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void gvAsslatlog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsslatlog.PageIndex = e.NewPageIndex;
            gvAsslatlog.DataSource = ViewState["griddata"];
            gvAsslatlog.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lat.Text = HiddenFieldLat.Value;
                longi.Text = HiddenFieldLong.Value;

                if (lat.Text == "" || lat.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Latitude and Longitude...!!!')", true);
                }
                else
                {
                    DataSet ds1 = null;
                    foreach (GridViewRow row in gvAsslatlog.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                            if (chkRow.Checked)
                            {
                                string IDCARDNO = row.Cells[2].Text.Trim();
                                string Name = row.Cells[1].Text.Trim();
                                string Latitude = HiddenFieldLat.Value;
                                string longitude = HiddenFieldLong.Value;
                                string CreatedBy = "SM";
                                string CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss tt");

                                string sqlQuery = "SELECT [IDCARD_NO] FROM [AC_174_ECI2016].[dbo].[tblLatLongAss] WHERE [IDCARD_NO]='" + IDCARDNO + "'";
                                cmd.Connection = contrue;
                                cmd.CommandText = sqlQuery;
                                cmd.CommandType = CommandType.Text;
                                da.SelectCommand = cmd;
                                ds1 = new DataSet();
                                da.Fill(ds1);

                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    string sqlQuery1 = "UPDATE [AC_174_ECI2016].[dbo].[tblLatLongAss] SET  [Name]='" + Name + "', [Latitude]='" + Latitude + "', [longitude]='" + longitude + "',[ACNO]='" + txtAcNo.Text + "',[PARTNO]='" + txtPartNo.Text + "',[UpdatedBy]='" + CreatedBy + "',[UpdatedDate]='" + CreatedDate + "' WHERE [IDCARD_NO]='" + IDCARDNO + "' ";
                                    cmd.Connection = contrue;
                                    cmd.CommandText = sqlQuery1;
                                    cmd.CommandType = CommandType.Text;
                                    contrue.Open();
                                    cmd.ExecuteNonQuery();
                                    contrue.Close();
                                }
                                else
                                {
                                    string sqlQuery1 = "INSERT INTO [AC_174_ECI2016].[dbo].[tblLatLongAss] ([IDCARD_NO], [Name], [Latitude], [longitude],[CreatedBy],[CreatedDate],[ACNO],[PARTNO]) VALUES ('" + IDCARDNO + "','" + Name + "','" + Latitude + "','" + longitude + "','" + CreatedBy + "','" + CreatedDate + "','" + txtAcNo.Text + "','" + txtPartNo.Text + "') ";
                                    cmd.Connection = contrue;
                                    cmd.CommandText = sqlQuery1;
                                    cmd.CommandType = CommandType.Text;
                                    contrue.Open();
                                    cmd.ExecuteNonQuery();
                                    contrue.Close();
                                }
                                Count += 1;

                            }

                        }

                    }
                    cnt.Text = Count.ToString();
                    cnt.Visible = true;
                    Latname0.Visible = true;
                    //Response.Write("<script>alert('" + Count + "'  Record Inserted Successfully...!!!'')</script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(" + Count + "'  Record Inserted Successfully...!!!')", true);
                    clear();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public void clear()
        {
            txtAcNo.Text = "";
            txtPartNo.Text = "";
            txtsearch.Text = "";
            lat.Text = "";
            longi.Text = "";

            foreach (GridViewRow Row in gvAsslatlog.Rows)
            {
                if (Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (Row.Cells[0].FindControl("chk") as CheckBox);
                    if (chkRow.Checked)
                    {
                        chkRow.Checked = false;
                    }
                }
            }
        }


    }
}