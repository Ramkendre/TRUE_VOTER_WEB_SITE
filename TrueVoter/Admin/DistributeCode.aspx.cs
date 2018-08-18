using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TrueVoter.Admin
{
    public partial class DistributeCode : System.Web.UI.Page
    {
        string sql = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        public void BindGvDistributeCode()
        {
            try
            {
                sql = "SELECT [SrNo],[referenceMobNo],[CodeForName] FROM [tblScratchcodeTV] where referenceMobNo='" + txtCandidateMobNo.Text.ToString() + "'";
                ds = cc.ExecuteDataset(sql);

                gvDistributeCode.DataSource = ds.Tables[0];
                gvDistributeCode.DataBind();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            //    {
            //        cmd.Connection = con;
            //        cmd.Parameters.AddWithValue("@FromSrNo", txtFromSrNo.Text.ToString());
            //        cmd.Parameters.AddWithValue("@ToSrNo", txtToSrNo.Text.ToString());
            //        cmd.CommandText = "spGetDistributeCode";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        da.SelectCommand = cmd;
            //        da.Fill(ds);

            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            sql = "Update [tblScratchcodeTV] set [CodeFor]='" + ddlCodeFor.SelectedValue.ToString() + "',[CodeForName]='" + ddlCodeFor.SelectedItem.Text.ToString() + "',[referenceMobNo]='" + txtCandidateMobNo.Text.ToString() + "',[RefAddedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' where SrNo='" + ds.Tables[0].Rows[i]["SrNo"].ToString() + "'";
            //            cc.ExecuteNonQuery(sql);
            //        }
            //    }
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Data Saved Sucessfully');", true);
            //    BindGvDistributeCode();
            //}
            //catch { }
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@FromSrNo", txtFromSrNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@ToSrNo", txtToSrNo.Text.ToString());
                    cmd.CommandText = "spGetDistributeCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    DateTime currentdate = System.DateTime.Now;
                    DateTime datetime = currentdate.AddDays(30);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        sql = "Update [tblScratchcodeTV] set [CodeFor]='" + ddlCodeFor.SelectedValue.ToString() + "',[CodeForName]='" + ddlCodeFor.SelectedItem.Text.ToString() + "',[referenceMobNo]='" + txtCandidateMobNo.Text.ToString() + "',[RefAddedDate]='" + currentdate.ToString() + "',[ExpireDate]='" + datetime.ToString("dd/MM/yyyy hh:mm:ss tt") + "' where SrNo='" + ds.Tables[0].Rows[i]["SrNo"].ToString() + "'";
                        cc.ExecuteNonQuery(sql);
                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Data Saved Sucessfully');", true);
                BindGvDistributeCode();
            }
            catch { }
        }

        protected void gvDistributeCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDistributeCode.PageIndex = e.NewPageIndex;
            BindGvDistributeCode();
        }
    }
}