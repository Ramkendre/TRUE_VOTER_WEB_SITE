using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Caching;

namespace TrueVoter.App_Code.DAL
{
	public class SearchDAL
	{
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private string searchUserByMobileQuery = "[TrueVoterDB].[dbo].[uspGetUserDataFromMobile]";
       // private string searchUserEmergencyContactsQuery = "[TrueVoterDB].[dbo].[uspGetEmergencyContacts]";

        private int Error = CommonCode.OK;
        public int isError { get { return this.Error; } }
        public DataSet userData { get { return this.data; } }
        public void SearchUserByMobile(string mobileNo)
        {
            try
            {
                data = new DataSet();
                SqlParameter mobileParameter = new SqlParameter("@userMobileNo", mobileNo);
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = searchUserByMobileQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(mobileParameter);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(data);
            }
            catch (SqlException)
            {
                Error = CommonCode.SQL_ERROR;
            }
            catch (Exception)
            {
                Error = CommonCode.ERROR;
            }
            finally { sqlCommand.Dispose(); }
        }
        public void SearchUserEmergencyContacts(string registrationId)
        {
            try
            {
                data = new DataSet();
                SqlParameter mobileParameter = new SqlParameter("@regId", registrationId);
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = searchUserByMobileQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(mobileParameter);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(data);
            }
            catch (SqlException)
            {
                Error = CommonCode.SQL_ERROR;
            }
            catch (Exception)
            {
                Error = CommonCode.ERROR;
            }
            finally { sqlCommand.Dispose(); }
        }

	}
}