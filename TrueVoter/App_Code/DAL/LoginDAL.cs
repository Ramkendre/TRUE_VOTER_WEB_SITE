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
    public class LoginDAL
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet dataset = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        public DataSet GetLoginDetails(LoginBAL objloginBAL)
        {
            try
            {

                //cmd.CommandText = "[TrueVoterDB].[dbo].[uspLoginByWebSiteRoleWise]";
                //cmd.CommandText = "[TrueVoterDB].[dbo].[uspLoginByWebSiteRoleWiseNew]";

                cmd.CommandText = "[TrueVoterDB].[dbo].[uspLoginDetails]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.GetConnectionString(); //con;//
                //con.Open();
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 20).Value = objloginBAL.UserName;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 15).Value = objloginBAL.PassWord;
                cmd.Parameters.Add("@role", SqlDbType.NVarChar, 15).Value = objloginBAL.Role;
                da.SelectCommand = cmd;
                da.Fill(dataset);
                // con.Close();
                return dataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetLoginDetailsPwd(LoginBAL objloginBAL)
        {
            try
            {
                cmd.CommandText = "[TrueVoterDB].[dbo].[uspGetLoginDetails]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection.GetConnectionString(); //con;//
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar, 20).Value = objloginBAL.UserName;
                da.SelectCommand = cmd;
                da.Fill(dataset);
                return dataset;
            }
            catch
            {
                return dataset;
            }
        }
    }
}