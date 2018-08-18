using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TrueVoter.App_Code.BAL;
using App_Code.BAL;
using TrueVoter;
namespace TrueVoter.App_Code.DAL
{
    public class RegistrationDAL
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet data = null;
        private int Error = TrueVoter.CommonCode.OK;
        CommonCode cc = new CommonCode();
        EncDecArrayClass objenc = new EncDecArrayClass();
        public int isError { get { return this.Error; } }
        public DataSet userData { get { return this.data; } }
        private string registerNewUserQuery = "[TrueVoterDB].[dbo].[uspRegisterUser1]";
        
        public string newRegistration(string name, string mobileNo, string userName, string password, String otp, string MName, string LName, string latitute, string langitute)
        { //Want to change in this service as enc and dec algo
            try
            {
                //userName = EncryptDecrypt.DecodeAndDecrypt(userName);
                //password = EncryptDecrypt.DecodeAndDecrypt(password);


                //string pw = password.Substring(0, password.Length - 12);
                //password = cc.DESEncrypt(pw);

                //string dt1 = userName.Substring(userName.Length - 12);
                //userName = userName.Substring(0, userName.Length - 12);

                //string retVal = objenc.DateTimeDec(dt1);

                //if (retVal == "0")
                //{
                //    return CommonCode.SQL_ERROR.ToString();
                //}

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
                sqlCommand.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                SqlParameter returnValue = sqlCommand.CreateParameter();
                returnValue.SqlDbType = SqlDbType.Int;
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.Parameters.Add(returnValue);

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                if (Convert.ToString(returnValue.Value) == "1")
                { return CommonCode.OK.ToString() + "*" + sqlCommand.Parameters["@rid"].Value.ToString(); }
                else if (Convert.ToString(returnValue.Value) == "2")
                    return CommonCode.USER_NAME_ALREADY_USED.ToString();
                else
                    return CommonCode.USER_NAME_ALREADY_USED.ToString();//returnValue.Value.ToString();

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

        public int GCMRegistration(string mobileNo, string regid, int userType) //Want to change in this service as enc and dec algo
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "[dbo].[uspInsertGCMRegid]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 15).Value = mobileNo;
                sqlCommand.Parameters.Add("@RegId", SqlDbType.NVarChar, 750).Value = regid;
                sqlCommand.Parameters.Add("@userType", SqlDbType.Int).Value = userType;

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();
                return CommonCode.OK;
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR;
            }
            catch (Exception)
            {
                return CommonCode.ERROR;
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
        }

        public string checkOtp(string mobileNo, string otp)  //Want to change in this service as enc and dec algo
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspCheckOTP]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter registrationSqlParameter = new SqlParameter("@regid", "");
                registrationSqlParameter.Direction = ParameterDirection.Output;
                registrationSqlParameter.SqlDbType = SqlDbType.NVarChar;
                registrationSqlParameter.Size = 20;

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@mobileNo", mobileNo), new SqlParameter("@otp", otp), registrationSqlParameter };
                sqlCommand.Parameters.AddRange(sqlParameter);
                SqlParameter returnValue = sqlCommand.CreateParameter();
                returnValue.SqlDbType = SqlDbType.Int;
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.Parameters.Add(returnValue);

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                if (Convert.ToString(returnValue.Value) == "1")
                    return CommonCode.OK.ToString() + "*" + sqlCommand.Parameters["@regid"].Value.ToString();
                else if (Convert.ToString(returnValue.Value) == "4")
                    return CommonCode.FAIL.ToString();
                else if (Convert.ToString(returnValue.Value) == "2")
                    return CommonCode.WRONG_INPUT.ToString();
                else
                    return Convert.ToString(returnValue.Value);

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

