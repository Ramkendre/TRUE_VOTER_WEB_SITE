using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;
using TrueVoter;


public class SendRegDataToTrueVoter
{
    public SendRegDataToTrueVoter()
    {

    }

    private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
    private SqlCommand sqlCommand = null;
    //private SqlDataAdapter sqlDataAdapter = null;
    private DataSet data = null;
    private int Error = CommonCode.OK;
    public int isError { get { return this.Error; } }
    public DataSet userData { get { return this.data; } }
    CommonCode cc = new CommonCode();
    string returnString = string.Empty;
    private string registerNewUserQuery = "[TrueVoterDB].[dbo].[uspRegisterUser]";

    #region Region For SMS CHANGES 27-10-2016

    public string newRegistration(string name, string mobileNo, string userName, string password, String otp, string MName, string LName, string latitute, string langitute, string email, string userType, string imeiNumber, string refMobileNo, string simSerialNo, string address, string state, string district, string taluka)
    {
        try
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = registerNewUserQuery;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = name;
            sqlCommand.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = mobileNo;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = userName;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
            sqlCommand.Parameters.Add("@mName", SqlDbType.NVarChar, 20).Value = MName;
            sqlCommand.Parameters.Add("@lName", SqlDbType.NVarChar, 20).Value = LName;
            sqlCommand.Parameters.Add("@otp", SqlDbType.NVarChar, 8).Value = otp;
            sqlCommand.Parameters.Add("@lat", SqlDbType.NVarChar, 8).Value = latitute;
            sqlCommand.Parameters.Add("@lag", SqlDbType.NVarChar, 8).Value = langitute;

            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
            sqlCommand.Parameters.Add("@usrType", SqlDbType.NVarChar, 50).Value = userType; //UserType means Role to TrueVoter as 1-Voter, 3-Candidate or 2-Officer
            sqlCommand.Parameters.Add("@imei", SqlDbType.NVarChar, 50).Value = imeiNumber;
            sqlCommand.Parameters.Add("@refMobileNo", SqlDbType.NVarChar, 50).Value = refMobileNo;

            sqlCommand.Parameters.Add("@simSerialNo", SqlDbType.NVarChar, 50).Value = simSerialNo;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar, 250).Value = address;
            sqlCommand.Parameters.Add("@state", SqlDbType.NVarChar, 50).Value = state;
            sqlCommand.Parameters.Add("@district", SqlDbType.NVarChar, 50).Value = district;
            sqlCommand.Parameters.Add("@taluka", SqlDbType.NVarChar, 50).Value = taluka;

            sqlCommand.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

            SqlParameter returnValue = sqlCommand.CreateParameter();
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnValue);

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

            if (Convert.ToString(returnValue.Value) == "1")
            {
                if (userType == "1") //VOTER
                {
                    //Do here work to sms for truevoter application
                    returnString = "PASS";
                }
                else if (userType == "2") //OFFICER
                {
                    string sqlAdd = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances] WHERE [UserMobile] = '" + mobileNo + "' AND [RefMobile] = '" + refMobileNo + "' AND [keyword] = 'JUNIOR' AND [isActive] = 'Active'";
                    DataSet dsAdd = cc.ExecuteDataset(sqlAdd);

                    if (dsAdd.Tables[0].Rows.Count > 0)
                    {
                        string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + mobileNo + "'";
                        cc.ExecuteNonQuery(sqlIsppUpdate);
                        returnString = "PASS";
                    }
                    else
                    {
                        string officerRole = string.Empty;

                        officerRole = "Officer";

                        string msg = "I " + name + " " + LName + " " + mobileNo + " installed TRUE VOTER for election purpose as " + officerRole + " role" +
                                     " Add me under you as Junior to give proper reporting thru TRUE VOTER";
                        cc.SMS(refMobileNo, msg);
                        returnString = "PASS";
                    }
                }
                else
                {
                    // This Work is For Candidate add representative
                    string sqlAdd = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances] WHERE [UserMobile] = '" + mobileNo + "' AND [RefMobile] = '" + refMobileNo + "' AND [keyword] = 'REPRESENTATIVE' AND [isActive] = 'Active'";
                    DataSet dsAdd = cc.ExecuteDataset(sqlAdd);

                    if (dsAdd.Tables[0].Rows.Count > 0)
                    {
                        string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + mobileNo + "'";
                        cc.ExecuteNonQuery(sqlIsppUpdate);
                        returnString = "PASS";
                    }
                    else
                    {
                        string candidateRole = string.Empty;
                        candidateRole = "Candidate";//"Representative";

                        string msg = "I " + name + " " + LName + " " + mobileNo + " installed TRUE VOTER for election purpose as " + candidateRole + "" +
                                     " Add me under you as Representative to give proper reporting thru TRUE VOTER";
                        cc.SMS(refMobileNo, msg);
                        returnString = "PASS";
                    }
                }
                return returnString;
            }
            else if (Convert.ToString(returnValue.Value) == "2")
                return CommonCode.USER_NAME_ALREADY_USED.ToString();
            else
                return returnValue.Value.ToString();
        }
        catch (SqlException)
        {
            return CommonCode.SQL_ERROR.ToString();
        }
        catch (Exception)
        {
            return CommonCode.ERROR.ToString();
        }
        finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
    }

    #endregion
}