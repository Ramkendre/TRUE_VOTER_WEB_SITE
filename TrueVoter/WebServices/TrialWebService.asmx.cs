using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for TrialWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TrialWebService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlConnection SECcon = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterSECSS"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        TrueVoter.CommonCode commonCode = new TrueVoter.CommonCode();
        [WebMethod]
        public string AddRefferances(string addRefferencesData)
        {
            string returnString = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                int count;
                string sqlQuery = string.Empty;
                string userMobile1 = string.Empty;
                string refMobile1 = string.Empty;
                string userMobile = string.Empty;
                string refMobile = string.Empty;
                string imeiNumber = string.Empty;
                string MaxId = string.Empty;
                string currentDate = string.Empty;
                string voterName = string.Empty;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(addRefferencesData));
                ds.Clear();
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;
                currentDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobile1 = ds.Tables[0].Rows[i]["UserMobileNumber"].ToString();
                        refMobile1 = ds.Tables[0].Rows[i]["MobileNumber"].ToString();
                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        voterName = Convert.ToString(ds.Tables[0].Rows[i]["ReferralName"]);


                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "REPRESENTATIVE" || ds.Tables[0].Rows[i]["Type"].ToString() == "JUNIOR")
                        {
                            userMobile = refMobile1;
                            refMobile = userMobile1;
                        }
                        else
                        {
                            userMobile = userMobile1;
                            refMobile = refMobile1;
                        }

                        string query = "SELECT [UserMobile],[RefMobile],[isActive] FROM [TrueVoterDB].[dbo].[tblAddRefferances] WHERE [UserMobile]='" + userMobile + "' AND [RefMobile] = '" + refMobile + "'";
                        ds2.Clear();
                        ds2 = commonCode.ExecuteDataset(query);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            string query1 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive]='Active',[IMEINumber]='" + imeiNumber + "',[ModifyDate]='" + currentDate + "', [RefName]=N'" + voterName + "',[keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "' WHERE [UserMobile]='" + userMobile + "' AND [RefMobile] = '" + refMobile + "'";
                            commonCode.ExecuteNonQuery(query1);

                            string sqlMaxId = "SELECT PK_Id FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile]='" + userMobile + "' AND [RefMobile] = '" + refMobile + "' ";
                            MaxId = commonCode.ExecuteScalar(sqlMaxId);

                            string query3 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive]='Deactive' ,[ModifyDate]='" + currentDate + "' WHERE [UserMobile]='" + userMobile + "' AND [RefMobile] != '" + refMobile + "'";
                            commonCode.ExecuteNonQuery(query3);
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
                                        if (dscandidateRole.Tables[0].Rows.Count > 0)//Tables[1]
                                        {
                                            candidateRole = dscandidateRole.Tables[0].Rows[0]["CandidateRoleName"].ToString();
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
                        else
                        {
                            sqlQuery = "INSERT INTO [TrueVoterDB].[dbo].[tblAddRefferances] ([UserMobile],[RefMobile],[IMEINumber],[InsertDate],[keyword],[RefName],[isActive])" +
                                       " VALUES ('" + userMobile + "','" + refMobile + "','" + imeiNumber + "','" + currentDate + "','" + ds.Tables[0].Rows[i]["Type"].ToString() + "',N'" + voterName + "','Active')";
                            commonCode.ExecuteNonQuery(sqlQuery);

                            string query3 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive]='Deactive' ,[ModifyDate]='" + currentDate + "' WHERE [UserMobile]='" + userMobile + "' AND [RefMobile] != '" + refMobile + "'";
                            commonCode.ExecuteNonQuery(query3);

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
                                        if (dscandidateRole.Tables[0].Rows.Count > 0)//Tables[1]
                                        {
                                            candidateRole = dscandidateRole.Tables[0].Rows[0]["CandidateRoleName"].ToString();
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
                }
                return returnString;
            }
            catch
            {
                returnString = "0";
                return returnString;
            }
        }


        [WebMethod(Description = "Method to find out Most Senior Person")]
        public string FindMostSeniorPerson(string UserMoNo)
        {
            string RefMoNo = string.Empty;
            string MoNo = string.Empty;
            MoNo = UserMoNo;
            int Level = 0;

        START:
            {
                //string query = "SELECT [RefMobileNo] FROM [TrueVoterDB].[dbo].[Logins] WHERE [UserName] = '" + MoNo.Trim() + "' AND [IsApproved]='1' AND [UserType]='2'";
                //DataSet ds = commonCode.ExecuteDataset(query);
                cmd.Connection = con;
                cmd.CommandText = "uspFindRefrence";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@refMoNo", SqlDbType.NVarChar, 10).Value = MoNo;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MoNo = Convert.ToString(ds.Tables[0].Rows[0]["RefMobileNo"]);
                }
                else
                {
                    MoNo = "0";
                }
                Level += 1;
            }
            if (MoNo == "9821128083")
            {
                return "999";
            }
            else if (MoNo == "" || MoNo == "0")
            {
                Level = Level - 1;
                goto RESULT;
            }
            else
            {
                goto START;
            }

        RESULT:
            {
                return Level.ToString();
            }
        }

        [WebMethod(Description = "METHOD TO FIND CANDIDATE HOW DOES NOT FILL DAILY EXPENSE")]
        public void FindCandidate()
        {
            string MobileNo = string.Empty;
            string msg = string.Empty;
            msg = "Dear Candidate Please Fill The Todays Daily Expense in True Voter App";
            string getDailyExpenseFilledData = "SELECT DISTINCT [InsertBy] FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('1','2') SELECT DISTINCT [ReffrenceMobile]  FROM [TrueVoterDB].[dbo].[tblDailyExpenses] WHERE [Date]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' AND CandidateRole IN('3') ";

            DataSet ds = commonCode.ExecuteDataset(getDailyExpenseFilledData);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MobileNo += "'" + Convert.ToString(ds.Tables[0].Rows[i][0]) + "',";
                }
                for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                {
                    MobileNo += "'" + Convert.ToString(ds.Tables[0].Rows[j][0]) + "',";
                }
            }
            else
            {

            }
            string FinalMoNo = MobileNo.Substring(0, MobileNo.Length - 1);
            string CandidateList = "SELECT DISTINCT[RegMobileNo] FROM [SEC_TV].[dbo].[tblRegistrationWithSymbolID](NOLOCK) WHERE [RegMobileNo] NOT IN (" + FinalMoNo + ")";
            cmd.Connection = SECcon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CandidateList;
            da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    string MoNo = Convert.ToString(ds.Tables[0].Rows[k][0]);
                    //commonCode.SMS(MoNo, msg);
                }
            }
        }
    }
}

