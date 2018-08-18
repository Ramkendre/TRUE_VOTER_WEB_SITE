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

    public class ExpenseManagement : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        EncDecArrayClass objenc = new EncDecArrayClass();
        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();

        string[] mesuringUnit = { "Select Unit", "Rs.PerSq.Feet", "Rs.PerDay", "Rs" };
        string[] electionType = { "Select LocalBody", "Municipal Corpooration", "Municipal Council", "Nagar Panchayat", "Zilla Parishad", "Panchayat Samiti" };
        string[] applicableFor = { "Select", "Candidate", "Party", "Both" };
        //string[] candidateRole = { "Select", "Voter", "Chairman", "WardMember", "Representative", "PartyOfficer" };
        string[] candidateRoleNew = { "Select", "Chairman", "WardMember", "Representative", "PartyOfficer" };


        #region DOWNLOAD EXPENSE MASTER

        [WebMethod(Description = "Download Expense Type")]
        public string DownloadExpenseType()
        {
            string id = string.Empty;
            string name = string.Empty;
            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT [EID],[ExpenseType] FROM [TrueVoterDB].[dbo].[tblExpenseType](NOLOCK)";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i]["EID"].ToString();
                        name = ds.Tables[0].Rows[i]["ExpenseType"].ToString();

                        returnString += id + "*" + name + "#";
                    }
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

        [WebMethod(Description = "Download Sub Expense Type")]
        public string DownloadSubExpenseType(string distID)
        {
            string returnString = string.Empty;
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "uspDownloadSubExpenseType";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@districtId", SqlDbType.NVarChar, 10).Value = distID;
                cmd.Parameters.Add("@mainRetString", SqlDbType.NVarChar, 100000).Direction = ParameterDirection.Output;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                returnString = cmd.Parameters["@mainRetString"].Value.ToString();

                if (returnString == "0" || returnString == null)
                    returnString = "0";

                return returnString;
            }
            catch
            {
                return "0";
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        #endregion

        //#region INSERT DATA TO EXPENSE MASTER TABLE
        //[WebMethod(Description = "INSERT DATA TO EXPENSE MASTER TABLE")]
        //public string InsertExpenseMaster(string ExpenseMasterData)
        //{
        //    string returnString = string.Empty;
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        string returnvalue = string.Empty;
        //        int count;

        //        string curdt = System.DateTime.Now.ToString();
        //        XmlReader reader = XmlReader.Create(new StringReader(ExpenseMasterData));
        //        ds.ReadXml(reader);
        //        count = ds.Tables[0].Rows.Count;

        //        if (count > 0)
        //        {
        //            for (int i = 0; i < count; i++)
        //            {
        //                if (ds.Tables[0].Rows[i]["ServerId"].ToString() == "0")
        //                {
        //                    string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[tblExpenseMaster] ([ExpenseType],[SubExpenseType],[ApplicableFor],[MeasuringUnit],[ElectionType],[StandardRate],[Description],[IMEINumber],[InsertBy],[InsertDate]) " +
        //                                       "VALUES ('" + Convert.ToInt32(ds.Tables[0].Rows[i]["ExpenseHead"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["SubExpenseHead"]) + "'," + Convert.ToInt32(ds.Tables[0].Rows[i]["District"]) + "," + Convert.ToInt32(ds.Tables[0].Rows[i]["MeasuringUnit"]) + ",'0','" + ds.Tables[0].Rows[i]["StandardRate"].ToString() + "',N'" + ds.Tables[0].Rows[i]["Description"].ToString() + "','" + ds.Tables[0].Rows[i]["IMEI"].ToString() + "','" + ds.Tables[0].Rows[i]["InsertedBy"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";

        //                    commonCode.ExecuteNonQuery(sqlInsert);

        //                    string sqlMaxId = "SELECT MAX(Id) FROM [TrueVoterDB].[dbo].[tblExpenseMaster](NOLOCK)";
        //                    string MaxId = commonCode.ExecuteScalar(sqlMaxId);
        //                    returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            returnString = "0";
        //        }
        //        return returnString;
        //    }
        //    catch
        //    {
        //        return "0";
        //    }

        //}
        //#endregion

        //#region  INSERT DATA OF CANDIDATE DAILY EXPENSES
        //[WebMethod(Description = "METHOD TO INSERT DAILY EXPENSES BY CANDIDATE OR OTHERS")]
        //public string InsertDailyExpenses(string insertExpenses)
        //{
        //    string returnString = string.Empty;
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        //XmlReader xmlFile;
        //        string returnvalue = string.Empty;
        //        string checkNo = string.Empty;
        //        string checkDate = string.Empty;
        //        int count;

        //        string curdt = System.DateTime.Now.ToString();
        //        XmlReader reader = XmlReader.Create(new StringReader(insertExpenses));
        //        ds.ReadXml(reader);
        //        count = ds.Tables[0].Rows.Count;

        //        if (count > 0)
        //        {
        //            for (int i = 0; i < count; i++)
        //            {
        //                if (ds.Tables[0].Rows[i]["PaymentMode"].ToString() == "Cheq")
        //                {
        //                    checkNo = ds.Tables[0].Rows[i]["Cheque"].ToString();
        //                    checkDate = "1991-12-12";
        //                }
        //                string sqlInsert = string.Empty;
        //                int isApprovedV = 0;
        //                if (ds.Tables[0].Rows[i]["REFNO"].ToString() == "0")
        //                {
        //                    isApprovedV = 1;
        //                }

        //                sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[tblDailyExpenses] ([Date],[ExpenseType],[SubExpenseType],[Qty_Size_Area],[Rate],[TotalExpense]," +
        //                "[PaymentMode],[ChequeNo],[ChequeDate],[PaidAmount],[InvoiceNo],[FirmName],[FirmOwnerMobNo],[IMEINumber],[InsertDate],[InsertBy],[Unit],[PaymentType]," +
        //                "[StandardRate],[BalancePayment],[SourceOfExpense],[PartyName],[PartyNo],[CandidateRole],[CandidateRoleName],[CandidateDistrict],[LocalBodyType]," +
        //                "[LocalBodyNameID],[WardNo],[ReffrenceMobile],[IsApproved]) "
        //                + "VALUES ('" + Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["ExpenseType"]) + "'" +
        //                ",'" + Convert.ToInt32(ds.Tables[0].Rows[i]["SubExpenseType"]) + "','" + ds.Tables[0].Rows[i]["Area"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["YourRate"].ToString() + "','" + ds.Tables[0].Rows[i]["TotalExpenses"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["PaymentMode"].ToString() + "','" + checkNo + "','" + checkDate + "','" + ds.Tables[0].Rows[i]["Ammount"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["Invoice"].ToString() + "',N'" + ds.Tables[0].Rows[i]["FirmName"].ToString() + "',N'" + ds.Tables[0].Rows[i]["FirmOwnerNumber"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["IMEI"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ds.Tables[0].Rows[i]["InsertedBy"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["Unit"].ToString() + "','" + ds.Tables[0].Rows[i]["PaymentType"].ToString() + "','" + ds.Tables[0].Rows[i]["StandardRate"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["BalancePayment"].ToString() + "',N'" + ds.Tables[0].Rows[i]["SourceOfExpense"].ToString() + "',N'" + ds.Tables[0].Rows[i]["PartyName"].ToString() + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["PartyNo"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateRole"]) + "'" +
        //                ",'" + ds.Tables[0].Rows[i]["CandidateRoleName"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateDistrict"]) + "'" +
        //                ",'" + Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateLocalBodyType"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateLocalBodyId"]) + "'" +
        //                ",'" + Convert.ToInt32(ds.Tables[0].Rows[i]["WardNo"]) + "','" + ds.Tables[0].Rows[i]["REFNO"].ToString() + "'," + isApprovedV + ")";

        //                commonCode.ExecuteNonQuery(sqlInsert);

        //                string sqlMaxId = "SELECT MAX(PK_Id) FROM [TrueVoterDB].[dbo].[tblDailyExpenses](NOLOCK)";
        //                string MaxId = commonCode.ExecuteScalar(sqlMaxId);
        //                returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";
        //            }
        //        }
        //        else
        //        {
        //            returnString = "0";
        //        }

        //        return returnString;
        //    }
        //    catch
        //    {
        //        return returnString;
        //    }
        //}
        //#endregion

        #region DOWNLOAD DAILY EXPENSE

        [WebMethod(Description = "DOWNLOAD DAILY EXPENSE")]
        public string DownloadDailyExpenses(string mobileNo, string insertDate)
        {
            try
            {
                string userMobile = string.Empty;
                string[] uregid = mobileNo.Split('$');
                userMobile = objenc.DecryptInteger(uregid[0], uregid[1]);

                //  userMobile = mobileNo;

                string pk_Id = string.Empty;
                string inDate = string.Empty;
                string expenseType = string.Empty;
                string subExpenseType = string.Empty;
                string qty_Size_Area = string.Empty;
                string rate = string.Empty;
                string totalExpense = string.Empty;
                string paymentMode = string.Empty;
                string chequeNo = string.Empty;
                string chequeDate = string.Empty;
                string paidAmount = string.Empty;
                string invoiceNo = string.Empty;
                string firmName = string.Empty;
                string firmOwnerMobNo = string.Empty;
                string imelNo = string.Empty;
                string insertBy = string.Empty;
                string unit = string.Empty;
                string paymentType = string.Empty;
                string standardRate = string.Empty;
                string balancePayment = string.Empty;
                string sourceOfExpense = string.Empty;
                string partyName = string.Empty;
                string partyNo = string.Empty;
                string usrName = string.Empty;
                string dateValue = string.Empty;

                string candidateRole = string.Empty;
                string candidateRoleName = string.Empty;
                string candidateDistrict = string.Empty;
                string localBodyType = string.Empty;
                string localBodyNameID = string.Empty;
                string wardNo = string.Empty;
                string refference = string.Empty;

                string returnString = string.Empty;


                string sqlSelect = "SELECT DE.[PK_Id],DE.[Date],DE.[ExpenseType],DE.[SubExpenseType],DE.[Qty_Size_Area],DE.[Rate],DE.[TotalExpense],DE.[PaymentMode],DE.[ChequeNo]" +
                    ",DE.[ChequeDate],DE.[PaidAmount],DE.[InvoiceNo],DE.[FirmName],DE.[FirmOwnerMobNo],DE.[IMEINumber],DE.[InsertDate],DE.[InsertBy]" +
                    ",DE.[Unit],DE.[PaymentType],DE.[StandardRate],DE.[BalancePayment],DE.[SourceOfExpense]" +
                    ",DE.[PartyName],DE.[PartyNo],DE.[CandidateRole],DE.[CandidateRoleName],DE.[CandidateDistrict],DE.[LocalBodyType],DE.[LocalBodyNameID],DE.[WardNo],DE.[ReffrenceMobile] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] AS DE " +
                    " WHERE (DE.[InsertBy]='" + userMobile + "' OR DE.[ReffrenceMobile] ='" + userMobile + "') AND DE.[Date]='" + insertDate + "' AND DE.[IsApproved] = 1" +
                    " SELECT ([Name]+' '+[LName]) AS UsrName FROM [TrueVoterDB].[dbo].[Logins] WHERE [MobileNo]='" + userMobile + "'";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        pk_Id = ds.Tables[0].Rows[i]["PK_Id"].ToString();
                        dateValue = ds.Tables[0].Rows[i]["Date"].ToString();
                        expenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                        subExpenseType = ds.Tables[0].Rows[i]["SubExpenseType"].ToString();
                        qty_Size_Area = ds.Tables[0].Rows[i]["Qty_Size_Area"].ToString();
                        rate = ds.Tables[0].Rows[i]["Rate"].ToString();
                        totalExpense = ds.Tables[0].Rows[i]["TotalExpense"].ToString();
                        paymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                        chequeNo = ds.Tables[0].Rows[i]["ChequeNo"].ToString();
                        chequeDate = ds.Tables[0].Rows[i]["ChequeDate"].ToString();
                        paidAmount = ds.Tables[0].Rows[i]["PaidAmount"].ToString();
                        invoiceNo = ds.Tables[0].Rows[i]["InvoiceNo"].ToString();
                        firmName = ds.Tables[0].Rows[i]["FirmName"].ToString();
                        firmOwnerMobNo = ds.Tables[0].Rows[i]["FirmOwnerMobNo"].ToString();
                        imelNo = ds.Tables[0].Rows[i]["IMEINumber"].ToString();
                        insertDate = ds.Tables[0].Rows[i]["InsertDate"].ToString();
                        insertBy = ds.Tables[0].Rows[i]["InsertBy"].ToString();
                        unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                        paymentType = ds.Tables[0].Rows[i]["PaymentType"].ToString();
                        standardRate = ds.Tables[0].Rows[i]["StandardRate"].ToString();
                        balancePayment = ds.Tables[0].Rows[i]["BalancePayment"].ToString();
                        sourceOfExpense = ds.Tables[0].Rows[i]["SourceOfExpense"].ToString();
                        partyName = ds.Tables[0].Rows[i]["PartyName"].ToString();
                        partyNo = ds.Tables[0].Rows[i]["PartyNo"].ToString();
                        usrName = ds.Tables[1].Rows[0]["UsrName"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();
                        candidateRoleName = ds.Tables[0].Rows[i]["CandidateRoleName"].ToString();
                        candidateDistrict = ds.Tables[0].Rows[i]["CandidateDistrict"].ToString();
                        localBodyType = ds.Tables[0].Rows[i]["LocalBodyType"].ToString();
                        localBodyNameID = ds.Tables[0].Rows[i]["LocalBodyNameID"].ToString();
                        wardNo = ds.Tables[0].Rows[i]["WardNo"].ToString();
                        refference = ds.Tables[0].Rows[i]["ReffrenceMobile"].ToString();

                        returnString += pk_Id + "*" + usrName + "*" + dateValue + "*" + expenseType + "*" + subExpenseType + "*" + qty_Size_Area + "*" + rate + "*" + totalExpense + "*" + paymentMode + "*" + chequeNo + "*" + chequeDate + "*" + paidAmount + "*" + invoiceNo + "*" + firmName + "*" + firmOwnerMobNo + "*" + imelNo + "*" + insertDate + "*" + insertBy + "*" + unit + "*" + paymentType + "*" + standardRate + "*" + balancePayment + "*" + sourceOfExpense + "*" + partyName + "*" + partyNo + "*" + candidateRole + "*" + candidateRoleName + "*" + candidateDistrict + "*" + localBodyType + "*" + localBodyNameID + "*" + wardNo + "*" + refference + "#";
                    }
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
        #endregion

        #region INSERT DATE FOR EXPENSE LIMIT
        [WebMethod(Description = "METHOD INSERT DATE FOR EXPENSE LIMIT")]
        public string InsertExpenseLimit(string ExpenseLimitData)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                string returnvalue = string.Empty;
                int count;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(ExpenseLimitData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[tblExpenseLimit] ([ElectionType], [ElectionTypeName], [CityType], [CityTypeName], [MaxExpenseLimit], [District], [Date], [IMEINo], [InsertedBy], [InsertDate],[ApplicableFor]) " +
                                                           "VALUES (N'" + Convert.ToInt32(ds.Tables[0].Rows[i]["ElectionType"]) + "',N'" + ds.Tables[0].Rows[i]["ElectionTypeName"].ToString() + "'," + Convert.ToInt32(ds.Tables[0].Rows[i]["CityType"]) + "" +
                                                                    ",'" + ds.Tables[0].Rows[i]["CityTypeName"].ToString() + "','" + ds.Tables[0].Rows[i]["MaxExpLimit"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["District"]) + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                                                                    ",'" + ds.Tables[0].Rows[i]["IMEI"].ToString() + "','" + ds.Tables[0].Rows[i]["InsertedBy"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ds.Tables[0].Rows[i]["ApplicableFor"].ToString() + "')";

                        commonCode.ExecuteNonQuery(sqlInsert);

                        string sqlMaxId = "SELECT MAX(ExpLimitID) FROM [TrueVoterDB].[dbo].[tblExpenseLimit](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                        returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";
                    }
                }
                else
                {
                    returnString = "0";
                }

                return returnString;
            }
            catch
            {
                return returnString;
            }
        }
        #endregion

        #region DOWNLOAD EXPENSE MASTER BY DISTRICT ID
        [WebMethod(Description = "DOWNLODE EXPENSE MASTER BY DISTRICT ID")]
        public string DownloadExpenseByDistrict(string DistictID)
        {
            string expenseType = string.Empty;
            string subExpenseType = string.Empty;
            string applicableFor = string.Empty;
            string measuringUnit = string.Empty;
            string standardRate = string.Empty;
            string id = string.Empty;
            string insertBy = string.Empty;
            string discription = string.Empty;
            string insertDate = string.Empty;

            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT [Id],[ExpenseType],[SubExpenseType],[MeasuringUnit],[ApplicableFor],[StandardRate],[InsertBy],[Description],[InsertDate] FROM [TrueVoterDB].[dbo].[tblExpenseMaster](NOLOCK) WHERE [ApplicableFor]='" + DistictID + "' AND IsActive=1 ";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        expenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString().Trim();
                        subExpenseType = ds.Tables[0].Rows[i]["SubExpenseType"].ToString().Trim();
                        measuringUnit = ds.Tables[0].Rows[i]["MeasuringUnit"].ToString().Trim();
                        applicableFor = ds.Tables[0].Rows[i]["ApplicableFor"].ToString().Trim();
                        standardRate = ds.Tables[0].Rows[i]["StandardRate"].ToString().Trim();
                        id = ds.Tables[0].Rows[i]["Id"].ToString().Trim();
                        insertBy = ds.Tables[0].Rows[i]["InsertBy"].ToString().Trim();
                        discription = ds.Tables[0].Rows[i]["Description"].ToString().Trim();
                        insertDate = ds.Tables[0].Rows[i]["InsertDate"].ToString().Trim();
                        returnString += expenseType + "*" + subExpenseType + "*" + measuringUnit + "*" + applicableFor + "*" + standardRate + "*" + id + "*" + insertBy + "*" + discription + "*" + insertDate + "#";
                    }
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

        #endregion

        #region INSERT METHOD FOR OBJECTION
        [WebMethod(Description = "INSERT METHOD FOR OBJECTION")]
        public string InsertObjection(string objectionData)
        {
            try
            {
                string returnString = string.Empty;
                string[] str = null;
                string id = String.Empty;
                string epicId = String.Empty;
                string localBodyType = String.Empty;
                string localBodyName = String.Empty;
                string acNo = String.Empty;
                string partNo = String.Empty;
                string srNoInPart = String.Empty;
                string objectionID = String.Empty;
                string objectionName = String.Empty;
                string remark = String.Empty;
                string mobileNumber = String.Empty;
                string name = String.Empty;
                string photo = String.Empty;
                string latitude = String.Empty;
                string longitude = String.Empty;
                string imeiNo = String.Empty;
                string insertBy = String.Empty;
                string userName = String.Empty;
                string userMNO = string.Empty;
                string keyWord = string.Empty;
                string insertDate = string.Empty;


                str = objectionData.Split(new char[] { '#', '*' });

                for (int i = 0; i < str.Length - 1; i += 21)
                {
                    id = str[i].ToString().Trim();
                    epicId = str[i + 1].ToString().Trim();
                    localBodyType = str[i + 2].ToString().Trim();
                    localBodyName = str[i + 3].ToString().Trim();
                    acNo = str[i + 4].ToString().Trim();
                    partNo = str[i + 5].ToString().Trim();
                    srNoInPart = str[i + 6].ToString().Trim();
                    objectionID = str[i + 7].ToString().Trim();
                    objectionName = str[i + 8].ToString().Trim();
                    remark = str[i + 9].ToString().Trim();
                    mobileNumber = str[i + 10].ToString().Trim();
                    name = str[i + 11].ToString().Trim();
                    photo = str[i + 12].ToString().Trim();
                    latitude = str[i + 13].ToString().Trim();
                    longitude = str[i + 14].ToString().Trim();
                    imeiNo = str[i + 15].ToString().Trim();
                    insertBy = str[i + 16].ToString().Trim();
                    userName = str[i + 17].ToString().Trim();
                    userMNO = str[i + 18].ToString().Trim();
                    keyWord = str[i + 19].ToString().Trim();
                    insertDate = str[i + 20].ToString().Trim();
                    ds.Clear();


                    string sql2 = "INSERT INTO [TrueVoterDB].[dbo].[tblObjection]([EpicId],[LocalBodyType],[LocalBodyName],[AcNo],[PartNo],[SrNoInPart],[ObjectionID],[ObjectionName]" +
                        ",[Remark],[MobileNumber],[Name],[Photo],[Latitude],[Longitude],[IMEI],[InsertBy],[userName],[userMNO],[InsertDate],[Keyword])" +
                        "VALUES ('" + epicId + "','" + localBodyType + "','" + localBodyName + "','" + acNo + "','" + partNo + "','" + srNoInPart + "'," +
                        "'" + objectionID + "','" + objectionName + "',N'" + remark + "','" + mobileNumber + "',N'" + name + "','" + photo + "','" + latitude + "','" + longitude + "'," +
                        "'" + imeiNo + "','" + insertBy + "','" + userName + "','" + userMNO + "','" + insertDate + "','" + keyWord + "')";

                    commonCode.ExecuteNonQuery(sql2);

                    string sqlMaxId = "SELECT MAX(ID) FROM [TrueVoterDB].[dbo].[tblObjection](NOLOCK)";
                    string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                    returnString += id + "*" + MaxId + "#";
                }

                return returnString;
            }
            catch (Exception)
            {
                return "0";
            }
        }
        #endregion

        #region DOWNLOAD DATA OF OBJECTION
        [WebMethod(Description = "DOWNLODE DATA OF OBJECTION")]
        public string DownloadObjections(string localType, string localName)
        {
            string id = String.Empty;
            string epicId = String.Empty;
            string localBodyType = String.Empty;
            string localBodyName = String.Empty;
            string acNo = String.Empty;
            string partNo = String.Empty;
            string srNoInPart = String.Empty;
            string objectionID = String.Empty;
            string objectionName = String.Empty;
            string remark = String.Empty;
            string mobileNumber = String.Empty;
            string name = String.Empty;
            string photo = String.Empty;
            string latitude = String.Empty;
            string longitude = String.Empty;
            string imeiNo = String.Empty;
            string insertBy = String.Empty;
            string userName = String.Empty;
            string userMNO = string.Empty;
            string keyWord = string.Empty;
            string insertDate = string.Empty;

            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT [ID],[EpicId],[LocalBodyType] ,[LocalBodyName],[AcNo],[PartNo],[SrNoInPart],[ObjectionID],[ObjectionName],[Remark],[MobileNumber],[Name],[Latitude]" +
                    ",[Longitude],[IMEI],[userName],[userMNO],[InsertBy],[InsertDate],[Keyword] FROM [TrueVoterDB].[dbo].[tblObjection](NOLOCK) WHERE [LocalBodyType]='" + localType + "' AND [LocalBodyName]='" + localName + "'";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i]["ID"].ToString();
                        epicId = ds.Tables[0].Rows[i]["EpicId"].ToString();
                        localBodyType = ds.Tables[0].Rows[i]["LocalBodyType"].ToString();
                        localBodyName = ds.Tables[0].Rows[i]["LocalBodyName"].ToString();
                        acNo = ds.Tables[0].Rows[i]["AcNo"].ToString();
                        partNo = ds.Tables[0].Rows[i]["PartNo"].ToString();
                        srNoInPart = ds.Tables[0].Rows[i]["SrNoInPart"].ToString();
                        objectionID = ds.Tables[0].Rows[i]["ObjectionID"].ToString();
                        objectionName = ds.Tables[0].Rows[i]["ObjectionName"].ToString();
                        remark = ds.Tables[0].Rows[i]["Remark"].ToString();
                        mobileNumber = ds.Tables[0].Rows[i]["MobileNumber"].ToString();
                        name = ds.Tables[0].Rows[i]["Name"].ToString();
                        latitude = ds.Tables[0].Rows[i]["Latitude"].ToString();
                        longitude = ds.Tables[0].Rows[i]["Longitude"].ToString();
                        imeiNo = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        insertBy = ds.Tables[0].Rows[i]["InsertBy"].ToString();
                        userName = ds.Tables[0].Rows[i]["userName"].ToString();
                        userMNO = ds.Tables[0].Rows[i]["userMNO"].ToString();
                        keyWord = ds.Tables[0].Rows[i]["Keyword"].ToString();
                        insertDate = ds.Tables[0].Rows[i]["InsertDate"].ToString();

                        returnString += id + "*" + epicId + "*" + localBodyType + "*" + localBodyName + "*" + acNo + "*" + partNo + "*" + srNoInPart + "*" + objectionID + "*" + objectionName + "*" + remark + "*" + mobileNumber + "*" + name + "*" + latitude + "*" + longitude + "*" + imeiNo + "*" + insertBy + "*" + userName + "*" + userMNO + "*" + keyWord + "*" + insertDate + "#";
                    }
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

        [WebMethod(Description = "DOWNLODE DATA OF OBJECTION PHOTO BY ID")]
        public string DownloadObjectionsPhoto(string photoServerId)
        {
            string id = string.Empty;
            string photo = string.Empty;
            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT [ID],[Photo] FROM [TrueVoterDB].[dbo].[tblObjection](NOLOCK) WHERE [ID]='" + photoServerId + "'";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        id = ds.Tables[0].Rows[i]["ID"].ToString();
                        photo = ds.Tables[0].Rows[i]["Photo"].ToString();

                        returnString += id + "*" + photo + "#";
                    }
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
        #endregion

        #region INSERT GENERAL EXPENCE OBJECTION
        [WebMethod(Description = "METHOD TO INSERT GENERAL OBJECTION DATA")]
        public string InsertGeneralObjection(string objectionDate)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                //XmlReader xmlFile;
                string returnvalue = string.Empty;
                string checkNo = string.Empty;
                string checkDate = string.Empty;
                int count;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(objectionDate));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string sqlInsert = "INSERT INTO [TrueVoterDB].[dbo].[tblGeneralObjection] ([ServerID],[DistrictID],[LocalBodyType],[LocalBodyName]" +
                                           ",[CandiMobileNo],[WardNo],[UserName],[UserMobileNo],[UserRole],[Designation],[ObjectionDetails],[YourFigure],[ObjectionType],[Imei],[InsertedBy],[InsertedDate],[CandidateRole]) " +
                        "VALUES ('" + Convert.ToInt32(ds.Tables[0].Rows[i]["ServerID"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["DistrictID"]) + "'" +
                                ",'" + Convert.ToInt32(ds.Tables[0].Rows[i]["LocalBodyType"]) + "','" + (ds.Tables[0].Rows[i]["LocalBodyName"]).ToString() + "'" +
                                ",'" + ds.Tables[0].Rows[i]["CandiMobileNo"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[i]["WardNo"]) + "'" +
                                ",'" + ds.Tables[0].Rows[i]["UserName"].ToString() + "','" + ds.Tables[0].Rows[i]["UserMobileNo"].ToString() + "'" +
                                ",'" + ds.Tables[0].Rows[i]["UserRole"].ToString() + "','" + ds.Tables[0].Rows[i]["Designation"].ToString() + "'" +
                                ",N'" + ds.Tables[0].Rows[i]["ObjectionDetails"].ToString() + "','" + ds.Tables[0].Rows[i]["YourFigure"].ToString() + "'" +
                                ",'" + ds.Tables[0].Rows[i]["ObjectionType"].ToString() + "','" + ds.Tables[0].Rows[i]["Imei"].ToString() + "'" +
                                ",'" + ds.Tables[0].Rows[i]["InsertedBy"].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                                ",'" + Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateRole"]) + "')";

                        commonCode.ExecuteNonQuery(sqlInsert);

                        string sqlMaxId = "SELECT MAX(ObjID) FROM [TrueVoterDB].[dbo].[tblGeneralObjection](NOLOCK)";
                        string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                        returnString += ds.Tables[0].Rows[i]["ID"].ToString() + "*" + MaxId + "#";
                    }
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
        #endregion

        #region DOWNLOAD GENERAL EXPENCE OBJECTION
        [WebMethod(Description = "DOWNLOAD DATA OF OBJECTION")]
        public string DownloadGeneralObjections(string localBodyType, string localBodyName)
        {
            string objID = String.Empty;
            string serverID = String.Empty;
            string districtID = String.Empty;
            string localBody = String.Empty;
            string localBodyNm = String.Empty;
            string candiMobileNo = String.Empty;
            string wardNo = String.Empty;
            string userName = String.Empty;
            string userMobileNo = String.Empty;
            string userRole = String.Empty;
            string designation = String.Empty;
            string objectionDetails = String.Empty;
            string yourFigure = String.Empty;
            string objectionType = String.Empty;
            string imei = String.Empty;
            string insertedBy = String.Empty;
            string insertedDate = String.Empty;
            string candidateRole = String.Empty;
            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT [ObjID],[ServerID] ,[DistrictID],[LocalBodyType],[LocalBodyName]," +
                                    "[CandiMobileNo],[WardNo],[UserName],[UserMobileNo],[UserRole],[Designation],[ObjectionDetails],[YourFigure]" +
                                    ",[ObjectionType],[Imei],[InsertedBy],[InsertedDate],[CandidateRole] FROM [TrueVoterDB].[dbo].[tblGeneralObjection](NOLOCK)" +
                                    "WHERE [LocalBodyType]='" + localBodyType + "' AND [LocalBodyName]='" + localBodyName + "'";
                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        objID = ds.Tables[0].Rows[i]["ObjID"].ToString();
                        serverID = ds.Tables[0].Rows[i]["ServerID"].ToString();
                        districtID = ds.Tables[0].Rows[i]["DistrictID"].ToString();
                        localBodyType = ds.Tables[0].Rows[i]["LocalBodyType"].ToString();
                        localBodyName = ds.Tables[0].Rows[i]["LocalBodyName"].ToString();
                        candiMobileNo = ds.Tables[0].Rows[i]["CandiMobileNo"].ToString();
                        wardNo = ds.Tables[0].Rows[i]["WardNo"].ToString();
                        userName = ds.Tables[0].Rows[i]["UserName"].ToString();
                        userMobileNo = ds.Tables[0].Rows[i]["UserMobileNo"].ToString();
                        userRole = ds.Tables[0].Rows[i]["UserRole"].ToString();
                        designation = ds.Tables[0].Rows[i]["Designation"].ToString();
                        objectionDetails = ds.Tables[0].Rows[i]["ObjectionDetails"].ToString();
                        yourFigure = ds.Tables[0].Rows[i]["YourFigure"].ToString();
                        objectionType = ds.Tables[0].Rows[i]["ObjectionType"].ToString();
                        imei = ds.Tables[0].Rows[i]["Imei"].ToString();
                        insertedBy = ds.Tables[0].Rows[i]["InsertedBy"].ToString();
                        insertedDate = ds.Tables[0].Rows[i]["InsertedDate"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();

                        returnString += objID + "*" + serverID + "*" + districtID + "*" + localBodyType + "*" + localBodyName + "*" + candiMobileNo + "*" + wardNo + "*" + userName + "*" + userMobileNo + "*" + userRole + "*" + designation + "*" + objectionDetails + "*" + yourFigure + "*" + objectionType + "*" + imei + "*" + insertedBy + "*" + insertedDate + "*" + candidateRole + "#";
                    }
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
        #endregion

        #region DOWNLOAD DAILY EXPENCES TO CANDIDATE OF HIS REPRESENTATIVES

        [WebMethod(Description = "DOWNLOAD DAILY EXPENCES TO CANDIDATE OF HIS REPRESENTATIVES")]
        public string DownloadDailyExpenseRepresentative(string candidateMobileNumber)
        {
            string userMobile = string.Empty;
            string[] uregid = candidateMobileNumber.Split('$');
            userMobile = objenc.DecryptInteger(uregid[0], uregid[1]);


            string pk_Id = string.Empty;
            string inDate = string.Empty;
            string expenseType = string.Empty;
            string subExpenseType = string.Empty;
            string qty_Size_Area = string.Empty;
            string rate = string.Empty;
            string totalExpense = string.Empty;
            string paymentMode = string.Empty;
            string chequeNo = string.Empty;
            string chequeDate = string.Empty;
            string paidAmount = string.Empty;
            string invoiceNo = string.Empty;
            string firmName = string.Empty;
            string firmOwnerMobNo = string.Empty;
            string imelNo = string.Empty;
            string insertBy = string.Empty;
            string unit = string.Empty;
            string paymentType = string.Empty;
            string standardRate = string.Empty;
            string balancePayment = string.Empty;
            string sourceOfExpense = string.Empty;
            string partyName = string.Empty;
            string partyNo = string.Empty;
            string usrName = string.Empty;
            string dateValue = string.Empty;
            string insertDate = string.Empty;

            string candidateRole = string.Empty;
            string candidateRoleName = string.Empty;
            string candidateDistrict = string.Empty;
            string localBodyType = string.Empty;
            string localBodyNameID = string.Empty;
            string wardNo = string.Empty;
            string refference = string.Empty;

            string returnString = string.Empty;

            try
            {
                string sqlSelect = "SELECT DE.[PK_Id],DE.[Date],DE.[ExpenseType],DE.[SubExpenseType],DE.[Qty_Size_Area],DE.[Rate],DE.[TotalExpense],DE.[PaymentMode],DE.[ChequeNo]" +
                    ",DE.[ChequeDate],DE.[PaidAmount],DE.[InvoiceNo],DE.[FirmName],DE.[FirmOwnerMobNo],DE.[IMEINumber],DE.[InsertDate],DE.[InsertBy]" +
                    ",DE.[Unit],DE.[PaymentType],DE.[StandardRate],DE.[BalancePayment],DE.[SourceOfExpense]" +
                    ",DE.[PartyName],DE.[PartyNo],(L.[Name]+' '+L.[LName]) AS UsrName ,DE.[CandidateRole],DE.[CandidateRoleName],DE.[CandidateDistrict],DE.[LocalBodyType],DE.[LocalBodyNameID],DE.[WardNo],DE.[ReffrenceMobile] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] AS DE " +
                    "INNER JOIN [TrueVoterDB].[dbo].[Logins] AS L ON DE.[InsertBy]=L.[MobileNo] WHERE DE.[ReffrenceMobile]='" + userMobile + "' AND DE.[IsApproved] = 0";

                ds = commonCode.ExecuteDataset(sqlSelect);
                int count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        pk_Id = ds.Tables[0].Rows[i]["PK_Id"].ToString();
                        dateValue = ds.Tables[0].Rows[i]["Date"].ToString();
                        expenseType = ds.Tables[0].Rows[i]["ExpenseType"].ToString();
                        subExpenseType = ds.Tables[0].Rows[i]["SubExpenseType"].ToString();
                        qty_Size_Area = ds.Tables[0].Rows[i]["Qty_Size_Area"].ToString();
                        rate = ds.Tables[0].Rows[i]["Rate"].ToString();
                        totalExpense = ds.Tables[0].Rows[i]["TotalExpense"].ToString();
                        paymentMode = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                        chequeNo = ds.Tables[0].Rows[i]["ChequeNo"].ToString();
                        chequeDate = ds.Tables[0].Rows[i]["ChequeDate"].ToString();
                        paidAmount = ds.Tables[0].Rows[i]["PaidAmount"].ToString();
                        invoiceNo = ds.Tables[0].Rows[i]["InvoiceNo"].ToString();
                        firmName = ds.Tables[0].Rows[i]["FirmName"].ToString();
                        firmOwnerMobNo = ds.Tables[0].Rows[i]["FirmOwnerMobNo"].ToString();
                        imelNo = ds.Tables[0].Rows[i]["IMEINumber"].ToString();
                        insertDate = ds.Tables[0].Rows[i]["InsertDate"].ToString();
                        insertBy = ds.Tables[0].Rows[i]["InsertBy"].ToString();
                        unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                        paymentType = ds.Tables[0].Rows[i]["PaymentType"].ToString();
                        standardRate = ds.Tables[0].Rows[i]["StandardRate"].ToString();
                        balancePayment = ds.Tables[0].Rows[i]["BalancePayment"].ToString();
                        sourceOfExpense = ds.Tables[0].Rows[i]["SourceOfExpense"].ToString();
                        partyName = ds.Tables[0].Rows[i]["PartyName"].ToString();
                        partyNo = ds.Tables[0].Rows[i]["PartyNo"].ToString();
                        usrName = ds.Tables[0].Rows[i]["UsrName"].ToString();
                        candidateRole = ds.Tables[0].Rows[i]["CandidateRole"].ToString();
                        candidateRoleName = ds.Tables[0].Rows[i]["CandidateRoleName"].ToString();
                        candidateDistrict = ds.Tables[0].Rows[i]["CandidateDistrict"].ToString();
                        localBodyType = ds.Tables[0].Rows[i]["LocalBodyType"].ToString();
                        localBodyNameID = ds.Tables[0].Rows[i]["LocalBodyNameID"].ToString();
                        wardNo = ds.Tables[0].Rows[i]["WardNo"].ToString();
                        refference = ds.Tables[0].Rows[i]["ReffrenceMobile"].ToString();

                        returnString += pk_Id + "*" + usrName + "*" + dateValue + "*" + expenseType + "*" + subExpenseType + "*" + qty_Size_Area + "*" + rate + "*" + totalExpense + "*" + paymentMode + "*" + chequeNo + "*" + chequeDate + "*" + paidAmount + "*" + invoiceNo + "*" + firmName + "*" + firmOwnerMobNo + "*" + imelNo + "*" + insertDate + "*" + insertBy + "*" + unit + "*" + paymentType + "*" + standardRate + "*" + balancePayment + "*" + sourceOfExpense + "*" + partyName + "*" + partyNo + "*" + candidateRole + "*" + candidateRoleName + "*" + candidateDistrict + "*" + localBodyType + "*" + localBodyNameID + "*" + wardNo + "*" + refference + "#";
                    }
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

        #endregion

        #region APPROVED DAILY EXPENCES ENTER BY REPRESENTATIVE TO CANDIDATE

        [WebMethod(Description = "APPROVED DAILY EXPENCES ENTER BY REPRESENTATIVE TO CANDIDATE")]
        public string ApprovedDailyExpences(string approvedIds)
        {
            try
            {
                string sqlApproved = "UPDATE [TrueVoterDB].[dbo].[tblDailyExpenses] SET [IsApproved] = 1 WHERE [PK_Id] IN (" + approvedIds + ")";
                commonCode.ExecuteNonQuery(sqlApproved);
                return approvedIds;
            }
            catch
            {
                return "0";
            }
        }

        #endregion

        #region METHOD FOR INSERT SUBEXPENSE TYPE
        [WebMethod(Description = "INSERT METHOD FOR INSERT SUBEXPENSE TYPE ")]
        public string InsertSubExpenseType(string subExpenseData)
        {
            try
            {
                string[] str = null;
                string returnString = String.Empty;
                string id = String.Empty;
                string subExpenseType = String.Empty;
                string expenseId = String.Empty;
                string createdBy = String.Empty;
                string distID = String.Empty;
                string createdDate = String.Empty;

                str = subExpenseData.Split(new char[] { '#', '*' });
                for (int i = 0; i < str.Length - 1; i += 5)
                {
                    id = str[i].ToString().Trim();
                    subExpenseType = str[i + 2].ToString().Trim();
                    expenseId = str[i + 1].ToString().Trim();
                    createdBy = str[i + 3].ToString().Trim();
                    distID = str[i + 4].ToString().Trim();
                    createdDate = System.DateTime.Now.ToString("yyyy-MM-dd");// str[i + 4].ToString().Trim(); 

                    string sql = "INSERT INTO [TrueVoterDB].[dbo].[tblSubExpenseType] ([SubExpenseType],[EID],[InsertBy],[InsertDate],[DistId]) VALUES (N'" + subExpenseType + "','" + expenseId + "','" + createdBy + "','" + createdDate + "','" + distID + "')";

                    commonCode.ExecuteNonQuery(sql);

                    string sqlMaxId = "SELECT MAX(SEID) FROM [TrueVoterDB].[dbo].[tblSubExpenseType](NOLOCK)";
                    string MaxId = commonCode.ExecuteScalar(sqlMaxId);
                    returnString += id + "*" + MaxId + "#";

                }
                return returnString;
            }
            catch
            {
                return "0";
            }
        }
        #endregion


        #region DOWNLOAD ELECTION EXPENSE LIMIT
        [WebMethod(Description = " DOWNLOAD  ELECTION EXPENSE LIMIT")]
        public XmlDocument downloadExpenseLimit(string electionTypeID)//, string applicableForID, string districtId)
        {

            string applicableForID = "0";//string.Empty;
            string districtId = "0";// string.Empty;

            DataTable dt1 = new DataTable();
            string returnString = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds1 = new DataSet();
            XmlDataDocument xmlData = new XmlDataDocument();

            string expLimitID = string.Empty;
            string electionType = string.Empty;
            string electionTypeName = string.Empty;
            string cityType = string.Empty;
            string cityTypeName = string.Empty;
            string maxExpenseLimit = string.Empty;
            string district = string.Empty;
            string date = string.Empty;
            string iMEINo = string.Empty;
            string insertedBy = string.Empty;
            string insertDate = string.Empty;
            string applicableFor = string.Empty;

            try
            {
                dt.Columns.Add(new DataColumn("ExpLimitID", typeof(string)));
                dt.Columns.Add(new DataColumn("ElectionType", typeof(string)));
                dt.Columns.Add(new DataColumn("ElectionTypeName", typeof(string)));
                dt.Columns.Add(new DataColumn("CityType", typeof(string)));
                dt.Columns.Add(new DataColumn("CityTypeName", typeof(string)));
                dt.Columns.Add(new DataColumn("MaxExpenseLimit", typeof(string)));
                dt.Columns.Add(new DataColumn("District", typeof(string)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("IMEINo", typeof(string)));
                dt.Columns.Add(new DataColumn("InsertedBy", typeof(string)));
                dt.Columns.Add(new DataColumn("InsertDate", typeof(string)));
                dt.Columns.Add(new DataColumn("ApplicableFor", typeof(string)));

                cmd.CommandText = "uspDownloadExpenseLimit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@electionTypeID", electionTypeID.Trim());
                cmd.Parameters.AddWithValue("@applicableForID", applicableForID.Trim());
                cmd.Parameters.AddWithValue("@districtId", districtId.Trim());
                da.SelectCommand = cmd;
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        expLimitID = ds.Tables[0].Rows[i][0].ToString();

                        electionType = ds.Tables[0].Rows[i][1].ToString();
                        if (electionType == "NULL" || electionType == "")
                        {
                            electionType = "0";
                        }
                        else
                        {
                            electionType = ds.Tables[0].Rows[i][1].ToString();
                        }

                        electionTypeName = ds.Tables[0].Rows[i][2].ToString();
                        if (electionTypeName == "NULL" || electionTypeName == "")
                        {
                            electionTypeName = "0";
                        }
                        else
                        {
                            electionTypeName = ds.Tables[0].Rows[i][2].ToString();
                        }

                        cityType = ds.Tables[0].Rows[i][3].ToString();
                        if (cityType == "NULL" || cityType == "")
                        {
                            cityType = "0";
                        }
                        else
                        {
                            cityType = ds.Tables[0].Rows[i][3].ToString();
                        }

                        cityTypeName = ds.Tables[0].Rows[i][4].ToString();
                        if (cityTypeName == "NULL" || cityTypeName == "")
                        {
                            cityTypeName = "0";
                        }
                        else
                        {
                            cityTypeName = ds.Tables[0].Rows[i][4].ToString();
                        }

                        maxExpenseLimit = ds.Tables[0].Rows[i][5].ToString();
                        if (maxExpenseLimit == "NULL" || maxExpenseLimit == "")
                        {
                            maxExpenseLimit = "0";
                        }
                        else
                        {
                            maxExpenseLimit = ds.Tables[0].Rows[i][5].ToString();
                        }

                        district = ds.Tables[0].Rows[i][6].ToString();
                        if (district == "NULL" || district == "")
                        {
                            district = "0";
                        }
                        else
                        {
                            district = ds.Tables[0].Rows[i][6].ToString();
                        }

                        date = ds.Tables[0].Rows[i][7].ToString();
                        if (date == "NULL" || date == "")
                        {
                            date = "0";
                        }
                        else
                        {
                            date = ds.Tables[0].Rows[i][7].ToString();
                        }

                        iMEINo = ds.Tables[0].Rows[i][8].ToString();
                        if (iMEINo == "NULL" || iMEINo == "")
                        {
                            iMEINo = "0";
                        }
                        else
                        {
                            iMEINo = ds.Tables[0].Rows[i][8].ToString();
                        }




                        insertedBy = ds.Tables[0].Rows[i][9].ToString();
                        if (insertedBy == "NULL" || insertedBy == "")
                        {
                            insertedBy = "0";
                        }
                        else
                        {
                            insertedBy = ds.Tables[0].Rows[i][9].ToString();
                        }

                        insertDate = ds.Tables[0].Rows[i][10].ToString();
                        if (insertDate == "NULL" || insertDate == "")
                        {
                            insertDate = "0";
                        }
                        else
                        {
                            insertDate = ds.Tables[0].Rows[i][10].ToString();
                        }

                        applicableFor = ds.Tables[0].Rows[i][11].ToString();
                        if (applicableFor == "NULL" || applicableFor == "")
                        {
                            applicableFor = "0";
                        }
                        else
                        {
                            applicableFor = ds.Tables[0].Rows[i][11].ToString();
                        }


                        dt.Rows.Add(expLimitID, electionType, electionTypeName, cityType, cityTypeName, maxExpenseLimit, district, date, iMEINo, insertedBy, insertDate, applicableFor);
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

        #region  INSERT DATA OF CANDIDATE DAILY EXPENSES NEW WITH STORED PROCEDURE
        [WebMethod(Description = "METHOD TO INSERT DAILY EXPENSES BY CANDIDATE OR OTHERS NEW WITH STORED PROCEDURE")]
        public string InsertDailyExpensesNew(string insertExpenses)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                //XmlReader xmlFile;
                string returnvalue = string.Empty;
                string checkNo = string.Empty;
                string checkDate = string.Empty;
                int count;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(insertExpenses));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string id = ds.Tables[0].Rows[i]["Id"].ToString();
                        if (ds.Tables[0].Rows[i]["PaymentMode"].ToString() == "Cheq")
                        {
                            checkNo = ds.Tables[0].Rows[i]["Cheque"].ToString();
                            checkDate = "1991-12-12";
                        }
                        string sqlInsert = string.Empty;
                        int isApprovedV = 0;
                        if (ds.Tables[0].Rows[i]["CandidateRole"].ToString() == "1" || ds.Tables[0].Rows[i]["CandidateRole"].ToString() == "2")
                        {
                            isApprovedV = 1;
                        }
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "uspInsertDailyExpenses";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"]);
                        cmd.Parameters.Add("@expenseType", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["ExpenseType"]);
                        cmd.Parameters.Add("@subExpenseType", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["SubExpenseType"]);
                        cmd.Parameters.Add("@qtySizeArea", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["Area"].ToString();
                        cmd.Parameters.Add("@rate", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["YourRate"].ToString();
                        cmd.Parameters.Add("@totalExpense", SqlDbType.Float).Value = ds.Tables[0].Rows[i]["TotalExpenses"].ToString();
                        cmd.Parameters.Add("@paymentMode", SqlDbType.NVarChar, 150).Value = ds.Tables[0].Rows[i]["PaymentMode"].ToString();
                        cmd.Parameters.Add("@chequeNo", SqlDbType.NVarChar, 20).Value = checkNo;
                        cmd.Parameters.Add("@chequeDate", SqlDbType.NVarChar, 10).Value = checkDate;
                        cmd.Parameters.Add("@paidAmount", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["Ammount"].ToString();
                        cmd.Parameters.Add("@invoiceNumber", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["Invoice"].ToString();
                        cmd.Parameters.Add("@firmName", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["FirmName"].ToString();
                        cmd.Parameters.Add("@firmOwnerMobNo", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["FirmOwnerNumber"].ToString();
                        cmd.Parameters.Add("@imeiNumber", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        cmd.Parameters.Add("@insertDate", SqlDbType.NVarChar, 50).Value = DateTime.Now.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@insertBy", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["InsertedBy"].ToString();
                        cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["Unit"].ToString();
                        cmd.Parameters.Add("@paymentType", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["PaymentType"].ToString();
                        cmd.Parameters.Add("@standardRate", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["StandardRate"].ToString();
                        cmd.Parameters.Add("@balancePayment", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["BalancePayment"].ToString();
                        cmd.Parameters.Add("@sourceOfExpense", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["SourceOfExpense"].ToString();
                        cmd.Parameters.Add("@partyName", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["PartyName"].ToString();
                        cmd.Parameters.Add("@partyNo", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["PartyNo"].ToString();
                        cmd.Parameters.Add("@candidateRole", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateRole"]);
                        cmd.Parameters.Add("@candidateRoleName", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["CandidateRoleName"].ToString();
                        cmd.Parameters.Add("@candidateDistrict", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateDistrict"]);
                        cmd.Parameters.Add("@localBodyType", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateLocalBodyType"]);
                        cmd.Parameters.Add("@localBodyNameId", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["CandidateLocalBodyId"]);
                        cmd.Parameters.Add("@wardNo", SqlDbType.Int).Value = Convert.ToInt32(ds.Tables[0].Rows[i]["WardNo"]);
                        cmd.Parameters.Add("@refMobileNumber", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["REFNO"].ToString();
                        cmd.Parameters.Add("@isApproved", SqlDbType.Int).Value = isApprovedV;
                        cmd.Parameters.Add("@serId", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["serverId"].ToString();

                        cmd.Parameters.Add("@returnValue", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        string MaxId = cmd.Parameters["@returnValue"].Value.ToString();
                        returnString += id + "*" + MaxId + "#";
                    }
                }
                else
                {
                    returnString = "0";
                }

                return returnString;
            }
            catch
            {
                return returnString;
            }
        }
        #endregion

        #region INSERT DATA TO EXPENSE MASTER TABLE NEW WITH STORED PROCEDURE
        [WebMethod(Description = "INSERT DATA TO EXPENSE MASTER TABLE")]
        public string InsertExpenseMaster(string ExpenseMasterData)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                string returnvalue = string.Empty;
                int count;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(ExpenseMasterData));
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string id = ds.Tables[0].Rows[i]["Id"].ToString();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "uspInsertExpenseMaster";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@expenseType", SqlDbType.NVarChar).Value = (ds.Tables[0].Rows[i]["ExpenseHead"]).ToString();
                        cmd.Parameters.Add("@subExpenseType", SqlDbType.NVarChar).Value = (ds.Tables[0].Rows[i]["SubExpenseHead"]).ToString();
                        cmd.Parameters.Add("@applicableFor", SqlDbType.NVarChar).Value = (ds.Tables[0].Rows[i]["District"]).ToString();
                        cmd.Parameters.Add("@measuringUnit", SqlDbType.NVarChar, 50).Value = ds.Tables[0].Rows[i]["MeasuringUnit"].ToString();
                        cmd.Parameters.Add("@electionType", SqlDbType.NVarChar, 50).Value = "0";
                        cmd.Parameters.Add("@standardRate", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["StandardRate"].ToString();
                        cmd.Parameters.Add("@description", SqlDbType.NVarChar, 1000).Value = ds.Tables[0].Rows[i]["Description"].ToString();
                        cmd.Parameters.Add("@iMEINumber", SqlDbType.NVarChar, 20).Value = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        cmd.Parameters.Add("@insertBy", SqlDbType.NVarChar, 10).Value = ds.Tables[0].Rows[i]["InsertedBy"].ToString();
                        cmd.Parameters.Add("@insertDate", SqlDbType.NVarChar, 10).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@serId", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["ServerId"].ToString(); 

                        cmd.Parameters.Add("@returnValue", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

                        if (cmd.Connection.State == ConnectionState.Closed)
                            cmd.Connection.Open();
                        cmd.ExecuteNonQuery();

                        string MaxId = cmd.Parameters["@returnValue"].Value.ToString();
                        returnString += id + "*" + MaxId + "#";
                    }
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
        #endregion

    }
}
