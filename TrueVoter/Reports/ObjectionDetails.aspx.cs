using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace TrueVoter.Reports
{
    public partial class ObjectionDetails : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string serviceURL = string.Empty;
        string dataString = string.Empty;
        WebClient proxy = new WebClient();
        DataSet ds = new DataSet();
        string dataNew = string.Empty;
        string str = string.Empty;
        string[] Arrstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dt = (DataTable)Application["dt12"];
                str = Request.QueryString["var"];
                Arrstr = str.Split('$');
                dataNew= Convert.ToString(Arrstr[0]);
                serviceURL = string.Format("http://truevoters.in:8100/ExpenseManagement.svc/DownloadGenObjExpenIdWise?ExpenseId=" + dataNew+"&maxId=0");//Request.QueryString["var"]
                byte[] data = proxy.DownloadData(serviceURL);
                Stream stream = new MemoryStream(data);

                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
                dataString = dataString.Replace("\"", "'");

                // Parse JSON into dynamic object, convenient!
                JObject results = JObject.Parse(dataString);
                dt.Columns.Add("userName");
                dt.Columns.Add("objID");
                dt.Columns.Add("wardNo");
                dt.Columns.Add("objectionDetails");
                dt.Columns.Add("userMobileNo");

                foreach (var result in results["DownloadGenObjExpenIdWiseResult"])
                {
                    dt.Rows.Add(result["userName"], result["objID"], result["wardNo"], result["objectionDetails"], result["userMobileNo"]);
                }

                FvObjectionDetails.DataSource = dt;
                FvObjectionDetails.DataBind();
                ViewState["dt"] = dt;

             //   ViewState["PreviousPage"] = Request.UrlReferrer;                
            }
        }
        

        

        protected void btnback_Click(object sender, EventArgs e)
        {
            var vr = Convert.ToString(Request.QueryString["var"]);
            Response.Redirect("~/Reports/Deviation.aspx?val=" + vr +"");

            //if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
            ////contains Previous page URL
            //{
            //    Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
            //    //Previous page by retrieving the PreviousPage Url from ViewState.
            //}
        }

        protected void FvDeviationDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            try
            {
                FvObjectionDetails.PageIndex = e.NewPageIndex;
                DataTable DT = new DataTable();
                DT = (DataTable)ViewState["dt"];
                FvObjectionDetails.DataSource = DT;
                FvObjectionDetails.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}