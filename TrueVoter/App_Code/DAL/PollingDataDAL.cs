using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.App_Code.DAL
{
    public class PollingDataDAL
    {
        private SqlCommand sqlCommand = null;
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);

        public int insert(PollingData pollingData)
        {
            try
            {
                EncDecArrayClass objenc = new EncDecArrayClass();
                string[] uregid = pollingData.userName.Split('$');
                pollingData.userName = objenc.DecryptInteger(uregid[0], uregid[1]);

                string[] uregid1 = pollingData.refMobileNo.Split('$');
                pollingData.refMobileNo = objenc.DecryptInteger(uregid1[0], uregid1[1]);



                sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add(new SqlParameter("@userName", pollingData.userName));
                sqlCommand.Parameters.Add(new SqlParameter("@wardNo", pollingData.wardNo));
                sqlCommand.Parameters.Add(new SqlParameter("@boothNo", pollingData.boothNo));
                sqlCommand.Parameters.Add(new SqlParameter("@noOfVotings", pollingData.noOfVoting));
                sqlCommand.Parameters.Add(new SqlParameter("@voters", pollingData.voters));
                sqlCommand.Parameters.Add(new SqlParameter("@localBody", pollingData.localBody));
                sqlCommand.Parameters.Add(new SqlParameter("@imeino", pollingData.imeino));
                sqlCommand.Parameters.Add(new SqlParameter("@userType", pollingData.userType));
                sqlCommand.Parameters.Add(new SqlParameter("@currentDate", pollingData.date));
                sqlCommand.Parameters.Add(new SqlParameter("@refMoNo", pollingData.refMobileNo));

                SqlParameter retrunParameter = sqlCommand.CreateParameter();
                retrunParameter.Direction = ParameterDirection.ReturnValue;
                retrunParameter.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(retrunParameter);

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspInsertPollingData]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                int result = sqlCommand.ExecuteNonQuery();
                if (Convert.ToString(retrunParameter.Value) == "1")
                {
                    return CommonCode.OK;
                }
                else
                    return CommonCode.FAIL;
            }
            catch (SqlException)
            {
                return CommonCode.ERROR;
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        }

        public int Responsibility(string UserNo, string ward, string booth, string sno, string localbody)
        {
            try
            {
                EncDecArrayClass objenc = new EncDecArrayClass();
                string[] uregid = UserNo.Split('$');
                UserNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "insert into [TrueVoterDB].[dbo].[Responsibility]([User],[WardNo],[BoothNo],[SNO],[Voted],[LocalBody])values('" + UserNo + "','" + ward + "','" + booth + "','" + sno + "',0," + localbody + ")";
                sqlCommand.Connection = sqlConnection;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                int result = sqlCommand.ExecuteNonQuery();
                return CommonCode.OK;
            }
            catch (SqlException)
            {
                return CommonCode.ERROR;
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        }

        public int UserStatus(string UserNo, string ward, string booth, string sno, string localbody, string color)
        {
            try
            {
                EncDecArrayClass objenc = new EncDecArrayClass();
                string[] uregid = UserNo.Split('$');
                UserNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspInsertUserStatus]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@user", UserNo));
                sqlCommand.Parameters.Add(new SqlParameter("@ward", ward));
                sqlCommand.Parameters.Add(new SqlParameter("@booth", booth));
                sqlCommand.Parameters.Add(new SqlParameter("@sno", sno));
                sqlCommand.Parameters.Add(new SqlParameter("@localbody", localbody));
                sqlCommand.Parameters.Add(new SqlParameter("@color", color));

                sqlCommand.Connection = sqlConnection;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                int result = sqlCommand.ExecuteNonQuery();
                return CommonCode.OK;
            }
            catch (SqlException)
            {
                return CommonCode.ERROR;
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        }

        public DataSet GetUserStatus(string UserNo, string ward, string booth, string loaclbody)
        {
            sqlCommand = new SqlCommand();
            if (booth == "0")
            {
                sqlCommand.CommandText = "SELECT [User],[Ward],[Booth],[Sno],[color] FROM [TrueVoterDB].[dbo].[UserStatus] where [Ward]=" + ward + " and [Localbody]=" + loaclbody + " and [User] in (" + UserNo + ")";
            }
            else
            {
                sqlCommand.CommandText = "SELECT [User],[Ward],[Booth],[Sno],[color] FROM [TrueVoterDB].[dbo].[UserStatus] where [Ward]=" + ward + " and [Booth]=" + booth + " and  [Localbody]=" + loaclbody + " and [User] in (" + UserNo + ")"; ;
            }

            sqlCommand.Connection = sqlConnection;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;

            adapter.Fill(ds);
            return ds;
        }
    }
}