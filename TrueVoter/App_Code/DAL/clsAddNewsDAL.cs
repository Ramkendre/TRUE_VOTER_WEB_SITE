using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.App_Code.DAL
{
    public class clsAddNewsDAL
    {
        string result = "";
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        public string Insert(clsAddNews objBAL)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspInsertNewsNotificationData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@NewsScope", SqlDbType.NVarChar, 10).Value = objBAL.NewsScope;
                cmd.Parameters.Add("@NewsScopeName", SqlDbType.NVarChar, 100).Value = objBAL.NewsScopeName;
                cmd.Parameters.Add("@DistrictId", SqlDbType.NVarChar, 10).Value = objBAL.DistrictId;
                cmd.Parameters.Add("@localBodyId", SqlDbType.NVarChar, 10).Value = objBAL.localBodyId;
                cmd.Parameters.Add("@Header", SqlDbType.NVarChar, 500).Value = objBAL.Header;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = objBAL.Description;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                cmd.Parameters.Add("@CreatedDate", SqlDbType.NVarChar, 10).Value = objBAL.CreatedDate;
                con.Open();
                result = Convert.ToString(cmd.ExecuteNonQuery());
                con.Close();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public DataSet BindGridBAL(clsAddNews objBAL) 
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "uspDownloadNewsNotificationData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 10).Value = objBAL.CreatedBy;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return ds;
            }
        }
    }
}