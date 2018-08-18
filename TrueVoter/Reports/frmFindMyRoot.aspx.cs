using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TrueVoter.Reports
{
    public partial class frmFindMyRoot : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        CommonCode commonCode = new CommonCode();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FindRoot(string MobileNo)
        {
            try
            {
                string qry = "SELECT ([Name]+' '+[LName]) AS Name,[RefMobileNo] FROM [TrueVoterDB].[dbo].[Logins] WHERE [UserName]='" + MobileNo + "'";

            }
            catch
            {

            }
        }

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
                string role = string.Empty;
                string roleId = string.Empty;
                string distID = string.Empty;
                string distName = string.Empty;
                string localbodyId = string.Empty;
                string localBodyName = string.Empty;

                string voterName = string.Empty;

                string curdt = System.DateTime.Now.ToString();
                XmlReader reader = XmlReader.Create(new StringReader(addRefferencesData));
                ds.Clear();
                ds.ReadXml(reader);
                count = ds.Tables[0].Rows.Count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        userMobile1 = ds.Tables[0].Rows[i]["UserMobileNumber"].ToString();
                        refMobile1 = ds.Tables[0].Rows[i]["MobileNumber"].ToString();
                        imeiNumber = ds.Tables[0].Rows[i]["IMEI"].ToString();
                        #region trycatch

                        try
                        {
                            role = ds.Tables[0].Rows[i]["Role"].ToString();
                        }
                        catch
                        {
                            role = "0";
                        }

                        try
                        {
                            roleId = ds.Tables[0].Rows[i]["RoleId"].ToString();
                        }
                        catch
                        {
                            roleId = "0";
                        }

                        try
                        {
                            distID = ds.Tables[0].Rows[i]["DistId"].ToString();
                        }
                        catch
                        {
                            distID = "0";
                        }

                        try
                        {
                            distName = ds.Tables[0].Rows[i]["DistName"].ToString();
                        }
                        catch
                        {
                            distName = "0";
                        }

                        try
                        {
                            localbodyId = ds.Tables[0].Rows[i]["LocalBodyId"].ToString();
                        }
                        catch
                        {
                            localbodyId = "0";
                        }

                        try
                        {
                            localBodyName = ds.Tables[0].Rows[i]["LocalBodyName"].ToString();
                        }
                        catch
                        {
                            localBodyName = "0";
                        }
                        #endregion

                        #region for Latest Entry Active
                        if (ds.Tables[0].Rows[i]["Type"].ToString() == "REPRESENTATIVE" || ds.Tables[0].Rows[i]["Type"].ToString() == "JUNIOR")
                        {
                            string query = "SELECT [UserMobile],[RefMobile],[isActive] FROM [TrueVoterDB].[dbo].[tblAddRefferances] WHERE [UserMobile]='" + refMobile1 + "'";
                            ds.Clear();
                            ds = commonCode.ExecuteDataset(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    string query1 = string.Empty;
                                    if (Convert.ToString(ds.Tables[0].Rows[j]["UserMobile"]) == refMobile1 && Convert.ToString(ds.Tables[0].Rows[j]["RefMobile"]) == userMobile1)
                                    {
                                        query1 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive]='Active',[IMEINumber]='" + imeiNumber + "',,[IMEINumber]='" + imeiNumber + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "', [RefName]=N'" + voterName + "',[keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "',[Role]='" + role + "',[RoleId]='" + roleId + "',[DistId]='" + distID + "',[DistName]='" + distName + "',[LocalBodyId]='" + localbodyId + "',[LocalBodyName]='" + localBodyName + "' WHERE [UserMobile]='" + refMobile1 + "' AND [RefMobile] = '" + userMobile1 + "'";
                                    }
                                    else
                                    {
                                        query1 = "UPDATE [TrueVoterDB].[dbo].[tblAddRefferances] SET [isActive]='Deactive',[IMEINumber]='" + imeiNumber + "',,[IMEINumber]='" + imeiNumber + "',[ModifyDate]='" + DateTime.Now.ToString("yyyy-MM-dd") + "', [RefName]=N'" + voterName + "',[keyword]='" + ds.Tables[0].Rows[i]["Type"].ToString() + "',[Role]='" + role + "',[RoleId]='" + roleId + "',[DistId]='" + distID + "',[DistName]='" + distName + "',[LocalBodyId]='" + localbodyId + "',[LocalBodyName]='" + localBodyName + "' WHERE [UserMobile]='" + refMobile1 + "' AND [RefMobile] != '" + userMobile1 + "'";
                                    }
                                    commonCode.ExecuteNonQuery(query1);

                                    string sqlMaxId = "SELECT MAX(PK_Id) FROM [TrueVoterDB].[dbo].[tblAddRefferances](NOLOCK) WHERE [UserMobile]='" + refMobile1 + "' AND [RefMobile] = '" + userMobile1 + "' ";
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
                            else
                            {
                                sqlQuery = "INSERT INTO [TrueVoterDB].[dbo].[tblAddRefferances] ([UserMobile],[RefMobile],[IMEINumber],[InsertDate],[keyword],[RefName],[isActive],[Role],[RoleId],[DistId],[DistName],[LocalBodyId],[LocalBodyName])" +
                                           " VALUES ('" + userMobile + "','" + refMobile + "','" + imeiNumber + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ds.Tables[0].Rows[i]["Type"].ToString() + "',N'" + voterName + "','Active',N'" + role + "',N'" + roleId + "',N'" + distID + "',N'" + distName + "',N'" + localbodyId + "',N'" + localBodyName + "')";

                                commonCode.ExecuteNonQuery(query1);
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
                        else
                        {

                        }
                        #endregion
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
    }
}