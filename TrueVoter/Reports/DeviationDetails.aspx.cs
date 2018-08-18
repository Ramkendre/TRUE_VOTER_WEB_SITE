using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class DeviationDetails : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string str = string.Empty;
        string[] Arrstr;
        string dataNew = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            str = Request.QueryString["var"];
            Arrstr = str.Split('$');
            dataNew = Convert.ToString(Arrstr[0]);
            GvBind(dataNew);
            if (!IsPostBack)
            {
                dt = (DataTable)Application["dt11"];
                FvDeviationDetails.DataSource = dt;
                FvDeviationDetails.DataBind();
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/Reports/Deviation.aspx");

            var vr = Convert.ToString(Request.QueryString["var"]);
            Response.Redirect("~/Reports/Deviation.aspx?val=" + vr + "");
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
    }
}