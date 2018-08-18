using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.DAL
{
    public class ClassExecute
    {
        public DataSet ExecuteDataset(string Sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                try
                {
                    ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return ds;
        }

        public string ExecuteScalar(string Sql)
        {
            string Data = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {
                try
                {
                    Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return Data;
        }

        public int ExecuteNonQuery(string Sql)
        {
            int flag = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString))
            {

                try
                {
                    flag = SqlHelper.ExecuteNonQuery(con, CommandType.Text, Sql);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return flag;
        }
    }
}