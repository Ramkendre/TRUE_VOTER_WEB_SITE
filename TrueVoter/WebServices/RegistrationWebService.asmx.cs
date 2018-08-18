using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using TrueVoter.App_Code.BAL;
using TrueVoter.App_Code.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TrueVoter;


namespace TrueVoter.WebServices
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class RegistrationWebService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
       // SqlCommand cmd = null;
        SendRegDataToTrueVoter objTrueReg = new SendRegDataToTrueVoter();
        CommonCode cc = new CommonCode();
        string returnnew = string.Empty;
        EncDecArrayClass objenc = new EncDecArrayClass();

        [WebMethod]
        public string newRegistration(string registrationString)
        {
            try
            {
                RegistrationBLL registrationBll = new RegistrationBLL();
                return registrationBll.NewRegistration(registrationString);
            }
            catch
            {
                return "0";
            }
        }

        [WebMethod]
        public string checkOTP(string mobileNo, string otp)
        {
            try
            {
                RegistrationBLL registrationBll = new RegistrationBLL();
                return registrationBll.checkOtp(mobileNo, otp);
            }
            catch
            {
                return "0";
            }
        }

        [WebMethod]
        public string resendOTP(string mobileNo)
        {
            try
            {
                RegistrationBLL registrationBll = new RegistrationBLL();
                return registrationBll.resendOtp(mobileNo);
            }
            catch
            {
                return "0";
            }
        }

        [WebMethod]
        public int newProfile(string profileString, string photo)
        {
            try
            {
                RegistrationBLL registrationBll = new RegistrationBLL();
                return registrationBll.newProfile(profileString, photo);
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(EnableSession = true)]
        public XmlDocument GetProfile(string regId)
        {
            XmlDocument xmlDocument = new XmlDocument();
            RegistrationDAL registrationDal = new RegistrationDAL();
            try
            {
                string[] uregid = regId.Split('$');
                string substr = uregid[0].Substring(0, 3);
                string ump = uregid[0].ToString();
                int len = ump.Length;
                len = len - 3;
                ump = ump.Substring(3, len);

                regId = objenc.DecryptInteger(ump, uregid[1]);
                regId = substr + regId;

                registrationDal.UserProfileData(regId);
                if (registrationDal.isError == CommonCode.OK)
                {
                    if (registrationDal.userData != null && registrationDal.userData.Tables[0].Rows.Count != 0)
                    {
                        registrationDal.userData.Tables[0].TableName = "UserProfile";
                        XmlDataDocument xmlDataDocument = new XmlDataDocument(registrationDal.userData);
                        XmlElement element = xmlDataDocument.DocumentElement;
                        return xmlDataDocument;
                    }
                    else if (registrationDal.userData.Tables[0].Rows.Count == 0)
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);

                        XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
                        doc.AppendChild(errrorNode);

                        XmlNode nameNode = doc.CreateElement("Error");
                        nameNode.AppendChild(doc.CreateTextNode(CommonCode.DATA_NOT_FOUND.ToString()));
                        errrorNode.AppendChild(nameNode);
                        return doc;
                    }
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(docNode);

                    XmlNode errrorNode = doc.CreateElement("ErrorMainNode");
                    doc.AppendChild(errrorNode);

                    XmlNode nameNode = doc.CreateElement("Error");
                    nameNode.AppendChild(doc.CreateTextNode(Convert.ToString(registrationDal.isError)));
                    errrorNode.AppendChild(nameNode);
                }
                return xmlDocument;
            }
            catch
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public int gcmRegistration(string mobile, string regid, int userType)
        {
            try
            {
                RegistrationDAL reg = new RegistrationDAL();

                string[] uregid = mobile.Split('$');
                mobile = objenc.DecryptInteger(uregid[0], uregid[1]);

                return reg.GCMRegistration(mobile, regid, userType);
            }
            catch
            {
                return 0;
            }
        }

        //New work done by jitendra aptil 23.09.2016 break to myct, this is a webservice for appregistration

        [WebMethod(Description = "METHOD FOR APP REGISTRATION")]
        public string Registration(string AppMobileNo, string RefmobileNo, string strDevId, string strSimSerialNo, string keyword, string firstName,
                               string lastName, string firmName, string address, string SchoolCode, string eMailId, string Role_Id, string pincode,
                               string passcode, string latitude, string longitude, string state, string district, string Taluka, string userType,
                               string DealerMobNo)
        {
            string returnStrig = string.Empty;
            try
            {
                Random rnd = new Random();
                string Password = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                string regValue = string.Empty;

                Random rand = new Random();
                string otpstr = Convert.ToString(rand.Next(1001, 9999));

                string sqlSelect = "SELECT [RegId] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + AppMobileNo + "' ";
                DataSet dsSelect = cc.ExecuteDataset(sqlSelect);

                if (dsSelect.Tables[0].Rows.Count > 0)
                {
                    string sqlUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [Name]=N'" + firstName + "',[LName]=N'" + lastName + "',[LATITUTE]='" + latitude + "',[LAGITUTE]='" + longitude + "',[EmailId]='" + eMailId + "',[UserType]='" + Role_Id + "',[ImeiNumber]='" + strDevId + "',[RefMobileNo]='" + RefmobileNo + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "',[ModifyBy]='" + AppMobileNo + "',[address]=N'" + address + "',[State]=" + state + ",[District]=" + district + ",[Taluka]=" + Taluka + ",[strSimSerialno]='" + strSimSerialNo + "' " +
                                       "WHERE [RegId] = '" + dsSelect.Tables[0].Rows[0]["RegId"].ToString() + "'";
                    cc.ExecuteNonQuery(sqlUpdate);

                    #region

                    if (Role_Id == "1") //VOTER
                    {
                        regValue = "PASS";
                    }
                    else if (Role_Id == "2") //OFFICER
                    {
                        string sqlAdd = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile] = '" + AppMobileNo + "' AND [RefMobile] = '" + RefmobileNo + "' AND [keyword] = 'JUNIOR' AND [isActive] = 'Active'";
                        DataSet dsAdd = cc.ExecuteDataset(sqlAdd);

                        if (dsAdd.Tables[0].Rows.Count > 0)//is aprove asel tr msg not send here it get approval
                        {
                            string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + AppMobileNo + "'";
                            cc.ExecuteNonQuery(sqlIsppUpdate);
                            regValue = "PASS";
                        }
                        else
                        {
                            string officerRole = string.Empty;
                            officerRole = "Officer";

                            string msg = "I " + firstName + " " + lastName + " " + AppMobileNo + " installed TRUE VOTER for election purpose as " + officerRole + " role" +
                                         " Add me under you as Junior to give proper reporting thru TRUE VOTER";
                            cc.SMS(RefmobileNo, msg);
                            regValue = "PASS";
                        }
                    }
                    else
                    {
                        // This Work is For Candidate add representative
                        string sqlAdd = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile] = '" + AppMobileNo + "' AND [RefMobile] = '" + RefmobileNo + "' AND [keyword] = 'REPRESENTATIVE' AND [isActive] = 'Active'";
                        DataSet dsAdd = cc.ExecuteDataset(sqlAdd);

                        if (dsAdd.Tables[0].Rows.Count > 0)
                        {
                            string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + AppMobileNo + "'";
                            cc.ExecuteNonQuery(sqlIsppUpdate);
                            regValue = "PASS";
                        }
                        else
                        {
                            string candidateRole = string.Empty;
                            candidateRole = "Candidate";//"Representative";

                            string msg = "I " + firstName + " " + lastName + " " + AppMobileNo + " installed TRUE VOTER for election purpose as " + candidateRole + "" +
                                         " Add me under you as Representative to give proper reporting thru TRUE VOTER";
                            cc.SMS(RefmobileNo, msg);
                            regValue = "PASS";
                        }
                    }

                    #endregion

                    returnnew = SendOtpTrueVoter(AppMobileNo, otpstr, keyword, strDevId, RefmobileNo, firstName, Role_Id, regValue); //SEND OTP
                }
                else
                {
                    regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, Password, otpstr, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo, strSimSerialNo, address, state, district, Taluka);
                    returnnew = SendOtpTrueVoter(AppMobileNo, otpstr, keyword, strDevId, RefmobileNo, firstName, Role_Id, regValue); //SEND OTP
                }

                return returnnew;
            }
            catch
            {
                return returnStrig = "0";
            }
        }


        #region METHOD TO CHECK OTP FOR TRUEVOTER

        [WebMethod(Description = "METHOD TO CHECK OTP FOR TRUEVOTER")]
        public string chkOTPForTrueVoter(string AppMobileNo, string OTP, string keyword, string iemiNo, string RefMobileNo)
        {
            string returnString = string.Empty;
            try
            {
                string[] uregid = OTP.Split('$');
                OTP = objenc.DecryptInteger(uregid[0], uregid[1]);

                string[] uregid1 = AppMobileNo.Split('$');
                AppMobileNo = objenc.DecryptInteger(uregid1[0], uregid1[1]);

                string[] uregid2 = iemiNo.Split('$');
                iemiNo = objenc.DecryptInteger(uregid2[0], uregid2[1]);

                string sqlQuery = "SELECT * FROM [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter](NOLOCK) WHERE [IEMINo]='" + iemiNo + "' AND [MobileNo]='" + AppMobileNo + "' AND [OTP]='" + OTP + "' ";
                DataSet ds1 = cc.ExecuteDataset(sqlQuery);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    sqlQuery = "UPDATE [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] SET [OTP] = '0' WHERE [IEMINo]='" + iemiNo + "' AND [MobileNo]='" + AppMobileNo + "'";
                    cc.ExecuteNonQuery(sqlQuery);
                    string otpVal = checkOtp(AppMobileNo, OTP);

                    #region SEND SMS OF PASSWORD TO USER AFTER VERFICATION OF OTP

                    //New Changes Done by Jitendra Patil for SMS Templates Dated On 26 Oct 2016 From Work At Home
                    string sqlPassword = "SELECT [Password],[Name],[LName],[UserType] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + AppMobileNo + "'";
                    DataSet dsPassword = cc.ExecuteDataset(sqlPassword);
                    string passwordVal = cc.DESDecrypt(dsPassword.Tables[0].Rows[0][0].ToString());

                    string name = dsPassword.Tables[0].Rows[0][1].ToString();
                    string LName = dsPassword.Tables[0].Rows[0][2].ToString();
                    string roleId = dsPassword.Tables[0].Rows[0][3].ToString();

                    if (roleId == "2")
                    {
                        string sqlofficerRole = "SELECT [DesignationName] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra](NOLOCK) WHERE [usrMobileNumber] = '" + AppMobileNo + "'";
                        DataSet dsofficerRole = cc.ExecuteDataset(sqlofficerRole);

                        string officerRole = string.Empty;
                        if (dsofficerRole.Tables[0].Rows.Count > 0)
                        {
                            officerRole = dsofficerRole.Tables[0].Rows[0]["DesignationName"].ToString();
                        }
                        else
                        {
                            officerRole = "Officer";
                        }

                        string msg = "Dear " + name + " " + LName + " you installed TRUE VOTER as " + officerRole + ". Your password for login is " + passwordVal + "";
                        cc.SMS(AppMobileNo, msg);
                    }

                    else if (roleId == "3")
                    {
                        string sqlcandidateRole = "SELECT [CandidateRoleName] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg](NOLOCK) WHERE [usrMobileNumber] = '" + AppMobileNo + "'";
                        DataSet dscandidateRole = cc.ExecuteDataset(sqlcandidateRole);

                        string candidateRole = string.Empty;
                        if (dscandidateRole.Tables[0].Rows.Count > 0)
                        {
                            candidateRole = dscandidateRole.Tables[0].Rows[0]["CandidateRoleName"].ToString();
                        }
                        else
                        {
                            candidateRole = "Representative";
                        }

                        string msg = "Dear " + name + " " + LName + " you installed TRUE VOTER as " + candidateRole + ". Your password for login is " + passwordVal + "";
                        cc.SMS(AppMobileNo, msg);
                    }

                    #endregion

                    returnString = "1";
                }
                else
                {
                    returnString = "0";
                }

                return returnString;
            }
            catch
            {
                return "0";
            }
        }

        public string checkOtp(string mobileNo, string otp)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
            SqlCommand sqlCommand = null;
            int Error = CommonCode.OK;

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

        #endregion

        #region SEND OTP VALUE TO USER MOBILE AFTER APP REGISTRATION

        [WebMethod]
        public string SendOtpTrueVoter(string AppMobileNo, string OTP, string keyword, string imeiNo, string RefMobileNo, string name, string role, string regValue)
        {
            string returnValue = string.Empty;
            try
            {
                string otpEzee12 = "SELECT [IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId] FROM [AllAppRegOTPForTrueVoter](NOLOCK) WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
                DataSet ds3 = cc.ExecuteDataset(otpEzee12);

                string mobileDs = string.Empty;
                string refMobileDs = string.Empty;
                string roleIdDs = string.Empty;
                string imeiNumberDs = string.Empty;
                string keywordValDs = string.Empty;
                string otpDs = string.Empty;

                if (ds3.Tables[0].Rows.Count > 0)
                {
                    mobileDs = Convert.ToString(ds3.Tables[0].Rows[0]["MobileNo"]);
                    refMobileDs = Convert.ToString(ds3.Tables[0].Rows[0]["RefMobileNo"]);
                    roleIdDs = Convert.ToString(ds3.Tables[0].Rows[0]["RoleId"]);
                    imeiNumberDs = Convert.ToString(ds3.Tables[0].Rows[0]["IEMINo"]);
                    keywordValDs = Convert.ToString(ds3.Tables[0].Rows[0]["Keyword"]);
                    otpDs = Convert.ToString(ds3.Tables[0].Rows[0]["OTP"]);

                    if (otpDs == null || otpDs == "0" || otpDs == "")
                    {
                        if (imeiNo != imeiNumberDs) //रेकॉर्ड database मध्ये असतील आणि verifed पण असेल पण imei नंबर दुसरा असेल 
                        {
                            string sqlUpadate = "UPDATE [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] SET [IEMINo]='" + imeiNo + "',[OTP]='" + OTP + "',[RefMobileNo]='" + RefMobileNo + "',[RoleId]='" + role + "',[CurrentDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "' " +
                                                "WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
                            cc.ExecuteNonQuery(sqlUpadate);

                            if (regValue == "PASS")
                            {
                                string passwordMessage = string.Empty;
                                if (role == "1")
                                {
                                    passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + OTP + "";
                                }
                                else if (role == "2")
                                {
                                    string officerRole = string.Empty;
                                    officerRole = "Officer";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + officerRole + ". OTP for your installation is " + OTP + "";
                                }
                                else
                                {
                                    string candidateRole = string.Empty;
                                    candidateRole = "Representative";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + candidateRole + ". OTP for your installation is " + OTP + "";
                                }
                                cc.SMS(AppMobileNo, passwordMessage);
                                returnValue = "1";
                            }
                            else
                            {
                                returnValue = "3";
                            }
                        }
                        else //जर mobile नंबर imei आणि keyword सारखे असतील आणि verified असेल तर
                        {
                            returnValue = "2";//Already Verified
                        }
                    }
                    else
                    {
                        if (imeiNo != imeiNumberDs) //रेकॉर्ड database मध्ये असतील आणि verifed पण नसेल imei नंबर दुसरा असेल 
                        {
                            string sqlUpadate = "UPDATE [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] SET [IEMINo]='" + imeiNo + "',[OTP]='" + OTP + "',[RefMobileNo]='" + RefMobileNo + "',[RoleId]='" + role + "',[CurrentDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "' " +
                                                "WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
                            cc.ExecuteNonQuery(sqlUpadate);

                            if (regValue == "PASS")
                            {
                                string passwordMessage = string.Empty;
                                if (role == "1")
                                {
                                    passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + OTP + "";
                                }
                                else if (role == "2")
                                {
                                    string officerRole = string.Empty;
                                    officerRole = "Officer";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + officerRole + ". OTP for your installation is " + OTP + "";
                                }
                                else
                                {
                                    string candidateRole = string.Empty;
                                    candidateRole = "Representative";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + candidateRole + ". OTP for your installation is " + OTP + "";
                                }
                                cc.SMS(AppMobileNo, passwordMessage);
                                returnValue = "1";
                            }
                            else
                            {
                                returnValue = "3";
                            }
                        }
                        else//जर mobile नंबर imei आणि keyword सारखे असतील आणि verified नसेल तर तोच otp पुन्हा पाठवणे
                        {
                            OTP = otpDs;
                            if (regValue == "PASS")
                            {
                                string passwordMessage = string.Empty;
                                if (role == "1")
                                {
                                    passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + OTP + "";
                                }
                                else if (role == "2")
                                {
                                    string officerRole = string.Empty;
                                    officerRole = "Officer";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + officerRole + ". OTP for your installation is " + OTP + "";
                                }
                                else
                                {
                                    string candidateRole = string.Empty;
                                    candidateRole = "Representative";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + candidateRole + ". OTP for your installation is " + OTP + "";
                                }
                                cc.SMS(AppMobileNo, passwordMessage);
                                returnValue = "1";
                            }
                            else
                            {
                                returnValue = "3";
                            }
                        }
                    }
                }
                else
                {// mobile नंबर आणि keyword सेम नसतील तर मोबईल व imei वरून data शोधणे
                    string sqlSelect = "SELECT [IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId] FROM [AllAppRegOTPForTrueVoter](NOLOCK) WHERE [MobileNo]='" + AppMobileNo + "' AND [IEMINo]='" + imeiNo + "'";
                    DataSet dsSelect = cc.ExecuteDataset(sqlSelect);

                    if (dsSelect.Tables[0].Rows.Count > 0)
                    {
                        mobileDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["MobileNo"]);
                        refMobileDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["RefMobileNo"]);
                        roleIdDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["RoleId"]);
                        imeiNumberDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["IEMINo"]);
                        keywordValDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["Keyword"]);
                        otpDs = Convert.ToString(dsSelect.Tables[0].Rows[0]["OTP"]);

                        if (otpDs == null || otpDs == "0" || otpDs == "") //data असेल आणि verified असेल तर त्या keyword नुसार values insert करणे
                        {
                            string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],[CurrentDate]) " +
                                               "VALUES ('" + imeiNo + "','" + AppMobileNo + "','" + keyword + "','" + otpDs + "','" + RefMobileNo + "','" + role + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                            cc.ExecuteNonQuery(sqlInsert);
                            returnValue = "2";//Already Verified
                        }
                        else
                        {//जर otp verified नसेल तर नवीन otp सोबत रेकॉर्ड insert करणे
                            string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],[CurrentDate]) " +
                                               "VALUES ('" + imeiNo + "','" + AppMobileNo + "','" + keyword + "','" + OTP + "','" + RefMobileNo + "','" + role + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                            cc.ExecuteNonQuery(sqlInsert);
                            if (regValue == "PASS")
                            {
                                string passwordMessage = string.Empty;
                                if (role == "1")
                                {
                                    passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + OTP + "";
                                }
                                else if (role == "2")
                                {
                                    string officerRole = string.Empty;
                                    officerRole = "Officer";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + officerRole + ". OTP for your installation is " + OTP + "";
                                }
                                else
                                {

                                    string candidateRole = string.Empty;
                                    candidateRole = "Representative";

                                    passwordMessage = "Thanks to Install TRUE VOTER as a " + candidateRole + ". OTP for your installation is " + OTP + "";
                                }
                                cc.SMS(AppMobileNo, passwordMessage);
                                returnValue = "1";
                            }
                            else
                            {
                                returnValue = "3";
                            }
                        }
                    }
                    else
                    {//नवीन रेकॉर्ड insert होणार जर keyword आणि imei दोन्ही दुसरे असतील
                        string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],[CurrentDate]) " +
                                           "VALUES ('" + imeiNo + "','" + AppMobileNo + "','" + keyword + "','" + OTP + "','" + RefMobileNo + "','" + role + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        cc.ExecuteNonQuery(sqlInsert);
                        if (regValue == "PASS")
                        {
                            string passwordMessage = string.Empty;
                            if (role == "1")
                            {
                                passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + OTP + "";
                            }
                            else if (role == "2")
                            {
                                string officerRole = string.Empty;
                                officerRole = "Officer";

                                passwordMessage = "Thanks to Install TRUE VOTER as a " + officerRole + ". OTP for your installation is " + OTP + "";
                            }
                            else
                            {
                                string candidateRole = string.Empty;
                                candidateRole = "Representative";

                                passwordMessage = "Thanks to Install TRUE VOTER as a " + candidateRole + ". OTP for your installation is " + OTP + "";
                            }
                            cc.SMS(AppMobileNo, passwordMessage);
                            returnValue = "1";
                        }
                        else
                        {
                            returnValue = "3";
                        }
                    }
                }
                return returnValue;
            }
            catch
            {
                return "0";
            }
        }

        #endregion
    }
}
