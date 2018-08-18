using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
namespace TrueVoter.Reports
{
    public partial class DeviationDetailsNew : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string data = string.Empty; string str = string.Empty; string[] Arrstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["var"] != null)
            {
                str = Request.QueryString["var"];
                Arrstr = str.Split('$');
                data = Convert.ToString(Arrstr[0]);
                //data = Convert.ToString(Request.QueryString["var"]);
                 GvBind(data);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('First Send the ID !!!!')", true);
            }
        }

        public void GvBind(string ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
                {
                    SqlParameter[] par = new SqlParameter[11];
                    par[0] = new SqlParameter("@type", 1);
                    par[1] = new SqlParameter("@ID", ID);                   
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UspDownloadObjectionDetails", par);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvData.DataSource = ds.Tables[0];
                        gvData.DataBind();
                        ViewState["dirState"] = dt;
                        ViewState["sortdr"] = "Asc";
                    }
                    else
                    {
                        gvData.EmptyDataText = "No Data Found !!!";
                        gvData.DataBind();
                    }
                }
            }
            catch
            {
                gvData.EmptyDataText = "No Data Found !!!";
                gvData.DataBind();
            }
        }

        protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                gvData.DataSource = dtrslt;
                gvData.DataBind();
            } 
        }
    }
}