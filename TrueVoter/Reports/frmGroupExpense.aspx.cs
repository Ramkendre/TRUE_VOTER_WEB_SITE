using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Reports
{
    public partial class frmGroupExpense : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        string mob = string.Empty;
        string roleID = string.Empty;
        CommonCode cc = new CommonCode();
        string serviceURL = string.Empty;
        string dataString = string.Empty;
        WebClient proxy = new WebClient();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            mob = Convert.ToString(Session["MobileNO"]);
            roleID = Convert.ToString(Session["UserType"]);
            
            if (roleID != null)
            {
                if (IsPostBack == false)
                {
                    BindGroups();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Session is Expired..')", true);
                Response.Redirect("../Admin/Login.aspx");
            }
        }
        public void BindGroups()
        {
            serviceURL = string.Format("http://www.truevoters.in:8100/ExpenseManagement.svc/DownloadGroupExpenses?MobileNo=" + mob + "");
            GetDeviation();
        }

        public void GetDeviation()
        {
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);
            string partname = string.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            dataString = dataString.Replace("\"", "'");

            // Parse JSON into dynamic object, convenient!
            JObject results = JObject.Parse(dataString);
            dt.Columns.Add("Id", (typeof(string)));
            dt.Columns.Add("ProgramName", (typeof(string)));
            dt.Columns.Add("ProgramDate", (typeof(string)));
            //dt.Columns.Add("Member1", (typeof(string)));
            //dt.Columns.Add("Share1", (typeof(string)));
            //dt.Columns.Add("Status1", (typeof(string)));
            // dt.Columns.Add("Member2", (typeof(string)));
            //dt.Columns.Add("Share2", (typeof(string)));
            //dt.Columns.Add("Status2", (typeof(string)));
            // dt.Columns.Add("Member3", (typeof(string)));
            //dt.Columns.Add("Share3", (typeof(string)));
            //dt.Columns.Add("Status3", (typeof(string)));
            // dt.Columns.Add("Member4", (typeof(string)));
            //dt.Columns.Add("Share4", (typeof(string)));
            //dt.Columns.Add("Status4", (typeof(string)));
            //dt.Columns.Add("EntryCount", (typeof(string)));
            //dt.Columns.Add("Total", (typeof(string)));
            //dt.Columns.Add("CreatedBy", (typeof(string)));
            //dt.Columns.Add("CreatedDate", (typeof(string)));
            //dt.Columns.Add("IsActive", (typeof(string)));

            foreach (var result in results["DownloadGroupExpensesResult"])
            {
                dt.Rows.Add(Convert.ToString(result["ServerId"]), Convert.ToString(result["ProgramName"]), Convert.ToString(result["ProgramDate"]));
                    //Convert.ToString(result["Member1"]), Convert.ToString(result["Share1"]), Convert.ToString(result["Status1"]),
                    //Convert.ToString(result["Member2"]), Convert.ToString(result["Share2"]), Convert.ToString(result["Status2"]),
                    //Convert.ToString(result["Member3"]), Convert.ToString(result["Share3"]), Convert.ToString(result["Status3"]),
                    //Convert.ToString(result["Member4"]), Convert.ToString(result["Share4"]), Convert.ToString(result["Status4"]),
                    //Convert.ToString(result["EntryCount"]), Convert.ToString(result["Total"]), Convert.ToString(result["CreatedBy"]),
                    //Convert.ToString(result["CreatedDate"]), Convert.ToString(result["IsActive"]));
            }
            if (dt.Rows.Count > 0)
            {
                ddlGroups.DataSource = dt;
                ddlGroups.DataTextField = "ProgramName";
                ddlGroups.DataValueField = "Id";
                ddlGroups.DataBind();
                ddlGroups.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlGroups.SelectedIndex = 0;
            }
            else
            { 
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlGroups.SelectedValue != "0")
            {
                string groupId = ddlGroups.SelectedValue;
                string qs = mob + "$" + groupId;
                qs = cc.DESEncrypt(qs);
                Response.Redirect("rptGroupExpense.aspx?data=" + qs + "");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Group')", true);
            }
        }
    }
}