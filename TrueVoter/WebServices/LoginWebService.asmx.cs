using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TrueVoter.App_Code.BAL;
using System.Xml;
using App_Code.BAL;

namespace TrueVoter.WebServices
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class LoginWebService : System.Web.Services.WebService
    {
        EncDecArrayClass objenc = new EncDecArrayClass();
        [WebMethod(EnableSession = true)]
        public string login(string userName, string password)
        {
            CommonCode cc = new CommonCode();
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspLogin]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter registrationSqlParameter = new SqlParameter("@regid", "");
                registrationSqlParameter.Direction = ParameterDirection.Output;
                registrationSqlParameter.SqlDbType = SqlDbType.NVarChar;
                registrationSqlParameter.Size = 20;

                userName = EncryptDecrypt.DecodeAndDecrypt(userName);
                password = EncryptDecrypt.DecodeAndDecrypt(password);
                //changes on 25-10-2016 SM
                string pw = password.Substring(0, password.Length - 12);
                password = cc.DESEncrypt(pw);

                //line Coment of reject encription

                string dt1 = userName.Substring(userName.Length - 12);
                userName = userName.Substring(0, userName.Length - 12);
                string retVal = objenc.DateTimeDec(dt1);

                // password = password.Substring(0, password.Length - 10);

                if (retVal == "0")
                {
                    return CommonCode.SQL_ERROR.ToString();
                }

                string temppass = password;

                CommonCode commoncode = new CommonCode();
                //password = commoncode.DESEncrypt(password); double method error in voter login 25-10-2016
                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@userName", userName), new SqlParameter("@pasword", password), registrationSqlParameter };
                sqlCommand.Parameters.AddRange(sqlParameter);
                SqlParameter returnValue = sqlCommand.CreateParameter();
                returnValue.SqlDbType = SqlDbType.Int;
                returnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.Parameters.Add(returnValue);

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();
                if (Convert.ToString(returnValue.Value) == "1")
                {
                    //RegID Encription 28-10-2016
                    string concate1 = sqlCommand.Parameters["@regid"].Value.ToString();
                    string currentdate = System.DateTime.Now.ToString("ddMMyyHHmmss");
                    string RegiID = currentdate + "" + concate1;
                    string regIdEnc = EncryptDecrypt.EncryptAndEncode(RegiID);

                    //string regIdEnc = EncryptDecrypt.EncryptAndEncode(sqlCommand.Parameters["@regid"].Value.ToString());
                    Session["regId"] = sqlCommand.Parameters["@regid"].Value.ToString();
                    return CommonCode.OK.ToString() + "*" + regIdEnc;
                    //Session["regID"] = (sqlCommand.Parameters["@regid"].Value.ToString());
                }
                else
                {
                    return CommonCode.SQL_ERROR.ToString();
                }
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

        [WebMethod]
        public string forgetPassword(string userName, int type)
        {
            try
            {
                if (type == 1)
                    return trueVoterPassword(userName);
                else
                    return myctPassword(userName);
            }
            catch
            {
                return CommonCode.ERROR.ToString();
            }
        }

        public string myct(string username, string password)
        {
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myctConnectionString"].ConnectionString);
                sqlCommand.CommandText = "select usrPassword,(select top 1  usertype FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail](NOLOCK) where UserId=usrUserId and [keyword]='TRUEVOTER' ORDER BY usertype DESC ) as usertype from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    CommonCode cc = new CommonCode();
                    string temppasword = cc.DESDecrypt(ds.Tables[0].Rows[0][0].ToString());
                    if (temppasword == password)
                        return ds.Tables[0].Rows[0][1].ToString();
                    else
                        return CommonCode.FAIL.ToString();
                }
                else
                {
                    return CommonCode.FAIL.ToString();
                }

            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
        }
        public string myctPassword(string userName) // Change made 24.09.2016
        {
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
                sqlCommand.CommandText = "SELECT [Password] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName]='" + userName + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    CommonCode cc = new CommonCode();
                    string temppasword = cc.DESDecrypt(ds.Tables[0].Rows[0][0].ToString());
                    string message = "Your PASSWORD for True Voter is " + temppasword + "";
                    cc.SMS(userName, message);
                    return CommonCode.OK.ToString();
                }
                else
                {
                    return CommonCode.FAIL.ToString();
                }
            }
            catch (SqlException)
            {
                return CommonCode.SQL_ERROR.ToString();
            }
            catch (Exception)
            {
                return CommonCode.ERROR.ToString();
            }
        }
        public string trueVoterPassword(string userName)
        {
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
                sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspGetPassword]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter registrationSqlParameter = new SqlParameter("@password", "");
                registrationSqlParameter.Direction = ParameterDirection.Output;
                registrationSqlParameter.SqlDbType = SqlDbType.NVarChar;
                registrationSqlParameter.Size = 50;

                SqlParameter mobileSqlParameter = new SqlParameter("@mobile", "");
                mobileSqlParameter.Direction = ParameterDirection.Output;
                mobileSqlParameter.SqlDbType = SqlDbType.NVarChar;
                mobileSqlParameter.Size = 20;

                CommonCode commoncode = new CommonCode();

                SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@userName", userName), registrationSqlParameter, mobileSqlParameter };
                sqlCommand.Parameters.AddRange(sqlParameter);

                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();
                string password = sqlCommand.Parameters["@password"].Value.ToString();
                string mobile = sqlCommand.Parameters["@mobile"].Value.ToString();
                if (password != null)
                {
                    string message = "Your PASSWORD for True Voter is " + commoncode.DESDecrypt(password) + "";
                    commoncode.SMS(mobile, message);
                    return CommonCode.OK.ToString();
                }
                else
                {
                    return CommonCode.WRONG_INPUT.ToString();
                }
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

        [WebMethod(Description = "METHOD TO CALL LOGIN FROM MYCT")]
        public XmlDocument OldLogin(string Password, string MobileNo) //Change made 24.09.2016
        {
            try
            {
                XmlDataDocument xmldata = new XmlDataDocument();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                CommonCode cc = new CommonCode();

                MobileNo = EncryptDecrypt.DecodeAndDecrypt(MobileNo);
                Password = EncryptDecrypt.DecodeAndDecrypt(Password);

                string pw = Password.Substring(0, Password.Length - 12);
                Password = cc.DESEncrypt(pw);

                string dt1 = MobileNo.Substring(MobileNo.Length - 12);
                MobileNo = MobileNo.Substring(0, MobileNo.Length - 12);
                string retVal = objenc.DateTimeDec(dt1);
                //retVal = "1";
                if (retVal == "0")
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "105";
                    dt.Rows.Add(dr);
                    DataSet ds3 = new DataSet();
                    ds3.Tables.Add(dt);
                    ds3.Tables[0].TableName = "NO";
                    xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlelement = xmldata.DocumentElement;
                    return xmldata;
                }

                string sqlQuery = "SELECT [UserType] AS [typeOfUse_Id] " +
                                  "FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "'";

                ds = cc.ExecuteDataset(sqlQuery);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string roleId = ds.Tables[0].Rows[0]["typeOfUse_Id"].ToString();
                    if (roleId == "2")
                    {
                        sqlQuery = "SELECT [keyword]='TRUEVOTER',[ImeiNumber] AS [strDevId],[strSimSerialno] AS [strSimSerialNo],[Name] AS [firstName],[LName] AS [lastName],'0' AS [firmName], [MobileNo] AS [mobileNo], [address],[EmailId] AS [eMailId],[UserType] AS [typeOfUse_Id],[RefMobileNo] AS [RefMobileNo],[State],[District],[Taluka],[LATITUTE] AS [latitude],[LAGITUTE] AS [longitude] " +
                                  ",[IsApproved]=0,[usrMobileNumber],[DesignationId],[DesignationName],[LokingAfterId],[LokingAfterName],[LocalBodyId],[LocalBodyName],[refMobileNumber],[OfficerDistrictId] " +
                                  "FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[tblNewDataRegExtra] " +
                                  "ON [TrueVoterDB].[dbo].[Logins].[UserName] = [TrueVoterDB].[dbo].[tblNewDataRegExtra].[usrMobileNumber] WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "'";
                    }
                    else
                    {
                        sqlQuery = "SELECT [keyword]='TRUEVOTER',[ImeiNumber] AS [strDevId],[strSimSerialno] AS [strSimSerialNo],[Name] AS [firstName],[LName] AS [lastName],'0' AS [firmName], " +
                                   "[MobileNo] AS [mobileNo], [address],[EmailId] AS [eMailId],[UserType] AS [typeOfUse_Id],[RefMobileNo] AS [RefMobileNo], " +
                                   "[State],[District],[Taluka],[LATITUTE] AS [latitude], [LAGITUTE] AS [longitude],[IsApproved]=0,[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID], " +
                                   "[LocalBodyType] AS CandiLocalBodyType,[LocalBodyName] As CandiLocalBodyName,[WardNo] As CandiWard,[LocalBodyID] As CandiLocalBodyId,[AssemblyID] As CandiAssemblyId " +
                                   "FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] " +
                                   "ON [TrueVoterDB].[dbo].[Logins].[UserName] = [TrueVoterDB].[dbo].[tblNewDataCandi_Reg].[usrMobileNumber] " +
                                   "WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "' ";
                    }

                    DataSet dsWholeData = cc.ExecuteDataset(sqlQuery);
                    xmldata = new XmlDataDocument(dsWholeData);
                    XmlElement xmlele = xmldata.DocumentElement;
                    return xmldata;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "105";
                    dt.Rows.Add(dr);
                    DataSet ds3 = new DataSet();
                    ds3.Tables.Add(dt);
                    ds3.Tables[0].TableName = "NO";
                    xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlelement = xmldata.DocumentElement;
                    return xmldata;
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod(Description = "NEW LOGIN METHOD WITH IMEINUMBER")]
        public XmlDocument Login(string Password, string MobileNo, string imeiNumber) //Change made 09.11.2016 
        {
            try
            {
                XmlDataDocument xmldata = new XmlDataDocument();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                CommonCode cc = new CommonCode();
                string sqlQuery = string.Empty;

                MobileNo = EncryptDecrypt.DecodeAndDecrypt(MobileNo);
                Password = EncryptDecrypt.DecodeAndDecrypt(Password);

                string pw = Password.Substring(0, Password.Length - 12);
                Password = cc.DESEncrypt(pw);

                string dt1 = MobileNo.Substring(MobileNo.Length - 12);
                MobileNo = MobileNo.Substring(0, MobileNo.Length - 12);
                string retVal = objenc.DateTimeDec(dt1);
                //retVal = "1";
                if (retVal == "0")
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "105";
                    dt.Rows.Add(dr);
                    DataSet ds3 = new DataSet();
                    ds3.Tables.Add(dt);
                    ds3.Tables[0].TableName = "NO";
                    xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlelement = xmldata.DocumentElement;
                    return xmldata;
                }

                //if (imeiNumber == "")
                //{
                //    sqlQuery = "SELECT [UserType] AS [typeOfUse_Id] " +
                //                  "FROM [TrueVoterDB].[dbo].[Logins] WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "'";
                //}
                //else
                //{
                    sqlQuery = "SELECT [UserType] AS [typeOfUse_Id] " +
                                  "FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "' AND [ImeiNumber] = '" + imeiNumber + "'";
               // }

                ds = cc.ExecuteDataset(sqlQuery);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string roleId = ds.Tables[0].Rows[0]["typeOfUse_Id"].ToString();

                    if (roleId == "2")
                    {
                        sqlQuery = "SELECT [keyword]='TRUEVOTER',[ImeiNumber] AS [strDevId],[strSimSerialno] AS [strSimSerialNo],[Name] AS [firstName],[LName] AS [lastName],'0' AS [firmName], [MobileNo] AS [mobileNo], [address],[EmailId] AS [eMailId],[UserType] AS [typeOfUse_Id],[RefMobileNo] AS [RefMobileNo],[State],[District],[Taluka],[LATITUTE] AS [latitude],[LAGITUTE] AS [longitude] " +
                                   ",[IsApproved]=0,[usrMobileNumber],[DesignationId],[DesignationName],[LokingAfterId],[LokingAfterName],[LocalBodyId],[LocalBodyName],[refMobileNumber],[OfficerDistrictId],[Post],[AllocatedWard] " +
                                   "FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[tblNewDataRegExtra] " +
                                   "ON [TrueVoterDB].[dbo].[Logins].[UserName] = [TrueVoterDB].[dbo].[tblNewDataRegExtra].[usrMobileNumber] WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "'";

                    }
                    else
                    {
                        sqlQuery = "SELECT [keyword]='TRUEVOTER',[ImeiNumber] AS [strDevId],[strSimSerialno] AS [strSimSerialNo],[Name] AS [firstName],[LName] AS [lastName],'0' AS [firmName], " +
                                   "[MobileNo] AS [mobileNo], [address],[EmailId] AS [eMailId],[UserType] AS [typeOfUse_Id],[RefMobileNo] AS [RefMobileNo], " +
                                   "[State],[District],[Taluka],[LATITUTE] AS [latitude], [LAGITUTE] AS [longitude],[IsApproved]=0,[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID], " +
                                   "[LocalBodyType] AS CandiLocalBodyType,[LocalBodyName] As CandiLocalBodyName,[WardNo] As CandiWard,[LocalBodyID] As CandiLocalBodyId,[AssemblyID] As CandiAssemblyId " +
                                   "FROM [TrueVoterDB].[dbo].[Logins] INNER JOIN [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] " +
                                   "ON [TrueVoterDB].[dbo].[Logins].[UserName] = [TrueVoterDB].[dbo].[tblNewDataCandi_Reg].[usrMobileNumber] " +
                                   "WHERE [UserName]='" + MobileNo + "' AND [Password]='" + Password + "' AND [ImeiNumber] = '" + imeiNumber + "'";
                    }

                    //if (imeiNumber != "")
                    //{
                        DataSet dsWholeData = cc.ExecuteDataset(sqlQuery);
                        xmldata = new XmlDataDocument(dsWholeData);
                    //}
                    //else
                    //{
                    //    xmldata = new XmlDataDocument(ds);
                    //}

                    XmlElement xmlele = xmldata.DocumentElement;
                    return xmldata;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "105";
                    dt.Rows.Add(dr);
                    DataSet ds3 = new DataSet();
                    ds3.Tables.Add(dt);
                    ds3.Tables[0].TableName = "NO";
                    xmldata = new XmlDataDocument(ds3);
                    XmlElement xmlelement = xmldata.DocumentElement;
                    return xmldata;
                }
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }
    }
}
