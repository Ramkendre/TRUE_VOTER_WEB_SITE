using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace TrueVoter.Reports
{
    public partial class Transactions : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            cmd.CommandText = "Select * from [TrueVoterDB].[dbo].[tblSMSInfo] ";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSmsRecharge.DataSource = ds.Tables[0];
                gvSmsRecharge.DataBind();
            }
            else
            {
                gvSmsRecharge.EmptyDataText = "Record Not Found !!!";
                gvSmsRecharge.DataBind();
            }
        }

        protected void lnkStatus_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);

            //Response.Redirect("BalanceSheet.aspx?UserID=" + gvSmsRecharge.Rows[i].Cells[0].Text + "&OrderID=" + gvSmsRecharge.Rows[i].Cells[5].Text );//+ "&MobileNo=" + gvSmsRecharge.Rows[i].Cells[4].Text); "&TransectionID=" + gvSmsRecharge.Rows[i].Cells[1].Text +

            //GridViewRow objGridViewRow = gvSmsRecharge.Rows[0];
            //Response.Redirect("BalanceSheet.aspx?UserID=" + objGridViewRow.Cells[0].Text + "&TransectionID=" + objGridViewRow.Cells[1].Text + "&OrderID=" + objGridViewRow.Cells[5].Text + "&MobileNo="+objGridViewRow.Cells[4].Text);   //UserID=" + objGridViewRow.Cells[0].Text + "&

            //if (ViewState["UserId"] != null)
            //{
                //gvSmsRecharge.Rows[i].Cells[0].Text = ViewState["UserID"].ToString();
                //Response.Redirect("BalanceSheet.aspx");
            //}

            //ViewState["UserID"] = gvSmsRecharge.Rows[i].Cells[0].Text;
            //Server.Transfer("BalanceSheet.aspx");

            Application["UserID"] = gvSmsRecharge.Rows[i].Cells[0].Text;
            Application["OrderID"] = gvSmsRecharge.Rows[i].Cells[5].Text;
            Server.Transfer("BalanceSheet.aspx");
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cmd.CommandText = "Select * from [TrueVoterDB].[dbo].[tblSMSInfo] where MobileNo ='" + txtSearch.Text + "'  OR TransectionID ='" + txtSearch.Text + "' OR CreatedDate ='" + txtSearch.Text + "'";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSmsRecharge.DataSource = ds.Tables[0];
                gvSmsRecharge.DataBind();
            }
            else
            {
                ds.Clear();
                gvSmsRecharge.EmptyDataText = "Record Not Found !!!";
                gvSmsRecharge.DataBind();
            }
            if (txtSearch.Text.Equals(""))
            {
                BindData();            
            }
        }
    }
}