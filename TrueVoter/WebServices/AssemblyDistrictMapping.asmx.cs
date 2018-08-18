using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TrueVoter.App_Code.BAL;

namespace TrueVoter.WebServices
{
    /// <summary>
    /// Summary description for AssemblyDistrictMapping
    /// </summary>
    /// 

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AssemblyDistrictMapping : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        EncDecArrayClass objenc = new EncDecArrayClass();
       
        [WebMethod]
        public XmlDocument downloadAssembly()
        {
            try
            {
                string sql = "select * from [TrueVoterDB].[dbo].[tblAssemblyMapping](NOLOCK)";
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                XmlDataDocument datadocument = new XmlDataDocument(ds);
                XmlElement xmlele = datadocument.DocumentElement;
                return datadocument;
            }
            catch (Exception)
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument downloadDistrict()
        {
            try
            {
                string sql = "select * from [TrueVoterDB].[dbo].[tblDistrictMapping](NOLOCK)";
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                XmlDataDocument datadocument = new XmlDataDocument(ds);
                XmlElement xmlele = datadocument.DocumentElement;
                return datadocument;
            }
            catch (Exception)
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod]
        public XmlDocument downloadElectionMaster()
        {
            try
            {
                string sql = "select * from [TrueVoterDB].[dbo].[tblElectionMaster](NOLOCK)";
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                XmlDataDocument datadocument = new XmlDataDocument(ds);
                XmlElement xmlele = datadocument.DocumentElement;
                return datadocument;
            }
            catch (Exception)
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod(EnableSession = true)]
        public XmlDocument downloadInfo(string regid) //Want to change here enc dec
        {
            try
            {
                string sql = "SELECT * FROM [TrueVoterDB].[dbo].[Registrations](NOLOCK) WHERE RegId='" + regid + "'";
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                XmlDataDocument datadocument = new XmlDataDocument(ds);
                XmlElement xmlele = datadocument.DocumentElement;
                return datadocument;
            }
            catch (Exception)
            {
                CommonCode commonCode = new CommonCode();
                return commonCode.ErrorXml(CommonCode.SQL_ERROR);
            }
        }

        [WebMethod(Description = "OFFICER ASSEMBLY INFO")]
        public string OfficerAssemblyInfo(string data)
        {
            string returnvalue = string.Empty;
            int count = 0;
            string dt = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string[] vStatusValues = { "Select", "Present", "Absent", "Shifted", "Dead" };

            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(data));
                ds.ReadXml(reader);
                int dsCountVal = ds.Tables[0].Rows.Count;

                for (int i = 0; i < dsCountVal; i++)
                {
                    int acno = Convert.ToInt32(ds.Tables[0].Rows[i]["ACNO"]);
                    int partno = Convert.ToInt32(ds.Tables[0].Rows[i]["PartNo"]);
                    int fromsrno = Convert.ToInt32(ds.Tables[0].Rows[i]["SrNoFrom"]);
                    int tosrno = Convert.ToInt32(ds.Tables[0].Rows[i]["SrNoTo"]);
                    int wardno = Convert.ToInt32(ds.Tables[0].Rows[i]["WardNo"]);
                    int roletype = Convert.ToInt32(ds.Tables[0].Rows[i]["roletype"]);
                    string userfrm = ds.Tables[0].Rows[i]["FromUser"].ToString();
                    string touser = ds.Tables[0].Rows[i]["ToUser"].ToString();

                    //New work by Jitu Security Purpose 29.09.2016
                    string[] ump = userfrm.Split('$');
                    string[] tmp = touser.Split('$');

                    userfrm = objenc.DecryptInteger(ump[0], ump[1]);
                    touser = objenc.DecryptInteger(tmp[0], tmp[1]);

                    if (userfrm == "0" || touser == "0")
                    {
                        Exception exceptionValue123 = new Exception();
                        throw exceptionValue123;
                    }

                    //upgrade web service 29.8.2016 by Suraj Mane
                    string lat = ds.Tables[0].Rows[i]["Lat"].ToString();
                    string longi = ds.Tables[0].Rows[i]["Log"].ToString();

                    //upgrade by jitendra patil on 04.11.2016
                    string vstatus = ds.Tables[0].Rows[i]["vstatus"].ToString();
                    string sql = string.Empty;

                    //add voterscount 09-12-2016
                    int voters = (tosrno - fromsrno) + 1;


                    #region oldData

                    sql = "INSERT INTO [TrueVoterDB].[dbo].[tblOfficerAllotted_Info]([ACNO],[PartNo],[SrNoFrom],[SrNoTo],[WardNo],[FromUser],[ToUser],[roletype],[CreateDate],[CreatedBy],[Latitude],[Longitude],[vstatus],[Voters]) VALUES" +
                          " (" + acno + "," + partno + "," + fromsrno + "," + tosrno + "," + wardno + "," + userfrm + "," + touser + "," + roletype + ",'" + dt + "','" + userfrm + "','" + lat + "','" + longi + "','" + vstatus + "'," + voters + ")";

                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    if (cmd.Connection.State == ConnectionState.Closed)
                        con.Open();

                    try
                    {
                        int a = cmd.ExecuteNonQuery();
                        if (a != 0)
                            returnvalue += "1*";
                        else
                            returnvalue += "0*";
                    }
                    catch (Exception)
                    {
                        returnvalue += "0*";
                    }
                    count++;
                }
                if (count == 1)
                {
                    return returnvalue;
                }
                if (returnvalue.EndsWith("*"))
                {
                    returnvalue = returnvalue.Substring(0, returnvalue.Length - 1);
                }

                return returnvalue;
                    #endregion


                #region NEWDATA
                //    cmd.Connection = con;
                //    cmd.CommandText = "uspInsertControlChartData";
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Clear();
                //    cmd.Parameters.Add("@acNo", SqlDbType.Int).Value = acno;
                //    cmd.Parameters.Add("@partNo", SqlDbType.Int).Value = partno;
                //    cmd.Parameters.Add("@fromSrNo", SqlDbType.Int).Value = fromsrno;
                //    cmd.Parameters.Add("@toSrNo", SqlDbType.Int).Value = tosrno;
                //    cmd.Parameters.Add("@wardNo", SqlDbType.Int).Value = wardno;
                //    cmd.Parameters.Add("@roleType", SqlDbType.Int).Value = roletype;
                //    cmd.Parameters.Add("@fromuser", SqlDbType.NVarChar, 10).Value = userfrm;
                //    cmd.Parameters.Add("@touser", SqlDbType.NVarChar, 10).Value = touser;
                //    cmd.Parameters.Add("@lat", SqlDbType.NVarChar, 50).Value = lat;
                //    cmd.Parameters.Add("@long", SqlDbType.NVarChar, 50).Value = longi;
                //    cmd.Parameters.Add("@vStatus", SqlDbType.Int).Value = vstatus;
                //    cmd.Parameters.Add("@votersCount", SqlDbType.Int).Value = voters;
                //    cmd.Parameters.Add("@createdDate", SqlDbType.NVarChar, 50).Value = dt;

                //    cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                //    if (cmd.Connection.State == ConnectionState.Closed)
                //        cmd.Connection.Open();
                //    cmd.ExecuteNonQuery();

                //    returnvalue = cmd.Parameters["@returnValue"].Value.ToString();
                //    returnvalue += "*" + returnvalue;
                //}

                //returnvalue = returnvalue.Substring(1);
                //return returnvalue;
                #endregion

            }
            catch
            {
                return "0";
            }
        }


        #region WEB SERVICE FOR DOWNLOAD CONTROL CHART DATA
        //CREATED BY SURAJ MANE
        [WebMethod(Description = "DOWNLOAD CONTROL CHART DATA REPORT")]
        public XmlDocument DownloadControlChartReport(string AcNo, string PartNo)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = " SELECT TOP 100 [SrNo],[ACNO],[PartNo],[SrNoFrom] AS FromSrNo,[SrNoTo] AS ToSrNo,[WardNo],[FromUser] AS VoterListStaff,[ToUser] AS Officer,[CreateDate] AS EntryDate,[Latitude],[Longitude],[vstatus]" +
                             " FROM [TrueVoterDB].[dbo].[tblOfficerAllotted_Info](NOLOCK) WHERE [ACNO]='" + AcNo + "' AND [PartNo]='" + PartNo + "' ORDER BY [SrNo] DESC";
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    XmlDataDocument datadocument = new XmlDataDocument(ds);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "106";
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                    XmlDataDocument datadocument = new XmlDataDocument(ds);
                    XmlElement xmlele = datadocument.DocumentElement;
                    return datadocument;
                }
            }
            catch (Exception ex)
            {
                dt.Columns.Add(new DataColumn("Error", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["Error"] = ex.ToString();
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                XmlDataDocument datadocument = new XmlDataDocument(ds);
                XmlElement xmlele = datadocument.DocumentElement;
                return datadocument;
            }
        }

        #endregion


        [WebMethod(Description = "OFFICER ASSEMBLY INFO NEW")]
        public string OfficerAssemblyInfoNEW(string data)
        {
            string returnvalue = string.Empty;
            string dt = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            string[] vStatusValues = { "Select", "Present", "Absent", "Shifted", "Dead" };

            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(data));
                ds.ReadXml(reader);
                int dsCountVal = ds.Tables[0].Rows.Count;

                for (int i = 0; i < dsCountVal; i++)
                {
                    int acno = Convert.ToInt32(ds.Tables[0].Rows[i]["ACNO"]);
                    int partno = Convert.ToInt32(ds.Tables[0].Rows[i]["PartNo"]);
                    int fromsrno = Convert.ToInt32(ds.Tables[0].Rows[i]["SrNoFrom"]);
                    int tosrno = Convert.ToInt32(ds.Tables[0].Rows[i]["SrNoTo"]);
                    int wardno = Convert.ToInt32(ds.Tables[0].Rows[i]["WardNo"]);
                    int roletype = Convert.ToInt32(ds.Tables[0].Rows[i]["roletype"]);
                    string userfrm = ds.Tables[0].Rows[i]["FromUser"].ToString();
                    string touser = ds.Tables[0].Rows[i]["ToUser"].ToString();
                    string mobiId = ds.Tables[0].Rows[i]["mobileId"].ToString();
                    string ServreID = ds.Tables[0].Rows[i]["serverId"].ToString();
                    //New work by Jitu Security Purpose 29.09.2016
                    string[] ump = userfrm.Split('$');
                    string[] tmp = touser.Split('$');

                    userfrm = objenc.DecryptInteger(ump[0], ump[1]);
                    touser = objenc.DecryptInteger(tmp[0], tmp[1]);

                    if (userfrm == "0" || touser == "0")
                    {
                        Exception exceptionValue123 = new Exception();
                        throw exceptionValue123;
                    }

                    //upgrade web service 29.8.2016 by Suraj Mane
                    string lat = ds.Tables[0].Rows[i]["Lat"].ToString();
                    string longi = ds.Tables[0].Rows[i]["Log"].ToString();

                    //upgrade by jitendra patil on 04.11.2016
                    string vstatus = ds.Tables[0].Rows[i]["vstatus"].ToString();
                    string sql = string.Empty;

                    //add voterscount 09-12-2016
                    int voters = (tosrno - fromsrno) + 1;

                    #region NEWDATA
                    cmd.Connection = con;
                    cmd.CommandText = "uspInsertControlChartDataNEW";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@acNo", SqlDbType.Int).Value = acno;
                    cmd.Parameters.Add("@partNo", SqlDbType.Int).Value = partno;
                    cmd.Parameters.Add("@fromSrNo", SqlDbType.Int).Value = fromsrno;
                    cmd.Parameters.Add("@toSrNo", SqlDbType.Int).Value = tosrno;
                    cmd.Parameters.Add("@wardNo", SqlDbType.Int).Value = wardno;
                    cmd.Parameters.Add("@roleType", SqlDbType.Int).Value = roletype;
                    cmd.Parameters.Add("@fromuser", SqlDbType.NVarChar, 10).Value = userfrm;
                    cmd.Parameters.Add("@touser", SqlDbType.NVarChar, 10).Value = touser;
                    cmd.Parameters.Add("@lat", SqlDbType.NVarChar, 50).Value = lat;
                    cmd.Parameters.Add("@long", SqlDbType.NVarChar, 50).Value = longi;
                    cmd.Parameters.Add("@vStatus", SqlDbType.Int).Value = vstatus;
                    cmd.Parameters.Add("@votersCount", SqlDbType.Int).Value = voters;
                    cmd.Parameters.Add("@createdDate", SqlDbType.NVarChar, 50).Value = dt;
                    cmd.Parameters.Add("@ServreID", SqlDbType.NVarChar, 50).Value = ServreID;


                    cmd.Parameters.Add("@returnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    //returnvalue = cmd.Parameters["@returnValue"].Value.ToString();
                    returnvalue += 1 + "*" + cmd.Parameters["@returnValue"].Value.ToString() + "*" + mobiId + "#";
                }

                if (returnvalue.EndsWith("#"))
                {
                    returnvalue = returnvalue.Substring(0, returnvalue.Length - 1);
                }
                return returnvalue;
                    #endregion
            }
            catch
            {
                return "0";
            }
        }
    }
}