        public string resendOTP(string mobileNo)
        {
            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetOTP]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter registrationSqlParameter = new SqlParameter("@otp", "");
                registrationSqlParameter.Direction = ParameterDirection.Output;
                registrationSqlParameter.SqlDbType = SqlDbType.NVarChar;
                registrationSqlParameter.Size = 20;

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@mobileNo", mobileNo), registrationSqlParameter };
                sqlCommand.Parameters.AddRange(sqlParameter);

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();
                string otp = sqlCommand.Parameters["@otp"].Value.ToString();
                if (otp != null)
                {
                    return otp;
                }
                else
                    return CommonCode.WRONG_INPUT.ToString();
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

        public int addProfile(Profile userProfile)
        {
            try
            {

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                #region Comment
                //sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspInsertUserProfile]";
                //sqlCommand.CommandType = CommandType.StoredProcedure;

                //sqlCommand.Parameters.Add("@regid", SqlDbType.NVarChar, 20).Value = userProfile.RegId;
                //sqlCommand.Parameters.Add("@uid", SqlDbType.NVarChar, 20).Value = userProfile.uid;
                //sqlCommand.Parameters.Add("@gender", SqlDbType.Int).Value = userProfile.gender;
                //sqlCommand.Parameters.Add("@dob", SqlDbType.NVarChar, 12).Value = userProfile.dob;
                //sqlCommand.Parameters.Add("@houseNo", SqlDbType.NVarChar, 10).Value = userProfile.houseNo;
                //sqlCommand.Parameters.Add("@societyName", SqlDbType.NVarChar, 50).Value =userProfile.SocietyName;
                //sqlCommand.Parameters.Add("@streetName", SqlDbType.NVarChar, 50).Value =userProfile.streetName;
                //sqlCommand.Parameters.Add("@landMark", SqlDbType.NVarChar, 50).Value =userProfile.landMark;
                //sqlCommand.Parameters.Add("@pincode", SqlDbType.Int).Value =userProfile.pincode;
                //sqlCommand.Parameters.Add("@moibleNo", SqlDbType.NVarChar, 12).Value =userProfile.mobileNo;
                //sqlCommand.Parameters.Add("@mobleNo2", SqlDbType.NVarChar, 12).Value =userProfile.mobileNo2;
                //sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 20).Value =userProfile.email;
                //sqlCommand.Parameters.Add("@userType", SqlDbType.Int).Value =userProfile.userType;
                //sqlCommand.Parameters.Add("@imeiNo", SqlDbType.NVarChar, 20).Value =userProfile.imeiNo;
                //sqlCommand.Parameters.Add("@currentDate", SqlDbType.NVarChar, 20).Value = userProfile.registrationDate;
                //sqlCommand.Parameters.Add("@status", SqlDbType.Int).Value =userProfile.status;
                //sqlCommand.Parameters.Add("@localBody", SqlDbType.Int).Value =userProfile.localBody;
                //sqlCommand.Parameters.Add("@taluka", SqlDbType.Int).Value =userProfile.taluka;
                //sqlCommand.Parameters.Add("@district", SqlDbType.Int).Value =userProfile.district;
                //sqlCommand.Parameters.Add("@voterNo", SqlDbType.NVarChar, 50).Value =userProfile.epicNo;
                //sqlCommand.Parameters.Add("@village", SqlDbType.NVarChar, 20).Value =userProfile.Village;
                //sqlCommand.Parameters.AddWithValue("photo",userProfile.photo);


                //SqlParameter returnValue = sqlCommand.CreateParameter();
                //returnValue.SqlDbType = SqlDbType.Int;
                //returnValue.Direction = ParameterDirection.ReturnValue;
                //sqlCommand.Parameters.Add(returnValue);
                #endregion

                sqlDataAdapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlCommand.CommandText = "SELECT *FROM [TrueVoterDB].[dbo].[Registrations] WHERE [RegId]='" + userProfile.RegId.Trim() + "'";
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    //Update
                    sqlCommand.CommandText = "update [TrueVoterDB].[dbo].[Registrations] "
                                             + "set [DOB]='" + userProfile.dob + "',[Email]='" + userProfile.email + "',[Photo]='" + userProfile.photo + "',[UserType]='" + userProfile.userType + "',[IMEINo]='" + userProfile.imeiNo + "',[RegistrationDate]='" + userProfile.registrationDate + "',[UpdateDate]='" + userProfile.updationDate + "',[AC_NO]='" + userProfile.acno + "',[PART_NO] ='" + userProfile.partNo + "',[SLNOINPART]='" + userProfile.slnoinpart +
                                            "',[HOUSE_NO]='" + userProfile.houseNo + "',[SECTION_NO]='" + userProfile.sectionno + "' ,[fm_name_v1]=N'" + userProfile.fm_name_v1 + "',[Lastname_v1]=N'" + userProfile.Lastname_v1 + "',[RLN_TYPE]=N'" + userProfile.RLN_TYPE + "',[RLN_FM_NM_v1]=N'" + userProfile.RLN_FM_NM_v1 + "',[RLN_L_NM_v1]=N'" + userProfile.RLN_L_NM_v1 + "',[IDCARD_NO]='" + userProfile.IDCARD_NO + "',[STATUSTYPE]='" + userProfile.STATUSTYPE + "' "
                                            + ",[SEX]='" + userProfile.SEX + "',[AGE]='" + userProfile.AGE + "',[FM_NAMEEN]=N'" + userProfile.FM_NAMEEN + "',[LASTNAMEEN]=N'" + userProfile.LASTNAMEEN + "',[RLN_FM_NMEN]=N'" + userProfile.RLN_FM_NMEN + "',[RLN_L_NMEN]=N'" + userProfile.RLN_L_NMEN + "',[FULL_NAMEEN]=N'" + userProfile.FULL_NAMEEN + "',[EB_No]='" + userProfile.EB_No + "',[Allocated_Ward]='" + userProfile.Allocated_Ward + "',[SerialNo_InWard]='" + userProfile.SerialNo_InWard + " '"
                                            + ",[BoothNo]='" + userProfile.BoothNo + "',[SerialNo_ForFinalList]='" + userProfile.SerialNo_ForFinalList + "',[old_serialIn_ward]='" + userProfile.old_serialIn_ward + "',[loclBody]='" + userProfile.localBody + "',[uid]='" + userProfile.uid + "',[Dist_ID]='" + userProfile.distritId + "',[LocalBodyType]='" + userProfile.assemblyId + "',[VoterWardNo]='" + userProfile.voterWardNo + "' WHERE [RegId]='" + userProfile.RegId.Trim() + "'";//Added18-1-17
                    if (sqlCommand.Connection.State == ConnectionState.Closed)
                        sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = "update  [TrueVoterDB].[dbo].[Logins] set [LATITUTE]='" + userProfile.latitude + "' , [LAGITUTE]='" + userProfile.langitute + "'  where [RegId]='" + userProfile.RegId.Trim() + "'";
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    //Insert

                    sqlCommand.CommandText = " SELECT [ID] FROM [TrueVoterDB].[dbo].[Logins] WHERE [RegId]='" + userProfile.RegId.Trim() + "'";
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    DataSet ds1 = new DataSet();
                    sqlDataAdapter.Fill(ds1);
                    userProfile.loginId = ds1.Tables[0].Rows[0][0].ToString();
                    sqlCommand.CommandText = "insert into [TrueVoterDB].[dbo].[Registrations]([RegId],[DOB],[Email],[Photo],[UserType],[IMEINo],[RegistrationDate],[UpdateDate],[Status],[LoginId],[AC_NO],[PART_NO] ,[SLNOINPART]" +
                    " ,[HOUSE_NO],[SECTION_NO] ,[fm_name_v1],[Lastname_v1],[RLN_TYPE],[RLN_FM_NM_v1],[RLN_L_NM_v1],[IDCARD_NO],[STATUSTYPE]" +
                    " ,[SEX],[AGE],[FM_NAMEEN],[LASTNAMEEN],[RLN_FM_NMEN],[RLN_L_NMEN],[FULL_NAMEEN],[EB_No],[Allocated_Ward],[SerialNo_InWard]" +
                    " ,[BoothNo],[SerialNo_ForFinalList],[old_serialIn_ward],[loclBody],[uid],[Dist_ID],[LocalBodyType],[VoterWardNo]) values('" + userProfile.RegId + "','" + userProfile.dob + "',N'" + userProfile.email + "',N'" + userProfile.photo + "','" + userProfile.userType + "','" + userProfile.imeiNo + "','" + userProfile.registrationDate + "','" + userProfile.updationDate + "','" + userProfile.status + "','" + userProfile.loginId + "','" + userProfile.acno + "','" + userProfile.partNo
                    + "','" + userProfile.slnoinpart + "',N'" + userProfile.houseNo + "',N'" + userProfile.sectionno + "',N'" + userProfile.fm_name_v1 + "',N'" + userProfile.Lastname_v1 + "',N'" + userProfile.RLN_TYPE + "',N'" + userProfile.RLN_FM_NM_v1
                    + "',N'" + userProfile.RLN_L_NM_v1 + "',N'" + userProfile.IDCARD_NO + "',N'" + userProfile.STATUSTYPE + "',N'" + userProfile.SEX + "',N'" + userProfile.AGE + "',N'" + userProfile.FM_NAMEEN + "',N'" + userProfile.LASTNAMEEN
                    + "',N'" + userProfile.RLN_FM_NMEN + "',N'" + userProfile.RLN_L_NMEN + "',N'" + userProfile.FULL_NAMEEN + "',N'" + userProfile.EB_No + "',N'" + userProfile.Allocated_Ward + "',N'" + userProfile.SerialNo_InWard + "',N'" + userProfile.BoothNo
                    + "',N'" + userProfile.SerialNo_ForFinalList + "','" + userProfile.old_serialIn_ward + "','" + userProfile.localBody + "','" + userProfile.uid + "','" + userProfile.distritId + "','" + userProfile.assemblyId + "','" + userProfile.voterWardNo + "')";

                    if (sqlCommand.Connection.State == ConnectionState.Closed)
                        sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

                if (userProfile.localBody == "" || userProfile.localBody == null)
                {

                    sqlCommand.CommandText = "if exists(select * FROM [TrueVoterDB].[dbo].[GCMRegistrations] where [MobileNo] =(SELECT [MobileNo]  FROM [TrueVoterDB].[dbo].[Logins] WHERE [RegId]='" + userProfile.RegId + "')) " +
                                        " begin update [TrueVoterDB].[dbo].[GCMRegistrations] set [localBody]=" + 0 + " where [MobileNo]=(SELECT [MobileNo]  FROM [TrueVoterDB].[dbo].[Logins] WHERE [RegId]='" + userProfile.RegId + "') end";
                    if (sqlCommand.Connection.State == ConnectionState.Closed)
                        sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    sqlCommand.CommandText = "if exists(select * FROM [TrueVoterDB].[dbo].[GCMRegistrations] where [MobileNo] =(SELECT [MobileNo]  FROM [TrueVoterDB].[dbo].[Logins] WHERE [RegId]='" + userProfile.RegId + "')) " +
                                      " begin update [TrueVoterDB].[dbo].[GCMRegistrations] set [localBody]=" + userProfile.localBody + " where [MobileNo]=(SELECT [MobileNo]  FROM [TrueVoterDB].[dbo].[Logins] WHERE [RegId]='" + userProfile.RegId + "') end";
                    if (sqlCommand.Connection.State == ConnectionState.Closed)
                        sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

                return CommonCode.OK;
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR;
            }
            catch (Exception)
            {
                return CommonCode.ERROR;
            }
            finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }

        }

        public void UserProfileData(string regId)
        {
            try
            {
                data = new DataSet();
                SqlParameter regIdParameter = new SqlParameter("@regId", regId);
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetProfile]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(regIdParameter);

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