using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using BLL;
//using BOL;

namespace TrueVoter.Reports
{
    public partial class TreeReport : System.Web.UI.Page
    {
        string mob = string.Empty;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["MobileNo"] != null)
                {
                    mob = Session["MobileNo"].ToString();
                    mob = "9821128083";// "9619460202";// objlogin.UserInformation.MobileNo;
                }
                PopulateRootLevel();
            }
        }

        private void PopulateRootLevel()
        {
            string sql = "select [UserName] AS m,(Name+' '+LName) AS firstName,RegId AS ID,(select count(*) FROM [TrueVoterDB].[dbo].[Logins] where [RefMobileNo]='" + mob + "')as childnodecount FROM [TrueVoterDB].[dbo].[Logins] WHERE [RefMobileNo]='" + mob + "' AND [UserType]=2 ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, TreeView1.Nodes);
        }

        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["firstName"].ToString() + "(" + (dr["m"].ToString()) + ")";
                tn.Value = dr["m"].ToString();
                string name = dr["firstName"].ToString();
                string nchild = dr["childnodecount"].ToString();

                nodes.Add(tn);
                tn.ToolTip = name;
                string id = Convert.ToString(tn.Value.ToString());

                tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
                int count = Convert.ToInt32(dr["childnodecount"].ToString());
            }
        }

        private void PopulateNodes1(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["m"].ToString() + "(" + (dr["firstName"].ToString()) + ")";
                tn.Value = dr["m"].ToString();
                string name = dr["firstName"].ToString();
                string nchild = dr["childnodecount"].ToString();

                nodes.Add(tn);
                tn.ToolTip = name;
                string id = Convert.ToString(tn.Value.ToString());

                tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
                int count = Convert.ToInt32(dr["childnodecount"].ToString());
            }
        }

        private void PopulateSubLevel(string senior_ID, TreeNode parentNode)
        {
            string str = "select DISTINCT table3.[UserName] as m,(table3.Name+' '+table3.LName) as firstName,table3.[UserName],table3.RefMobileNo,(select count(*) FROM [TrueVoterDB].[dbo].[Logins] AS table2 where RefMobileNo=table1.[UserName]) childnodecount FROM [TrueVoterDB].[dbo].[Logins] table1 inner join [TrueVoterDB].[dbo].[Logins] AS table3 on table3.[UserName]=table1.[UserName] where  table3.RefMobileNo='" + senior_ID + "' AND table1.[UserType]=2";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes1(dt, parentNode.ChildNodes);
        }

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateSubLevel(Convert.ToString(e.Node.Value), e.Node);
        }
    }
}