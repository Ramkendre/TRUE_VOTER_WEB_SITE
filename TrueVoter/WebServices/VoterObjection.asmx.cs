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
    public class VoterObjection : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        EncDecArrayClass objenc = new EncDecArrayClass();
        CommonCode cc = new CommonCode();

        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();

        #region VOTER OBJECTION REGISTRATION
        [WebMethod(Description = "WEB METHOD FOR VOTER OBJECTION")]
        public string voterObjectionRegister(string usrMobileNumber, string name, string emailId, string imeiNo)
        {

            string sqlQuery = string.Empty;
            try
            {
                string MaxId = string.Empty;
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                Random otpGenerator = new Random();
                string otpNumber = otpGenerator.Next(1000, 9999).ToString();

                sqlQuery = " SELECT * FROM [TrueVoterDB].[dbo].[tblVoterObjection](NOLOCK) WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                ds = commonCode.ExecuteDataset(sqlQuery);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string tblotp = ds.Tables[0].Rows[0]["OTP"].ToString();
                    string MoimeiNo = ds.Tables[0].Rows[0]["IMEINo"].ToString();

                    if (imeiNo == MoimeiNo && tblotp == "0")
                    {
                        sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                        commonCode.ExecuteNonQuery(sqlQuery);

                        MaxId = "1*";
                    }
                    else if (imeiNo == MoimeiNo && tblotp != "0")
                    {
                        sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                        commonCode.ExecuteNonQuery(sqlQuery);
                        MaxId = "2*";
                        otpNumber = tblotp;

                        string passwordMessage = "OTP for " + name + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                        commonCode.SMS(usrMobileNumber, passwordMessage);
                    }
                    else if (imeiNo != MoimeiNo && tblotp == "0")
                    {
                        sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[OTP]='" + otpNumber + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                        commonCode.ExecuteNonQuery(sqlQuery);
                        MaxId = "2*";

                        string passwordMessage = "OTP for " + name + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                        commonCode.SMS(usrMobileNumber, passwordMessage);
                    }
                    else if (imeiNo != MoimeiNo && tblotp != "0")
                    {
                        sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                        commonCode.ExecuteNonQuery(sqlQuery);
                        MaxId = "2*";
                        otpNumber = tblotp;

                        string passwordMessage = "OTP for " + name + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                        commonCode.SMS(usrMobileNumber, passwordMessage);
                    }
                    //1*100#=Verify OTP 0 No Wait,2*100#=Verify not Wait,3*100=New Record Wait response
                    #region Comment
                    //if (tblotp == "0")
                    //{
                    //    sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                    //    commonCode.ExecuteNonQuery(sqlQuery);

                    //    MaxId = "1*";
                    //}
                    //else
                    //{
                    //    sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [Name]='" + name + "',[EmailId]='" + emailId + "',[IMEINo]='" + imeiNo + "',[ModifyBy]='" + usrMobileNumber + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                    //    commonCode.ExecuteNonQuery(sqlQuery);
                    //    MaxId = "2*";
                    //    otpNumber = tblotp;

                    //    //otp send OTP for {name} verification, to take objection on Voter List through TRUE VOTER app is {xxxx}
                    //    // string passwordMessage = "Thanks to Install TRUE VOTER as a Voter. OTP for your installation is " + otpNumber + "";
                    //    string passwordMessage = "OTP for " + name + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                    //    commonCode.SMS(usrMobileNumber, passwordMessage);
                    //}
                    #endregion
                    MaxId += ds.Tables[0].Rows[0]["ID"].ToString() + "#";
                }
                else
                {
                    sqlQuery = " INSERT INTO [TrueVoterDB].[dbo].[tblVoterObjection] ([Name],[UserMobileNo],[EmailId],[IMEINo],[OTP],[CreatedBy],[CreatedDate]) " +
                               " VALUES ('" + name + "','" + usrMobileNumber + "','" + emailId + "','" + imeiNo + "','" + otpNumber + "','" + usrMobileNumber + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "') ";

                    commonCode.ExecuteNonQuery(sqlQuery);
                    string sqlMaxId = "SELECT MAX(ID) FROM [TrueVoterDB].[dbo].[tblVoterObjection](NOLOCK)";
                    MaxId = "3*";
                    MaxId += commonCode.ExecuteScalar(sqlMaxId) + "#";

                    string passwordMessage = "OTP for " + name + " verification, to take objection on Voter List through TRUE VOTER app is " + otpNumber + "";
                    commonCode.SMS(usrMobileNumber, passwordMessage);
                }

                return MaxId.ToString();
            }
            catch
            {
                return "0";
            }
        }
        #endregion

        #region WEB METHOD FOR OBJECTION OTP VERIFICATION
        [WebMethod(Description = "WEB METHOD FOR OTP VERIFICATION")]
        public string otpVerification(string usrMobileNumber, string otp)
        {

            string sqlQuery = string.Empty;
            try
            {
                string MaxId = string.Empty;
                string[] uregid = usrMobileNumber.Split('$');
                usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                sqlQuery = " SELECT * FROM [TrueVoterDB].[dbo].[tblVoterObjection](NOLOCK) WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                ds = commonCode.ExecuteDataset(sqlQuery);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    string tblotp = ds.Tables[0].Rows[0]["OTP"].ToString();
                    if (otp == tblotp)
                    {
                        sqlQuery = " UPDATE [TrueVoterDB].[dbo].[tblVoterObjection] SET [OTP]=0 WHERE [UserMobileNo] = '" + usrMobileNumber + "'";
                        commonCode.ExecuteNonQuery(sqlQuery);
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
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

        #region INSERT COMPLAINT DATA
        [WebMethod(Description = "WEB METHOD FOR INSERT VOTER COMPALINTS")]  // ADD NEW METHOD 17.12.2016
        public string InsertComplaints(string complaintData)
        {
            string StrQry = string.Empty; string MaxId = string.Empty;
            string returnString = string.Empty;
            string usrMobileNumber = string.Empty;
            string desid = string.Empty;
            int result = 0;
            string compttype = string.Empty; string msg = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                XmlReader reader = XmlReader.Create(new StringReader(complaintData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        usrMobileNumber = ds.Tables[0].Rows[i]["MobileNo"].ToString();

                        //string[] uregid = usrMobileNumber.Split('$');
                        //usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                        string mobID = ds.Tables[0].Rows[i]["Id"].ToString();
                        cmd.CommandText = "uspInsertComplaints";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@serverId", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Serverid"].ToString();
                        cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = usrMobileNumber;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = ds.Tables[0].Rows[i]["Name"].ToString();
                        cmd.Parameters.Add("@emailID", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["Emailid"].ToString();
                        cmd.Parameters.Add("@districtId", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["DistrictId"].ToString();
                        cmd.Parameters.Add("@localBody", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["Localbody"].ToString();
                        cmd.Parameters.Add("@localBodyID", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["LocalbodyId"].ToString();
                        cmd.Parameters.Add("@complaintType", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["ComplaintType"].ToString();
                        cmd.Parameters.Add("@aCNo", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Acno"].ToString();
                        cmd.Parameters.Add("@pARTNo", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Partno"].ToString();
                        cmd.Parameters.Add("@sRNo", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Srno"].ToString();
                        cmd.Parameters.Add("@voterName", SqlDbType.NVarChar, 120).Value = ds.Tables[0].Rows[i]["Votername"].ToString();
                        cmd.Parameters.Add("@voterMoNo", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Votermobno"].ToString();
                        cmd.Parameters.Add("@objectionType", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Objectiontype"].ToString();
                        cmd.Parameters.Add("@remark", SqlDbType.NVarChar, 120).Value = ds.Tables[0].Rows[i]["Remark"].ToString();
                        cmd.Parameters.Add("@latitude", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Lattitude"].ToString();
                        cmd.Parameters.Add("@longitude", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Longitude"].ToString();
                        cmd.Parameters.Add("@imeiNo", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Imei"].ToString();
                        cmd.Parameters.Add("@createdDate", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Date"].ToString();
                        cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                        //
                        cmd.Parameters.Add("@expectedWard", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["ExpectedWard"].ToString();
                        cmd.Parameters.Add("@docID", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["DocID"].ToString();
                        //
                        cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        result = cmd.ExecuteNonQuery();

                        ///// ADD by Ram 09-01-2017
                        if (result.Equals(-1))
                        {
                            compttype = ds.Tables[0].Rows[i]["Objectiontype"].ToString();
                            string ObjectionMsg = string.Empty;
                            StrQry = "select [usrMobileNumber],[DesignationId] from [tblNewDataRegExtra] where LocalBodyId=" + ds.Tables[0].Rows[i]["LocalbodyId"].ToString() + " and [AllocatedWard]=" + ds.Tables[0].Rows[i]["ExpectedWard"].ToString() + "";
                            da = new SqlDataAdapter(StrQry, con);
                            DataSet DS = new DataSet();
                            da.Fill(DS);

                            if (DS.Tables[0].Rows.Count > 0)
                            {
                                desid = DS.Tables[0].Rows[0]["DesignationId"].ToString();

                                if (desid == "22")
                                {
                                    if (compttype == "1")
                                    {
                                        msg = "Name Not found in voter list";
                                    }
                                    else
                                    {
                                        msg = "Allocated to wrong ward";
                                    }
                                    StrQry = "select [Name] from [Logins] where [MobileNo]='" + DS.Tables[0].Rows[0]["usrMobileNumber"].ToString() + "'";
                                    da = new SqlDataAdapter(StrQry, con);
                                    DataSet dtsetname = new DataSet();
                                    da.Fill(dtsetname);

                                    ObjectionMsg = "Dear " + dtsetname.Tables[0].Rows[0][0].ToString() + " sir objection of " + ds.Tables[0].Rows[i]["Votername"].ToString() + "," + ds.Tables[0].Rows[i]["Votermobno"].ToString() + "is received for Ac No." + ds.Tables[0].Rows[i]["Acno"].ToString() + " Part No" + ds.Tables[0].Rows[i]["Partno"].ToString() + " Sr no" + ds.Tables[0].Rows[i]["Srno"].ToString() + " Expected ward No" + ds.Tables[0].Rows[i]["ExpectedWard"].ToString() + " for " + msg + " ";  //'" + MaxId + "'
                                    int smslength = ObjectionMsg.Length;
                                    cc.SMS(DS.Tables[0].Rows[0]["usrMobileNumber"].ToString(), ObjectionMsg);
                                }
                            }


                            if (compttype == "1")
                            {
                                msg = "Name Not Found in Voter List";
                            }
                            else
                            {
                                msg = "Allocated to Wrong Ward";
                            }
                            string Voterobj = "Dear " + ds.Tables[0].Rows[i]["Votername"].ToString() + " your objection on Voter List about " + msg + " is taken by " + usrMobileNumber + " " + ds.Tables[0].Rows[i]["Name"].ToString() + ".";                                     //{Representative name} {Representative mobile no}.";
                            cc.SMS(ds.Tables[0].Rows[i]["Votermobno"].ToString(), Voterobj);
                        }

                        MaxId = cmd.Parameters["@maxID"].Value.ToString();
                        returnString += mobID + "*" + MaxId + "#";

                        //MSG
                        //Dear {voter name} your objection on Voter List about {"Name Not Found in Voter List" / "Allocated to Wrong Ward"} is taken by {Representative name} {Representative mobile no}.
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

        #region INSERT COMPLAINT DATA PHOTOS
        [WebMethod(Description = "WEB METHOD FOR INSERT VOTER COMPALINTS PHOTOS")]  // ADD NEW METHOD 17.12.2016
        public string InsertComplaintsPhotos(string complaintPhotosData)
        {
            string returnString = string.Empty;
            string usrMobileNumber = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                XmlReader reader = XmlReader.Create(new StringReader(complaintPhotosData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        usrMobileNumber = ds.Tables[0].Rows[i]["MobileNo"].ToString();

                        //string[] uregid = usrMobileNumber.Split('$');
                        //usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                        string mobID = ds.Tables[0].Rows[i]["ID"].ToString();
                        cmd.CommandText = "uspInsertCompalintPhotos";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@serverId", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["Serverid"].ToString();
                        cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = usrMobileNumber;
                        cmd.Parameters.Add("@latitude", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Lattitude"].ToString();
                        cmd.Parameters.Add("@longitude", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Longitude"].ToString();
                        cmd.Parameters.Add("@homePhoto", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["Homephoto"].ToString();
                        cmd.Parameters.Add("@docPhoto", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["Documentproofphoto"].ToString();
                        cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 20).Value = usrMobileNumber;
                        cmd.Parameters.Add("@createdDate", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Date"].ToString();
                        cmd.Parameters.Add("@imeiNO", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Imei"].ToString();
                        cmd.Parameters.Add("@comID", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["ComplaintServerId"].ToString();//
                        cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        string MaxId = cmd.Parameters["@maxID"].Value.ToString();
                        returnString += mobID + "*" + MaxId + "#";
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

        #region DOWNLOAD OBJECTION/COMPLAINTS 22 ROLE
        [WebMethod(Description = "DOWNLOAD ELECTION OBJECTION/COMPLAINTS")]
        public XmlDocument DownloadComplaintObje(string districtId, string localBody, string localBodyID, string maxServerId, string expectedward)
        {
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();

            try
            {
                #region tablecolumn

                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dt.Columns.Add(new DataColumn("Name", typeof(string)));

                dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBody", typeof(string)));

                dt.Columns.Add(new DataColumn("LocalBodyID", typeof(string)));
                dt.Columns.Add(new DataColumn("ComplaintType", typeof(string)));
                dt.Columns.Add(new DataColumn("ACNo", typeof(string)));

                dt.Columns.Add(new DataColumn("PARTNo", typeof(string)));
                dt.Columns.Add(new DataColumn("SRNo", typeof(string)));
                dt.Columns.Add(new DataColumn("VoterName", typeof(string)));

                dt.Columns.Add(new DataColumn("VoterMoNo", typeof(string)));
                dt.Columns.Add(new DataColumn("ObjectionType", typeof(string)));
                dt.Columns.Add(new DataColumn("Remark", typeof(string)));

                dt.Columns.Add(new DataColumn("Latitude", typeof(string)));
                dt.Columns.Add(new DataColumn("Longitude", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));

                dt.Columns.Add(new DataColumn("ExpectedWard", typeof(string)));
                dt.Columns.Add(new DataColumn("DocID", typeof(string)));

                dt.Columns.Add(new DataColumn("PayUID", typeof(string)));
                dt.Columns.Add(new DataColumn("PayUTxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("TxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("BankTxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("Amount", typeof(string)));
                dt.Columns.Add(new DataColumn("PayUTxnID2", typeof(string)));
                dt.Columns.Add(new DataColumn("IsVerified", typeof(string)));

                dt.Columns.Add(new DataColumn("IsCorrect", typeof(string)));//ADDED 02-01-2016

                cmd.CommandText = "uspDownloadObjectionCompl";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                cmd.Parameters.AddWithValue("@localBody", localBody.Trim());
                cmd.Parameters.AddWithValue("@localBodyID", localBodyID.Trim());
                cmd.Parameters.AddWithValue("@maxServerId", maxServerId.Trim());
                cmd.Parameters.AddWithValue("@expectedward", expectedward.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string ID = string.Empty;
                        ID = ds.Tables[0].Rows[i][0].ToString();

                        string mobileNo = string.Empty;
                        try { mobileNo = ds.Tables[0].Rows[i][1].ToString(); }
                        catch { mobileNo = "0"; }
                        if (mobileNo == "NULL" || mobileNo == "") { mobileNo = "0"; }

                        string name = string.Empty;
                        try { name = ds.Tables[0].Rows[i][2].ToString(); }
                        catch { name = "0"; }
                        if (name == "NULL" || name == "") { name = "0"; }

                        string emailID = string.Empty;
                        try { emailID = ds.Tables[0].Rows[i][3].ToString(); }
                        catch { emailID = "0"; }
                        if (emailID == "NULL" || emailID == "") { emailID = "0"; }

                        string distId = string.Empty;
                        try { distId = ds.Tables[0].Rows[i][4].ToString(); }
                        catch { distId = "0"; }
                        if (distId == "NULL" || distId == "") { distId = "0"; }

                        string localBodytbl = string.Empty;
                        try { localBodytbl = ds.Tables[0].Rows[i][5].ToString(); }
                        catch { localBodytbl = "0"; }
                        if (localBodytbl == "NULL" || localBodytbl == "") { localBodytbl = "0"; }

                        string localBodyIDtbl = string.Empty;
                        try { localBodyIDtbl = ds.Tables[0].Rows[i][6].ToString(); }
                        catch { localBodyIDtbl = "0"; }
                        if (localBodyIDtbl == "NULL" || localBodyIDtbl == "") { localBodyIDtbl = "0"; }

                        string complaintType = string.Empty;
                        try { complaintType = ds.Tables[0].Rows[i][7].ToString(); }
                        catch { complaintType = "0"; }
                        if (complaintType == "NULL" || complaintType == "") { complaintType = "0"; }

                        string longitude = string.Empty;
                        try { longitude = ds.Tables[0].Rows[i][8].ToString(); }
                        catch { longitude = "0"; }
                        if (longitude == "NULL" || longitude == "") { longitude = "0"; }

                        string aCNo = string.Empty;
                        try { aCNo = ds.Tables[0].Rows[i][9].ToString(); }
                        catch { aCNo = "0"; }
                        if (aCNo == "NULL" || aCNo == "") { aCNo = "0"; }

                        string pARTNo = string.Empty;
                        try { pARTNo = ds.Tables[0].Rows[i][10].ToString(); }
                        catch { pARTNo = "0"; }
                        if (pARTNo == "NULL" || pARTNo == "") { pARTNo = "0"; }

                        string sRNo = string.Empty;
                        try { sRNo = ds.Tables[0].Rows[i][11].ToString(); }
                        catch { sRNo = "0"; }
                        if (sRNo == "NULL" || sRNo == "") { sRNo = "0"; }

                        string voterName = string.Empty;
                        try { voterName = ds.Tables[0].Rows[i][12].ToString(); }
                        catch { voterName = "0"; }
                        if (voterName == "NULL" || voterName == "") { voterName = "0"; }


                        string voterMoNo = string.Empty;
                        try { voterMoNo = ds.Tables[0].Rows[i][13].ToString(); }
                        catch { voterMoNo = "0"; }
                        if (voterMoNo == "NULL" || voterMoNo == "") { voterMoNo = "0"; }

                        string objectionType = string.Empty;
                        try { objectionType = ds.Tables[0].Rows[i][14].ToString(); }
                        catch { objectionType = "0"; }
                        if (objectionType == "NULL" || objectionType == "") { objectionType = "0"; }

                        string remark = string.Empty;
                        try { remark = ds.Tables[0].Rows[i][15].ToString(); }
                        catch { remark = "0"; }
                        if (remark == "NULL" || remark == "") { remark = "0"; }

                        string latitude = string.Empty;
                        try { latitude = ds.Tables[0].Rows[i][16].ToString(); }
                        catch { latitude = "0"; }
                        if (latitude == "NULL" || latitude == "") { latitude = "0"; }

                        string createdDate = string.Empty;
                        try { createdDate = ds.Tables[0].Rows[i][17].ToString(); }
                        catch { createdDate = "0"; }
                        if (createdDate == "NULL" || createdDate == "") { createdDate = "0"; }

                        string ExpectedWard = string.Empty;
                        try { ExpectedWard = ds.Tables[0].Rows[i][18].ToString(); }
                        catch { ExpectedWard = "0"; }
                        if (ExpectedWard == "NULL" || ExpectedWard == "") { ExpectedWard = "0"; }

                        string DocId = string.Empty;
                        try { DocId = ds.Tables[0].Rows[i][19].ToString(); }
                        catch { DocId = "0"; }
                        if (DocId == "NULL" || DocId == "") { DocId = "0"; }

                        string PayUID = string.Empty;
                        try { PayUID = ds.Tables[0].Rows[i][20].ToString(); }
                        catch { PayUID = "0"; }
                        if (PayUID == "NULL" || PayUID == "") { PayUID = "0"; }

                        string PayUTxnID = string.Empty;
                        try { PayUTxnID = ds.Tables[0].Rows[i][21].ToString(); }
                        catch { PayUTxnID = "0"; }
                        if (PayUTxnID == "NULL" || PayUTxnID == "") { PayUTxnID = "0"; }

                        string TxnID = string.Empty;
                        try { TxnID = ds.Tables[0].Rows[i][22].ToString(); }
                        catch { TxnID = "0"; }
                        if (TxnID == "NULL" || TxnID == "") { TxnID = "0"; }

                        string BankTxnID = string.Empty;
                        try { BankTxnID = ds.Tables[0].Rows[i][23].ToString(); }
                        catch { BankTxnID = "0"; }
                        if (BankTxnID == "NULL" || BankTxnID == "") { BankTxnID = "0"; }

                        string Amount = string.Empty;
                        try { Amount = ds.Tables[0].Rows[i][24].ToString(); }
                        catch { Amount = "0"; }
                        if (Amount == "NULL" || Amount == "") { Amount = "0"; }

                        string PayUTxnID2 = string.Empty;
                        try { PayUTxnID2 = ds.Tables[0].Rows[i][25].ToString(); }
                        catch { PayUTxnID2 = "0"; }
                        if (PayUTxnID2 == "NULL" || PayUTxnID2 == "") { PayUTxnID2 = "0"; }

                        string IsVerified = string.Empty;
                        try { IsVerified = ds.Tables[0].Rows[i][26].ToString(); }
                        catch { IsVerified = "0"; }
                        if (IsVerified == "NULL" || IsVerified == "") { IsVerified = "0"; }

                        string isCorrect = string.Empty;
                        try { isCorrect = ds.Tables[0].Rows[i][27].ToString(); }
                        catch { isCorrect = "0"; }
                        if (isCorrect == "NULL" || isCorrect == "") { isCorrect = "0"; }

                #endregion
                        dt.Rows.Add(ID, mobileNo, name, emailID, distId, localBodytbl, localBodyIDtbl, complaintType, aCNo, pARTNo, sRNo, voterName, voterMoNo, objectionType, remark, latitude, longitude, createdDate, ExpectedWard, DocId, PayUID, PayUTxnID, TxnID, BankTxnID, Amount, PayUTxnID2, IsVerified, isCorrect);
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

        #region DOWNLOAD OBJECTION/COMPLAINTS PHOTOS
        [WebMethod(Description = "DOWNLOAD ELECTION OBJECTION/COMPLAINTS PHOTOS")]
        public XmlDocument DownloadComplaintObjPhotos(string ComID, string PhotoID)
        {
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();

            string Id = string.Empty;
            string mobileNo = string.Empty;
            string HomePhoto = string.Empty;
            string DocumentPhoto = string.Empty;
            string Photo = string.Empty;
            string latitude = string.Empty;
            string longitude = string.Empty;
            string iMEI = string.Empty;
            string comIDtbl = string.Empty;
            string createdDate = string.Empty;
            try
            {
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dt.Columns.Add(new DataColumn("Photo", typeof(string)));
                dt.Columns.Add(new DataColumn("Latitude", typeof(string)));
                dt.Columns.Add(new DataColumn("Longitude", typeof(string)));

                dt.Columns.Add(new DataColumn("IMEI", typeof(string)));
                dt.Columns.Add(new DataColumn("ComID", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));

                cmd.CommandText = "uspDownloadObjectionComplPhotos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ComID", ComID.Trim());
                cmd.Parameters.AddWithValue("@PhotoID", PhotoID.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Id = ds.Tables[0].Rows[i]["ID"].ToString();

                        try { mobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString(); }
                        catch { mobileNo = "NA"; }

                        try { Photo = ds.Tables[0].Rows[i]["Photo"].ToString(); }
                        catch { Photo = "NA"; }

                        try { latitude = ds.Tables[0].Rows[i]["Latitude"].ToString(); }
                        catch { latitude = "0"; }
                        if (latitude == "NULL" || latitude == "")
                        {
                            latitude = "0";
                        }

                        try { longitude = ds.Tables[0].Rows[i]["Longitude"].ToString(); }
                        catch { longitude = "0"; }
                        if (longitude == "NULL" || longitude == "")
                        {
                            longitude = "0";
                        }

                        try { iMEI = ds.Tables[0].Rows[i]["IMEI"].ToString(); }
                        catch { iMEI = "0"; }
                        if (iMEI == "NULL" || iMEI == "")
                        {
                            iMEI = "0";
                        }
                        try { comIDtbl = ds.Tables[0].Rows[i]["ComID"].ToString(); }
                        catch { comIDtbl = "0"; }
                        if (comIDtbl == "NULL" || comIDtbl == "")
                        {
                            comIDtbl = "0";
                        }
                        try { createdDate = ds.Tables[0].Rows[i]["CreatedDate"].ToString(); }
                        catch { createdDate = "0"; }
                        if (createdDate == "NULL" || createdDate == "")
                        {
                            createdDate = "0";
                        }

                        dt.Rows.Add(Id, mobileNo, Photo, latitude, longitude, iMEI, comIDtbl, createdDate);
                    }

                    ds1.Tables.Add(dt);
                    ds1.Tables[0].TableName = "Table";
                    xmlData = new XmlDataDocument(ds1);
                }
                else
                {
                    dt1.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt1.NewRow();
                    dr["NoRecord"] = "106";
                    dt1.Rows.Add(dr);
                    ds1.Tables.Add(dt1);
                    ds1.Tables[0].TableName = "Table";
                    xmlData = new XmlDataDocument(ds1);
                    return xmlData;
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
            }
            return xmlData;
        }

        #endregion

        #region INSERT FUND DETAILS
        [WebMethod(Description = "WEB METHOD FOR INSERT FUND DETAILS")]  // ADD NEW METHOD 19.12.2016
        public string InsertFundDetails(string fundData)
        {
            string returnString = string.Empty;
            string usrMobileNumber = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                XmlReader reader = XmlReader.Create(new StringReader(fundData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        //string[] uregid = usrMobileNumber.Split('$');
                        //usrMobileNumber = objenc.DecryptInteger(uregid[0], uregid[1]);

                        string mobID = ds.Tables[0].Rows[i]["Id"].ToString();
                        cmd.CommandText = "uspInsertFundDetails";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@serverId", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["ServerId"].ToString();
                        cmd.Parameters.Add("@date", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["Date"].ToString();
                        cmd.Parameters.Add("@fromWhom", SqlDbType.NVarChar, 100).Value = ds.Tables[0].Rows[i]["From"].ToString();
                        cmd.Parameters.Add("@fundType", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["FundType"].ToString();
                        cmd.Parameters.Add("@amount", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["Ammount"].ToString();
                        cmd.Parameters.Add("@paidBy", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["PaidBy"].ToString();
                        cmd.Parameters.Add("@checkNo", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["ChequeNo"].ToString();
                        cmd.Parameters.Add("@providerBankName", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["ProviderBankName"].ToString();
                        cmd.Parameters.Add("@providerName", SqlDbType.NVarChar, 100).Value = ds.Tables[0].Rows[i]["ProviderName"].ToString();
                        cmd.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = ds.Tables[0].Rows[i]["Address"].ToString();
                        cmd.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = ds.Tables[0].Rows[i]["MobNo"].ToString();
                        cmd.Parameters.Add("@imeiNo", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        cmd.Parameters.Add("@createdDate", SqlDbType.NVarChar, 20).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["CreatedBy"].ToString();
                        cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;


                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        string MaxId = cmd.Parameters["@maxID"].Value.ToString();
                        returnString += mobID + "*" + MaxId + "#";
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
            finally
            {
                cmd.Connection.Close();
            }
        }
        #endregion

        #region UPDATE COMPLAINT TRANSECTION DATA
        [WebMethod(Description = "WEB METHOD FOR UPDATE COMPLAINT OBJECTION TRANSECTION DATA")]  // ADD NEW METHOD 17.12.2016
        public string UpdateObjectioTxnData(string objTxnData)
        {
            string returnString = string.Empty;
            string usrMobileNumber = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                int count;
                XmlReader reader = XmlReader.Create(new StringReader(objTxnData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string Id = string.Empty;
                        try { Id = ds.Tables[0].Rows[i][0].ToString(); }
                        catch { Id = "0"; }

                        string payUId = string.Empty;
                        try { payUId = ds.Tables[0].Rows[i][1].ToString(); }
                        catch { payUId = "0"; }

                        string PayUTxnId = string.Empty;
                        try { PayUTxnId = ds.Tables[0].Rows[i][2].ToString(); }
                        catch { PayUTxnId = "0"; }

                        string TxnId = string.Empty;
                        try { TxnId = ds.Tables[0].Rows[i][3].ToString(); }
                        catch { TxnId = "0"; }

                        string BankTxnId = string.Empty;
                        try { BankTxnId = ds.Tables[0].Rows[i][4].ToString(); }
                        catch { BankTxnId = "0"; }

                        string Amount = string.Empty;
                        try { Amount = ds.Tables[0].Rows[i][5].ToString(); }
                        catch { Amount = "0"; }

                        string payUtxnId2 = string.Empty;
                        try { payUtxnId2 = ds.Tables[0].Rows[i][6].ToString(); }
                        catch { payUtxnId2 = "0"; }

                        string SERVERID = string.Empty;
                        try { SERVERID = ds.Tables[0].Rows[i][7].ToString(); }
                        catch { SERVERID = "0"; }

                        string MobileNo = string.Empty;
                        try { MobileNo = ds.Tables[0].Rows[i][8].ToString(); }
                        catch { MobileNo = "0"; }

                        cmd.CommandText = "uspUpdateComplaint";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@serverId", SqlDbType.NVarChar, 12).Value = SERVERID;
                        cmd.Parameters.Add("@payUId", SqlDbType.NVarChar, 20).Value = payUId;
                        cmd.Parameters.Add("@PayUTxnId", SqlDbType.NVarChar, 20).Value = PayUTxnId;
                        cmd.Parameters.Add("@TxnId", SqlDbType.NVarChar, 20).Value = TxnId;
                        cmd.Parameters.Add("@BankTxnId", SqlDbType.NVarChar).Value = BankTxnId;
                        cmd.Parameters.Add("@Amount", SqlDbType.NVarChar).Value = Amount;
                        cmd.Parameters.Add("@payUtxnId2", SqlDbType.NVarChar, 20).Value = payUtxnId2;
                        cmd.Parameters.Add("@modifyDate", SqlDbType.NVarChar, 20).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@modifyBy", SqlDbType.NVarChar, 15).Value = MobileNo;
                        cmd.Parameters.Add("@maxID", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;

                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        string MaxId = cmd.Parameters["@maxID"].Value.ToString();
                        returnString += SERVERID + "#";
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

        #region UPDATE VOTEROBJECTION ISCORRECT //METHOD PREPARED BY SURAJ MANE 31-12-2016 UPDATED 2-1-2017
        [WebMethod(Description = "UPDATE ISCORRECT STATUS")]
        public string UpdateVoterObjIsCorrect(string dataIsCorrect)
        {
            try
            {
                string[] str = null;
                string status = string.Empty;
                string serverID = string.Empty;
                string IsCorrect = string.Empty;
                string Latitude = string.Empty;
                string Longitude = string.Empty;
                string MobileNo = string.Empty;
                string IsCorRefMobNo = string.Empty;
                string createdDate = System.DateTime.Now.ToString("yyyy-MM-dd");

                str = dataIsCorrect.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 6)
                {
                    try
                    {
                        serverID = str[i].ToString().Trim();
                        IsCorrect = str[i + 1].ToString().Trim();
                        Latitude = str[i + 2].ToString().Trim();
                        Longitude = str[i + 3].ToString().Trim();
                        MobileNo = str[i + 4].ToString().Trim();
                        IsCorRefMobNo = str[i + 5].ToString().Trim();
                        string sql2 = "UPDATE [TrueVoterDB].[dbo].[tblComplaint] SET [IsCorrect]='" + IsCorrect + "',[IsCorLatitude]='" + Latitude + "',[IsCorLongitude]='" + Longitude + "',[IsCorrectedBy]='" + MobileNo + "',[IsCorrectedDate]='" + createdDate + "',[IsCorRefMobNo]='" + IsCorRefMobNo + "' WHERE [ID]='" + serverID + "'";
                        string ust = Convert.ToString(commonCode.ExecuteNonQuery(sql2));
                        status += ust + "*" + serverID + "#";
                    }
                    catch
                    {
                        status += "0" + "*" + serverID + "#";
                    }
                }
                return status;
            }
            catch
            {
                return "0";
            }
        }
        #endregion

        #region UPDATE VOTEROBJECTION ISAPPROVE //METHOD PREPARED BY SURAJ MANE 31-12-2016 UPDATED 2-1-2017
        [WebMethod(Description = "UPDATE ISAPPROVE STATUS")]
        public string UpdateVoterObjIsApprove(string dataIsApprove)
        {
            try
            {
                string[] str = null;
                string status = string.Empty;
                string serverID = string.Empty;
                string IsApprove = string.Empty;
                string Latitude = string.Empty;
                string Longitude = string.Empty;
                string MobileNo = string.Empty;
                string IsAppRefMobNo = string.Empty;
                string createdDate = System.DateTime.Now.ToString("yyyy-MM-dd");

                str = dataIsApprove.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 6)
                {
                    try
                    {
                        serverID = str[i].ToString().Trim();
                        IsApprove = str[i + 1].ToString().Trim();
                        Latitude = str[i + 2].ToString().Trim();
                        Longitude = str[i + 3].ToString().Trim();
                        MobileNo = str[i + 4].ToString().Trim();
                        IsAppRefMobNo = str[i + 5].ToString().Trim();
                        string sql2 = "UPDATE [TrueVoterDB].[dbo].[tblComplaint] SET [IsApprove]='" + IsApprove + "',[IsAppLatitude]='" + Latitude + "',[IsAppLongitude]='" + Longitude + "',[IsApproveBy]='" + MobileNo + "',[IsApproveDate]='" + createdDate + "',[IsAppRefMobNo]='" + IsAppRefMobNo + "' WHERE [ID]='" + serverID + "'";
                        string ust = Convert.ToString(commonCode.ExecuteNonQuery(sql2));
                        status += ust + "*" + serverID + "#";
                    }
                    catch
                    {
                        status += "0" + "*" + serverID + "#";
                    }
                }
                return status;
            }
            catch
            {
                return "0";
            }
        }
        #endregion

        #region DOWNLOAD OBJECTION/COMPLAINTS WITH ISAPPROVED DATA 21 ROLE
        [WebMethod(Description = "DOWNLOAD ELECTION OBJECTION/COMPLAINTS ISAPPROVED")]
        public XmlDocument DownloadComplaintObjeIsApp(string districtId, string localBody, string localBodyID, string maxServerId, string mobileNo)
        {
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();

            try
            {
                #region tablecolumn
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dt.Columns.Add(new DataColumn("Name", typeof(string)));
                dt.Columns.Add(new DataColumn("EmailID", typeof(string)));
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBody", typeof(string)));
                dt.Columns.Add(new DataColumn("LocalBodyID", typeof(string)));
                dt.Columns.Add(new DataColumn("ComplaintType", typeof(string)));
                dt.Columns.Add(new DataColumn("ACNo", typeof(string)));
                dt.Columns.Add(new DataColumn("PARTNo", typeof(string)));
                dt.Columns.Add(new DataColumn("SRNo", typeof(string)));
                dt.Columns.Add(new DataColumn("VoterName", typeof(string)));
                dt.Columns.Add(new DataColumn("VoterMoNo", typeof(string)));
                dt.Columns.Add(new DataColumn("ObjectionType", typeof(string)));
                dt.Columns.Add(new DataColumn("Remark", typeof(string)));
                dt.Columns.Add(new DataColumn("Latitude", typeof(string)));
                dt.Columns.Add(new DataColumn("Longitude", typeof(string)));
                dt.Columns.Add(new DataColumn("CreatedDate", typeof(string)));
                dt.Columns.Add(new DataColumn("ExpectedWard", typeof(string)));
                dt.Columns.Add(new DataColumn("DocID", typeof(string)));
                dt.Columns.Add(new DataColumn("PayUID", typeof(string)));
                dt.Columns.Add(new DataColumn("PayUTxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("TxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("BankTxnID", typeof(string)));
                dt.Columns.Add(new DataColumn("Amount", typeof(string)));
                dt.Columns.Add(new DataColumn("PayUTxnID2", typeof(string)));
                dt.Columns.Add(new DataColumn("IsVerified", typeof(string)));
                dt.Columns.Add(new DataColumn("IsCorrect", typeof(string)));
                dt.Columns.Add(new DataColumn("IsApprove", typeof(string)));

                cmd.CommandText = "uspDownloadObjComplIsApp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                cmd.Parameters.AddWithValue("@localBody", localBody.Trim());
                cmd.Parameters.AddWithValue("@localBodyID", localBodyID.Trim());
                cmd.Parameters.AddWithValue("@mobileNo", mobileNo.Trim());
                cmd.Parameters.AddWithValue("@maxServerId", maxServerId.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string ID = string.Empty;
                        ID = ds.Tables[0].Rows[i][0].ToString();

                        string usrmobileNo = string.Empty;
                        try { usrmobileNo = ds.Tables[0].Rows[i][1].ToString(); }
                        catch { usrmobileNo = "0"; }
                        if (usrmobileNo == "NULL" || usrmobileNo == "") { usrmobileNo = "0"; }

                        string name = string.Empty;
                        try { name = ds.Tables[0].Rows[i][2].ToString(); }
                        catch { name = "0"; }
                        if (name == "NULL" || name == "") { name = "0"; }

                        string emailID = string.Empty;
                        try { emailID = ds.Tables[0].Rows[i][3].ToString(); }
                        catch { emailID = "0"; }
                        if (emailID == "NULL" || emailID == "") { emailID = "0"; }

                        string distId = string.Empty;
                        try { distId = ds.Tables[0].Rows[i][4].ToString(); }
                        catch { distId = "0"; }
                        if (distId == "NULL" || distId == "") { distId = "0"; }

                        string localBodytbl = string.Empty;
                        try { localBodytbl = ds.Tables[0].Rows[i][5].ToString(); }
                        catch { localBodytbl = "0"; }
                        if (localBodytbl == "NULL" || localBodytbl == "") { localBodytbl = "0"; }

                        string localBodyIDtbl = string.Empty;
                        try { localBodyIDtbl = ds.Tables[0].Rows[i][6].ToString(); }
                        catch { localBodyIDtbl = "0"; }
                        if (localBodyIDtbl == "NULL" || localBodyIDtbl == "") { localBodyIDtbl = "0"; }

                        string complaintType = string.Empty;
                        try { complaintType = ds.Tables[0].Rows[i][7].ToString(); }
                        catch { complaintType = "0"; }
                        if (complaintType == "NULL" || complaintType == "") { complaintType = "0"; }

                        string longitude = string.Empty;
                        try { longitude = ds.Tables[0].Rows[i][8].ToString(); }
                        catch { longitude = "0"; }
                        if (longitude == "NULL" || longitude == "") { longitude = "0"; }

                        string aCNo = string.Empty;
                        try { aCNo = ds.Tables[0].Rows[i][9].ToString(); }
                        catch { aCNo = "0"; }
                        if (aCNo == "NULL" || aCNo == "") { aCNo = "0"; }

                        string pARTNo = string.Empty;
                        try { pARTNo = ds.Tables[0].Rows[i][10].ToString(); }
                        catch { pARTNo = "0"; }
                        if (pARTNo == "NULL" || pARTNo == "") { pARTNo = "0"; }

                        string sRNo = string.Empty;
                        try { sRNo = ds.Tables[0].Rows[i][11].ToString(); }
                        catch { sRNo = "0"; }
                        if (sRNo == "NULL" || sRNo == "") { sRNo = "0"; }

                        string voterName = string.Empty;
                        try { voterName = ds.Tables[0].Rows[i][12].ToString(); }
                        catch { voterName = "0"; }
                        if (voterName == "NULL" || voterName == "") { voterName = "0"; }

                        string voterMoNo = string.Empty;
                        try { voterMoNo = ds.Tables[0].Rows[i][13].ToString(); }
                        catch { voterMoNo = "0"; }
                        if (voterMoNo == "NULL" || voterMoNo == "") { voterMoNo = "0"; }

                        string objectionType = string.Empty;
                        try { objectionType = ds.Tables[0].Rows[i][14].ToString(); }
                        catch { objectionType = "0"; }
                        if (objectionType == "NULL" || objectionType == "") { objectionType = "0"; }

                        string remark = string.Empty;
                        try { remark = ds.Tables[0].Rows[i][15].ToString(); }
                        catch { remark = "0"; }
                        if (remark == "NULL" || remark == "") { remark = "0"; }

                        string latitude = string.Empty;
                        try { latitude = ds.Tables[0].Rows[i][16].ToString(); }
                        catch { latitude = "0"; }
                        if (latitude == "NULL" || latitude == "") { latitude = "0"; }

                        string createdDate = string.Empty;
                        try { createdDate = ds.Tables[0].Rows[i][17].ToString(); }
                        catch { createdDate = "0"; }
                        if (createdDate == "NULL" || createdDate == "") { createdDate = "0"; }

                        string ExpectedWard = string.Empty;
                        try { ExpectedWard = ds.Tables[0].Rows[i][18].ToString(); }
                        catch { ExpectedWard = "0"; }
                        if (ExpectedWard == "NULL" || ExpectedWard == "") { ExpectedWard = "0"; }

                        string DocId = string.Empty;
                        try { DocId = ds.Tables[0].Rows[i][19].ToString(); }
                        catch { DocId = "0"; }
                        if (DocId == "NULL" || DocId == "") { DocId = "0"; }

                        string PayUID = string.Empty;
                        try { PayUID = ds.Tables[0].Rows[i][20].ToString(); }
                        catch { PayUID = "0"; }
                        if (PayUID == "NULL" || PayUID == "") { PayUID = "0"; }

                        string PayUTxnID = string.Empty;
                        try { PayUTxnID = ds.Tables[0].Rows[i][21].ToString(); }
                        catch { PayUTxnID = "0"; }
                        if (PayUTxnID == "NULL" || PayUTxnID == "") { PayUTxnID = "0"; }

                        string TxnID = string.Empty;
                        try { TxnID = ds.Tables[0].Rows[i][22].ToString(); }
                        catch { TxnID = "0"; }
                        if (TxnID == "NULL" || TxnID == "") { TxnID = "0"; }

                        string BankTxnID = string.Empty;
                        try { BankTxnID = ds.Tables[0].Rows[i][23].ToString(); }
                        catch { BankTxnID = "0"; }
                        if (BankTxnID == "NULL" || BankTxnID == "") { BankTxnID = "0"; }

                        string Amount = string.Empty;
                        try { Amount = ds.Tables[0].Rows[i][24].ToString(); }
                        catch { Amount = "0"; }
                        if (Amount == "NULL" || Amount == "") { Amount = "0"; }

                        string PayUTxnID2 = string.Empty;
                        try { PayUTxnID2 = ds.Tables[0].Rows[i][25].ToString(); }
                        catch { PayUTxnID2 = "0"; }
                        if (PayUTxnID2 == "NULL" || PayUTxnID2 == "") { PayUTxnID2 = "0"; }

                        string IsVerified = string.Empty;
                        try { IsVerified = ds.Tables[0].Rows[i][26].ToString(); }
                        catch { IsVerified = "0"; }
                        if (IsVerified == "NULL" || IsVerified == "") { IsVerified = "0"; }

                        string isCorrect = string.Empty;
                        try { isCorrect = ds.Tables[0].Rows[i][27].ToString(); }
                        catch { isCorrect = "0"; }
                        if (isCorrect == "NULL" || isCorrect == "") { isCorrect = "0"; }

                        string isApprove = string.Empty;
                        try { isApprove = ds.Tables[0].Rows[i][28].ToString(); }
                        catch { isApprove = "0"; }
                        if (isApprove == "NULL" || isApprove == "") { isApprove = "0"; }

                #endregion
                        dt.Rows.Add(ID, usrmobileNo, name, emailID, distId, localBodytbl, localBodyIDtbl, complaintType, aCNo, pARTNo, sRNo, voterName, voterMoNo, objectionType, remark, latitude, longitude, createdDate, ExpectedWard, DocId, PayUID, PayUTxnID, TxnID, BankTxnID, Amount, PayUTxnID2, IsVerified, isCorrect, isApprove);
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

      

    }
}

