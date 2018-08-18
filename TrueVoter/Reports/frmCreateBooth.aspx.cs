using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmCreateBooth : System.Web.UI.Page
    {
        CommonCode cc = new CommonCode();
        SqlCommand cmd = null;
        DataSet ds = new DataSet();
        string mob = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
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
                    mob = Session["MobileNo"].ToString();
                }
                else
                {
                    Response.Redirect("../Admin/Login.aspx");
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reports/frmHomeUser.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        public void BindGridView()
        {
            //string qry = "SELECT *  FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] WHERE [ACNO]='" + txtACNO.Text.Trim() + "' AND [PartNo]='" + txtPartNo.Text.Trim() + "' AND [WardNo]='" + txtWardNo.Text.Trim() + "' AND [IsActive]=1 ORDER By [BoothNo],[SrNoFrom]";
            //ds.Clear();
            //ds = cc.ExecuteDataset(qry);
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@acno",txtACNO.Text.ToString()),
                new SqlParameter("@partno", txtPartNo.Text.ToString()),
                new SqlParameter("@wardNo", txtWardNo.Text.ToString())
            };
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspGetCCDataForBooth", par);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvBoothAdd.DataSource = ds.Tables[0];
                gvBoothAdd.DataBind();
                pnlbooth.Visible = true;
            }
            else
            {
                gvBoothAdd.DataSource = ds.Tables[0];
                gvBoothAdd.DataBind();
            }

        }

        protected void SubmitRecord(object sender, EventArgs e)
        {
            if (txtBoothNo.Text == null || txtBoothNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Valid Booth No..!!!')", true);
            }
            else
            {
                string gvSrNo = string.Empty;
                cmd = new SqlCommand();
                LinkButton lnkbtnSubmit = (LinkButton)sender;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                int updatecount = 0;

                for (int i = 0; i < gvBoothAdd.Rows.Count; i++)
                {
                    CheckBox chkbox = ((CheckBox)gvBoothAdd.Rows[i].Cells[13].FindControl("CheckBox1"));
                    if (chkbox != null)
                    {
                        if (chkbox.Checked == true)
                        {
                            gvSrNo += Convert.ToString(gvBoothAdd.DataKeys[i].Value) + ",";
                            updatecount++;
                        }
                    }
                    chkbox.Checked = false;
                }

                if (gvSrNo != "")
                {
                    gvSrNo = gvSrNo.Substring(0, gvSrNo.Length - 1);
                }
                else
                {
                    gvSrNo = lnkbtnSubmit.CommandArgument;
                    updatecount = 1;
                }

                //string qry = "UPDATE [TrueVoterDB].[dbo].[tblOfficerAllotted_Info] SET [BoothNo]='" + txtBoothNo.Text.Trim() + "',[UpdatedBy]='" + mob + "'  WHERE [SrNo] IN (" + gvSrNo + ")";
                //cc.ExecuteNonQuery(qry);

                SqlParameter[] par = new SqlParameter[]
                    {
                        new SqlParameter("@boothno",txtBoothNo.Text.ToString()),
                        new SqlParameter("@mob", mob.ToString()),
                        new SqlParameter("@srno", gvSrNo.ToString())
                    };
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspUpdateBoothInCC", par);

                BindGridView();
            }
        }
    }
}