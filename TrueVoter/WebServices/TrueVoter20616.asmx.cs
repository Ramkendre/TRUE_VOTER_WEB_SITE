using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using TrueVoter.App_Code.BAL;
using System.IO;

namespace TrueVoter.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class TrueVoter20616 : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        //SqlConnection conKYC = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionKycDataString"].ConnectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        EncDecArrayClass objenc = new EncDecArrayClass();

        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();

        [WebMethod(Description = "NEW TRUE VOTER EXTRA DATA INSERT")]
        public int InsertExtraRegData(string usrMobileNumber, string designationId, string designationName, string lookingAfterId, string lookingAfterName, string localBodyId, string localBodyName, string emergencyNum1, string emergencyNum2, string emergencyNum3, string emergencyNum4, string emergencyNum5, string refMobileNumber, string officerDistrictId, string post, string allocatedWard)
        {
            string sqlQuery = string.Empty;
            try
            {
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                sqlQuery = " SELECT * FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra](NOLOCK) WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";
                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblNewDataRegExtra] SET [DesignationId]='" + designationId + "',[DesignationName]='" + designationName + "',[LokingAfterId]='" + lookingAfterId + "',[LokingAfterName]='" + lookingAfterName + "',[LocalBodyId]='" + localBodyId + "',[LocalBodyName]='" + localBodyName + "',[EmergencyNum1]='" + emergencyNum1 + "',[EmergencyNum2]='" + emergencyNum2 + "',[EmergencyNum3]='" + emergencyNum3 + "',[EmergencyNum4]='" + emergencyNum4 + "',[EmergencyNum5]='" + emergencyNum5 + "',[refMobileNumber]='" + refMobileNumber + "',[OfficerDistrictId]='" + officerDistrictId + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now + "',[Post]='" + post + "',[AllocatedWard]='" + allocatedWard + "'" +
                               " WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";
                    con.Open();
                    cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblNewDataRegExtra] ([usrMobileNumber],[DesignationId],[DesignationName],[LokingAfterId],[LokingAfterName],[LocalBodyId],[LocalBodyName],[EmergencyNum1],[EmergencyNum2],[EmergencyNum3],[EmergencyNum4],[EmergencyNum5],[refMobileNumber],[OfficerDistrictId],[CreatedBy],[CreatedDate],[Post],[AllocatedWard]) " +
                               " VALUES ('" + usrMobileNumber + "','" + designationId + "','" + designationName + "','" + lookingAfterId + "','" + lookingAfterName + "','" + localBodyId + "','" + localBodyName + "','" + emergencyNum1 + "','" + emergencyNum2 + "','" + emergencyNum3 + "','" + emergencyNum4 + "','" + emergencyNum5 + "','" + refMobileNumber + "','" + officerDistrictId + "','" + usrMobileNumber + "','" + System.DateTime.Now + "' ,'" + post + "','" + allocatedWard + "') ";
                    con.Open();
                    cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(Description = "INSERT DATA TO NOMINATION PART ONE")]
        public int InsertNominationPart_1(string firstName, string lastName, string fatherName, string mobileNumber, string emailId, string electionFor, string electionYear, string electionType, string localBody, string startDate, string endDate, string divisionName, string districtName, string talukaName, string electoralDivisionNo, string electoralDivisionName, string electoralCollegeNo, string electoralCollegeName, string wardNo, string wardName, string seatNo, string reservationCategory, string startDate1, string endDate1, string userName, string usrPassword, string txtMobileNo, string AppMobileNumber)
        {
            try
            {
                string[] uregid = txtMobileNo.Split('$');
                txtMobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                string[] uregid1 = AppMobileNumber.Split('$');
                AppMobileNumber = objenc.DecryptInteger(uregid1[0], uregid1[1]);

                string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblNEnrCandidateApp] ([FirstName],[LastName],[FatherName],[MobileNo],[EmailId],[ElectionFor],[ElectionYear],[ElectionType],[LocalBody],[StartDate],[EndDate],[CreatedBy],[CreatedDate]) " +
                                  " VALUES ('" + firstName + "','" + lastName + "','" + fatherName + "','" + mobileNumber + "','" + emailId + "','" + electionFor + "','" + electionYear + "','" + electionType + "','" + localBody + "','" + startDate + "','" + endDate + "','" + AppMobileNumber + "','" + System.DateTime.Now + "')";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                InsertNominationPart_2(divisionName, districtName, talukaName, electoralDivisionNo, electoralDivisionName, electoralCollegeNo, electoralCollegeName, wardNo, wardName, seatNo, reservationCategory, startDate1, endDate1, userName, usrPassword, txtMobileNo, AppMobileNumber);
                return 1;

            }
            catch
            {
                return 0;
            }
        }

        public int InsertNominationPart_2(string divisionName, string districtName, string talukaName, string electoralDivisionNo, string electoralDivisionName, string electoralCollegeNo, string electoralCollegeName, string wardNo, string wardName, string seatNo, string reservationCategory, string startDate, string endDate, string userName, string usrPassword, string txtMobileNo, string AppMobileNumber)
        {
            try
            {
                string sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblNEnrCandidateApp] SET [DivisionName]='" + divisionName + "',[DistrictId]='1',[DistrictName]='" + districtName + "',[TalukaId]='1',[TalukaName]='" + talukaName + "',[ElectoralDivisionNo]='" + electoralDivisionNo + "',[ElectoralDivisionName]='" + electoralDivisionName + "',[ElectoralCollegeNo]='" + electoralCollegeNo + "',[ElectoralCollegeName]='" + electoralCollegeName + "',[WardNo]='" + wardNo + "',[WardName]='" + wardName + "',[SeatNo]='" + seatNo + "',[ReservationCategory]='" + reservationCategory + "',[NstartDate]='" + startDate + "',[NendDate]='" + endDate + "',[UserName]='" + userName + "',[UserPassword]='" + usrPassword + "',[Status]='1',[ModifyBy]='" + AppMobileNumber + "',[ModifyDate]='" + System.DateTime.Now + "'" +
                                  " WHERE [MobileNo]='" + txtMobileNo + "'";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(Description = "INSERT ELECTION STATUS DETAILS ACTIVITY")] //CHANGE ON 28-11-2016 Upgraded
        public int InsertElectionStatus(string electionStatusId, string electionStatusName, string remarks, string date, string loginNumber, string localbId, string distID, string wardNo, string boothNo, string userRole)
        {
            try
            {
                string[] uregid = loginNumber.Split('$');
                loginNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblElectionStatus] ([ElectionStatusId],[ElectionStatusName],[Remarks],[Status],[Date],[LoginNumber],[CreatedBy],[CreatedDate],[LocalBodyID],[DistrictID],[WardNo],[BoothNo],[UserRole]) " +
                                  " VALUES ('" + electionStatusId + "','" + electionStatusName + "',N'" + remarks + "','1','" + date + "','" + loginNumber + "','" + loginNumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + localbId + "','" + distID + "','" + wardNo + "','" + boothNo + "','" + userRole + "')";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(Description = "INSERT EMERGENCY SERVICES DETAILS")] //CHANGE ON 28-11-2016 Upgraded
        public int InsertEmergencyServices(string emergSeviceId, string emergeServiceName, string remarks, string date, string loginNumber, string localbid, string distID, string wardNo, string boothNo, string userRole)
        {
            try
            {
                string[] uregid = loginNumber.Split('$');
                loginNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                string sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblEmergencyServices] ([EmergServiceId],[EmergServiceName],[Remark],[Status],[Date],[LoginNumber],[CreatedBy],[CreatedDate],[LocalBodyID],[DistrictID],[WardNo],[BoothNo],[UserRole]) " +
                                  " VALUES ('" + emergSeviceId + "','" + emergeServiceName + "',N'" + remarks + "','1','" + date + "','" + loginNumber + "','" + loginNumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + localbid + "','" + distID + "','" + wardNo + "','" + boothNo + "','" + userRole + "')";
                con.Open();
                cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int SendRegDataTrueVoter(string firstName, string mobile, string usrName, string usrPassword, string otp, string middleName, string lastName, string latitude, string longitude)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[TrueVoterDB].[dbo].[uspRegisterUser]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = firstName;
                cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = mobile;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = usrName;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = usrPassword;
                cmd.Parameters.Add("@mName", SqlDbType.NVarChar, 20).Value = middleName;
                cmd.Parameters.Add("@lName", SqlDbType.NVarChar, 20).Value = lastName;
                cmd.Parameters.Add("@otp", SqlDbType.NVarChar, 8).Value = otp;
                cmd.Parameters.Add("@lat", SqlDbType.NVarChar, 8).Value = latitude;
                cmd.Parameters.Add("@lag", SqlDbType.NVarChar, 8).Value = longitude;
                cmd.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                SqlParameter returnValue = cmd.CreateParameter();
                returnValue.SqlDbType = SqlDbType.Int;
                returnValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(returnValue);

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(Description = "GET TOATAL CATEGORIES DETAILS TO APP")]
        public string DownloadCategories()
        {
            try
            {
                string returnString = string.Empty;
                string sqlQuery = "SELECT [CID],[CategoryName],[DefaultorDefine],[SelorType],[Validation] FROM [TrueVoterDB].[dbo].[tblCategories](NOLOCK)";
                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);
                int countds = ds.Tables[0].Rows.Count;

                if (countds > 0)
                {
                    for (int i = 0; i < countds; i++)
                    {
                        string cid = ds.Tables[0].Rows[i][0].ToString(), categoryName = ds.Tables[0].Rows[i][1].ToString(), defordefine = ds.Tables[0].Rows[i][2].ToString(), seloftype = ds.Tables[0].Rows[i][3].ToString(), validation = ds.Tables[0].Rows[i][4].ToString();
                        returnString += "#" + cid + "*" + categoryName + "*" + defordefine + "*" + seloftype + "*" + validation;
                    }
                    returnString = returnString.Substring(1);
                    return returnString;
                }
                else
                {
                    return "105";
                }
            }
            catch
            {
                return "105";
            }
        }

        [WebMethod(Description = "DOWNLOAD CATEGORY ITEMS DETAILS")]
        public string DownloadCategoryItems()
        {
            try
            {
                string returnString = string.Empty;
                string sqlQuery = "SELECT [ItemId],[ItemName],[CategoryId],[DefaultorDefine],[RepreMobile],[Area],[Ward],[Part],[IMEI],[Validation] FROM [TrueVoterDB].[dbo].[tblCategoryItems](NOLOCK) ORDER BY [ItemId] ASC";
                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);
                int countds = ds.Tables[0].Rows.Count;

                if (countds > 0)
                {
                    for (int i = 0; i < countds; i++)
                    {
                        string itemId = ds.Tables[0].Rows[i][0].ToString(), itemName = ds.Tables[0].Rows[i][1].ToString(), categoryId = ds.Tables[0].Rows[i][2].ToString(), defordefine = ds.Tables[0].Rows[i][3].ToString(), reprmob = ds.Tables[0].Rows[i][4].ToString();
                        string area = ds.Tables[0].Rows[i][5].ToString(), ward = ds.Tables[0].Rows[i][6].ToString(), part = ds.Tables[0].Rows[i][7].ToString(), imei = ds.Tables[0].Rows[i][8].ToString(), validation = ds.Tables[0].Rows[i][9].ToString();

                        returnString += "#" + itemId + "*" + itemName + "*" + categoryId + "*" + defordefine + "*" + reprmob + "*" + area + "*" + ward + "*" + part + "*" + imei + "*" + validation;
                    }
                    returnString = returnString.Substring(1);
                    return returnString;
                }
                else
                {
                    return "105";
                }
            }
            catch
            {
                return "105";
            }
        }

        [WebMethod(Description = "TO DOWNLOAD VOTER LIST")]
        public XmlDocument GetVoterDetails(string Assembly, string FirstName, string LastName, string PageSize, string PageIndex)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            DataSet dataset = new DataSet();
            DataTable dt = new DataTable("Table");
            DataSet dsXml = new DataSet();

            string sqlQuery = "SELECT TOP 20 [SECTION_NO] AS Sr,[Allocated_Ward] AS WardNo,[SerialNo_ForFinalList] AS SerialNo,[IDCARD_NO],[fm_name_v1],[RLN_FM_NM_v1],[RLN_L_NM_v1],[FM_NAMEEN], " +
                              "[LASTNAMEEN],[RLN_FM_NMEN],[SEX],[AGE],[AC_NO],[PART_NO],[SLNOINPART] FROM [TrueVoterDB].[dbo].[TestData](NOLOCK) " +
                              "SELECT TOP 20 [BoothNo] AS BoothNumber,[BoothAddress] AS boothname,[BoothAddress] AS BoothAddress FROM [TrueVoterDB].[dbo].[BoothAddresses](NOLOCK) ";
            cmd = new SqlCommand(sqlQuery, con);
            da.SelectCommand = cmd;
            da.Fill(dataset);
            int countds = dataset.Tables[0].Rows.Count;

            if (countds > 0)
            {
                dt.Columns.Add(new DataColumn("Sr", typeof(string)));
                dt.Columns.Add(new DataColumn("WardNo", typeof(string)));
                dt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
                dt.Columns.Add(new DataColumn("IDCARD_NO", typeof(string)));
                dt.Columns.Add(new DataColumn("fm_name_v1", typeof(string)));
                dt.Columns.Add(new DataColumn("RLN_FM_NM_v1", typeof(string)));
                dt.Columns.Add(new DataColumn("RLN_L_NM_v1", typeof(string)));
                dt.Columns.Add(new DataColumn("FM_NAMEEN", typeof(string)));
                dt.Columns.Add(new DataColumn("LASTNAMEEN", typeof(string)));
                dt.Columns.Add(new DataColumn("RLN_FM_NMEN", typeof(string)));
                dt.Columns.Add(new DataColumn("SEX", typeof(string)));
                dt.Columns.Add(new DataColumn("AGE", typeof(string)));
                dt.Columns.Add(new DataColumn("AC_NO", typeof(string)));
                dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
                dt.Columns.Add(new DataColumn("SLNOINPART", typeof(string)));
                dt.Columns.Add(new DataColumn("BoothNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("boothname", typeof(string)));
                dt.Columns.Add(new DataColumn("BoothAddress", typeof(string)));

                for (int i = 0; i < 20; i++)
                {
                    dt.Rows.Add(dataset.Tables[0].Rows[i][0].ToString(), dataset.Tables[0].Rows[i][1].ToString(), dataset.Tables[0].Rows[i][2].ToString(), dataset.Tables[0].Rows[i][3].ToString(), dataset.Tables[0].Rows[i][4].ToString(), dataset.Tables[0].Rows[i][5].ToString(), dataset.Tables[0].Rows[i][6].ToString(), dataset.Tables[0].Rows[i][7].ToString(), dataset.Tables[0].Rows[i][8].ToString(), dataset.Tables[0].Rows[i][9].ToString(), dataset.Tables[0].Rows[i][10].ToString(), dataset.Tables[0].Rows[i][11].ToString(), dataset.Tables[0].Rows[i][12].ToString(), dataset.Tables[0].Rows[i][13].ToString(), dataset.Tables[0].Rows[i][14].ToString(), dataset.Tables[1].Rows[i][0].ToString(), dataset.Tables[1].Rows[i][1].ToString(), dataset.Tables[1].Rows[i][2].ToString());
                }
                dsXml.Tables.Add(dt);
                xmldoc = new XmlDataDocument(dsXml);
                XmlElement xmlelement = xmldoc.DocumentElement;
            }
            return xmldoc;
        }

        [WebMethod(Description = "INSERT VOTER DETAILS (SELECTABLE TYPEABLE)")] //METHOD PREPARED BY SURAJ MANE 
        public string InsertVoterDetails(string VoterDetails)
        {
            try
            {
               // int inserted = 0;
                string[] str = null;
                string ACNO = String.Empty;
                string PARTNO = String.Empty;
                string SRNO = String.Empty;
                string CID = String.Empty;
                string ITEMID = String.Empty;
                string VALUE = String.Empty;
                string IMEI = String.Empty;
                string CreatedDate = String.Empty;
                string CreatedBy = String.Empty;
                string ModifiedDate = string.Empty;
                string ModifiedBy = string.Empty;
                string status = string.Empty;
                string refMoNo = string.Empty;
                string mobId = string.Empty;
                string serId = string.Empty;
                string wardNo = string.Empty;
                string boothNo = string.Empty;
                string name_M = string.Empty;
                string name_E = string.Empty;

                str = VoterDetails.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 18)
                {
                    ACNO = str[i].ToString().Trim();
                    PARTNO = str[i + 1].ToString().Trim();
                    SRNO = str[i + 2].ToString().Trim();
                    CID = str[i + 3].ToString().Trim();
                    ITEMID = str[i + 4].ToString().Trim();
                    VALUE = str[i + 5].ToString().Trim();
                    IMEI = str[i + 6].ToString().Trim();
                    CreatedDate = str[i + 7].ToString().Trim();
                    CreatedBy = str[i + 8].ToString().Trim();
                    ModifiedDate = str[i + 9].ToString().Trim();
                    ModifiedBy = str[i + 10].ToString().Trim();
                    refMoNo = str[i + 11].ToString().Trim();
                    mobId = str[i + 12].ToString().Trim();
                    serId = str[i + 13].ToString().Trim();
                    wardNo = str[i + 14].ToString().Trim();
                    boothNo = str[i + 15].ToString().Trim();
                    name_M = str[i + 16].ToString().Trim();
                    name_E = str[i + 17].ToString().Trim();
                    ds.Clear();

                    string[] uregid = IMEI.Split('$');
                    IMEI = objenc.DecryptInteger(uregid[0], uregid[1]);

                    string[] uregid1 = CreatedBy.Split('$');
                    CreatedBy = objenc.DecryptInteger(uregid1[0], uregid1[1]);

                    //string sql = "SELECT ID FROM [TrueVoterDB].[dbo].[tblVoterDetails] WHERE [ACNO]='" + ACNO + "'AND [PARTNO]='" + PARTNO + "'AND [SRNO]='" + SRNO + "'AND [CID]='" + CID + "'AND [ITEMID]='" + ITEMID + "'AND [VALUE]='" + VALUE + "'";
                    string sql = "SELECT ID FROM [TrueVoterDB].[dbo].[tblVoterDetails] with(NOLOCK) WHERE [ID]='" + serId + "'";
                    ds = commonCode.ExecuteDataset(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string sql1 = "UPDATE [TrueVoterDB].[dbo].[tblVoterDetails]  SET [ACNO]='" + ACNO + "',[PARTNO]='" + PARTNO + "',[SRNO]='" + SRNO + "',[CID]='" + CID + "',[ITEMID]='" + ITEMID + "',[VALUE]='" + VALUE + "',[IMEI]='" + IMEI + "',[ModifiedDate]='" + ModifiedDate + "',[ModifiedBy]='" + ModifiedBy + "' ,[RefMobileNo]='" + refMoNo + "' ,[WardNo]='" + wardNo + "',[BoothNo]='" + boothNo + "',[Name_M]=N'" + name_M + "',[Name_E]='" + name_E + "' WHERE [ID]='" + serId + "'";
                        commonCode.ExecuteNonQuery(sql1);
                        status += mobId + "*" + serId + "#";
                    }
                    else
                    {
                        string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVoterDetails]  ([ACNO],[PARTNO],[SRNO],[CID],[ITEMID],[VALUE],[IMEI],[CreatedDate],[CreatedBy],[RefMobileNo],[WardNo],[BoothNo],[Name_M],[Name_E])  VALUES ('" + ACNO + "','" + PARTNO + "','" + SRNO + "','" + CID + "','" + ITEMID + "','" + VALUE + "','" + IMEI + "','" + CreatedDate + "','" + CreatedBy + "','" + refMoNo + "','" + wardNo + "','" + boothNo + "',N'" + name_M + "','" + name_E + "')";
                        commonCode.ExecuteNonQuery(sql2);

                        string sqlMaxId = "SELECT MAX(ID) FROM [TrueVoterDB].[dbo].[tblVoterDetails](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                        status += mobId + "*" + MaxId + "#";
                    }
                }
                if (status.EndsWith("*"))
                {
                    status = status.Remove(status.Length - 1);
                }
                return status;
            }
            catch (Exception)
            {
                return "0";
            }
        }

        [WebMethod(Description = "INSERT VOTER TIME DETAILS")]
        public string InsertVoterTimeDetails(string VotetimeDetails)
        {
            try
            {
               // int inserted = 0;
                string[] str = null;
                string RECORDTYPE = String.Empty;
                string MALE = String.Empty;
                string FEMALE = String.Empty;
                string OTHER = String.Empty;
                string WARDNO = String.Empty;
                string BOOTHNO = String.Empty;
                string DISTID = String.Empty;
                string TALUKAID = String.Empty;
                string LOCALBODYID = String.Empty;
                string LOCALBODY = String.Empty;
                string IMEI = String.Empty;
                string TIME = String.Empty;

                string CreatedBy = String.Empty;
                string ModifiedDate = string.Empty;
                string ModifiedBy = string.Empty;
                string status = string.Empty;

                string totalVoters = string.Empty;
                string percentage = string.Empty;
                string idMob = string.Empty;
                string sevIDMob = string.Empty;

                str = VotetimeDetails.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 17)
                {
                    RECORDTYPE = str[i].ToString().Trim();
                    MALE = str[i + 1].ToString().Trim();
                    FEMALE = str[i + 2].ToString().Trim();
                    OTHER = str[i + 3].ToString().Trim();
                    WARDNO = str[i + 4].ToString().Trim();
                    BOOTHNO = str[i + 5].ToString().Trim();
                    DISTID = str[i + 6].ToString().Trim();
                    TALUKAID = str[i + 7].ToString().Trim();
                    LOCALBODYID = str[i + 8].ToString().Trim();
                    LOCALBODY = str[i + 9].ToString().Trim();
                    IMEI = str[i + 10].ToString().Trim();
                    TIME = str[i + 11].ToString().Trim();

                    CreatedBy = str[i + 12].ToString().Trim(); //added 22-11-2016
                    totalVoters = str[i + 13].ToString().Trim();
                    percentage = str[i + 14].ToString().Trim();
                    idMob = str[i + 15].ToString().Trim();
                    sevIDMob = str[i + 16].ToString().Trim();
                    ds.Clear();

                    string[] uregid = IMEI.Split('$');
                    IMEI = objenc.DecryptInteger(uregid[0], uregid[1]);

                    string[] uregid1 = CreatedBy.Split('$');
                    CreatedBy = objenc.DecryptInteger(uregid1[0], uregid1[1]);

                    if (sevIDMob == "0")
                    {
                        string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVoteTimeDetails]([RECORDTYPE],[MALE],[FEMALE],[OTHER],[WARDNO],[BOOTHNO],[DISTID],[TALUKAID],[LOCALBODYID],[LOCALBODY],[IMEI],[TIME],[Createdby],[CreatedDate],[TotalVoters],[Percentage])  VALUES ('" + RECORDTYPE + "','" + MALE + "','" + FEMALE + "','" + OTHER + "','" + WARDNO + "','" + BOOTHNO + "','" + DISTID + "','" + TALUKAID + "','" + LOCALBODYID + "','" + LOCALBODY + "','" + IMEI + "','" + TIME + "','" + CreatedBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + totalVoters + "','" + percentage + "')";
                        int stus = commonCode.ExecuteNonQuery(sql2);

                        string sql3 = "SELECT MAX(ID) AS MAXID  FROM [TrueVoterDB].[dbo].[tblVoteTimeDetails](NOLOCK)";
                        DataSet dataset1 = commonCode.ExecuteDataset(sql3);

                        status += stus.ToString() + "*" + idMob + "*" + dataset1.Tables[0].Rows[0]["MAXID"].ToString() + "#";
                    }
                    else
                    {
                        string sql1 = "UPDATE [TrueVoterDB].[dbo].[tblVoteTimeDetails] SET [RECORDTYPE]='" + RECORDTYPE + "',[MALE]='" + MALE + "',[FEMALE]='" + FEMALE + "',[OTHER]='" + OTHER + "', [WARDNO]='" + WARDNO + "', [BOOTHNO]='" + BOOTHNO + "', [DISTID]='" + DISTID + "' , [TALUKAID]='" + TALUKAID + "' , [LOCALBODYID]='" + LOCALBODYID + "' , [LOCALBODY]='" + LOCALBODY + "' , [IMEI]='" + IMEI + "', [TIME]='" + TIME + "',[Updatedby]='" + CreatedBy + "',[UpdatedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',[TotalVoters]='" + totalVoters + "',[Percentage]='" + percentage + "' WHERE [ID]='" + sevIDMob + "'";
                        int stus = commonCode.ExecuteNonQuery(sql1);
                        status += stus.ToString() + "*" + idMob + "*" + sevIDMob + "#";
                    }
                    #region Comment

                    //string sql = "SELECT ID FROM [TrueVoterDB].[dbo].[tblVoteTimeDetails] WHERE [RECORDTYPE]='" + RECORDTYPE + "' AND [WARDNO]='" + WARDNO + "' AND [BOOTHNO]='" + BOOTHNO + "' AND [DISTID]='" + DISTID + "' AND [TALUKAID]='" + TALUKAID + "' AND [LOCALBODYID]='" + LOCALBODYID + "' AND [LOCALBODY]='" + LOCALBODY + "' AND [TIME]='" + TIME + "' AND [Createdby]='" + CreatedBy + "'";
                    //ds = commonCode.ExecuteDataset(sql);
                    ////cmd = new SqlCommand(sql, con);
                    ////if (cmd.Connection.State == ConnectionState.Closed)
                    ////    cmd.Connection.Open();
                    ////da.SelectCommand = cmd;
                    ////da.Fill(ds);
                    ////cmd.Connection.Close();
                    //// string ServerId = ds.Tables[0].Rows[0]["ID"].ToString();
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    string sql1 = "UPDATE [TrueVoterDB].[dbo].[tblVoteTimeDetails] SET [RECORDTYPE]='" + RECORDTYPE + "',[MALE]='" + MALE + "',[FEMALE]='" + FEMALE + "',[OTHER]='" + OTHER + "', [WARDNO]='" + WARDNO + "', [BOOTHNO]='" + BOOTHNO + "', [DISTID]='" + DISTID + "' , [TALUKAID]='" + TALUKAID + "' , [LOCALBODYID]='" + LOCALBODYID + "' , [LOCALBODY]='" + LOCALBODY + "' , [IMEI]='" + IMEI + "', [TIME]='" + TIME + "',[Updatedby]='" + CreatedBy + "',[UpdatedDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [ID]='" + ds.Tables[0].Rows[0]["ID"] + "'";
                    //    //cmd = new SqlCommand(sql1, con);
                    //    //if (cmd.Connection.State == ConnectionState.Closed)
                    //    //    cmd.Connection.Open();
                    //    //inserted = cmd.ExecuteNonQuery();
                    //    //cmd.Connection.Close();
                    //    int flag = commonCode.ExecuteNonQuery(sql1);
                    //    status += flag + "*";
                    //}
                    //else
                    //{
                    //    //string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVoteTimeDetails]([RECORDTYPE],[MALE],[FEMALE],[OTHER],[WARDNO],[BOOTHNO],[DISTID],[TALUKAID],[LOCALBODYID],[LOCALBODY],[IMEI],[TIME],[Createdby],[CreatedDate])  VALUES ('" + RECORDTYPE + "','" + MALE + "','" + FEMALE + "','" + OTHER + "','" + WARDNO + "','" + BOOTHNO + "','" + DISTID + "','" + TALUKAID + "','" + LOCALBODYID + "','" + LOCALBODY + "','" + IMEI + "','" + TIME + "','" + CreatedBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    //    //cmd = new SqlCommand(sql2, con);
                    //    //if (cmd.Connection.State == ConnectionState.Closed)
                    //    //    cmd.Connection.Open();
                    //    //inserted = cmd.ExecuteNonQuery();
                    //    //cmd.Connection.Close();
                    //    //status += inserted.ToString() + "*";
                    //}
                    //}
                    //if (status.EndsWith("*"))
                    //{
                    //    status = status.Remove(status.Length - 1);
                    //}
                    #endregion
                }
                return status;
            }
            catch (Exception)
            {
                return "0";
            }
        }

        [WebMethod(Description = "WEB METHOD FOR INSERT ADD REFFERENCE")]
        public string AddRefferances(string addRefferencesData)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                int count;
                string sqlQuery = string.Empty;
                string userMobile1 = string.Empty;
                string refMobile1 = string.Empty;
                string userMobile = string.Empty;
                string refMobile = string.Empty;
                string imeiNumber = string.Empty;
                string MaxId = string.Empty;

                string voterName = string.Empty;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(addRefferencesData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobile1 = ds.Tables[0].Rows[i]["UserMobileNumber"].ToString();
                        refMobile1 = ds.Tables[0].Rows[i]["MobileNumber"].ToString();
                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();

                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "REPRESENTATIVE" || ds.Tables[0].Rows[i]["Type"].ToString() == "JUNIOR")
                        {
                            userMobile = refMobile1;
                            refMobile = userMobile1;
                            voterName = ds.Tables[0].Rows[i]["ReferralName"].ToString();
                            sqlQuery = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile] = '" + userMobile + "' AND [keyword] IN ('REPRESENTATIVE','JUNIOR')";
                        }
                        else
                        {
                            userMobile = userMobile1;
                            refMobile = refMobile1;
                            string sqlusemobie = "SELECT [MobileNo],[Name]+' '+[LName] AS FullName FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [RegId] = '" + userMobile + "' ";
                            DataSet dsusemobie = commonCode.ExecuteDataset(userMobile);
                            userMobile = dsusemobie.Tables[0].Rows[0]["MobileNo"].ToString();
                            voterName = dsusemobie.Tables[0].Rows[0]["FullName"].ToString();

                            sqlQuery = "SELECT * FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile] = '" + userMobile + "' AND [RefMobile]='" + refMobile + "' AND [keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "'";
                        }

                        cmd = new SqlCommand(sqlQuery, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds1);

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[i]["Type"].ToString() == "REPRESENTATIVE" || ds.Tables[0].Rows[i]["Type"].ToString() == "JUNIOR")
                            {
                                sqlQuery = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [UserMobile]='" + userMobile + "',[RefMobile]='" + refMobile + "',[IMEINumber]='" + imeiNumber + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "', [RefName]=N'" + voterName + "',[keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "',[isActive] = 'Active' WHERE [UserMobile]='" + userMobile + "' AND [keyword] IN ('REPRESENTATIVE','JUNIOR')"; //AND [RefMobile]='" + refMobile + "' AND [keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "'";
                            }
                            else
                            {
                                sqlQuery = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [UserMobile]='" + userMobile + "',[RefMobile]='" + refMobile + "',[IMEINumber]='" + imeiNumber + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "', [RefName]=N'" + voterName + "',[keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "',[isActive] = 'Active' WHERE [UserMobile]='" + userMobile + "' AND [RefMobile]='" + refMobile + "' AND [keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "'";
                            }
                            commonCode.ExecuteNonQuery(sqlQuery);

                            MaxId = ds1.Tables[0].Rows[0]["PK_Id"].ToString();
                            returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";
                        }
                        else
                        {
                            sqlQuery = "INSERT INTO [TrueVoterDB].[dbo].[tblAddRefferances] ([UserMobile],[RefMobile],[IMEINumber],[InsertDate],[keyword],[RefName],[isActive])" +
                                       " VALUES ('" + userMobile + "','" + refMobile + "','" + imeiNumber + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ds.Tables[0].Rows[i]["Type"].ToString() + "',N'" + voterName + "','Active')";

                            commonCode.ExecuteNonQuery(sqlQuery);

                            string sqlMaxId = "SELECT MAX(PK_Id) FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK)";
                            MaxId = commonCode.ExecuteScalar(sqlMaxId);
                            returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";

                            #region MESSAGE SENT TO JUNIOR MOBILE NUMBER

                            ////New Work Done by Jitendra Patil From Home Dated On 26.10.2016
                            if (ds.Tables[0].Rows[i]["Type"].ToString() == "JUNIOR" || ds.Tables[0].Rows[i]["Type"].ToString() == "REPRESENTATIVE")
                            {
                                string msgValue = string.Empty;
                                string sqlVal = "SELECT [Name],[UserName],[UserType] AS RoleId FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + refMobile + "'";
                                DataSet dsVal = commonCode.ExecuteDataset(sqlVal);
                                if (dsVal.Tables[0].Rows.Count > 0)
                                {
                                    if (dsVal.Tables[0].Rows[0]["RoleId"].ToString() == "3")
                                    {
                                        string sqlcandidateRole = "SELECT [CandidateRoleName] FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg](NOLOCK) WHERE [usrMobileNumber] = '" + userMobile + "'";
                                        DataSet dscandidateRole = commonCode.ExecuteDataset(sqlcandidateRole);

                                        string candidateRole = string.Empty;
                                        if (dscandidateRole.Tables[1].Rows.Count > 0)
                                        {
                                            candidateRole = dscandidateRole.Tables[1].Rows[0]["CandidateRoleName"].ToString();
                                        }
                                        else
                                        {
                                            candidateRole = "Representative";
                                        }

                                        msgValue = "Dear " + ds.Tables[0].Rows[i]["ReferralName"].ToString() + " you are added under me " + dsVal.Tables[0].Rows[0]["Name"].ToString() + " " + dsVal.Tables[0].Rows[0]["UserName"].ToString() + " Pl download and install TRUE " +
                                                   "VOTER app using my reference no as a " + candidateRole + " for election reporting";

                                        //New Work by Jitendra Patil Dated On 07.11.2016 for IsApproved When Senior Add Junior
                                        string sqlJunior = "SELECT * FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + userMobile + "' AND [RefMobileNo] = '" + refMobile + "'";
                                        sqlJunior += " SELECT * FROM [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter](NOLOCK) WHERE [MobileNo] = '" + userMobile + "' AND [RefMobileNo] = '" + refMobile + "' AND [OTP] = '0'";
                                        DataSet dsJunior = commonCode.ExecuteDataset(sqlJunior);
                                        if (dsJunior.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsJunior.Tables[1].Rows.Count > 0)
                                            {
                                                string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + userMobile + "'";
                                                commonCode.ExecuteNonQuery(sqlIsppUpdate);
                                            }
                                        }
                                    }

                                    else if (dsVal.Tables[0].Rows[0]["RoleId"].ToString() == "2")
                                    {
                                        string sqlofficerRole = "SELECT [DesignationName] FROM [TrueVoterDB].[dbo].[tblNewDataRegExtra](NOLOCK) WHERE [usrMobileNumber] = '" + userMobile + "'";
                                        DataSet dsofficerRole = commonCode.ExecuteDataset(sqlofficerRole);

                                        string officerRole = string.Empty;
                                        if (dsofficerRole.Tables[0].Rows.Count > 0)
                                        {
                                            officerRole = dsofficerRole.Tables[0].Rows[0]["DesignationName"].ToString();
                                        }
                                        else
                                        {
                                            officerRole = "Officer";
                                        }

                                        msgValue = "Dear " + ds.Tables[0].Rows[i]["ReferralName"].ToString() + " you are added under me " + dsVal.Tables[0].Rows[0]["Name"].ToString() + " " + dsVal.Tables[0].Rows[0]["UserName"].ToString() + " Pl download and install TRUE " +
                                                   "VOTER app using my reference no as a " + officerRole + " for election reporting";

                                        //New Work by Jitendra Patil Dated On 07.11.2016 for IsApproved When Senior Add Junior
                                        string sqlJunior = "SELECT * FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + userMobile + "' AND [RefMobileNo] = '" + refMobile + "'";
                                        sqlJunior += " SELECT * FROM [TrueVoterDB].[dbo].[AllAppRegOTPForTrueVoter](NOLOCK) WHERE [MobileNo] = '" + userMobile + "' AND [RefMobileNo] = '" + refMobile + "' AND [OTP] = '0'";
                                        DataSet dsJunior = commonCode.ExecuteDataset(sqlJunior);
                                        if (dsJunior.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsJunior.Tables[1].Rows.Count > 0)
                                            {
                                                string sqlIsppUpdate = "UPDATE [TrueVoterDB].[dbo].[Logins] SET [IsApproved] = 1 WHERE [UserName] = '" + userMobile + "'";
                                                commonCode.ExecuteNonQuery(sqlIsppUpdate);
                                            }
                                        }
                                    }

                                    commonCode.SMS(userMobile, msgValue);
                                }
                            }

                            #endregion
                        }
                    }
                    return returnString;
                }

                else
                {
                    returnString = "0";
                    return returnString;
                }
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }

        [WebMethod(Description = "METHOD TO DOWNLOAD MY FAVOURITE REFFRANCES")]
        public string DownloadRefferances(string refMobileNumber, string maxServerId)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string userMobile = string.Empty;
            string serverId = string.Empty;
            string retrunString = string.Empty;

            try
            {
                string[] uregid = refMobileNumber.Split('$');
                refMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                string sqlQuery = "SELECT [Name] AS FirstName,[LName] AS LastName,[UserMobile],[PK_Id] AS ServerId FROM [TrueVoterDB].[dbo].[Logins] AS T1 INNER JOIN [TrueVoterDB].[dbo].[tblAddRefferances] AS T2 " +
                                  "ON T1.[MobileNo]=T2.[UserMobile] WHERE [RefMobile] = '" + refMobileNumber + "' AND [PK_Id] > " + maxServerId + "";
                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        firstName = ds.Tables[0].Rows[i][0].ToString();
                        lastName = ds.Tables[0].Rows[i][1].ToString();
                        userMobile = ds.Tables[0].Rows[i][2].ToString();
                        serverId = ds.Tables[0].Rows[i][3].ToString();

                        retrunString += firstName + "*" + lastName + "*" + userMobile + "*" + serverId + "*" + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        [WebMethod(Description = "METHOD TO SEND GCM MESSAGES TO ALL FAVOURITE USERS OF CANDIDATE")]
        public string SendGCMMessages(string userMobileNumber, string message)
        {
            string retrunString = string.Empty;
            try
            {
                string[] uregid = userMobileNumber.Split('$');
                userMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                string sqlQuery = "SELECT [Regid] FROM [TrueVoterDB].[dbo].[GCMRegistrations](NOLOCK) WHERE [MobileNo] IN (SELECT DISTINCT [UserMobile] FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [RefMobile] = '" + userMobileNumber + "')";

                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);

                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    List<string> list = ds.Tables[0].AsEnumerable().Select(r => r.Field<string>("Regid")).ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonCode.MulitipleSenders(list, message);
                    }
                    retrunString = "1";
                }
                else
                {
                    retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        [WebMethod(Description = "NEW TRUE VOTER EXTRA DATA INSERT FOR CANDIDATE")] // ADD NEW METHOD 20.10.2016
        public int InsertExtraRegDataCandidate(string usrMobileNumber, string candiRole, string roleName, string districtID, string localBodyType, string localBodyName, string wardNo, string localBodyId, string assemblyId)
        {
            string sqlQuery = string.Empty;
            try
            {
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                sqlQuery = " SELECT * FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg](NOLOCK) WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";
                ds = commonCode.ExecuteDataset(sqlQuery);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string sqlName = "SELECT [Name] +' '+[LName] AS NAME FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + usrMobileNumber + "' ";
                    DataSet dsName = commonCode.ExecuteDataset(sqlName);

                    sqlQuery = "UPDATE [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] SET [usrMobileNumber]='" + usrMobileNumber + "',[CandidateRole]='" + candiRole + "',[CandidateRoleName]='" + roleName + "',[CandidateDistrictID]='" + districtID + "',[LocalBodyType]='" + localBodyType + "',[LocalBodyName]='" + localBodyName + "',[WardNo]='" + wardNo + "' " +
                               ",[LocalBodyID]='" + localBodyId + "',[AssemblyID]='" + assemblyId + "',[usrFullName]=N'" + dsName.Tables[0].Rows[0]["NAME"].ToString() + "'  WHERE [usrMobileNumber] = '" + usrMobileNumber + "'";

                    commonCode.ExecuteNonQuery(sqlQuery);
                }
                else
                {
                    string sqlName = "SELECT [Name] +' '+[LName] AS NAME FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + usrMobileNumber + "' ";
                    DataSet dsName = commonCode.ExecuteDataset(sqlName);

                    sqlQuery = "INSERT INTO [TrueVoterDB].[dbo].[tblNewDataCandi_Reg] ([usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo] " +
                               ",[LocalBodyID],[AssemblyID],[usrFullName]) VALUES ('" + usrMobileNumber + "','" + candiRole + "','" + roleName + "','" + districtID + "','" + localBodyType + "','" + localBodyName + "','" + wardNo + "','" + localBodyId + "','" + assemblyId + "',N'" + dsName.Tables[0].Rows[0]["NAME"].ToString() + "') ";

                    commonCode.ExecuteNonQuery(sqlQuery);
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD CANDIDATE EXTRA INFORMATION")] // ADD NEW METHOD 21.10.2016
        public string DownloadExtraDetails(string distID, string localBodyTypeID, string localBodyID, string cRole, string wardNo)
        {
            string id = string.Empty;
            string usrMobileNo = string.Empty;
            string candidateRole = string.Empty;
            string candidateRoleName = string.Empty;
            string candidateDistrictID = string.Empty;
            string localBodyType = string.Empty;
            string LocalBodyName = string.Empty;
            string Ward = string.Empty;
            string LocalBodyID = string.Empty;
            string AssemblyID = string.Empty;
            string usrName = string.Empty;
            string sqlQuery = string.Empty;
            string retrunString = string.Empty;

            try
            {
                if (cRole == "1")
                {
                    sqlQuery = "SELECT [CId],[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID],[usrFullName] " +
                               "FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg](NOLOCK) WHERE [CandidateDistrictID] = '" + distID + "' AND [LocalBodyType] = '" + localBodyTypeID + "' AND [LocalBodyID] = '" + localBodyID + "' AND [CandidateRole] = 1";
                }
                else
                {
                    sqlQuery = "SELECT [CId],[usrMobileNumber],[CandidateRole],[CandidateRoleName],[CandidateDistrictID],[LocalBodyType],[LocalBodyName],[WardNo],[LocalBodyID],[AssemblyID],[usrFullName] " +
                               "FROM [TrueVoterDB].[dbo].[tblNewDataCandi_Reg](NOLOCK) WHERE [CandidateDistrictID] = '" + distID + "' AND [LocalBodyType] = '" + localBodyTypeID + "' AND [LocalBodyID] = '" + localBodyID + "' AND [WardNo] = '" + wardNo + "' AND [CandidateRole] = 2 ";
                }

                ds = commonCode.ExecuteDataset(sqlQuery);

                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i][0].ToString();
                        usrMobileNo = ds.Tables[0].Rows[i][1].ToString();
                        candidateRole = cRole.ToString();
                        candidateRoleName = ds.Tables[0].Rows[i][3].ToString();
                        candidateDistrictID = ds.Tables[0].Rows[i][4].ToString();
                        localBodyType = ds.Tables[0].Rows[i][5].ToString();
                        LocalBodyName = ds.Tables[0].Rows[i][6].ToString();
                        Ward = ds.Tables[0].Rows[i][7].ToString();
                        LocalBodyID = ds.Tables[0].Rows[i][8].ToString();
                        AssemblyID = ds.Tables[0].Rows[i][9].ToString();

                        usrName = ds.Tables[0].Rows[i][10].ToString();
                        if (usrName == "" || usrName == null)
                        {
                            usrName = "Name Not Available";
                        }
                        else
                        {
                            usrName = ds.Tables[0].Rows[i][10].ToString();
                        }
                        retrunString += id + "*" + usrMobileNo + "*" + candidateRole + "*" + candidateRoleName + "*" + candidateDistrictID + "*" + localBodyType + "*" + LocalBodyName + "*" + Ward + "*" + LocalBodyID + "*" + AssemblyID + "*" + usrName + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        [WebMethod(Description = "METHOD TO DOWNLOAD MY REFRENCE")] // ADD NEW METHOD 21.10.2016
        public string DownloadRefferancesNew(string usrMobileNumber, string keyword)
        {
            string sqlQuery = string.Empty;
            string refName = string.Empty;
            string refMobileNo = string.Empty;
            string retrunString = string.Empty;
            string isActive = string.Empty;
            string pkID = string.Empty;
            try
            {
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                if (keyword == "REPRESENTATIVE")
                {
                    sqlQuery = "SELECT [UserMobile],[RefName],[PK_Id],[isActive] FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [RefMobile]='" + usrMobileNumber + "' AND [keyword]='" + keyword + "'";
                }
                else if (keyword == "JUNIOR")
                {
                    sqlQuery = "SELECT [UserMobile],[RefName],[PK_Id],[isActive] FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [RefMobile]='" + usrMobileNumber + "' AND [keyword]='" + keyword + "'";
                }
                else if (keyword == "REFFERENSE")
                {
                    sqlQuery = "SELECT [RefMobile],[RefName],[PK_Id],[isActive] FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [RefMobile]='" + usrMobileNumber + "' AND [keyword]='" + keyword + "'";
                }

                cmd = new SqlCommand(sqlQuery, con);
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        refMobileNo = ds.Tables[0].Rows[i][0].ToString();
                        refName = ds.Tables[0].Rows[i][1].ToString();
                        pkID = ds.Tables[0].Rows[i][2].ToString();
                        isActive = ds.Tables[0].Rows[i][3].ToString();
                        retrunString += refMobileNo + "*" + refName + "*" + pkID + "*" + isActive + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        [WebMethod(Description = "WEB METHOD FOR UPDATE REFRENCE STATUS")]  // ADD NEW METHOD 26.10.2016
        public string InsertUpdateStatus(string statusUpdateData)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                string serverId = string.Empty;
                string active = string.Empty;
                string curdt = System.DateTime.Now.ToString("yyyy-MM-dd");
                XmlReader reader = XmlReader.Create(new StringReader(statusUpdateData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        serverId = ds.Tables[0].Rows[i]["ServerId"].ToString();
                        active = ds.Tables[0].Rows[i]["Active"].ToString();

                        string q1 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive] = '" + active + "',[ModifyDate]='" + curdt + "' WHERE [PK_Id]='" + serverId + "'";

                        int j = commonCode.ExecuteNonQuery(q1);
                        if (j > 0)
                        {
                            returnString += serverId + "*";
                        }
                    }
                    return returnString;
                }

                else
                {
                    returnString = "0";
                    return returnString;
                }
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }


        /*Created by Ram For KYC WEB METHOD*/

        #region METHOD TO DOWNLOAD CANDIDATE LIST DETAILS RAM KENDRE

        //[WebMethod(Description = "Candidate list details")]
        //public XmlDataDocument DownloadWardWiseCandidateData(string districtid, string localbodynameid, string wardid)
        //{
        //    XmlDataDocument xmlData = new XmlDataDocument();
        //    DataSet DS = new DataSet();
        //    DataSet DS1 = new DataSet();
        //    DataTable dt = new DataTable();
        //    string SqlQry = string.Empty;
        //    string nominationID = string.Empty;
        //    string firstName = string.Empty;
        //    string middleName = string.Empty;
        //    string lastName = string.Empty;
        //    string symbolID = string.Empty;
        //    string symbolName = string.Empty;
        //    string nameOfParty = string.Empty;
        //    string sId = string.Empty;
        //    try
        //    {
        //        string sql = "Select  N.[NominationID],N.[FirstName],N.[MiddleName],N.[LastName],S.[SymbolID],S.[SymbolName],S.[NameOfParty] from [SEC].[dbo].[NominationMunicipalCouncil_Reg] AS N LEFT JOIN [SEC].[dbo].[Symbol_MasterNew] AS S ON N.[Symbols_ID]=S.[PPID]  where [ElectionID]='" + localbodynameid + "' and [WardID]='" + wardid + "'";
        //        cmd = new SqlCommand(sql, conKYC);
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(DS);

        //        dt.Columns.Add(new DataColumn("NominationID", typeof(string)));
        //        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("MiddleName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("SymbolID", typeof(string)));
        //        dt.Columns.Add(new DataColumn("SymbolName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("NameOfParty", typeof(string)));

        //        int Dscnt = DS.Tables[0].Rows.Count;

        //        for (int i = 0; i < Dscnt; i++)
        //        {
        //            nominationID = DS.Tables[0].Rows[i]["NominationID"].ToString();
        //            firstName = DS.Tables[0].Rows[i]["FirstName"].ToString();
        //            middleName = DS.Tables[0].Rows[i]["MiddleName"].ToString();
        //            lastName = DS.Tables[0].Rows[i]["LastName"].ToString();

        //            string sybID = DS.Tables[0].Rows[i]["SymbolID"].ToString();
        //            string symNm = DS.Tables[0].Rows[i]["SymbolName"].ToString();
        //            string nmprty = DS.Tables[0].Rows[i]["NameOfParty"].ToString();

        //            if (sybID == "" || sybID == "NULL")
        //            {
        //                symbolID = "NULL";
        //            }
        //            else
        //            {
        //                symbolID = DS.Tables[0].Rows[i]["SymbolID"].ToString();
        //            }

        //            if (symNm == "" || symNm == "NULL")
        //            {
        //                symbolName = "NULL";
        //            }
        //            else
        //            {
        //                symbolName = DS.Tables[0].Rows[i]["SymbolName"].ToString();
        //            }


        //            if (nmprty == "" || nmprty == "NULL")
        //            {
        //                nameOfParty = "NULL";
        //            }
        //            else
        //            {
        //                nameOfParty = DS.Tables[0].Rows[i]["NameOfParty"].ToString();
        //            }
        //            dt.Rows.Add(nominationID, firstName, middleName, lastName, symbolID, symbolName, nameOfParty);  // DS.Tables[0].Rows[i]["SymbolID"].ToString(), DS.Tables[0].Rows[i]["SymbolName"].ToString(), DS.Tables[0].Rows[i]["NameOfParty"].ToString());   //, DS.Tables[0].Rows[i]["Symbol_Image"].ToString());
        //        }
        //        DS1.Tables.Add(dt);
        //        DS1.Tables[0].TableName = "Table";

        //        xmlData = new XmlDataDocument(DS1);
        //        XmlElement xmlEle = xmlData.DocumentElement;
        //    }
        //    catch
        //    {
        //        dt.Columns.Add(new DataColumn("Error", typeof(string)));
        //        DataRow dr = dt.NewRow();
        //        dr["Error"] = "105";
        //        dt.Rows.Add(dr);
        //        DS1.Tables.Add(dt);
        //        xmlData = new XmlDataDocument(DS1);
        //        XmlElement xmlelement = xmlData.DocumentElement;
        //    }
        //    return xmlData;
        //}
        #endregion

        #region METHOD TO DOWNLOAD CANDIDATE PERSONAL INFORMATION DETAILS BY RAM KENDRE

        //[WebMethod(Description = "Candidate Personal Information details")]
        //public XmlDataDocument DownloadCandidateDetails(string NId)
        //{
        //    XmlDataDocument xmlData = new XmlDataDocument();
        //    DataSet DS = new DataSet();
        //    DataSet DS1 = new DataSet();
        //    DataSet DS2 = new DataSet();
        //    DataSet DS3 = new DataSet();
        //    DataSet DS4 = new DataSet();
        //    DataSet DS5 = new DataSet();
        //    DataTable dt = new DataTable();
        //    XmlElement xmlEle;
        //    string SqlQry = string.Empty;
        //    string sId = string.Empty;
        //    Int32 AffID = 0, S1, S2, S3, S4, S5, S6, S7;
        //    string incomeAmount = string.Empty;
        //    string spouseOccupationName = string.Empty;
        //    string qualification = string.Empty;
        //    string candidateEmail = string.Empty;
        //    string candidateMob = string.Empty;
        //    string occupationName = string.Empty;
        //    string Address = string.Empty;

        //    string Sql = string.Empty;
        //    try
        //    {
        //        Sql = "select [NominationId] from [SEC].[dbo].[tblCandidateInfo] where [NominationId]=' " + NId + " '";
        //        cmd = new SqlCommand(Sql, conKYC);
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(DS5);
        //        if (DS5.Tables[0].Rows.Count > 0)
        //        {
        //            Sql = "select [CandidateEmail],[CandidateMob],[OccupationName],[Qualification],[CasesTaken],[CasesAcquitted],[CasesConvicted],[TotalCases]," +
        //                 "[ImmovableProperty],[MovableProperty],[SpouseOccupationName],[TotalAssets],[TotalIncome],[NominationId] FROM [SEC].[dbo].[tblCandidateInfo] where [NominationId]=' " + NId + " '";
        //            cmd = new SqlCommand(Sql, conKYC);
        //            da = new SqlDataAdapter(cmd);
        //            da.Fill(DS4);
        //            xmlData = new XmlDataDocument(DS4);
        //            xmlEle = xmlData.DocumentElement;
        //        }
        //        else
        //        {
        //            string sql3 = "SELECT [AffID] FROM [SEC].[dbo].[Aff_CandidateDetails] WHERE NominationId = " + NId + "";
        //            cmd = new SqlCommand(sql3, conKYC);
        //            da = new SqlDataAdapter(cmd);
        //            da.Fill(DS3);
        //            if (DS3.Tables[0].Rows.Count > 0)
        //            {
        //                AffID = Convert.ToInt32(DS3.Tables[0].Rows[0]["AffID"]);
        //            }

        //            string sql = "SELECT NMCR.[CandidateEmail],NMCR.[CandidateMob],NMCR.[Occuption],OM.[OccupationName]" +
        //                         "FROM [SEC].[dbo].[NominationMunicipalCouncil_Reg] AS NMCR INNER JOIN [SEC].[dbo].[mstOccupation] AS OM ON NMCR.[Occuption]=OM.[OccupationCode] " +
        //                         " WHERE NMCR.NominationId = " + NId + " AND OM.[LangID] = 1";
        //            cmd = new SqlCommand(sql, conKYC);
        //            da = new SqlDataAdapter(cmd);
        //            da.Fill(DS);
        //            if (DS.Tables[0].Rows.Count > 0)
        //            {
        //                candidateEmail = DS.Tables[0].Rows[0]["CandidateEmail"].ToString();
        //                candidateMob = DS.Tables[0].Rows[0]["CandidateMob"].ToString();
        //                occupationName = DS.Tables[0].Rows[0]["OccupationName"].ToString();
        //            }
        //            else
        //            {
        //                candidateEmail = "NA";
        //                candidateMob = "NA";
        //                occupationName = "NA";
        //            }

        //            string sql1 = "SELECT SUM(CONVERT(bigint,[CurrentMarketValue])) AS SUM1 FROM [SEC].[dbo].[Aff_ImmovablePropertyDetails] WHERE [AffID] = '" + AffID + "'" +
        //                          "SELECT SUM(CONVERT(bigint,[FDAmount])) AS SUM2 FROM [SEC].[dbo].[Aff_Fixeddeposit] WHERE [AffID] = '" + AffID + "'" +
        //                          "SELECT [AffID],[IncomeAmount],[SpouseOccupationName] FROM [SEC].[dbo].[Aff_Income] WHERE [AffID]='" + AffID + "'" +
        //                          "SELECT [Qualification] FROM [SEC].[dbo].[Aff_EducationalDetails] WHERE [AffID]='" + AffID + "'";
        //            cmd = new SqlCommand(sql1, conKYC);
        //            da = new SqlDataAdapter(cmd);
        //            da.Fill(DS1);
        //            if (DS1.Tables[0].Rows.Count > 0)//imoveble
        //            {
        //                S1 = Convert.ToInt32(DS1.Tables[0].Rows[0]["SUM1"]);
        //            }
        //            else
        //            {
        //                S1 = 0;
        //            }
        //            if (DS1.Tables[1].Rows.Count > 0)//moveble
        //            {
        //                S2 = Convert.ToInt32(DS1.Tables[1].Rows[0]["SUM2"]);
        //            }
        //            else
        //            {
        //                S2 = 0;
        //            }

        //            S3 = S1 + S2;//total assets

        //            if (DS1.Tables[2].Rows.Count > 0)
        //            {
        //                incomeAmount = DS1.Tables[2].Rows[0]["IncomeAmount"].ToString();
        //                spouseOccupationName = DS1.Tables[2].Rows[0]["SpouseOccupationName"].ToString();
        //            }
        //            else
        //            {
        //                incomeAmount = "NA";
        //                spouseOccupationName = "NA";
        //            }
        //            if (DS1.Tables[3].Rows.Count > 0)
        //            {
        //                qualification = DS1.Tables[3].Rows[0]["Qualification"].ToString();
        //            }
        //            else
        //            {
        //                qualification = "NA";
        //            }

        //            string sql2 = "select AffCovictedID FROM [SEC].[dbo].[Aff_ConvictedDtls] where AffID='" + AffID + "' AND [StatusAppealConvictedid] !=0" +
        //                            "select AffCovictedID FROM [SEC].[dbo].[Aff_ConvictedDtls] where AffID='" + AffID + "' AND [StatusAppealConvictedid]= 21" +
        //                            "select AffCovictedID FROM [SEC].[dbo].[Aff_ConvictedDtls] where AffID='" + AffID + "' AND [StatusAppealConvictedid]= 22" +
        //                            "select AffCovictedID FROM [SEC].[dbo].[Aff_ConvictedDtls] where AffID='" + AffID + "' AND [StatusAppealConvictedid]= 23";
        //            cmd = new SqlCommand(sql2, conKYC);
        //            da = new SqlDataAdapter(cmd);
        //            da.Fill(DS2);

        //            S4 = Convert.ToInt32(DS2.Tables[0].Rows.Count);  //Total cases
        //            S5 = Convert.ToInt32(DS2.Tables[1].Rows.Count); //Pending Vs Cases Framed
        //            S6 = Convert.ToInt32(DS2.Tables[2].Rows.Count);// Convicated 
        //            S7 = Convert.ToInt32(DS2.Tables[3].Rows.Count); // Acquitted 

        //            string instSql = "INSERT INTO [tblCandidateInfo]([NominationId],[Candidate_FullName],[Address],[Qualification],[TotalIncome],[CandidateMob],[CandidateEmail],[MovableProperty],[ImmovableProperty],[SpouseOccupationName],[TotalAssets],[CasesTaken],[CasesAcquitted],[CasesConvicted],[TotalCases],[OccupationName])" +
        //                            "VALUES ('" + Convert.ToInt32(NId) + "','XYZ','ABZ','" + qualification.ToString() + "','" + Convert.ToString(incomeAmount) + "','" + candidateMob.ToString() + "','" + candidateEmail.ToString() + "','" + (S2).ToString() + "','" + (S1).ToString() + "','" + spouseOccupationName.ToString() + "','" + (S3).ToString() + "','" + S5.ToString() + "','" + S7.ToString() + "','" + S6.ToString() + "','" + (S4).ToString() + "','" + occupationName.ToString() + "')";
        //            conKYC.Open();
        //            cmd = new SqlCommand(instSql, conKYC);
        //            cmd.ExecuteNonQuery();
        //            conKYC.Close();

        //            dt.Columns.Add(new DataColumn("CandidateEmail", typeof(string)));
        //            dt.Columns.Add(new DataColumn("CandidateMob", typeof(string)));
        //            dt.Columns.Add(new DataColumn("OccupationName", typeof(string)));
        //            dt.Columns.Add(new DataColumn("Qualification", typeof(string)));

        //            dt.Columns.Add(new DataColumn("CasesTaken", typeof(string)));
        //            dt.Columns.Add(new DataColumn("CasesAcquitted", typeof(string)));
        //            dt.Columns.Add(new DataColumn("CasesConvicted", typeof(string)));
        //            dt.Columns.Add(new DataColumn("TotalCases", typeof(string)));

        //            dt.Columns.Add(new DataColumn("ImmovableProperty", typeof(string)));
        //            dt.Columns.Add(new DataColumn("MovableProperty", typeof(string)));
        //            dt.Columns.Add(new DataColumn("SpouseOccupationName", typeof(string)));
        //            dt.Columns.Add(new DataColumn("TotalAssets", typeof(string)));

        //            dt.Columns.Add(new DataColumn("TotalIncome", typeof(string)));
        //            dt.Columns.Add(new DataColumn("NID", typeof(string)));

        //            int dscnt = DS.Tables[0].Rows.Count;

        //            for (int i = 0; i < dscnt; i++)
        //            {
        //                dt.Rows.Add(candidateEmail, candidateMob, occupationName, qualification, S5.ToString(), S7.ToString(), S6.ToString(), S4.ToString(), S1.ToString(), S2.ToString(), spouseOccupationName, S3.ToString(), incomeAmount, NId);
        //            }

        //            //ds.Tables.RemoveAt(0);
        //            ds.Tables.Add(dt);
        //            ds.Tables[0].TableName = "Table";

        //            xmlData = new XmlDataDocument(ds);
        //            xmlEle = xmlData.DocumentElement;
        //        }
        //    }
        //    catch
        //    {
        //        dt.Columns.Add(new DataColumn("Error", typeof(string)));
        //        DataRow dr = dt.NewRow();
        //        dr["Error"] = "105";
        //        dt.Rows.Add(dr);
        //        ds.Tables.Add(dt);
        //        xmlData = new XmlDataDocument(ds);
        //        XmlElement xmlelement = xmlData.DocumentElement;
        //    }

        //    return xmlData;
        //}
        #endregion

        /* END OF KYC WORK */

        #region FEEDBACK FOR TRUE VOTER APPLICATION

        [WebMethod(Description = "METHOD TO INSERT FEEDBACK DETAILS BY USERS")]
        public string InsertFeedbackDetails(string feedbackXML)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                string appInsertID = string.Empty;
                string userMobileNumber = string.Empty;
                string imeiNumber = string.Empty;
                string feedbackType = string.Empty;
                string feedbackContent = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string feedbackSubject = string.Empty;
                string candidateRole = string.Empty;

                XmlReader reader = XmlReader.Create(new StringReader(feedbackXML));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobileNumber = ds.Tables[0].Rows[i]["UserMobile"].ToString();
                        string sqlName = "SELECT [Name],[LName] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + userMobileNumber + "'";
                        DataSet dsName = commonCode.ExecuteDataset(sqlName);

                        if (dsName.Tables[0].Rows.Count > 0)
                        {
                            firstName = dsName.Tables[0].Rows[0]["Name"].ToString();
                            lastName = dsName.Tables[0].Rows[0]["LName"].ToString();
                        }
                        else
                        {
                            firstName = "";
                            lastName = "";
                        }

                        appInsertID = ds.Tables[0].Rows[i]["Id"].ToString();

                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        feedbackType = ds.Tables[0].Rows[i]["FeedbackType"].ToString();
                        feedbackSubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                        feedbackContent = ds.Tables[0].Rows[i]["FeedbackContent"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();

                        string sqlInsertFeedback = "INSERT INTO [TrueVoterDB].[dbo].[tblFeedbackDetails] ([FirstName],[LastName],[UserMobileNumber],[ImeiNumber],[FeedbackTypeId],[FeedbackTypeName],[FeedbackSubject],[FeedbackDetails],[EntryDate]) " +
                                                   "VALUES (N'" + firstName + "',N'" + lastName + "','" + userMobileNumber + "','" + imeiNumber + "',N'" + feedbackType + "','0',N'" + feedbackSubject + "',N'" + feedbackContent + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        commonCode.ExecuteNonQuery(sqlInsertFeedback);

                        string sqlMaxId = "SELECT MAX(Id) FROM [TrueVoterDB].[dbo].[tblFeedbackDetails](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);

                        returnString += appInsertID + "*" + MaxId + "#";
                    }

                    return returnString;
                }
                else
                {
                    returnString = "0";
                    return returnString;
                }
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }

        #endregion

        #region VISION BY CANDIDATE FOR TRUE VOTER APPLICATION 08-12-2016 upgread


        [WebMethod(Description = "METHOD TO INSERT VISION DETAILS BY CANDIDATE")]
        public string InsertVisionDetails(string visionXML)
        {
            string returnString = string.Empty;
            try
            {
                string[] candidateRoleNew = { "Select", "Chairman", "WardMember", "Representative", "PartyOfficer" };
                DataSet ds = new DataSet();
                int count;
                string appInsertID = string.Empty;
                string userMobileNumber = string.Empty;
                string imeiNumber = string.Empty;
                string visionType = string.Empty;
                string visionContent = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string visionSubject = string.Empty;
                string candidateRole = string.Empty;
                string mobSevID = string.Empty;

                XmlReader reader = XmlReader.Create(new StringReader(visionXML));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobileNumber = ds.Tables[0].Rows[i]["UserMobile"].ToString();
                        string sqlName = "SELECT [Name],[LName] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + userMobileNumber + "'";
                        DataSet dsName = commonCode.ExecuteDataset(sqlName);

                        if (dsName.Tables[0].Rows.Count > 0)
                        {
                            firstName = dsName.Tables[0].Rows[0]["Name"].ToString();
                            lastName = dsName.Tables[0].Rows[0]["LName"].ToString();
                        }
                        else
                        {
                            firstName = "";
                            lastName = "";
                        }

                        appInsertID = ds.Tables[0].Rows[i]["Id"].ToString();

                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        visionType = ds.Tables[0].Rows[i]["VisionType"].ToString();
                        visionSubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                        visionContent = ds.Tables[0].Rows[i]["VisionContent"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();
                        mobSevID = ds.Tables[0].Rows[i]["ServerID"].ToString();
                        int cVal = Convert.ToInt32(candidateRole);
                        string candidateRoleName = candidateRoleNew[cVal].ToString();

                        if (mobSevID == "0")
                        {
                            string sqlInsertVision = "INSERT INTO [TrueVoterDB].[dbo].[tblVisionDetails] ([FirstName],[LastName],[UserMobileNumber],[ImeiNumber],[VisionTypeId],[VisionTypeName],[VisionSubject],[VisionDetails],[CandidateRole],[CandidateRoleName],[EntryDate]) " +
                                                       "VALUES ('" + firstName + "','" + lastName + "','" + userMobileNumber + "','" + imeiNumber + "',N'" + visionType + "','0',N'" + visionSubject + "',N'" + visionContent + "'," + cVal + ",'" + candidateRoleName + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                            commonCode.ExecuteNonQuery(sqlInsertVision);

                            string sqlMaxId = "SELECT MAX(Id) FROM [TrueVoterDB].[dbo].[tblVisionDetails](NOLOCK)";
                            string MaxId = commonCode.ExecuteScalar(sqlMaxId);

                            returnString += appInsertID + "*" + MaxId + "#";
                        }
                        else
                        {
                            string sqlUpdateVision = "UPDATE [TrueVoterDB].[dbo].[tblVisionDetails] SET [FirstName]='" + firstName + "',[LastName]='" + lastName + "',[UserMobileNumber]='" + userMobileNumber + "',[ImeiNumber]='" + imeiNumber + "',[VisionTypeId]=N'" + visionType + "',[VisionTypeName]='0',[VisionSubject]=N'" + visionSubject + "',[VisionDetails]=N'" + visionContent + "',[CandidateRole]=" + cVal + ",[CandidateRoleName]='" + candidateRoleName + "',[ModifyBy]='" + userMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [Id] ='" + mobSevID + "' ";
                            commonCode.ExecuteNonQuery(sqlUpdateVision);

                            returnString += appInsertID + "*" + mobSevID + "#";
                        }
                    }

                    return returnString;
                }
                else
                {
                    returnString = "0";
                    return returnString;
                }
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }

        #endregion

        #region PROFILE BY CANDIDATE FOR TRUE VOTER APPLICATION

        [WebMethod(Description = "METHOD TO INSERT VISION DETAILS BY CANDIDATE")]
        public string InsertProfileDetails(string profileXML)
        {
            string returnString = string.Empty;
            try
            {
                string[] candidateRoleNew = { "Select", "Chairman", "WardMember", "Representative", "PartyOfficer" };
                DataSet ds = new DataSet();
                int count;
                string appInsertID = string.Empty;
                string userMobileNumber = string.Empty;
                string imeiNumber = string.Empty;
                string profileType = string.Empty;
                string profileContent = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string profileSubject = string.Empty;
                string candidateRole = string.Empty;

                XmlReader reader = XmlReader.Create(new StringReader(profileXML));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobileNumber = ds.Tables[0].Rows[i]["UserMobile"].ToString();
                        string sqlName = "SELECT [Name],[LName] FROM [TrueVoterDB].[dbo].[Logins](NOLOCK) WHERE [UserName] = '" + userMobileNumber + "'";
                        DataSet dsName = commonCode.ExecuteDataset(sqlName);

                        if (dsName.Tables[0].Rows.Count > 0)
                        {
                            firstName = dsName.Tables[0].Rows[0]["Name"].ToString();
                            lastName = dsName.Tables[0].Rows[0]["LName"].ToString();
                        }
                        else
                        {
                            firstName = "";
                            lastName = "";
                        }

                        appInsertID = ds.Tables[0].Rows[i]["Id"].ToString();

                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        profileType = ds.Tables[0].Rows[i]["ProfileType"].ToString();
                        profileSubject = ds.Tables[0].Rows[i]["Subject"].ToString();
                        profileContent = ds.Tables[0].Rows[i]["ProfileContent"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();
                        int cVal = Convert.ToInt32(candidateRole);

                        string candidateRoleName = candidateRoleNew[cVal].ToString();

                        string sqlInsertFeedback = "INSERT INTO [TrueVoterDB].[dbo].[tblProfileDetails] ([FirstName],[LastName],[UserMobileNumber],[ImeiNumber],[ProfileTypeId],[ProfileTypeName],[ProfileSubject],[ProfileDetails],[CandidateRole],[CandidateRoleName],[EntryDate]) " +
                                                   "VALUES ('" + firstName + "','" + lastName + "','" + userMobileNumber + "','" + imeiNumber + "','" + profileType + "','0','" + profileSubject + "','" + profileContent + "'," + cVal + ",'" + candidateRoleName + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        commonCode.ExecuteNonQuery(sqlInsertFeedback);

                        string sqlMaxId = "SELECT MAX(Id) FROM [TrueVoterDB].[dbo].[tblProfileDetails](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);

                        returnString += appInsertID + "*" + MaxId + "#";
                    }

                    return returnString;
                }
                else
                {
                    returnString = "0";
                    return returnString;
                }
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }

        #endregion

        #region WEB METHOD FOR DOWNLOAD PROFILE DETAILS AND VISION DETAILS
        //CREATED BY SURAJ MANE 10-11-2016
        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD PROFILE DETAILS")]
        public string DownloadProfileDetails(string userMobileNo)
        {
            string id = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string userMobileNumber = string.Empty;
            string imeiNumber = string.Empty;
            string profileTypeId = string.Empty;
            string profileSubject = string.Empty;
            string profileDetails = string.Empty;
            string candidateRole = string.Empty;
            string sqlQuery = string.Empty;
            string retrunString = string.Empty;

            try
            {
                sqlQuery = "SELECT [Id],[FirstName],[LastName],[UserMobileNumber],[ImeiNumber],[ProfileTypeId],[ProfileSubject],[ProfileDetails],[CandidateRole] FROM [TrueVoterDB].[dbo].[tblProfileDetails](NOLOCK) WHERE [UserMobileNumber]='" + userMobileNo + "'";

                ds = commonCode.ExecuteDataset(sqlQuery);

                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i][0].ToString();
                        firstName = ds.Tables[0].Rows[i][1].ToString();
                        lastName = ds.Tables[0].Rows[i][2].ToString();
                        userMobileNumber = ds.Tables[0].Rows[i][3].ToString();
                        imeiNumber = ds.Tables[0].Rows[i][4].ToString();
                        profileTypeId = ds.Tables[0].Rows[i][5].ToString();
                        profileSubject = ds.Tables[0].Rows[i][6].ToString();
                        profileDetails = ds.Tables[0].Rows[i][7].ToString();
                        candidateRole = ds.Tables[0].Rows[i][8].ToString();

                        retrunString += id + "*" + firstName + "*" + lastName + "*" + userMobileNumber + "*" + imeiNumber + "*" + profileTypeId + "*" + profileSubject + "*" + profileDetails + "*" + candidateRole + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD VISION DETAILS")]
        public string DownloadVisionDetails(string userMobileNo)
        {
            string id = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string userMobileNumber = string.Empty;
            string imeiNumber = string.Empty;
            string visionTypeId = string.Empty;
            string visionSubject = string.Empty;
            string visionDetails = string.Empty;
            string candidateRole = string.Empty;
            string sqlQuery = string.Empty;
            string retrunString = string.Empty;

            try
            {
                sqlQuery = "SELECT [Id],[FirstName],[LastName],[UserMobileNumber],[ImeiNumber],[VisionTypeId],[VisionSubject],[VisionDetails],[CandidateRole] FROM [TrueVoterDB].[dbo].[tblVisionDetails](NOLOCK) WHERE [UserMobileNumber]='" + userMobileNo + "'";
                ds = commonCode.ExecuteDataset(sqlQuery);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i][0].ToString();
                        firstName = ds.Tables[0].Rows[i][1].ToString();
                        lastName = ds.Tables[0].Rows[i][2].ToString();
                        userMobileNumber = ds.Tables[0].Rows[i][3].ToString();
                        imeiNumber = ds.Tables[0].Rows[i][4].ToString();
                        visionTypeId = ds.Tables[0].Rows[i][5].ToString();
                        visionSubject = ds.Tables[0].Rows[i][6].ToString();
                        visionDetails = ds.Tables[0].Rows[i][7].ToString();
                        candidateRole = ds.Tables[0].Rows[i][8].ToString();

                        retrunString += id + "*" + firstName + "*" + lastName + "*" + userMobileNumber + "*" + imeiNumber + "*" + visionTypeId + "*" + visionSubject + "*" + visionDetails + "*" + candidateRole + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        #endregion

        #region WEB METHOD FOR DOWNLOAD VOTERDETAILS ADDED BY REPRESENTATIVE DATE 18-11-2016 SURAJ MANE
        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD VOTERDETAILS ADDED BY REPRESENTATIVE")]
        public string DownloadVoterDetails(string usrMobileNumber)
        {
            string sqlQuery = string.Empty;

            DataSet DS1 = new DataSet();
            string iD = string.Empty;
            string acNo = string.Empty;
            string partNo = string.Empty;
            string srNo = string.Empty;
            string cid = string.Empty;
            string itemID = string.Empty;
            string value = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;
            string inData = string.Empty;
            string mob = string.Empty;
            string refMobile = string.Empty;

            string wardNo = string.Empty;
            string boothNo = string.Empty;
            string name_M = string.Empty;
            string name_E = string.Empty;
            string imei = string.Empty;
            string modifyDate = string.Empty;
            string modifyBy = string.Empty;


            string retrunString = string.Empty;

            try
            {
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                //sqlQuery = "SELECT [UserMobile],[RefName] FROM [TrueVoterDB].[dbo].[tblAddRefferances] WHERE [RefMobile]='" + usrMobileNumber + "' AND [isActive]='Active'";
                //cmd = new SqlCommand(sqlQuery, con);
                //da.SelectCommand = cmd;
                //da.Fill(DS1);
                //int count1 = DS1.Tables[0].Rows.Count;
                //if (count1 > 0)
                //{
                //    for (int i = 0; i < count1; i++)
                //    {
                //        mob = DS1.Tables[0].Rows[i]["UserMobile"].ToString().Trim();
                //        refName = DS1.Tables[0].Rows[i]["RefName"].ToString().Trim();

                sqlQuery = "SELECT [ID],[ACNO],[PARTNO],[SRNO],[CID],[ITEMID],[VALUE],[CreatedBy],[CreatedDate],[RefMobileNo],[WardNo],[BoothNo],[IMEI],[ModifiedDate],[ModifiedBy],[Name_M],[Name_E] FROM [TrueVoterDB].[dbo].[tblVoterDetails](NOLOCK) WHERE [RefMobileNo] = '" + usrMobileNumber + "'";
                DataSet DS = new DataSet();
                DS = commonCode.ExecuteDataset(sqlQuery);
                //cmd = new SqlCommand(sqlQuery, con);
                //da.SelectCommand = cmd;
                //da.Fill(DS);
                int count = DS.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        iD = DS.Tables[0].Rows[j][0].ToString().Trim();
                        acNo = DS.Tables[0].Rows[j][1].ToString().Trim();
                        partNo = DS.Tables[0].Rows[j][2].ToString().Trim();
                        srNo = DS.Tables[0].Rows[j][3].ToString().Trim();
                        cid = DS.Tables[0].Rows[j][4].ToString().Trim();
                        itemID = DS.Tables[0].Rows[j][5].ToString().Trim();
                        value = DS.Tables[0].Rows[j][6].ToString().Trim();
                        createdBy = DS.Tables[0].Rows[j][7].ToString().Trim();
                        createdDate = DS.Tables[0].Rows[j][8].ToString().Trim();
                        refMobile = DS.Tables[0].Rows[j][9].ToString().Trim();
                        wardNo = DS.Tables[0].Rows[j][10].ToString().Trim();
                        boothNo = DS.Tables[0].Rows[j][11].ToString().Trim();
                        imei = DS.Tables[0].Rows[j][12].ToString().Trim();
                        modifyDate = DS.Tables[0].Rows[j][13].ToString().Trim();
                        modifyBy = DS.Tables[0].Rows[j][14].ToString().Trim();
                        name_M = DS.Tables[0].Rows[j][15].ToString().Trim();
                        name_E = DS.Tables[0].Rows[j][16].ToString().Trim();

                        retrunString += iD + "*" + acNo + "*" + partNo + "*" + srNo + "*" + cid + "*" + itemID + "*" + value + "*" + createdBy + "*" + refMobile + "*" + createdDate + "*" + wardNo + "*" + boothNo + "*" + imei + "*" + modifyDate + "*" + modifyBy + "*" + name_M + "*" + name_E + "#";
                    }
                }
                //    }
                //}
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }
        #endregion


        //#region NEW Work FOR KYC DATA 24-11-2016
        //[WebMethod(Description = "NEW Work FOR KYC DATA 24-11-2016")]
        //public XmlDataDocument DownloadWardWiseInfinitiy(string districtid, string localbodynameid, string wardid)
        //{
        //    XmlDataDocument xmlData = new XmlDataDocument();
        //    DataSet DS = new DataSet();
        //    DataSet DS1 = new DataSet();
        //    DataTable dt = new DataTable();
        //    string SqlQry = string.Empty;
        //    string nominationID = string.Empty;
        //    string firstName = string.Empty;
        //    string middleName = string.Empty;
        //    string lastName = string.Empty;
        //    string symbolID = string.Empty;
        //    string symbolName = string.Empty;
        //    string nameOfParty = string.Empty;
        //    string name = string.Empty;
        //    string[] str = null;
        //    string sId = string.Empty;
        //    try
        //    {
        //        string sql = " SELECT [Candidate ID] AS [NominationID], [Candidate Name] AS [FirstName] ,[Symbol] AS SymbolName,[Party Name] AS NameOfParty FROM [TrueVoterDB].[dbo].[vw_nominations$] Where [ElectionId]='" + localbodynameid + "' AND [Ward No]='" + wardid + "'";
        //        cmd = new SqlCommand(sql, con);
        //        //cmd = new SqlCommand(sql, conKYC);
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(DS);

        //        dt.Columns.Add(new DataColumn("NominationID", typeof(string)));
        //        dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("MiddleName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("LastName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("SymbolID", typeof(string)));
        //        dt.Columns.Add(new DataColumn("SymbolName", typeof(string)));
        //        dt.Columns.Add(new DataColumn("NameOfParty", typeof(string)));

        //        int Dscnt = DS.Tables[0].Rows.Count;

        //        for (int i = 0; i < Dscnt; i++)
        //        {
        //            nominationID = DS.Tables[0].Rows[i]["NominationID"].ToString();
        //            name = DS.Tables[0].Rows[i]["FirstName"].ToString();
        //            //middleName = DS.Tables[0].Rows[i]["MiddleName"].ToString();
        //            //lastName = DS.Tables[0].Rows[i]["LastName"].ToString();

        //            str = firstName.Split(new char[] { ' ' });

        //            firstName = str[i].ToString().Trim();
        //            middleName = str[i + 1].Trim();
        //            lastName = str[i + 2].ToString().Trim();

        //            string sybID = "0";// DS.Tables[0].Rows[i]["SymbolID"].ToString();
        //            string symNm = DS.Tables[0].Rows[i]["SymbolName"].ToString();
        //            string nmprty = DS.Tables[0].Rows[i]["NameOfParty"].ToString();



        //            if (sybID == "" || sybID == "NULL")
        //            {
        //                symbolID = "NULL";
        //            }
        //            else
        //            {
        //                symbolID = DS.Tables[0].Rows[i]["SymbolID"].ToString();
        //            }

        //            if (symNm == "" || symNm == "NULL")
        //            {
        //                symbolName = "NULL";
        //            }
        //            else
        //            {
        //                symbolName = DS.Tables[0].Rows[i]["SymbolName"].ToString();
        //            }


        //            if (nmprty == "" || nmprty == "NULL")
        //            {
        //                nameOfParty = "NULL";
        //            }
        //            else
        //            {
        //                nameOfParty = DS.Tables[0].Rows[i]["NameOfParty"].ToString();
        //            }
        //            dt.Rows.Add(nominationID, firstName, middleName, lastName, symbolID, symbolName, nameOfParty);  // DS.Tables[0].Rows[i]["SymbolID"].ToString(), DS.Tables[0].Rows[i]["SymbolName"].ToString(), DS.Tables[0].Rows[i]["NameOfParty"].ToString());   //, DS.Tables[0].Rows[i]["Symbol_Image"].ToString());
        //        }
        //        DS1.Tables.Add(dt);
        //        DS1.Tables[0].TableName = "Table";

        //        xmlData = new XmlDataDocument(DS1);
        //        XmlElement xmlEle = xmlData.DocumentElement;
        //    }
        //    catch
        //    {
        //        dt.Columns.Add(new DataColumn("Error", typeof(string)));
        //        DataRow dr = dt.NewRow();
        //        dr["Error"] = "105";
        //        dt.Rows.Add(dr);
        //        DS1.Tables.Add(dt);
        //        xmlData = new XmlDataDocument(DS1);
        //        XmlElement xmlelement = xmlData.DocumentElement;
        //    }
        //    return xmlData;
        //}

        //#endregion

        #region Treereports
        [WebMethod(Description = "WEB METHOD FOR DOWNLOAD DATA FOR TREE REPORTS")] // ADD NEW METHOD 21.10.2016
        public string DownloadTreeData(string userMoNo)
        {
            string retrunString = string.Empty;
            try
            {
                string id = string.Empty;
                string mobileNo = string.Empty;
                string childMobileNumber = string.Empty;
                string childName = string.Empty;
                string parentMobileNumber = string.Empty;
                string parentName = string.Empty;
                string roleId = string.Empty;
                string roleName = string.Empty;
                string post = string.Empty;
                string districtId = string.Empty;
                string districtName = string.Empty;
                string localBodyId = string.Empty;
                string localBodyName = string.Empty;
                string lookingAfterId = string.Empty;
                string lookingAfterName = string.Empty;
                string isActive = string.Empty;
                string sqlQuery = string.Empty;

                //string[] uregid = userMoNo.Split('$');
                // mobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);

                mobileNo = userMoNo.Trim();
                if (mobileNo == "0")
                {
                    mobileNo = "9821128083";// "9619460202";
                }
                else
                {
                    mobileNo = userMoNo.Trim();
                }

                sqlQuery = "SELECT TOP 1 L.[UserName] AS ParentMobileNumber,(L.Name+' '+L.LName) AS ParentName FROM [TrueVoterDB].[dbo].[Logins] AS L  WHERE [UserName] = '" + mobileNo + "' ORDER BY [ID] DESC " +
                           "SELECT L.RegId AS ID, L.[UserName] AS ChildMobileNumber,(L.Name+' '+L.LName) AS ChildName,EL.[DesignationId] AS RoleId,EL.[DesignationName] AS RoleName, " +
                           "EL.[Post] ,EL.[OfficerDistrictId] AS DistrictId,D.[Name_E] AS DistrictName,EL.[LocalBodyId] AS LocalBodyId,EL.[LocalBodyName] AS LocalBodyName, " +
                           "EL.[LokingAfterId] AS LookingAfterId,EL.[LokingAfterName] AS LookingAfterName,[IsApproved] AS IsActive " +
                           "FROM [TrueVoterDB].[dbo].[Logins] AS L LEFT JOIN [TrueVoterDB].[dbo].[tblNewDataRegExtra] AS EL ON L.[UserName]=EL.[usrMobileNumber] " +
                           "LEFT JOIN [TrueVoterDB].[dbo].[Districts] AS D ON EL.[OfficerDistrictId]=D.[Id] WHERE [RefMobileNo] = '" + mobileNo + "' AND [UserType] = 2 ";

                ds = commonCode.ExecuteDataset(sqlQuery);

                int count = ds.Tables[1].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        #region IFELSE
                        parentMobileNumber = ds.Tables[0].Rows[0]["ParentMobileNumber"].ToString();

                        if (parentMobileNumber == "NULL" || parentMobileNumber == "")
                        {
                            parentMobileNumber = "0";
                        }
                        else
                        {
                            parentMobileNumber = ds.Tables[0].Rows[0]["ParentMobileNumber"].ToString();
                        }

                        parentName = ds.Tables[0].Rows[0]["ParentName"].ToString();

                        if (parentName == "NULL" || parentName == "")
                        {
                            parentName = "0";
                        }
                        else
                        {
                            parentName = ds.Tables[0].Rows[0]["ParentName"].ToString();
                        }


                        childMobileNumber = ds.Tables[1].Rows[i]["ChildMobileNumber"].ToString();

                        if (childMobileNumber == "NULL" || childMobileNumber == "")
                        {
                            childMobileNumber = "0";
                        }
                        else
                        {
                            childMobileNumber = ds.Tables[1].Rows[i]["ChildMobileNumber"].ToString();
                        }

                        childName = ds.Tables[1].Rows[i]["ChildName"].ToString();

                        if (childName == "NULL" || childName == "")
                        {
                            childName = "0";
                        }
                        else
                        {
                            childName = ds.Tables[1].Rows[i]["ChildName"].ToString();
                        }

                        roleId = ds.Tables[1].Rows[i]["RoleId"].ToString();

                        if (roleId == "NULL" || roleId == "")
                        {
                            roleId = "0";
                        }
                        else
                        {
                            roleId = ds.Tables[1].Rows[i]["RoleId"].ToString();
                        }

                        roleName = ds.Tables[1].Rows[i]["RoleName"].ToString();

                        if (roleName == "NULL" || roleName == "")
                        {
                            roleName = "0";
                        }
                        else
                        {
                            roleName = ds.Tables[1].Rows[i]["RoleName"].ToString();
                        }


                        post = ds.Tables[1].Rows[i]["Post"].ToString();

                        if (post == "NULL" || post == "")
                        {
                            post = "0";
                        }
                        else
                        {
                            post = ds.Tables[1].Rows[i]["Post"].ToString();
                        }


                        districtId = ds.Tables[1].Rows[i]["DistrictId"].ToString();

                        if (districtId == "NULL" || districtId == "")
                        {
                            districtId = "0";
                        }
                        else
                        {
                            districtId = ds.Tables[1].Rows[i]["DistrictId"].ToString();
                        }

                        districtName = ds.Tables[1].Rows[i]["DistrictName"].ToString();

                        if (districtName == "NULL" || districtName == "")
                        {
                            districtName = "0";
                        }
                        else
                        {
                            districtName = ds.Tables[1].Rows[i]["DistrictName"].ToString();
                        }

                        localBodyId = ds.Tables[1].Rows[i]["LocalBodyId"].ToString();

                        if (localBodyId == "NULL" || localBodyId == "")
                        {
                            localBodyId = "0";
                        }
                        else
                        {
                            localBodyId = ds.Tables[1].Rows[i]["LocalBodyId"].ToString();
                        }


                        localBodyName = ds.Tables[1].Rows[i]["LocalBodyName"].ToString();

                        if (localBodyName == "NULL" || localBodyName == "")
                        {
                            localBodyName = "0";
                        }
                        else
                        {
                            localBodyName = ds.Tables[1].Rows[i]["LocalBodyName"].ToString();
                        }

                        lookingAfterId = ds.Tables[1].Rows[i]["LookingAfterId"].ToString();

                        if (lookingAfterId == "NULL" || lookingAfterId == "")
                        {
                            lookingAfterId = "0";
                        }
                        else
                        {
                            lookingAfterId = ds.Tables[1].Rows[i]["LookingAfterId"].ToString();
                        }

                        lookingAfterName = ds.Tables[1].Rows[i]["LookingAfterName"].ToString();
                        if (lookingAfterName == "NULL" || lookingAfterName == "")
                        {
                            lookingAfterName = "0";
                        }
                        else
                        {
                            lookingAfterName = ds.Tables[1].Rows[i]["LookingAfterName"].ToString();
                        }

                        isActive = ds.Tables[1].Rows[i]["IsActive"].ToString();
                        if (isActive == "NULL" || isActive == "")
                        {
                            isActive = "0";
                        }
                        else
                        {
                            isActive = ds.Tables[1].Rows[i]["IsActive"].ToString();
                        }
                        #endregion

                        retrunString += parentMobileNumber + "*" + parentName + "*" + childMobileNumber + "*" + childName + "*" + roleId + "*" + roleName + "*" + post + "*" + districtId + "*" + districtName + "*" + localBodyId + "*" + localBodyName + "*" + lookingAfterId + "*" + lookingAfterName + "*" + isActive + "#";
                    }
                }
                else
                {
                    return retrunString = "0";
                }
                return retrunString;
            }
            catch
            {
                return retrunString = "0";
            }
        }

        #endregion

        #region DOWNLOAD EMERGENCY SERVICE REPORTS OR DATA
        [WebMethod(Description = "DOWNLOAD EMERGENCY SERVICE REPORTS OR DATA")]
        public XmlDocument downloadEmergencyReports(string districtId, string localBodyId, string emergencyId)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();
            string returnString = string.Empty;
            string serverId = string.Empty;
            string emegencyServiceId = string.Empty;
            string emergServiceName = string.Empty;
            string remark = string.Empty;
            string status = string.Empty;
            string date = string.Empty;
            string loginNumber = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;
            string localBID = string.Empty;

            string distID = string.Empty;
            string wardNo = string.Empty;
            string boothNo = string.Empty;
            string userType = string.Empty;

            try
            {
                dt.Columns.Add(new DataColumn("EmSID", typeof(string)));
                dt.Columns.Add(new DataColumn("EmergServiceId", typeof(string)));
                dt.Columns.Add(new DataColumn("EmergServiceName", typeof(string)));
                dt.Columns.Add(new DataColumn("Remark", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("LoginNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBodyID", typeof(string)));

                dt.Columns.Add(new DataColumn("DistrictID", typeof(string)));
                dt.Columns.Add(new DataColumn("WardNo", typeof(string)));
                dt.Columns.Add(new DataColumn("BoothNo", typeof(string)));
                dt.Columns.Add(new DataColumn("UserRole", typeof(string)));

                cmd.CommandText = "uspDownloadEmergencyServices";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                cmd.Parameters.AddWithValue("@localBodyId", localBodyId.Trim());
                cmd.Parameters.AddWithValue("@emergencyId", emergencyId.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        serverId = ds.Tables[0].Rows[i][0].ToString();

                        emegencyServiceId = ds.Tables[0].Rows[i][1].ToString();
                        if (emegencyServiceId == "NULL" || emegencyServiceId == "")
                        {
                            emegencyServiceId = "0";
                        }
                        else
                        {
                            emegencyServiceId = ds.Tables[0].Rows[i][1].ToString();
                        }
                        emergServiceName = ds.Tables[0].Rows[i][2].ToString();
                        if (emergServiceName == "NULL" || emergServiceName == "")
                        {
                            emergServiceName = "0";
                        }
                        else
                        {
                            emergServiceName = ds.Tables[0].Rows[i][2].ToString();
                        }
                        remark = ds.Tables[0].Rows[i][3].ToString();
                        if (remark == "NULL" || remark == "")
                        {
                            remark = "0";
                        }
                        else
                        {
                            remark = ds.Tables[0].Rows[i][3].ToString();
                        }
                        status = ds.Tables[0].Rows[i][4].ToString();
                        if (status == "NULL" || status == "")
                        {
                            status = "0";
                        }
                        else
                        {
                            status = ds.Tables[0].Rows[i][4].ToString();
                        }
                        date = ds.Tables[0].Rows[i][5].ToString();
                        if (date == "NULL" || date == "")
                        {
                            date = "0";
                        }
                        else
                        {
                            date = ds.Tables[0].Rows[i][5].ToString();
                        }
                        loginNumber = ds.Tables[0].Rows[i][6].ToString();
                        if (loginNumber == "NULL" || loginNumber == "")
                        {
                            loginNumber = "0";
                        }
                        else
                        {
                            loginNumber = ds.Tables[0].Rows[i][6].ToString();
                        }
                        createdBy = ds.Tables[0].Rows[i][7].ToString();
                        if (createdBy == "NULL" || createdBy == "")
                        {
                            createdBy = "0";
                        }
                        else
                        {
                            createdBy = ds.Tables[0].Rows[i][7].ToString();
                        }
                        createdDate = ds.Tables[0].Rows[i][8].ToString();
                        if (createdDate == "NULL" || createdDate == "")
                        {
                            createdDate = "0";
                        }
                        else
                        {
                            createdDate = ds.Tables[0].Rows[i][8].ToString();
                        }
                        localBID = ds.Tables[0].Rows[i][9].ToString();
                        if (localBID == "NULL" || localBID == "")
                        {
                            localBID = "0";
                        }
                        else
                        {
                            localBID = ds.Tables[0].Rows[i][9].ToString();
                        }

                        distID = ds.Tables[0].Rows[i][10].ToString();
                        if (distID == "NULL" || distID == "")
                        {
                            distID = "0";
                        }
                        else
                        {
                            distID = ds.Tables[0].Rows[i][10].ToString();
                        }

                        wardNo = ds.Tables[0].Rows[i][11].ToString();
                        if (wardNo == "NULL" || wardNo == "")
                        {
                            wardNo = "0";
                        }
                        else
                        {
                            wardNo = ds.Tables[0].Rows[i][11].ToString();
                        }

                        boothNo = ds.Tables[0].Rows[i][12].ToString();
                        if (boothNo == "NULL" || boothNo == "")
                        {
                            boothNo = "0";
                        }
                        else
                        {
                            boothNo = ds.Tables[0].Rows[i][12].ToString();
                        }

                        userType = ds.Tables[0].Rows[i][13].ToString();
                        if (userType == "NULL" || userType == "")
                        {
                            userType = "0";
                        }
                        else
                        {
                            userType = ds.Tables[0].Rows[i][13].ToString();
                        }

                        dt.Rows.Add(serverId, emegencyServiceId, emergServiceName, remark, status, date, loginNumber, createdBy, createdDate, localBID, distID, wardNo, boothNo, userType);
                    }

                    ds1.Tables.Add(dt);
                    ds1.Tables[0].TableName = "Table";

                    xmlData = new XmlDataDocument(ds1);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt1.NewRow();
                    dr["NoRecord"] = "106";
                    dt1.Rows.Add(dr);
                    ds1.Tables.Add(dt1);
                    ds1.Tables[0].TableName = "Table";
                    XmlDataDocument datadocument = new XmlDataDocument(ds1);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
            }
            catch
            {
                dt1.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt1.NewRow();
                dr["Error"] = "105";
                dt1.Rows.Add(dr);
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds1);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
            return xmlData;
        }
        #endregion

        #region DOWNLOAD ELECTION DATA TIME DETAILS
        [WebMethod(Description = "DOWNLOAD ELECTION DATA TIME DETAILS")]
        public XmlDocument downloadElectionDataReports(string districtId, string localBodyId, string wardNumber, string boothNumber)
        {
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();
            string serverId = string.Empty;
            string recordType = string.Empty;
            string male = string.Empty;
            string female = string.Empty;
            string other = string.Empty;
            string wardNo = string.Empty;
            string boothNo = string.Empty;
            string distID = string.Empty;
            string localBody = string.Empty;
            string time = string.Empty;
            string imeiNo = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;

            try
            {
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("RECORDTYPE", typeof(string)));
                dt.Columns.Add(new DataColumn("MALE", typeof(string)));
                dt.Columns.Add(new DataColumn("FEMALE", typeof(string)));
                dt.Columns.Add(new DataColumn("OTHER", typeof(string)));
                dt.Columns.Add(new DataColumn("WARDNO", typeof(string)));
                dt.Columns.Add(new DataColumn("BOOTHNO", typeof(string)));
                dt.Columns.Add(new DataColumn("DISTID", typeof(string)));
                dt.Columns.Add(new DataColumn("LOCALBODY", typeof(string)));
                dt.Columns.Add(new DataColumn("IMEI", typeof(string)));
                dt.Columns.Add(new DataColumn("TIME", typeof(string)));
                dt.Columns.Add(new DataColumn("Createdby", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));

                cmd.CommandText = "uspDownloadElectionDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                cmd.Parameters.AddWithValue("@localBodyId", localBodyId.Trim());
                cmd.Parameters.AddWithValue("@wardNo", wardNumber.Trim());
                cmd.Parameters.AddWithValue("@boothNo", boothNumber.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        serverId = ds.Tables[0].Rows[i][0].ToString();

                        recordType = ds.Tables[0].Rows[i][1].ToString();
                        if (recordType == "NULL" || recordType == "")
                        {
                            recordType = "0";
                        }
                        else
                        {
                            recordType = ds.Tables[0].Rows[i][1].ToString();
                        }
                        male = ds.Tables[0].Rows[i][2].ToString();
                        if (male == "NULL" || male == "")
                        {
                            male = "0";
                        }
                        else
                        {
                            male = ds.Tables[0].Rows[i][2].ToString();
                        }
                        female = ds.Tables[0].Rows[i][3].ToString();
                        if (female == "NULL" || female == "")
                        {
                            female = "0";
                        }
                        else
                        {
                            female = ds.Tables[0].Rows[i][3].ToString();
                        }
                        other = ds.Tables[0].Rows[i][4].ToString();
                        if (other == "NULL" || other == "")
                        {
                            other = "0";
                        }
                        else
                        {
                            other = ds.Tables[0].Rows[i][4].ToString();
                        }
                        wardNo = ds.Tables[0].Rows[i][5].ToString();
                        if (wardNo == "NULL" || wardNo == "")
                        {
                            wardNo = "0";
                        }
                        else
                        {
                            wardNo = ds.Tables[0].Rows[i][5].ToString();
                        }
                        boothNo = ds.Tables[0].Rows[i][6].ToString();
                        if (boothNo == "NULL" || boothNo == "")
                        {
                            boothNo = "0";
                        }
                        else
                        {
                            boothNo = ds.Tables[0].Rows[i][6].ToString();
                        }

                        distID = ds.Tables[0].Rows[i][7].ToString();
                        if (distID == "NULL" || distID == "")
                        {
                            distID = "0";
                        }
                        else
                        {
                            distID = ds.Tables[0].Rows[i][7].ToString();
                        }

                        localBody = ds.Tables[0].Rows[i][8].ToString();
                        if (localBody == "NULL" || localBody == "")
                        {
                            localBody = "0";
                        }
                        else
                        {
                            localBody = ds.Tables[0].Rows[i][8].ToString();
                        }

                        imeiNo = ds.Tables[0].Rows[i][9].ToString();
                        if (imeiNo == "NULL" || imeiNo == "")
                        {
                            imeiNo = "0";
                        }
                        else
                        {
                            imeiNo = ds.Tables[0].Rows[i][9].ToString();
                        }

                        time = ds.Tables[0].Rows[i][10].ToString();
                        if (time == "NULL" || time == "")
                        {
                            time = "0";
                        }
                        else
                        {
                            time = ds.Tables[0].Rows[i][10].ToString();
                        }


                        createdBy = ds.Tables[0].Rows[i][11].ToString();
                        if (createdBy == "NULL" || createdBy == "")
                        {
                            createdBy = "0";
                        }
                        else
                        {
                            createdBy = ds.Tables[0].Rows[i][11].ToString();
                        }
                        createdDate = ds.Tables[0].Rows[i][12].ToString();
                        if (createdDate == "NULL" || createdDate == "")
                        {
                            createdDate = "0";
                        }
                        else
                        {
                            createdDate = ds.Tables[0].Rows[i][12].ToString();
                        }
                        dt.Rows.Add(serverId, recordType, male, female, other, wardNo, boothNo, distID, localBody, imeiNo, time, createdBy, createdDate);
                    }

                    ds1.Tables.Add(dt);
                    ds1.Tables[0].TableName = "Table";

                    xmlData = new XmlDataDocument(ds1);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt1.NewRow();
                    dr["NoRecord"] = "106";
                    dt1.Rows.Add(dr);
                    ds1.Tables.Add(dt1);
                    ds1.Tables[0].TableName = "Table";
                    XmlDataDocument datadocument = new XmlDataDocument(ds1);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
            }
            catch
            {
                dt1.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt1.NewRow();
                dr["Error"] = "105";
                dt1.Rows.Add(dr);
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds1);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
            return xmlData;
        }

        #endregion

        #region DOWNLOAD ELECTION STATUS ACTIVITY
        [WebMethod(Description = " DOWNLOAD ELECTION STATUS REPORT ACTIVITY")]
        public XmlDocument downloadElectionStatusReports(string eleStatusId, string localBodyId, string districtId)
        {
            DataTable dt1 = new DataTable();
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();
            string serverId = string.Empty;
            string electionStatusId = string.Empty;
            string electionStatusName = string.Empty;
            string remarks = string.Empty;
            string status = string.Empty;
            string date = string.Empty;
            string loginNumber = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;
            string localBodyID = string.Empty;

            string distID = string.Empty;
            string wardNo = string.Empty;
            string boothNo = string.Empty;
            string userType = string.Empty;

            try
            {
                dt.Columns.Add(new DataColumn("ESID", typeof(string)));
                dt.Columns.Add(new DataColumn("ElectionStatusId", typeof(string)));
                dt.Columns.Add(new DataColumn("ElectionStatusName", typeof(string)));
                dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("LoginNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBodyID", typeof(string)));

                dt.Columns.Add(new DataColumn("DistrictID", typeof(string)));
                dt.Columns.Add(new DataColumn("WardNo", typeof(string)));
                dt.Columns.Add(new DataColumn("BoothNo", typeof(string)));
                dt.Columns.Add(new DataColumn("UserRole", typeof(string)));

                cmd.CommandText = "uspDownloadElectionStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@electionStatusId", eleStatusId.Trim());
                cmd.Parameters.AddWithValue("@localBodyId", localBodyId.Trim());
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        serverId = ds.Tables[0].Rows[i][0].ToString();

                        electionStatusId = ds.Tables[0].Rows[i][1].ToString();
                        if (electionStatusId == "NULL" || electionStatusId == "")
                        {
                            electionStatusId = "0";
                        }
                        else
                        {
                            electionStatusId = ds.Tables[0].Rows[i][1].ToString();
                        }
                        electionStatusName = ds.Tables[0].Rows[i][2].ToString();
                        if (electionStatusName == "NULL" || electionStatusName == "")
                        {
                            electionStatusName = "0";
                        }
                        else
                        {
                            electionStatusName = ds.Tables[0].Rows[i][2].ToString();
                        }
                        remarks = ds.Tables[0].Rows[i][3].ToString();
                        if (remarks == "NULL" || remarks == "")
                        {
                            remarks = "0";
                        }
                        else
                        {
                            remarks = ds.Tables[0].Rows[i][3].ToString();
                        }
                        status = ds.Tables[0].Rows[i][4].ToString();
                        if (status == "NULL" || status == "")
                        {
                            status = "0";
                        }
                        else
                        {
                            status = ds.Tables[0].Rows[i][4].ToString();
                        }
                        date = ds.Tables[0].Rows[i][5].ToString();
                        if (date == "NULL" || date == "")
                        {
                            date = "0";
                        }
                        else
                        {
                            date = ds.Tables[0].Rows[i][5].ToString();
                        }
                        loginNumber = ds.Tables[0].Rows[i][6].ToString();
                        if (loginNumber == "NULL" || loginNumber == "")
                        {
                            loginNumber = "0";
                        }
                        else
                        {
                            loginNumber = ds.Tables[0].Rows[i][6].ToString();
                        }

                        createdBy = ds.Tables[0].Rows[i][7].ToString();
                        if (createdBy == "NULL" || createdBy == "")
                        {
                            createdBy = "0";
                        }
                        else
                        {
                            createdBy = ds.Tables[0].Rows[i][7].ToString();
                        }

                        createdDate = ds.Tables[0].Rows[i][8].ToString();
                        if (createdDate == "NULL" || createdDate == "")
                        {
                            createdDate = "0";
                        }
                        else
                        {
                            createdDate = ds.Tables[0].Rows[i][8].ToString();
                        }

                        localBodyID = ds.Tables[0].Rows[i][11].ToString();
                        if (localBodyID == "NULL" || localBodyID == "")
                        {
                            localBodyID = "0";
                        }
                        else
                        {
                            localBodyID = ds.Tables[0].Rows[i][11].ToString();
                        }




                        distID = ds.Tables[0].Rows[i][12].ToString();
                        if (distID == "NULL" || distID == "")
                        {
                            distID = "0";
                        }
                        else
                        {
                            distID = ds.Tables[0].Rows[i][12].ToString();
                        }

                        wardNo = ds.Tables[0].Rows[i][13].ToString();
                        if (wardNo == "NULL" || wardNo == "")
                        {
                            wardNo = "0";
                        }
                        else
                        {
                            wardNo = ds.Tables[0].Rows[i][13].ToString();
                        }

                        boothNo = ds.Tables[0].Rows[i][14].ToString();
                        if (boothNo == "NULL" || boothNo == "")
                        {
                            boothNo = "0";
                        }
                        else
                        {
                            boothNo = ds.Tables[0].Rows[i][14].ToString();
                        }

                        userType = ds.Tables[0].Rows[i][15].ToString();
                        if (userType == "NULL" || userType == "")
                        {
                            userType = "0";
                        }
                        else
                        {
                            userType = ds.Tables[0].Rows[i][15].ToString();
                        }


                        dt.Rows.Add(serverId, electionStatusId, electionStatusName, remarks, status, date, loginNumber, createdBy, createdDate, localBodyID, distID, wardNo, boothNo, userType);
                    }

                    ds1.Tables.Add(dt);
                    ds1.Tables[0].TableName = "Table";

                    xmlData = new XmlDataDocument(ds1);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt1.NewRow();
                    dr["NoRecord"] = "106";
                    dt1.Rows.Add(dr);
                    ds1.Tables.Add(dt1);
                    ds1.Tables[0].TableName = "Table";
                    XmlDataDocument datadocument = new XmlDataDocument(ds1);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
            }
            catch
            {
                dt1.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt1.NewRow();
                dr["Error"] = "105";
                dt1.Rows.Add(dr);
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds1);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
            return xmlData;
        }

        #endregion

        #region DOWNLOAD ELECTION CANDIDATE RESULT DETAILS
        [WebMethod(Description = " DOWNLOAD CANDIDATE RESULT DETAILS")]
        public XmlDocument downloadCandidateResultDetails(string distID, string localBodyId, string wardNumber)
        {
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();
            string serverId = string.Empty;
            string districtId = string.Empty;
            string localBody = string.Empty;
            string wardNo = string.Empty;
            string seatNo = string.Empty;
            string candidateName = string.Empty;
            string partyName = string.Empty;
            string allocatedSymbol = string.Empty;
            string registrationId = string.Empty;
            string count = string.Empty;
            string elected = string.Empty;
            string isActive = string.Empty;
            try
            {
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBodyId", typeof(string)));
                dt.Columns.Add(new DataColumn("WardNo", typeof(string)));
                dt.Columns.Add(new DataColumn("SeatNo", typeof(string)));
                dt.Columns.Add(new DataColumn("CandidateName", typeof(string)));
                dt.Columns.Add(new DataColumn("PartyName", typeof(string)));
                dt.Columns.Add(new DataColumn("AllocatedSymbol", typeof(string)));
                dt.Columns.Add(new DataColumn("RegistrationId", typeof(string)));
                dt.Columns.Add(new DataColumn("Count", typeof(string)));
                dt.Columns.Add(new DataColumn("Elected", typeof(string)));
                dt.Columns.Add(new DataColumn("IsActive", typeof(string)));

                cmd.CommandText = "uspDownloadResultDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@districtId", distID);
                cmd.Parameters.AddWithValue("@localBodyId", localBodyId);
                cmd.Parameters.AddWithValue("@wardNumber", wardNumber);

                da.SelectCommand = cmd;
                da.Fill(ds);
                int count1 = ds.Tables[0].Rows.Count;
                if (count1 > 0)
                {
                    for (int i = 0; i < count1; i++)
                    {
                        serverId = ds.Tables[0].Rows[i][0].ToString();

                        districtId = ds.Tables[0].Rows[i][1].ToString();
                        if (districtId == "NULL" || districtId == "")
                        {
                            districtId = "0";
                        }
                        else
                        {
                            districtId = ds.Tables[0].Rows[i][1].ToString();
                        }
                        localBody = ds.Tables[0].Rows[i][2].ToString();
                        if (localBody == "NULL" || localBody == "")
                        {
                            localBody = "0";
                        }
                        else
                        {
                            localBody = ds.Tables[0].Rows[i][2].ToString();
                        }
                        wardNo = ds.Tables[0].Rows[i][3].ToString();
                        if (wardNo == "NULL" || wardNo == "")
                        {
                            wardNo = "0";
                        }
                        else
                        {
                            wardNo = ds.Tables[0].Rows[i][3].ToString();
                        }
                        seatNo = ds.Tables[0].Rows[i][4].ToString();
                        if (seatNo == "NULL" || seatNo == "")
                        {
                            seatNo = "0";
                        }
                        else
                        {
                            seatNo = ds.Tables[0].Rows[i][4].ToString();
                        }
                        candidateName = ds.Tables[0].Rows[i][5].ToString();
                        if (candidateName == "NULL" || candidateName == "")
                        {
                            candidateName = "0";
                        }
                        else
                        {
                            candidateName = ds.Tables[0].Rows[i][5].ToString();
                        }
                        partyName = ds.Tables[0].Rows[i][6].ToString();
                        if (partyName == "NULL" || partyName == "")
                        {
                            partyName = "0";
                        }
                        else
                        {
                            partyName = ds.Tables[0].Rows[i][6].ToString();
                        }

                        allocatedSymbol = ds.Tables[0].Rows[i][7].ToString();
                        if (allocatedSymbol == "NULL" || allocatedSymbol == "")
                        {
                            allocatedSymbol = "0";
                        }
                        else
                        {
                            allocatedSymbol = ds.Tables[0].Rows[i][7].ToString();
                        }

                        registrationId = ds.Tables[0].Rows[i][8].ToString();
                        if (registrationId == "NULL" || registrationId == "")
                        {
                            registrationId = "0";
                        }
                        else
                        {
                            registrationId = ds.Tables[0].Rows[i][8].ToString();
                        }


                        count = ds.Tables[0].Rows[i][9].ToString();
                        if (count == "NULL" || count == "")
                        {
                            count = "0";
                        }
                        else
                        {
                            count = ds.Tables[0].Rows[i][9].ToString();
                        }
                        elected = ds.Tables[0].Rows[i][10].ToString();
                        if (elected == "NULL" || elected == "")
                        {
                            elected = "0";
                        }
                        else
                        {
                            elected = ds.Tables[0].Rows[i][10].ToString();
                        }
                        isActive = ds.Tables[0].Rows[i][11].ToString();
                        if (isActive == "NULL" || isActive == "")
                        {
                            isActive = "0";
                        }
                        else
                        {
                            isActive = ds.Tables[0].Rows[i][11].ToString();
                        }

                        dt.Rows.Add(serverId, districtId, localBody, wardNo, seatNo, candidateName, partyName, allocatedSymbol, registrationId, count, elected, isActive);
                    }

                    ds1.Tables.Add(dt);
                    ds1.Tables[0].TableName = "Table";

                    xmlData = new XmlDataDocument(ds1);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt1.NewRow();
                    dr["NoRecord"] = "106";
                    dt1.Rows.Add(dr);
                    ds1.Tables.Add(dt1);
                    ds1.Tables[0].TableName = "Table";
                    XmlDataDocument datadocument = new XmlDataDocument(ds1);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
            }
            catch
            {
                dt1.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt1.NewRow();
                dr["Error"] = "105";
                dt1.Rows.Add(dr);
                ds1.Tables.Add(dt1);
                ds1.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds1);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
            return xmlData;
        }

        #endregion

        #region WEB SERVICE FOR DOWNLOAD VOTER TIME DETAILS
        [WebMethod(Description = "WEB SERVICE FOR DOWNLOAD VOTER TIME DETAILS 06-12-2016")]
        public XmlDataDocument DownloadVoteTimeDetails(string localbodynameid, string wardid, string maxServerId)
        {
            XmlDataDocument xmlData = new XmlDataDocument();
            DataSet DS = new DataSet();
            DataSet DS1 = new DataSet();
            DataSet DS2 = new DataSet();
            DataTable dt = new DataTable();
            string SqlQry = string.Empty;
            string id = string.Empty;
            string recordType = string.Empty;
            string male = string.Empty;
            string female = string.Empty;
            string other = string.Empty;
            string wardNo = string.Empty;
            string boothNo = string.Empty;
            string distId = string.Empty;
            string localBodyId = string.Empty;
            string localBody = string.Empty;
            string imei = string.Empty;
            string time = string.Empty;
            string createdBy = string.Empty;
            string createdDate = string.Empty;
            string totalVoters = string.Empty;
            string percentage = string.Empty;
            try
            {
                string sql = "SELECT TOP 10 [ID],[RECORDTYPE],[MALE],[FEMALE],[OTHER],[WARDNO],[BOOTHNO],[DISTID],[LOCALBODYID],[LOCALBODY],[IMEI],[TIME],[Createdby],[CreatedDate],[TotalVoters],[Percentage] FROM [TrueVoterDB].[dbo].[tblVoteTimeDetails] WITH (NOLOCK) Where [LOCALBODY]='" + localbodynameid + "' AND [WARDNO]='" + wardid + "' AND [ID] >'" + maxServerId.Trim() + "'";
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(DS);

                int Dscnt = DS.Tables[0].Rows.Count;
                if (Dscnt > 0)
                {
                    dt.Columns.Add(new DataColumn("ID", typeof(string)));
                    dt.Columns.Add(new DataColumn("RECORDTYPE", typeof(string)));
                    dt.Columns.Add(new DataColumn("MALE", typeof(string)));
                    dt.Columns.Add(new DataColumn("FEMALE", typeof(string)));
                    dt.Columns.Add(new DataColumn("OTHER", typeof(string)));
                    dt.Columns.Add(new DataColumn("WARDNO", typeof(string)));
                    dt.Columns.Add(new DataColumn("BOOTHNO", typeof(string)));
                    dt.Columns.Add(new DataColumn("DISTID", typeof(string)));
                    dt.Columns.Add(new DataColumn("LOCALBODYID", typeof(string)));
                    dt.Columns.Add(new DataColumn("LOCALBODY", typeof(string)));
                    dt.Columns.Add(new DataColumn("IMEI", typeof(string)));
                    dt.Columns.Add(new DataColumn("TIME", typeof(string)));
                    dt.Columns.Add(new DataColumn("Createdby", typeof(string)));
                    dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));
                    dt.Columns.Add(new DataColumn("TotalVoters", typeof(string)));
                    dt.Columns.Add(new DataColumn("Percentage", typeof(string)));

                    for (int i = 0; i < Dscnt; i++)
                    {
                        id = DS.Tables[0].Rows[i]["ID"].ToString().Trim();
                        recordType = DS.Tables[0].Rows[i]["RECORDTYPE"].ToString().Trim();
                        male = DS.Tables[0].Rows[i]["MALE"].ToString().Trim();
                        female = DS.Tables[0].Rows[i]["FEMALE"].ToString().Trim();
                        other = DS.Tables[0].Rows[i]["OTHER"].ToString().Trim();
                        wardNo = DS.Tables[0].Rows[i]["WARDNO"].ToString().Trim();
                        boothNo = DS.Tables[0].Rows[i]["BOOTHNO"].ToString().Trim();
                        distId = DS.Tables[0].Rows[i]["DISTID"].ToString().Trim();
                        localBodyId = DS.Tables[0].Rows[i]["LOCALBODYID"].ToString().Trim();
                        localBody = DS.Tables[0].Rows[i]["LOCALBODY"].ToString().Trim();
                        imei = DS.Tables[0].Rows[i]["IMEI"].ToString().Trim();
                        time = DS.Tables[0].Rows[i]["TIME"].ToString().Trim();
                        createdBy = DS.Tables[0].Rows[i]["Createdby"].ToString().Trim();
                        createdDate = DS.Tables[0].Rows[i]["CreatedDate"].ToString().Trim();
                        totalVoters = DS.Tables[0].Rows[i]["TotalVoters"].ToString().Trim();
                        percentage = DS.Tables[0].Rows[i]["Percentage"].ToString().Trim();

                        dt.Rows.Add(id, recordType, male, female, other, wardNo, boothNo, distId, localBodyId, localBody, imei, time, createdBy, createdDate, totalVoters, percentage);
                    }

                    DS1.Tables.Add(dt);
                    DS1.Tables[0].TableName = "Table";

                    xmlData = new XmlDataDocument(DS1);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("NoData", typeof(string)));
                    DataRow dr = dt.NewRow();
                    dr["NoData"] = "107";
                    dt.Rows.Add(dr);
                    DS2.Tables.Add(dt);
                    DS2.Tables[0].TableName = "Table";
                    xmlData = new XmlDataDocument(DS2);
                    XmlElement xmlelement = xmlData.DocumentElement;
                }
            }
            catch
            {
                dt.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["Error"] = "105";
                dt.Rows.Add(dr);
                DS2.Tables.Add(dt);
                DS2.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(DS2);
                XmlElement xmlelement = xmlData.DocumentElement;
            }
            return xmlData;
        }

        #endregion

        #region Voter Voice
        [WebMethod(Description = "INSERT VOTER VOICE")] //METHOD PREPARED BY SURAJ MANE 13-12-2016 
        public string InsertVotersVoice(string voterVoice)
        {
            try
            {
                string[] str = null;
                string userMobileNo = String.Empty;
                string demand = String.Empty;
                string demandFor = String.Empty;
                string localBodyId = String.Empty;
                string wardNo = String.Empty;
                string date = String.Empty;
                string IMEI = String.Empty;
                string createdBy = String.Empty;
                string createdDate = String.Empty;
                string modifyBy = String.Empty;
                string modifyDate = string.Empty;
                string mobId = string.Empty;
                string serId = string.Empty;
                string status = string.Empty;

                str = voterVoice.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 9)
                {
                    mobId = str[i].ToString().Trim();
                    date = str[i + 1].ToString().Trim();
                    userMobileNo = str[i + 2].ToString().Trim();
                    demand = str[i + 3].ToString().Trim();
                    demandFor = str[i + 4].ToString().Trim();
                    localBodyId = str[i + 5].ToString().Trim();
                    wardNo = str[i + 6].ToString().Trim();
                    IMEI = str[i + 7].ToString().Trim();
                    serId = str[i + 8].ToString().Trim();
                    createdDate = System.DateTime.Now.ToString("yyyy-MM-dd");


                    string[] uregid = userMobileNo.Split('$');
                    userMobileNo = objenc.DecryptInteger(uregid[0], uregid[1]);
                    if (serId == "0")
                    {
                        string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblVotersVoice] ([UserMobileNo], [Demand], [DemandFor], [LocalBodyId], [WardNo], [IMEI], [CreatedBy], [CreatedDate],[Date])  VALUES ('" + userMobileNo + "',N'" + demand + "',N'" + demandFor + "','" + localBodyId + "','" + wardNo + "','" + IMEI + "','" + userMobileNo + "','" + createdDate + "','" + date + "')";
                        commonCode.ExecuteNonQuery(sql2);

                        string sqlMaxId = "SELECT MAX(ID) FROM [TrueVoterDB].[dbo].[tblVotersVoice](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                        status += MaxId + "*" + mobId + "#";
                    }
                    else
                    {
                        string sql2 = "UPDATE [TrueVoterDB].[dbo].[tblVotersVoice] SET [UserMobileNo]='" + userMobileNo + "',[Demand]='" + demand + "',[DemandFor]='" + demandFor + "',[LocalBodyId]='" + localBodyId + "',[WardNo]='" + wardNo + "',[IMEI]='" + IMEI + "',[ModifyBy]='" + userMobileNo + "',[ModifyDate]='" + createdDate + "',[Date]='" + date + "' WHERE [ID]='" + serId + "'";
                        commonCode.ExecuteNonQuery(sql2);
                        status += serId + "*" + mobId + "#";
                    }

                }

                //if (status.EndsWith("*"))
                //{
                //    status = status.Remove(status.Length - 1);
                //}
                return status;
            }
            catch (Exception)
            {
                return "0";
            }
        }

        [WebMethod(Description = "Download voter Voice Details")]
        public string DownloadVoterVoice(string localBodyid, string demandFor, string wardNo)
        {
            DataSet dsVoterVoice = new DataSet();
            string returnString = string.Empty;
            string sqlquery = string.Empty;
            try
            {
                if (demandFor == "1")
                {

                    sqlquery = "SELECT [ID],[UserMobileNo],[Demand],[DemandFor],[Date],[LocalBodyId],[WardNo],[IMEI],[CreatedBy],[CreatedDate] FROM [TrueVoterDB].[dbo].[tblVotersVoice](NOLOCK) WHERE [LocalBodyId]='" + localBodyid + "' AND [DemandFor]='" + demandFor + "'";
                }
                else
                {
                    sqlquery = "SELECT [ID],[UserMobileNo],[Demand],[DemandFor],[Date],[LocalBodyId],[WardNo],[IMEI],[CreatedBy],[CreatedDate] FROM [TrueVoterDB].[dbo].[tblVotersVoice](NOLOCK) WHERE [LocalBodyId]='" + localBodyid + "' AND [WardNo]='" + wardNo + "' ";
                }
                dsVoterVoice = commonCode.ExecuteDataset(sqlquery);
                int cnt = dsVoterVoice.Tables[0].Rows.Count;
                if (cnt > 0)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        returnString += dsVoterVoice.Tables[0].Rows[i]["ID"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["UserMobileNo"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["Demand"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["DemandFor"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["Date"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["LocalBodyId"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["WardNo"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["IMEI"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["CreatedBy"].ToString().Trim() + "*" + dsVoterVoice.Tables[0].Rows[i]["CreatedDate"].ToString().Trim() + "#";
                    }
                    return returnString;
                }
                else
                {
                    return "0";
                }
            }
            catch
            {
                return "0";
            }
        }
        #endregion
    }
}


