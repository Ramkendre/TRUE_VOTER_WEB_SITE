using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueVoter.Admin
{
    public partial class Dynamic_code_generate : System.Web.UI.Page
    {
        Random rndom = new Random();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString();
                bindgrid();
            }
        }

        public void bindgrid()
        {
            //string str = "select SrNo, Scratchcode from tblScratchcode";              
            //cmd.CommandText = str;
            //cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("select SrNo, Scratchcode from tblScratchcodeTV order by SrNo DESC", con);
            // cmd.ExecuteNonQuery();
            // con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcodelist.DataSource = ds;
                gvcodelist.DataBind();
            }
        }

        private string getScrachCode(int digit)
        {
            string schrachCode = string.Empty;
            for (int i = 0; i < digit; i++)
            {
                int flag = rndom.Next();
                int reminder = 0;
                if (rdobtnYesNo.SelectedValue == "1")
                    reminder = (flag % 2);

                if (reminder == 0)
                {
                    flag = rndom.Next();
                    int rmd = flag % 9;
                    schrachCode += rmd;

                }
                if (reminder == 1)
                {
                    flag = rndom.Next(65, 90);
                    schrachCode += Convert.ToChar(flag);
                }
            }
            return schrachCode;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string rndstring = string.Empty;
            //char c;
            string schrachCode = string.Empty;
            uint series = Convert.ToUInt32(txttotacodes.Text);
            uint srNo = Convert.ToUInt32(txtseries.Text);
            series += srNo;

            for (; srNo <= series; srNo++)
            {
                //schrachCode = getScrachCode();
                string select = "";
                string sqlQuer = "";
                cmd.Connection = con;

                try
                {
                    for (; ; )
                    {
                        int isExeist;
                        schrachCode = getScrachCode(Convert.ToUInt16(txtscratchcode.Text));
                        select = "SELECT  [SrNo][Scratchcode] FROM [tblScratchcodeTV] where Scratchcode='" + schrachCode + "'";
                        cmd.CommandText = select;
                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        isExeist = cmd.ExecuteNonQuery();
                        if (isExeist < 0)
                            break;
                    }
                    //DateTime currentdate = DateTime.Now;
                    //DateTime expdate= currentdate.AddDays(360);
                    //sqlQuer = "insert into tblScratchcodeTV (SrNo,Scratchcode,CreateDate,isUsed,MktPerson,[ExpireDate])values(" + srNo + ",'" + schrachCode + "','" + txtDate.Text + "','0','" + txtAssigntoMktperson.Text + "','" + expdate.ToString("dd/MM/yyyy hh:mm:ss tt") + "')";       //'"+ txtAssigntoMktperson.Text +"')";
                    //cmd.CommandText = sqlQuer;
                    sqlQuer = "insert into tblScratchcodeTV (SrNo,Scratchcode,CreateDate,isUsed,MktPerson)values(" + srNo + ",'" + schrachCode + "','" + txtDate.Text + "','0','" + txtAssigntoMktperson.Text + "')";       //'"+ txtAssigntoMktperson.Text +"')";
                    cmd.CommandText = sqlQuer;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException sqlException)
                {
                    srNo--;
                }
                catch (Exception execption)
                {
                    srNo--;
                }

            }
            bindgrid();
            Clear();

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Data Saved Sucessfully');", true);
        }

        public void Clear()
        {
            txtseries.Text = "";
            txtscratchcode.Text = "";
            txttotacodes.Text = "";
        }

        protected void gvcodelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvcodelist.PageIndex = e.NewPageIndex;
            bindgrid();
        }
    }
}